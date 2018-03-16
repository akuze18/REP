Public Class mant_clasificacion_detalle
    ''' <summary>
    ''' inicializo clase con configuraciones de INI y Base de Datos
    ''' </summary>
    ''' <remarks></remarks>
    Private base As New base_REP

    Private _regla As regla_clasif_row
    Private _id_reporte As Integer
    Private _gasto As dt_fila_reporte.myRow

#Region "Constructores"
    ''' <summary>
    ''' Constructor para una NUEVA clasificiación de un reporte
    ''' </summary>
    ''' <param name="id_reporte">Indica el ID del reporte al que pertenecerá la regla</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal id_reporte As Integer)
        InitializeComponent()
        _regla = Nothing
        _id_reporte = id_reporte
    End Sub
    ''' <summary>
    ''' Constructor para una MODIFICACION a una clasificación
    ''' </summary>
    ''' <param name="regla">Indica la regla especifica que se va a modificar</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal regla As regla_clasif_row)
        InitializeComponent()
        _regla = regla
        _id_reporte = _regla.REPORTE
    End Sub
#End Region

    Private Sub mant_clasificacion_detalle_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        With cbFila
            Dim sel_filas As dt_fila_reporte
            sel_filas = base.FILAS_REPORTE(_id_reporte)
            _gasto = Nothing
            For Each sel_f As dt_fila_reporte.myRow In sel_filas.Rows
                If Not sel_f.TOTALIZAR Then
                    .Items.Add(sel_f)
                    If sel_f.DESCRIP = "Gastos de Administ Departamento" Then
                        _gasto = sel_f
                    End If
                End If
            Next
            .DropDownHeight = 14 * 6
            .SelectedIndex = -1
        End With

        With cbTipo
            .DataSource = base.VALOR_TIPO_CLAS(Not IsNothing(_gasto))
            .ValueMember = CType(.DataSource, DataTable).Columns(0).ColumnName
            .DisplayMember = CType(.DataSource, DataTable).Columns(1).ColumnName
            .SelectedIndex = 0
        End With
        With tbValid1
            .Text = String.Empty
            '.DataSource = base.SOLO_CUENTA
            '.ValueMember = CType(.DataSource, DataTable).Columns(1).ColumnName
            '.DisplayMember = CType(.DataSource, DataTable).Columns(1).ColumnName
            '.DropDownHeight = 14 * 6
            '.SelectedIndex = -1
        End With
        With tbValid2
            .Text = String.Empty
            '.DataSource = base.SOLO_CUENTA
            '.ValueMember = CType(.DataSource, DataTable).Columns(1).ColumnName
            '.DisplayMember = CType(.DataSource, DataTable).Columns(1).ColumnName
            '.DropDownHeight = 14 * 6
            '.SelectedIndex = -1
        End With

        If IsNothing(_regla) Then
            Me.Text = "Creación " + Me.Text
        Else
            Me.Text = "Modificación " + Me.Text
            cbTipo.SelectedValue = _regla.TIPO
            Dim validacion As String()

            validacion = _regla.VALIDACION.Replace(" TO ", "T").Split("T")

            If validacion.Count = 2 Then
                tbValid1.Text = validacion(0)
                tbValid2.Text = validacion(1)
            Else
                tbValid1.Text = validacion(0)
            End If
            For i = 0 To cbFila.Items.Count - 1
                Dim fil As dt_fila_reporte.myRow
                fil = cbFila.Items(i)
                If fil.ID = _regla.FILA Then
                    cbFila.SelectedIndex = i
                End If

            Next

        End If
    End Sub

    Private Sub btn_off_Click(sender As System.Object, e As System.EventArgs) Handles btn_off.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub cbTipo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbTipo.SelectedIndexChanged
        If cbTipo.SelectedIndex >= 0 Then
            Dim cod_tipo_regla As String
            If TypeOf cbTipo.SelectedValue Is DataRow Then
                Dim fila_tipo_regla As DataRowView
                Dim ftr As DataRow
                fila_tipo_regla = cbTipo.SelectedValue
                ftr = fila_tipo_regla.Row
                cod_tipo_regla = ftr.Item(0)
            Else
                cod_tipo_regla = cbTipo.SelectedValue.ToString
            End If

            With cbFila
                .Enabled = True
                .SelectedIndex = -1
            End With


            Select Case cod_tipo_regla
                Case "SC", "EC", "SL"
                    With tbValid1
                        .Visible = True
                        .Width = cbTipo.Width
                        .Text = String.Empty
                    End With
                    With tbValid2
                        .Visible = False
                        '.Width = 150
                    End With
                    If cod_tipo_regla = "EC" Then

                        With cbFila
                            .Enabled = False
                            .SelectedItem = _gasto
                        End With

                    End If
                Case "RC", "RL"
                    With tbValid1
                        .Visible = True
                        .Width = 150
                        .Text = String.Empty
                    End With
                    With tbValid2
                        .Visible = True
                        .Width = 150
                        .Text = String.Empty
                    End With
            End Select
        End If
    End Sub

    Private Sub btn_guardar_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardar.Click
        'Inicio Validacion
        If cbTipo.SelectedIndex < 0 Then
            Mensaje.Alerta("No ha seleccionado un tipo de regla")
            cbTipo.Focus()
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(tbValid1.Text) Then
            Mensaje.Alerta("No ha indicado la validación para la regla")
            tbValid1.Focus()
            Exit Sub
        End If
        If tbValid2.Visible And String.IsNullOrWhiteSpace(tbValid2.Text) Then
            Mensaje.Alerta("no ha indicado la validación para la regla")
            tbValid2.Focus()
            Exit Sub
        End If
        If IsNothing(cbFila.SelectedItem) Then
            Mensaje.Alerta("No ha indicado una fila para la regla")
            cbFila.Focus()
            Exit Sub
        End If
        'Fin de Validacion
        Dim Sregla, Svalidacion As String
        Dim Rfila As dt_fila_reporte.myRow
        Sregla = cbTipo.SelectedValue
        If tbValid2.Visible Then
            Svalidacion = tbValid1.Text + " TO " + tbValid2.Text
        Else
            Svalidacion = tbValid1.Text
        End If
        Rfila = cbFila.SelectedItem

        Dim resultado As dt_query_result.myRow
        If IsNothing(_regla) Then
            'Es una nueva regla, por lo tanto la creo
            resultado = base.NEW_REGLA_CLASIFICACION(_id_reporte, Sregla, Svalidacion, Rfila.ID)

        Else
            'Ya existia una regla, por lo tanto la modifico
            resultado = base.MOD_REGLA_CLASIFICACION(_regla.ID, Sregla, Svalidacion, Rfila.ID)
        End If
        If IsNothing(resultado) Then
            Mensaje.Fallo("Se produjo un error al intentar guardar la regla de clasificacion")
            Exit Sub
        Else
            If resultado.COD_ESTADO <= 0 Then
                Mensaje.Fallo(resultado.TXT_ESTADO)
                Exit Sub
            Else
                Mensaje.Info("Se ha guardado correctamente la regla de clasificación")
                DialogResult = Windows.Forms.DialogResult.OK
            End If
        End If
    End Sub
End Class