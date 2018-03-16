Imports ACode
Imports ACode.general
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.ComponentModel

Public Class form_reporte
#Region "Variables del formulario"
    ''' <summary>
    ''' inicializo clase con configuraciones de INI y Base de Datos
    ''' </summary>
    ''' <remarks></remarks>
    Private base As New base_REP
    ''' <summary>
    ''' Contiene la información del tipo de reporte que se mostrará en el formulario
    ''' </summary>
    ''' <remarks></remarks>
    Private _reporte As dt_tipo_reporte.myRow
    ''' <summary>
    ''' Indica cual es formulario previo del que fue llamado
    ''' </summary>
    ''' <remarks></remarks>
    Private _previo As Form

    Private _vista As dt_vista.myRow
    Private _presentacion, _cantidad, _acumulado As Integer
    Private _periodo As Vperiodo

    'Private _datos As DataTable()

#End Region

#Region "Constructores"

    Public Sub New(ByVal tipo_reporte As Integer)
        InitializeComponent()
        _reporte = base.TIPO_REPORTE(tipo_reporte)
        _previo = Nothing
    End Sub
    Public Sub New(ByVal tipo_reporte As Integer, ByVal padre As Form)
        InitializeComponent()
        _reporte = base.TIPO_REPORTE(tipo_reporte)
        _previo = padre
    End Sub

#End Region

#Region "Eventos del Formulario"
    Private Sub form_reporte_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        If Not IsNothing(_previo) Then
            _previo.Show()
        End If
    End Sub
    Private Sub form_reporte_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If base.estado Then
            _previo.Hide()
            Me.Text = "Formulario de " + _reporte.DESCRIP
            Dim sel_vistas As dt_vista
            Dim sel_per, min_per As Vperiodo
            'Cargar información en combo Vistas
            sel_vistas = base.VISTAS(_reporte.ID)
            If sel_vistas.Rows.Count > 0 Then
                For Each sel As dt_vista.myRow In sel_vistas.Rows
                    cbVista.Items.Add(sel)
                Next
                cbVista.SelectedIndex = 0
            End If
            'Cargar información en combo Periodoss
            sel_per = New Vperiodo(Now.Year, Now.Month)
            min_per = New Vperiodo(2017, 1)
            While sel_per.last >= min_per.last
                cbPeriodo.Items.Add(sel_per)
                sel_per = sel_per - 1
            End While
            cbPeriodo.SelectedIndex = 0
            op1.Checked = True
        Else
            Mensaje.Fallo(base.estado_desc)
            Me.Dispose()
        End If
    End Sub
#End Region

#Region "Eventos de Controles"

    Private Sub btnGenerar_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerar.Click
        'validar entradas del formulario
        If IsNothing(cbVista.SelectedItem) Then
            Mensaje.Alerta("No ha seleccionado ninguna vista")
            cbVista.Focus()
            Exit Sub
        End If
        _vista = cbVista.SelectedItem
        If IsNothing(cbPeriodo.SelectedItem) Then
            Mensaje.Alerta("No ha seleccionado ningún periodo")
            cbPeriodo.Focus()
            Exit Sub
        End If
        If cbPresentacion.SelectedIndex < 0 Then
            Mensaje.Alerta("No ha seleccionado ninguna presentación")
            cbPresentacion.Focus()
            Exit Sub
        End If
        'Almaceno variables del formulario en variables de clase
        _periodo = cbPeriodo.SelectedItem
        _presentacion = cbPresentacion.SelectedValue
        _acumulado = Math.Abs(CInt(ckAcum.Checked))
        For Each elemento As RadioButton In Pcantidad.Controls.OfType(Of RadioButton)()
            If elemento.Checked Then
                _cantidad = CInt(elemento.Tag)
            End If
        Next
        general.bloquearW(Me)
        'Validar Clasificación de cuentas
        Dim clasificacion As DataTable()
        clasificacion = base.AUTOCLASIFICAR(_periodo.last.Year, _periodo.last.Month, _acumulado, _reporte.ID)
        For Each clasif As DataTable In clasificacion
            If IsNothing(clasif) Then
                Mensaje.Fallo("Se produjo un error al intentar autoclasificar las cuentas del reporte")
                general.desbloquearW(Me)
                Exit Sub
            End If
        Next
        If clasificacion.Count <> 2 Then
            Mensaje.Fallo("Existe una diferencia en el resultado de la autoclasificacion")
            general.desbloquearW(Me)
            Exit Sub
        End If
        'primer resultado indica lo nuevo que se clasifico (no necesito hacer nada con eso)
        'segundo resultado indica lo que no se pudo clasificar automaticamente
        'Inicio el proceso general con una barra
        Dim fbp As ProgressShow = general.cargar_barra(Me) 'se definen 3 procesos, obtención de datos, escribir datos en excel y formatear hoja
        'Proceso 1: Obtener Información calculada desde la base de datos
        fbp.inicializar(3)
        fbp.cambiar_parte(1, 10)
        fbp.cambiar_parte(0, 70)
        hiloSegundoPlano.RunWorkerAsync()

    End Sub

    Private Sub cbVista_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbVista.SelectedIndexChanged
        If cbVista.SelectedIndex >= 0 Then
            Dim sel_vista As dt_vista.myRow = cbVista.SelectedItem
            Dim present As DataTable
            present = base.VALOR_PRESENTACIONxVISTA(sel_vista.ID)
            With cbPresentacion
                .Enabled = False
                .DataSource = present
                .ValueMember = present.Columns(0).ColumnName
                .DisplayMember = present.Columns(1).ColumnName
                .Enabled = True
                .SelectedIndex = -1
                If present.Rows.Count = 1 Then
                    .SelectedIndex = 0
                End If
            End With
        End If
    End Sub

    Private Sub cbPresentacion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbPresentacion.SelectedIndexChanged
        If cbPresentacion.SelectedIndex >= 0 And cbPresentacion.Enabled Then
            Dim reg_pres As DataRow
            Dim sel_pres As Integer
            sel_pres = cbPresentacion.SelectedValue
            reg_pres = base.presentacion_single(sel_pres)
            If IsNothing(reg_pres) Then
                ckAcum.Enabled = False
            Else
                If reg_pres("SOLO_ACUM") = 0 Then
                    ckAcum.Enabled = True
                    ckAcum.Checked = False
                Else
                    ckAcum.Enabled = False
                    ckAcum.Checked = True
                End If
            End If
        Else
            ckAcum.Enabled = False
        End If
    End Sub

#End Region

#Region "Procesos para generar reporte"

    Private Function calcular_info() As DataTable()
        Dim hilo As New BackProcess(base, 8, 1)
        hiloSegundoPlano.ReportProgress(3, hilo.intervalos)
        hilo.INI_REPORTE(_vista.ID, _vista.REPORTE, _periodo.last, _acumulado, _cantidad, _presentacion)
        While hilo.isWorking
            hilo.Keep()
            If hilo.UpdateBar Then
                hiloSegundoPlano.ReportProgress(4)
            End If
        End While
        Return hilo.resultados
    End Function

    Private Function imprimir_libro(ByVal resultados As DataTable()) As Excel.Workbook
        'Declaro variables para Excel
        Dim objExcel = New Excel.Application
        Dim objBook As Excel.Workbook = objExcel.Workbooks.Add
        Dim contador As Integer
        contador = 0
        For Each resul As DataTable In resultados
            If resul.Rows.Count > 0 Then
                contador = contador + 1
            End If
        Next
        'determino cantidad de hojas a utilizar y si necesito agregar o quitar
        If objBook.Sheets.Count < contador Then
            For i = objBook.Sheets.Count To contador - 1
                objBook.Sheets.Add()
            Next
        Else
            For i = objBook.Sheets.Count To contador + 1 Step -1
                objBook.Sheets(i).Delete()
            Next
        End If
        'PROCESO CADA TABLA DEL RECORDSET EN UNA HOJA DIFERENTE DEL EXCEL
        Dim t As Integer
        t = 0
        For z = 0 To resultados.Count - 1
            Dim tabla As DataTable = resultados(z)
            If tabla.Rows.Count > 0 Then
                Dim ultima_columna, ultimo_grupo As String
                Dim fila_titulo, id_fila, inicio_grupo, fila_proceso, final_grupo As Integer
                Dim oSheet As Excel.Worksheet = objBook.Sheets(t + 1)

                'las 3 primeras columnas de tabla contienen información de control y no se mostrarán en el reporte
                Dim cont_especial As Integer = 0
                If tabla.Columns.Contains("ID") Then
                    cont_especial = cont_especial + 1
                End If
                If tabla.Columns.Contains("NOMBRE") Then
                    cont_especial = cont_especial + 1
                End If
                If tabla.Columns.Contains("GRUPO") Then
                    cont_especial = cont_especial + 1
                End If
                ultima_columna = lcol(tabla.Columns.Count - cont_especial)
                'DETERMINO NOMBRE DE LA HOJA
                If tabla.Columns.Contains("NOMBRE") And tabla.Rows.Count > 0 Then
                    oSheet.Name = tabla.Rows(0).Item("NOMBRE")
                Else
                    oSheet.Name = _vista.N_CORTO + "_" + _reporte.DESCRIP
                End If
                fila_titulo = 1
                'imprimo los titulos de la tabla en la hoja
                For i = 1 To tabla.Columns.Count - cont_especial

                    Dim rango_total As Excel.Range
                    Dim valor_titulo, tipo_titulo As String
                    valor_titulo = tabla.Columns(i - 1 + cont_especial).ColumnName
                    tipo_titulo = tabla.Columns(i - 1 + cont_especial).DataType.Name
                    If _presentacion = 8 Then
                        If tipo_titulo = "Decimal" Then
                            Dim rango_titulo, rango_cabecera, rango_cabecera_previo As Excel.Range
                            Dim t1, t2 As String
                            t1 = valor_titulo.Substring(0, valor_titulo.Length - 4)
                            t2 = valor_titulo.Substring(valor_titulo.Length - 4)
                            rango_cabecera = oSheet.Cells(fila_titulo, i)
                            rango_cabecera_previo = oSheet.Cells(fila_titulo, i - 1)
                            Dim new_cabecera As Excel.Range
                            If rango_cabecera_previo.Value = t1 Then
                                'Dim new_cabecera As Excel.Range
                                new_cabecera = oSheet.Range(rango_cabecera_previo, rango_cabecera)
                                new_cabecera.Merge()
                            Else
                                rango_cabecera.Value = t1
                                new_cabecera = rango_cabecera
                            End If
                            rango_titulo = oSheet.Cells(fila_titulo + 1, i)
                            rango_titulo.Value = t2
                            rango_total = oSheet.Range(new_cabecera, rango_titulo)
                        Else
                            rango_total = oSheet.Range(oSheet.Cells(fila_titulo, i), oSheet.Cells(fila_titulo + 1, i))
                            rango_total.Merge()
                            rango_total.Value = valor_titulo
                        End If
                    Else
                        rango_total = oSheet.Cells(fila_titulo, i)
                        rango_total.Value = valor_titulo
                    End If
                    'Valor y formatos para titulos
                    formatear_titulo(rango_total, _reporte.ID)
                Next
                If _presentacion = 7 Or _presentacion = 8 Then
                    fila_titulo = fila_titulo + 1
                End If
                'INICIALIZO VARIABLES PARA RECORRER LA FILA
                inicio_grupo = fila_titulo + 1
                final_grupo = 0
                fila_proceso = inicio_grupo
                ultimo_grupo = String.Empty
                For j = 0 To tabla.Rows.Count
                    Dim info_fila As dt_fila_reporte.myRow
                    Dim curr_grupo As String
                    'ESTABLESCO GRUPO ACTUAL
                    If j < tabla.Rows.Count Then
                        Dim fila_dato As DataRow = tabla.Rows(j)
                        If tabla.Columns.Contains("GRUPO") Then
                            curr_grupo = fila_dato("GRUPO")
                        Else
                            curr_grupo = ""
                        End If
                    Else
                        curr_grupo = "EXIT"
                    End If
                    'FORMATO PARA GRUPO DE DATOS
                    If ultimo_grupo <> curr_grupo And ultimo_grupo <> String.Empty Then
                        'ENMARCO EL GRUPO
                        Dim marco_grupo As Excel.Range
                        Dim BordeColor, BackColor As Integer
                        'Determino el color del borde según el grupo (de momento a fuego en el codigo, luego vemos como dejarlo dinamico en la BD)
                        Select Case ultimo_grupo
                            Case "CONT", "CONT_AD", "A_VOL"
                                BordeColor = RGB(0, 0, 0)       'NEGRO
                                BackColor = RGB(192, 192, 192)  'PLOMO
                            Case "IV_COM"
                                oSheet.Range("A" + (inicio_grupo - 1).ToString).Value = "Compra - Produccion"
                                BordeColor = RGB(0, 0, 255)     'AZUL
                                BackColor = RGB(204, 204, 255)  'AZUL PASTEL (CLARO)
                            Case "IV_VEN"
                                oSheet.Range("A" + (inicio_grupo - 1).ToString).Value = "Venta"
                                BordeColor = RGB(0, 255, 0)     'VERDE
                                BackColor = RGB(204, 255, 204)  'VERDE PASTEL (CLARO)
                            Case Else
                                BordeColor = RGB(255, 255, 255) 'BLANCO
                                BackColor = RGB(255, 255, 255)  'BLANCO
                        End Select
                        marco_grupo = oSheet.Range("A" + inicio_grupo.ToString + ":" + ultima_columna + final_grupo.ToString)
                        With marco_grupo
                            With .Borders(Excel.XlBordersIndex.xlEdgeTop)
                                .Color = BordeColor
                                .TintAndShade = 0
                                .Weight = 3
                            End With
                            With .Borders(Excel.XlBordersIndex.xlEdgeBottom)
                                .Color = BordeColor
                                .TintAndShade = 0
                                .Weight = 3
                            End With
                            With .Borders(Excel.XlBordersIndex.xlEdgeLeft)
                                .Color = BordeColor
                                .TintAndShade = 0
                                .Weight = 3
                            End With
                            With .Borders(Excel.XlBordersIndex.xlEdgeRight)
                                .Color = BordeColor
                                .TintAndShade = 0
                                .Weight = 3
                            End With
                            With .Borders(Excel.XlBordersIndex.xlInsideVertical)
                                .Color = BordeColor
                                .TintAndShade = 0
                                .Weight = 3
                            End With
                        End With
                        'RESALTO LAS COLUMNAS SI CORRESPONDE PINTARLAS
                        For c = 1 To tabla.Columns.Count - cont_especial
                            Dim info_columna As dt_columnas.myRow
                            Dim val_titulo As String
                            Dim pintar As Boolean = False
                            val_titulo = oSheet.Cells(fila_titulo, c).Value
                            info_columna = base.FIND_COLUMNA(val_titulo)
                            If IsNothing(info_columna) Then
                                'si no encontro la columna, entonces debe ser la primera columna que si se pinta siempre
                                If c = 1 Or c = 2 Then
                                    If val_titulo = "JP" Or val_titulo = "" Or val_titulo = "DESCRIPCIÓN" Then
                                        pintar = True
                                    End If
                                Else
                                    pintar = False
                                End If
                            Else
                                If info_columna.TOTALIZA Then
                                    'si es columna totalizada
                                    pintar = True
                                End If
                            End If
                            If pintar Then
                                Dim col_total As Excel.Range
                                col_total = oSheet.Range(lcol(c) + inicio_grupo.ToString + ":" + lcol(c) + final_grupo.ToString)
                                With col_total
                                    With .Interior
                                        .Pattern = 1
                                        .Color = BackColor
                                    End With
                                End With
                            End If
                        Next
                        If ultimo_grupo = "A_VOL" Then
                            fila_proceso = fila_proceso + 0
                        Else
                            If curr_grupo = "CONT_AD" Then
                                fila_proceso = fila_proceso + 1
                            Else
                                fila_proceso = fila_proceso + 2
                            End If
                        End If

                        inicio_grupo = fila_proceso
                        final_grupo = 0
                    End If
                    'IMPRIMO LOS RESULTADO DE LA FILA EN LA HOJA
                    If j < tabla.Rows.Count Then
                        If cont_especial = 3 Then
                            'tiene las 3 columnas especiales para formatear reportes
                            Dim fila_dato As DataRow = tabla.Rows(j)
                            id_fila = fila_dato("ID")
                            info_fila = base.FILA_REP(id_fila)
                            For i = 1 To tabla.Columns.Count - 3
                                If tabla.Columns(i + 2).DataType.Name = "String" Then
                                    oSheet.Cells(fila_proceso, i).NumberFormat = "@"
                                End If
                                oSheet.Cells(fila_proceso, i).Value = tabla.Rows(j).Item(i + 2)
                            Next
                            'ingreso si fila es total
                            If Not IsNothing(info_fila) Then
                                If Val(info_fila.TOTAL_PINTA) > 0 Then
                                    Dim rango_total As Excel.Range
                                    rango_total = oSheet.Range("A" + fila_proceso.ToString + ":" + ultima_columna + fila_proceso.ToString)
                                    If Val(info_fila.TOTAL_PINTA) = 1 Then
                                        With rango_total
                                            .Font.Bold = True
                                            With .Borders(Excel.XlBordersIndex.xlEdgeTop)        'corresponde SOLO a la linea superior de la seleccion
                                                .LineStyle = Excel.XlLineStyle.xlContinuous
                                                .ColorIndex = 0
                                                .TintAndShade = 0
                                                .Weight = Excel.XlBorderWeight.xlThin
                                            End With
                                        End With
                                    ElseIf Val(info_fila.TOTAL_PINTA) = 2 Then
                                        With rango_total
                                            .Font.Bold = True
                                            With .Borders(Excel.XlBordersIndex.xlEdgeTop)        'corresponde SOLO a la linea superior de la seleccion
                                                .LineStyle = Excel.XlLineStyle.xlDouble
                                                .ColorIndex = 0
                                                .TintAndShade = 0
                                                .Weight = Excel.XlBorderWeight.xlThick
                                            End With
                                        End With
                                    End If
                                End If
                            End If
                        Else
                            'no tiene las 3 columnas especiales, entonces es el detalle
                            For i = 1 To tabla.Columns.Count
                                If tabla.Columns(i - 1).DataType.Name = "String" Then
                                    oSheet.Cells(fila_proceso, i).NumberFormat = "@"
                                End If
                                oSheet.Cells(fila_proceso, i).Value = tabla.Rows(j).Item(i - 1)
                            Next
                        End If
                        final_grupo = fila_proceso
                    End If
                    fila_proceso = fila_proceso + 1
                    'MARCO EL ULTIMO GRUPO QUE PROCESE PARA DETERMINAR SI CAMBIO EN EL SIGUIENTE CICLO
                    ultimo_grupo = curr_grupo
                Next
                'Letras de vista JP
                If _presentacion = 5 Then
                    Dim msg_jp As Excel.Range = oSheet.Cells(fila_proceso - 2, 1)
                    Dim range_mes As String
                    If _acumulado = 0 Then
                        range_mes = _periodo.last.Month.ToString
                    Else
                        range_mes = "1-" + _periodo.last.Month.ToString
                    End If
                    msg_jp.Value = "チリ日本ハム　損益計算書　" + _periodo.last.Year.ToString + "年" + range_mes + "月"
                    msg_jp = oSheet.Cells(fila_proceso - 1, 1)
                    msg_jp.Value = "（単位：チリペソ）"
                    msg_jp = oSheet.Cells(1, 2)
                    msg_jp.Value = "項　目"
                End If

                If _presentacion = 7 Then   'balance jp
                    Dim msg_jp As Excel.Range
                    Dim range_mes As String
                    msg_jp = oSheet.Range("A" + (fila_proceso - 4).ToString + ":D" + (fila_proceso - 4).ToString)
                    With msg_jp.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                        .LineStyle = Excel.XlLineStyle.xlDouble
                        .Color = RGB(0, 0, 0)
                    End With
                    msg_jp = oSheet.Cells(1, 1)
                    msg_jp.Value = ""
                    msg_jp = oSheet.Cells(1, 2)
                    msg_jp.Value = "項　目"
                    msg_jp = oSheet.Cells(1, 3)
                    range_mes = _periodo.last.Month.ToString
                    msg_jp.Value = range_mes + "月" + Chr(10) + "CH PESO"
                    msg_jp = oSheet.Cells(1, 4)
                    range_mes = (IIf(_periodo.last.Month = 1, 12, _periodo.last.Month - 1)).ToString
                    msg_jp.Value = range_mes + "月" + Chr(10) + "CH PESO"
                    oSheet.Rows("1:1").RowHeight = 40
                End If
                'FORMATO GENERAL DE LA HOJA
                If cont_especial = 3 Then
                    oSheet.Cells.NumberFormat = "#,###;(#,###);"
                    oSheet.Columns("B:" & ultima_columna).ColumnWidth = 13.5
                End If
                oSheet.Cells.EntireColumn.AutoFit()
                t = t + 1
            End If
        Next
        Return objBook
    End Function

    Private Function formatear_libro(ByRef oBook As Excel.Workbook) As Boolean
        Dim titulo_mostrar, titulo_periodo, titulo_jp As String
        Dim app_dir, img_dir, compañia As String
        Dim top_margen As Decimal
        titulo_mostrar = _reporte.DESCRIP + " " + _vista.DESCRIP
        If _cantidad = 1000 Then
            titulo_mostrar = titulo_mostrar + " POR MILES"
        End If
        titulo_periodo = _periodo.mostrar + IIf(_acumulado <> 0, " ACUMULADO", "")
        app_dir = System.AppDomain.CurrentDomain.BaseDirectory()
        If _presentacion = 7 Then
            titulo_jp = Chr(10) & Chr(10) & "貸借対照表 " & _periodo.last.ToString("yyyy/MM/dd")
            top_margen = 1.51
        Else
            titulo_jp = ""
            top_margen = 1.01
        End If
        If base.base_dato = "PRVNR" Then
            compañia = "&G"
            img_dir = app_dir + "\logo_porvenir_h.jpg"
            My.Resources.logo_porvenir_h.Save(img_dir)
        Else
            compañia = "&G NH FOODS CHILE"
            img_dir = app_dir + "\logo_nippon.jpg"
            My.Resources.logo_nippon.Save(img_dir)
        End If
        For Each oHoja As Excel.Worksheet In oBook.Sheets
            With oHoja.PageSetup
                .LeftHeaderPicture.Filename = img_dir
                If _vista.REPORTE = 1 Then
                    'reporte=1 es estado resultado, van horizonal
                    .Orientation = Excel.XlPageOrientation.xlLandscape
                Else
                    'reporte=2 es balance, van vertical
                    .Orientation = Excel.XlPageOrientation.xlPortrait
                End If
                .FitToPagesWide = 1
                .FitToPagesTall = 1
                .BlackAndWhite = False
                .Zoom = False
                .FitToPagesWide = 1
                .FitToPagesTall = 1
                Try
                    .PaperSize = 14
                Catch
                    Try
                        .PaperSize = Excel.XlPaperSize.xlPaperLetter
                    Catch ex As Exception
                        'si no puede cambiarlos, que lo deje como esta
                    End Try

                End Try
                .LeftHeader = compañia
                .CenterHeader = Chr(10) & titulo_mostrar & Chr(10) & titulo_periodo & titulo_jp
                .RightHeader = Chr(10) & "Fecha de Impresion : &D" & Chr(10) & "Hora de Impresion: &T"
                .LeftFooter = "Usuario: " & ObtenerUsuarioActual()
                .CenterFooter = oHoja.Name
                .RightFooter = "Pagina &P de &N"
                .TopMargin = oBook.Application.InchesToPoints(top_margen)
                .CenterHorizontally = True
            End With
        Next

        Return True
    End Function

    Private Function formatear_titulo(ByRef rango_titulo As Excel.Range, ByVal reporte_id As Integer) As Boolean
        With rango_titulo
            .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter       '-4108 equivale a centrar
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .WrapText = True                    'equivale a alinear contenido a la celda
            .Orientation = 0
            '.AddIndent = False
            '.IndentLevel = 0
            '.ShrinkToFit = False
            .RowHeight = 20                     'alto de fila se estable en 30
            With .Borders(Excel.XlBordersIndex.xlEdgeBottom)        'corresponde SOLO a la linea inferior de la seleccion
                .ColorIndex = 0
                .TintAndShade = 0
                .Weight = 3
            End With
            With .Borders(Excel.XlBordersIndex.xlEdgeTop)
                .ColorIndex = 0
                .TintAndShade = 0
                .Weight = 3
            End With
            If reporte_id = 1 Then
                With .Borders(Excel.XlBordersIndex.xlEdgeLeft)
                    .ColorIndex = 0
                    .TintAndShade = 0
                    .Weight = 3
                End With
                With .Borders(Excel.XlBordersIndex.xlEdgeRight)
                    .ColorIndex = 0
                    .TintAndShade = 0
                    .Weight = 3
                End With
            Else

            End If
        End With
        Return True
    End Function

#End Region

#Region "Accion del Proceso en segundo plano"
    Private Sub hiloSegundoPlano_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles hiloSegundoPlano.DoWork
        Dim bg As BackgroundWorker = CType(sender, BackgroundWorker)
        Dim datos As DataTable()
        
        datos = calcular_info()
        'si llegamos aca, se supone que el proceso ya completo el datatable global
        bg.ReportProgress(1)
        Dim libro As Excel.Workbook
        'Proceso 2: Escribir los datos obtenidos en un archivo excel
        libro = imprimir_libro(datos)
        bg.ReportProgress(2)
        'Proceso 3: Formatear la hoja segun lineas necesarias
        formatear_libro(libro)
        bg.ReportProgress(2)

        libro.Application.Visible = True
    End Sub
    Private Sub hiloSegundoPlano_ProgressChanged(sender As System.Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles hiloSegundoPlano.ProgressChanged
        Dim avance As ProgressShow
        avance = Nothing
        For Each elemento As ProgressShow In Me.Controls.OfType(Of ProgressShow)()
            avance = elemento
        Next
        If Not IsNothing(avance) Then
            Select Case e.ProgressPercentage
                Case 1
                    avance.inicia_proceso(1)
                Case 2
                    avance.continua_proceso()
                Case 3
                    avance.definir_proceso(0, e.UserState)
                Case 4
                    avance.continua_proceso(0)
            End Select
        End If
        
    End Sub
    Private Sub hiloSegundoPlano_RunWorkerCompleted(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles hiloSegundoPlano.RunWorkerCompleted
        general.descargar_barra(Me)
        general.desbloquearW(Me)
    End Sub
#End Region

End Class