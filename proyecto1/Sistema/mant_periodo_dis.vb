Imports ACode
Public Class mant_periodo_dis

#Region "Variables de Clase"
    ''' <summary>
    ''' inicializo clase con configuraciones de INI y Base de Datos
    ''' </summary>
    ''' <remarks></remarks>
    Private base As New base_REP
    Private _perDis As periodo_dis_row
    Private _distribucion As tipo_distribucion_row
    Private _Eperiodos As sector_table
#End Region

   
#Region "Constructores"
    Public Sub New(ByVal id_distribucion As Integer)
        InitializeComponent()
        _perDis = Nothing
        _distribucion = base.TIPO_DISTRIB(id_distribucion)
    End Sub
    Public Sub New(ByVal PeriodoDis As periodo_dis_row)
        InitializeComponent()
        _perDis = PeriodoDis
        _distribucion = base.TIPO_DISTRIB(_perDis.DISTRIB)
    End Sub
#End Region

    Private Sub mant_periodo_dis_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If IsNothing(_perDis) Then
            lbTitle.Text = "Creación"
            _Eperiodos = base.SECTORES_ENTRADA
            Dim rango As Vperiodo
            rango = New Vperiodo(Year(Now), Month(Now)) - 1
            Odesde.especificar = rango.first
            Ohasta.especificar = rango.last
        Else
            lbTitle.Text = "Modificación"
            _Eperiodos = base.SECTORES_ENTRADA(_perDis.ID)
            If _perDis.DESDE = Odesde.siempre Then
                Odesde.op1.Checked = True
            Else
                Odesde.especificar = _perDis.DESDE
                Odesde.op3.Checked = True
            End If
            If _perDis.HASTA = Ohasta.siempre Then
                Ohasta.op1.Checked = True
            Else
                Ohasta.especificar = _perDis.HASTA
                Ohasta.op3.Checked = True
            End If
        End If
        lbTitle.Text = lbTitle.Text + " Periodo de Distribucion: " + _distribucion.DESCRIP

        'ingreso de sectores
        With dgDepto
            .DataSource = base.cabecera_sector_distrib
            .Columns(0).Visible = False
            .Columns(1).Width = 150
            .Columns(2).DefaultCellStyle.Format = "#0.00%"
        End With
        With dgLugar
            .DataSource = base.cabecera_sector_distrib
            .Columns(0).Visible = False
            .Columns(1).Width = 150
            .Columns(2).DefaultCellStyle.Format = "#0.00%"
        End With

        completar_depto()
    End Sub

    Private Sub completar_depto()
        'Dim entradas As sector_tabla
        Dim infoDepto As DataTable
        'entradas = obtener_datos()
        infoDepto = dgDepto.DataSource
        infoDepto.Rows.Clear()
        Dim depto As String = ""
        For Each sector_entrada As sector_row In _Eperiodos.Rows
            If sector_entrada.COD_DEPTO <> depto Then
                depto = sector_entrada.COD_DEPTO
                Dim f1 As DataRow = infoDepto.NewRow
                f1(0) = depto
                f1(1) = sector_entrada.NOMBRE_DEPTO
                f1(2) = sector_entrada.CALC_TOTAL_DEPTO
                infoDepto.Rows.Add(f1)
            End If
        Next
        dgDepto.ClearSelection()
        Dim total_depto As Double = infoDepto.Compute("SUM(VALOR)", "")
        lb_depto_total.Text = (total_depto).ToString("0.00%")
        dgLugar.DataSource.Rows.Clear()
        lb_lugar_total.Text = "0.00%"
    End Sub

    Private Sub btn_save_Click(sender As System.Object, e As System.EventArgs) Handles btn_save.Click
        'Validar que las entradas de segmentos cumplan con 100%
        For Each valor As sector_row In _Eperiodos.Rows
            If valor.CALC_TOTAL_DEPTO <> _Eperiodos.TOTAL_DEPTO_VALOR(valor.COD_DEPTO) Then
                Mensaje.Fallo("Los porcentajes para el departamento " + valor.NOMBRE_DEPTO + " no son correctas")
                Exit Sub
            End If
        Next
        If _Eperiodos.TOTAL_VALOR <> 1 Then
            Mensaje.Fallo("No ha distribuido completamente entre todos los departamentos")
            Exit Sub
        End If
        'Fin Validación
        Dim id_periodo As Integer
        Dim resultado As dt_query_result.myRow
        If IsNothing(_perDis) Then
            'ingreso de nuevo periodo
            resultado = base.NEW_PERIODO_ENTRADA(_distribucion.ID, Odesde.marcado, Ohasta.marcado)
            If IsNothing(resultado) Then
                Mensaje.Fallo("Se ha producido un error al intentar guardar el periodo")
                Exit Sub
            Else
                If resultado.COD_ESTADO = 1 Then
                    id_periodo = resultado.ID_NUEVO
                Else
                    Mensaje.Fallo(resultado.TXT_ESTADO)
                    Exit Sub
                End If
            End If
        Else
            'Existe un periodo previo, lo modifico
            resultado = base.MOD_PERIODO_ENTRADA(_perDis.ID, Odesde.marcado, Ohasta.marcado)
            If IsNothing(resultado) Then
                Mensaje.Fallo("Se ha producido un error al intentar guardar el periodo")
                Exit Sub
            Else
                If resultado.COD_ESTADO = 1 Then
                    id_periodo = _perDis.ID
                Else
                    Mensaje.Fallo(resultado.TXT_ESTADO)
                    Exit Sub
                End If
            End If
        End If
        'ACTUALIZACIÓN DE LA INFORMACIÓN DE DISTRIBUCIONES
        Dim ingresos, modificacion, eliminacion, sin_efecto As Integer
        ingresos = 0
        modificacion = 0
        eliminacion = 0
        sin_efecto = 0
        For Each entrada As sector_row In _Eperiodos.Rows
            resultado = base.ACTUALIZA_SECTOR_DISTRIB(id_periodo, entrada.ID, entrada.VALOR)
            If IsNothing(resultado) Then
                Mensaje.Fallo("Se ha producido un error al intentar guardar una distribución")
                Exit Sub
            Else
                If resultado.COD_ESTADO >= 0 Then
                    'si esta ok, entonces debe continuar con los registros
                    Select Case resultado.TXT_ESTADO
                        Case "SIN CAMBIOS"
                            sin_efecto = sin_efecto + 1
                        Case "REGISTRO NUEVO"
                            ingresos = ingresos + 1
                        Case "REGISTRO MODIFICADO"
                            modificacion = modificacion + 1
                        Case "REGISTRO ELIMINADO"
                            eliminacion = eliminacion + 1
                    End Select
                Else
                    Mensaje.Fallo(resultado.TXT_ESTADO)
                    Exit Sub
                End If
            End If
        Next
        If IsNothing(_perDis) Then
            Mensaje.Info("Se ha ingresado correctamente la entrada de periodos distribuidos")
        Else
            Mensaje.Info("Se ha modificado correctamente la entrada de periodos distribuidos")
        End If

        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btn_cancel_Click(sender As System.Object, e As System.EventArgs) Handles btn_cancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub dgDepto_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDepto.CellClick
        If e.RowIndex > -1 Then
            'Dim entradas As sector_tabla
            Dim infoLugar As DataTable
            Dim cod_depto As String
            Dim val_depto As Double
            infoLugar = dgLugar.DataSource
            cod_depto = dgDepto.Rows(e.RowIndex).Cells(0).Value
            val_depto = dgDepto.Rows(e.RowIndex).Cells(2).Value
            dgLugar.DataSource.Rows.Clear()
            'entradas = obtener_datos()
            For Each lugar As sector_row In _Eperiodos.DETALLE_DEPTO(cod_depto)
                Dim f1 As DataRow = infoLugar.NewRow
                f1(0) = lugar.COD_LUGAR
                f1(1) = lugar.NOMBRE_LUGAR
                f1(2) = IIf(val_depto = 0, 0, lugar.VALOR / val_depto)
                infoLugar.Rows.Add(f1)
            Next
            dgLugar.ClearSelection()
            dgLugar.Tag = cod_depto
            Dim total_lugar As Double
            If infoLugar.Rows.Count = 0 Then
                total_lugar = 0
            Else
                total_lugar = infoLugar.Compute("SUM(VALOR)", "")
            End If

            lb_lugar_total.Text = (total_lugar).ToString("0.00%")

        End If
    End Sub
    Private Sub dgDepto_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDepto.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim nuevo_valor, nom_depto, cod_depto As String
            Dim num_valor As Decimal
            cod_depto = dgDepto.Rows(e.RowIndex).Cells(0).Value
            nom_depto = dgDepto.Rows(e.RowIndex).Cells(1).Value
            nuevo_valor = Mensaje.Digite("Ingrese el porcentaje para el departamento " + nom_depto)
            nuevo_valor = nuevo_valor.Replace("%", "")  'quito signo % si lo ingreso
            Try
                num_valor = CDbl(nuevo_valor) / 100
                'num_valor = Decimal.Parse(nuevo_valor, Globalization.NumberStyles.Float) / 100.0
            Catch ex As Exception
                Mensaje.Fallo("Debe digitar un numero")
                Exit Sub
            End Try
            'DEBO ANALIZAR QUE PASA CON num_valor
            If _Eperiodos.DETALLE_DEPTO(cod_depto).Count = 1 Then
                _Eperiodos.DETALLE_DEPTO(cod_depto)(0).VALOR = num_valor
                _Eperiodos.DETALLE_DEPTO(cod_depto)(0).CALC_TOTAL_DEPTO = num_valor
            Else
                'hay mas de un lugar para el departamento
                Dim total_depto As Double
                total_depto = _Eperiodos.TOTAL_DEPTO_VALOR(cod_depto)
                If total_depto = 0 Then
                    'sus lugares estan todos en 0, por lo tanto, le asigno al primero
                    _Eperiodos.DETALLE_DEPTO(cod_depto)(0).VALOR = num_valor
                    For Each dp As sector_row In _Eperiodos.DETALLE_DEPTO(cod_depto)
                        dp.CALC_TOTAL_DEPTO = num_valor
                    Next
                Else
                    'sus lugares o alguno de ellos tiene valor, se debe mantener la proporcion de ellos
                    For Each ep As sector_row In _Eperiodos.DETALLE_DEPTO(cod_depto)
                        ep.VALOR = (ep.VALOR / ep.CALC_TOTAL_DEPTO) * num_valor
                        ep.CALC_TOTAL_DEPTO = num_valor
                    Next

                End If
            End If
            completar_depto()
            dgDepto_CellClick(sender, New DataGridViewCellEventArgs(2, e.RowIndex))
            dgDepto.CurrentCell = dgDepto.Rows(e.RowIndex).Cells(2)
        End If
    End Sub
    Private Sub dgLugar_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgLugar.CellDoubleClick
        If e.RowIndex > -1 Then
            Dim nuevo_valor, nom_lugar, cod_lugar As String
            Dim num_valor As Double
            cod_lugar = dgLugar.Rows(e.RowIndex).Cells(0).Value
            nom_lugar = dgLugar.Rows(e.RowIndex).Cells(1).Value
            nuevo_valor = Mensaje.Digite("Ingrese el porcentaje para el departamento " + nom_lugar)
            nuevo_valor = nuevo_valor.Replace("%", "")  'quito signo % si lo ingreso
            Try
                num_valor = CDbl(nuevo_valor) / 100
            Catch ex As Exception
                Mensaje.Fallo("Debe digitar un numero")
                Exit Sub
            End Try
            'DEBO ANALIZAR QUE PASA CON num_valor
            Dim cod_depto As String
            Dim indice_depto As Integer
            cod_depto = dgLugar.Tag
            indice_depto = dgDepto.SelectedRows.Item(0).Index
            If _Eperiodos.DETALLE_DEPTO(cod_depto).Count = 1 Then
                Mensaje.Fallo("Solo existe un lugar, no puede cambiar el porcentaje")
                Exit Sub
            Else
                'hay mas de un lugar para el departamento
                Dim total_depto As Double
                total_depto = _Eperiodos.TOTAL_DEPTO_VALOR(cod_depto)
                If total_depto = 0 Then
                    _Eperiodos.DETALLE_DEPTO(cod_depto)(e.RowIndex).VALOR = num_valor
                    For Each dp As sector_row In _Eperiodos.DETALLE_DEPTO(cod_depto)
                        dp.CALC_TOTAL_DEPTO = num_valor
                    Next
                Else
                    'sus lugares o alguno de ellos tiene valor, se debe mantener la proporcion de ellos
                    Dim ep As sector_row = _Eperiodos.DETALLE_DEPTO(cod_depto)(e.RowIndex)

                    ep.VALOR = num_valor * ep.CALC_TOTAL_DEPTO

                End If
            End If
            completar_depto()
            dgDepto_CellClick(sender, New DataGridViewCellEventArgs(2, indice_depto))
            dgDepto.CurrentCell = dgDepto.Rows(indice_depto).Cells(2)
            dgLugar.CurrentCell = dgLugar.Rows(e.RowIndex).Cells(2)


        End If
    End Sub

End Class