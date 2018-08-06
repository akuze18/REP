Public Class mant_filas_reporte_detalle

#Region "Variables de clase"
    ''' <summary>
    ''' inicializo clase con configuraciones de INI y Base de Datos
    ''' </summary>
    ''' <remarks></remarks>
    Private base As New base_REP
    Private _fila As dt_fila_reporte.myRow
    Private _id_reporte As Integer
#End Region

#Region "Constructores"
    ''' <summary>
    ''' Constructor para indicar una fila nueva
    ''' </summary>
    ''' <param name="id_reporte">ID del reporte al que pertenecerá la fila una vez este creada</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal id_reporte As Integer)
        InitializeComponent()
        _fila = Nothing
        _id_reporte = id_reporte
    End Sub
    ''' <summary>
    ''' Constructor para indicar que se modificará una fila existente
    ''' </summary>
    ''' <param name="fila">Contiene la información actual de la fila representada desde un fila_reporte_row</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal fila As dt_fila_reporte.myRow)
        InitializeComponent()
        _fila = fila
        _id_reporte = fila.REPORTE
    End Sub
#End Region

#Region "Formulario"
    Private Sub mant_filas_reporte_detalle_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsNothing(_fila) Then
            'Es fila para modificar
            With tbID
                .Text = _fila.ID
                .Enabled = False
            End With
            With tb_descrip
                .Text = _fila.DESCRIP
            End With
            With tbCcode
                .Text = _fila.CCODE
            End With
            op1.Checked = True
            For Each opcion As RadioButton In P_total_pinta.Controls.OfType(Of RadioButton)()
                If opcion.Tag = _fila.TOTAL_PINTA Then
                    opcion.Checked = True
                End If
            Next
            With ck_camb
                .Checked = _fila.CAMBIAR
            End With
            With ck_dist
                .Checked = _fila.DISTRIB
                .Enabled = False
            End With
            With ck_total
                .Checked = _fila.TOTALIZAR
            End With
        Else
            'Es fila nueva
            With tbID
                .Text = String.Empty
                .Enabled = False
            End With
            With tb_descrip
                .Text = String.Empty
            End With
            With tbCcode
                .Text = String.Empty
            End With
            op1.Checked = True 'Primera opcion del panel P_total_pinta se marca
            With ck_camb
                .Checked = False
            End With
            With ck_dist
                .Checked = False
                .Enabled = False
            End With
            With ck_total
                .Checked = False
            End With
        End If
        dibuja_composicion()
    End Sub
#End Region

#Region "Controles"
    Private Sub btn_canc_Click(sender As System.Object, e As System.EventArgs) Handles btn_canc.Click
        Dim form_parent As form_configurar
        form_parent = Me.ParentForm
        form_parent.TVopciones.Enabled = True
        If IsNothing(_fila) Then
            form_parent.dibujar_filas_reporte(_id_reporte)
        Else

            form_parent.dibujar_filas_reporte(_fila.REPORTE, _fila.ID)
        End If

    End Sub
    Private Sub btn_new_Click(sender As System.Object, e As System.EventArgs) Handles btn_new.Click
        Dim agregar As mant_comp_fila
        If IsNothing(_fila) Then
            Mensaje.Alerta("No puede modificar la composición sin haber guardado la información general de la fila")
            btn_guardar.Focus()
            Exit Sub
        End If
        If ck_total.Checked Then
            agregar = New mant_comp_fila(_fila.ID, mant_comp_fila.composicion.fila)
        Else
            agregar = New mant_comp_fila(_fila.ID, mant_comp_fila.composicion.cuenta)
        End If

        Dim resultado As DialogResult = agregar.ShowDialog
        If resultado = DialogResult.OK Then
            dibuja_composicion()
        Else
            'NADA
        End If
    End Sub
    Private Sub btn_off_Click(sender As System.Object, e As System.EventArgs) Handles btn_off.Click
        'valido si se está todo lo requerido para eliminar
        If IsNothing(_fila) Then
            Mensaje.Alerta("No puede modificar la composición sin haber guardado la información general de la fila")
            btn_guardar.Focus()
            Exit Sub
        End If
        If lst_composicion.SelectedItems.Count = 0 Then
            Mensaje.Alerta("No ha seleccionado una " + IIf(ck_total.Checked, "Fila", "Cuenta") + " para eliminar")
            Exit Sub
        End If
        If ck_total.Checked Then
            Dim cont_mark As Integer = lst_composicion.SelectedItems.Count
            Dim comp_fila(cont_mark - 1) As dt_fila_reporte.myRow
            For i = 0 To cont_mark - 1
                comp_fila(i) = lst_composicion.SelectedItems(i)
            Next
            Dim pregunta As DialogResult
            If cont_mark = 1 Then
                pregunta = Mensaje.Confirma("Está seguro que desea eliminar la fila " + comp_fila(0).DESCRIP + " del contenido?")
            Else
                pregunta = Mensaje.Confirma("Está seguro que desea eliminar " + cont_mark.ToString + " filas del contenido?")
            End If

            If pregunta = DialogResult.Yes Then
                Dim infoResult As dt_query_result.myRow
                For Each marcado In comp_fila
                    infoResult = base.DROP_FILA_COMP(marcado.ID_COMP_FILA)
                    If IsNothing(infoResult) Then
                        Mensaje.Fallo("Se ha producido un error inesperado")
                        Exit Sub
                    Else
                        If infoResult.COD_ESTADO < 0 Then
                            Mensaje.Fallo(infoResult.TXT_ESTADO)
                            Exit Sub
                        End If
                    End If
                Next
                If cont_mark = 1 Then
                    Mensaje.Info("Se ha quitado correctamente de la composicion del detalle de fila")
                Else
                    Mensaje.Info("Se han quitado correctamente de la composicion del detalle de fila")
                End If

                dibuja_composicion()
            End If
        Else
            Dim cont_mark As Integer = lst_composicion.SelectedItems.Count
            Dim comp_cuenta(cont_mark - 1) As indice_cuenta_row
            For i = 0 To cont_mark - 1
                comp_cuenta(i) = lst_composicion.SelectedItems(i)
            Next
            Dim pregunta As DialogResult
            If cont_mark = 1 Then
                pregunta = Mensaje.Confirma("Está seguro que desea eliminar la fila " + comp_cuenta(0).DESCRIP + " del contenido?")
            Else
                pregunta = Mensaje.Confirma("Está seguro que desea eliminar " + cont_mark.ToString + " filas del contenido?")
            End If

            If pregunta = DialogResult.Yes Then
                Dim infoResult As dt_query_result.myRow
                For Each marcado As indice_cuenta_row In comp_cuenta
                    infoResult = base.DROP_FILA_COMP(marcado.ID_COMP_FILA)
                    If IsNothing(infoResult) Then
                        Mensaje.Fallo("Se ha producido un error inesperado")
                        Exit Sub
                    Else
                        If infoResult.COD_ESTADO < 0 Then
                            Mensaje.Fallo(infoResult.TXT_ESTADO)
                            Exit Sub
                        End If
                    End If
                Next
                Mensaje.Info("Se ha quitado correctamente la composicion del detalle de fila")
                dibuja_composicion()
            End If
        End If
    End Sub
    Private Sub btn_guardar_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardar.Click
        'valido que los campos requeridos estén ingresados
        If String.IsNullOrEmpty(tbCcode.Text) Then
            Mensaje.Alerta("Codigo Personalizado no ha sido completado")
            tbCcode.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(tb_descrip.Text) Then
            Mensaje.Alerta("Descripción no ha sido completada")
            tb_descrip.Focus()
            Exit Sub
        End If
        Dim marco_pinta As Boolean = False
        Dim val_marco_pinta As Integer
        For Each elemento As RadioButton In P_total_pinta.Controls.OfType(Of RadioButton)()
            If elemento.Checked Then
                marco_pinta = True
                val_marco_pinta = elemento.Tag
            End If
        Next
        If Not marco_pinta Then
            Mensaje.Alerta("No ha indicado como remarcar la linea")
            P_total_pinta.Controls(0).Focus()
            Exit Sub
        End If
        'los 3 check de cambio, totaliza y distribución, no pueden ser validados, ya que si o si tendran su checked en true o false
        Dim resultado As dt_query_result.myRow
        If IsNothing(_fila) Then
            'Entonces es un registro nuevo
            resultado = base.NEW_FILAS_REPORTE(_id_reporte, tbCcode.Text, tb_descrip.Text, ck_camb.Checked, val_marco_pinta)
            If IsNothing(resultado) Then
                Mensaje.Fallo("Se produjo un error al crear una nueva fila")
            Else
                If resultado.COD_ESTADO < 0 Then
                    Mensaje.Fallo(resultado.TXT_ESTADO)
                Else
                    Mensaje.Info("Se creó correctamente la linea")
                End If
            End If
        Else
            'entonces es un registro para modificar
            resultado = base.MOD_FILAS_REPORTE(_fila.ID, _id_reporte, tbCcode.Text, tb_descrip.Text, ck_camb.Checked, val_marco_pinta)
            If IsNothing(resultado) Then
                Mensaje.Fallo("Se produjo un error al modificar la fila " + _fila.DESCRIP)
            Else
                If resultado.COD_ESTADO < 0 Then
                    Mensaje.Fallo(resultado.TXT_ESTADO)
                Else
                    Mensaje.Info("Se modificó correctamente la linea")
                End If
            End If
        End If
    End Sub
#End Region

    Private Sub dibuja_composicion()
        ck_total.Enabled = True
        If Not IsNothing(_fila) Then
            Dim detalle_composicion As DataTable
            If Not ck_total.Checked Then
                lb_titulo.Text = "Cuentas"
                detalle_composicion = base.DETALLE_CUENT_COMP(_fila.ID)
                With lst_composicion
                    .Items.Clear()
                    For Each registro As indice_cuenta_row In detalle_composicion.Rows
                        .Items.Add(registro)
                        ck_total.Enabled = False
                    Next
                End With
            Else
                lb_titulo.Text = "Otras Filas"
                detalle_composicion = base.DETALLE_FILA_COMP(_fila.ID)
                With lst_composicion
                    .Items.Clear()
                    For Each registro As dt_fila_reporte.myRow In detalle_composicion.Rows
                        .Items.Add(registro)
                        ck_total.Enabled = False
                    Next
                End With
            End If
        End If
    End Sub


End Class
