Public Class mant_regla_columna
    ''' <summary>
    ''' inicializo clase con configuraciones de INI y Base de Datos
    ''' </summary>
    ''' <remarks></remarks>
    Private base As New base_REP
    Private _regla As regla_columna_row
    Private _id_columna As Integer
    Private _columna As dt_columnas.myRow

#Region "Constructores"
    Public Sub New(ByVal id_columna As Integer)
        InitializeComponent()
        _regla = Nothing
        _id_columna = id_columna
        _columna = base.COLUMNA(_id_columna)
    End Sub
    Public Sub New(ByVal regla As regla_columna_row)
        InitializeComponent()
        _regla = regla
        _id_columna = _regla.COLUMNA
        _columna = base.COLUMNA(_id_columna)
    End Sub
#End Region

    Private Sub mant_regla_columna_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        
        tbColumna.Text = _columna.DESCRIP
        tbColumna.Enabled = False

        With cbAplicar
            Dim datos As DataTable = base.VALOR_APLICA(_columna.TOTALIZA)
            .DataSource = datos
            .ValueMember = datos.Columns(0).ColumnName
            .DisplayMember = datos.Columns(1).ColumnName
            .SelectedIndex = -1
        End With
        With cbTipo
            Dim datos As DataTable = base.VALOR_TIPO(_columna.TOTALIZA)
            .DataSource = datos
            .ValueMember = datos.Columns(0).ColumnName
            .DisplayMember = datos.Columns(1).ColumnName
            .SelectedIndex = -1
        End With
        tbValor.Visible = True
        cbValor1.Visible = False
        cbValor2.Visible = False

        If Not IsNothing(_regla) Then
            'Entonces es una regla para editar
            cbAplicar.SelectedValue = _regla.APLICAR
            cbTipo.SelectedValue = _regla.TIPO
        End If


    End Sub

    Private Sub CAMBIO_COMBOS(sender As System.Object, e As System.EventArgs) Handles cbAplicar.SelectedIndexChanged, cbTipo.SelectedIndexChanged
        If cbAplicar.SelectedIndex > -1 And cbTipo.SelectedIndex > -1 Then
            Dim _tipo, _aplica As String
            _tipo = cbTipo.SelectedValue
            _aplica = cbAplicar.SelectedValue
            Select Case _tipo
                Case "IGUAL", "DIF"
                    tbValor.Visible = False
                    cbValor1.Visible = True
                    cbValor2.Visible = False
                    With cbValor1
                        Dim datos As DataTable
                        Select Case _aplica
                            Case "LUGAR"
                                datos = base.LUGARES()
                            Case "COL"
                                datos = base.COLUMNAS(_columna.VISTA, _columna.ID)
                            Case "GESTION"
                                datos = base.GESTION
                            Case Else
                                datos = base.DEPTOS()
                        End Select
                        .DataSource = datos
                        .ValueMember = datos.Columns(0).ColumnName
                        If _aplica = "COL" Then
                            .DisplayMember = datos.Columns(3).ColumnName
                        Else
                            .DisplayMember = datos.Columns(1).ColumnName
                        End If

                        If Not IsNothing(_regla) Then
                            .SelectedValue = _regla.VALIDACION
                        End If

                    End With
                Case "COMIENZA"
                    tbValor.Visible = True
                    cbValor1.Visible = False
                    cbValor2.Visible = False
                    If IsNothing(_regla) Then
                        tbValor.Text = String.Empty
                    Else
                        tbValor.Text = _regla.VALIDACION
                    End If
                Case "ENTRE"
                    tbValor.Visible = False
                    cbValor1.Visible = True
                    cbValor2.Visible = True
                    With cbValor1
                        Dim datos As DataTable
                        Select Case _aplica
                            Case "LUGAR"
                                datos = base.LUGARES()
                            Case "COL"
                                datos = base.COLUMNAS(_columna.VISTA, _columna.ID)
                            Case Else
                                datos = base.DEPTOS()
                        End Select
                        .DataSource = datos
                        .ValueMember = datos.Columns(0).ColumnName
                        .DisplayMember = datos.Columns(1).ColumnName
                        If Not IsNothing(_regla) Then
                            .SelectedValue = _regla.VALIDACION.Split(" TO ")(0)
                        End If
                    End With
                    With cbValor2
                        Dim datos As DataTable
                        Select Case _aplica
                            Case "LUGAR"
                                datos = base.LUGARES()
                            Case "COL"
                                datos = base.COLUMNAS(_columna.VISTA, _columna.ID)
                            Case Else
                                datos = base.DEPTOS()
                        End Select
                        .DataSource = datos
                        .ValueMember = datos.Columns(0).ColumnName
                        .DisplayMember = datos.Columns(1).ColumnName
                        If Not IsNothing(_regla) Then
                            Try
                                .SelectedValue = _regla.VALIDACION.Split(" TO ")(1)
                            Catch ex As Exception
                                .SelectedIndex = -1
                            End Try
                        End If
                    End With
            End Select
        End If
    End Sub


    Private Sub btn_ok_Click(sender As System.Object, e As System.EventArgs) Handles btn_ok.Click
        'Validacion
        If cbAplicar.SelectedIndex < 0 Then
            Mensaje.Alerta("No ha indicado sobre que aplica la regla")
            cbAplicar.Focus()
            Exit Sub
        End If
        If cbTipo.SelectedIndex < 0 Then
            Mensaje.Alerta("No ha seleccionado un tipo de regla")
            cbTipo.Focus()
            Exit Sub
        End If
        If cbValor1.Visible And cbValor1.SelectedIndex < 0 Then
            Mensaje.Alerta("No ha indicado un valor para la regla")
            cbValor1.Focus()
            Exit Sub
        End If
        If cbValor2.Visible And cbValor2.SelectedIndex < 0 Then
            Mensaje.Alerta("No ha indicado un valor para la regla")
            cbValor2.Focus()
            Exit Sub
        End If
        If tbValor.Visible And String.IsNullOrEmpty(tbValor.Text) Then
            Mensaje.Alerta("No ha indicado un valor para la regla")
            tbValor.Focus()
            Exit Sub
        End If
        'aplicar cambio
        Dim Aaplicar, Atipo, Avalidacion As String
        Aaplicar = cbAplicar.SelectedValue
        Atipo = cbTipo.SelectedValue
        If Atipo = "IGUAL" Then
            Avalidacion = cbValor1.SelectedValue
        ElseIf Atipo = "ENTRE" Then
            Avalidacion = cbValor1.SelectedValue + " TO " + cbValor2.SelectedValue
        Else 'o sea COMIENZA
            Avalidacion = tbValor.Text
        End If
        Dim resultado As dt_query_result.myRow
        If IsNothing(_regla) Then
            resultado = base.NEW_REGLA_COL(_id_columna, Aaplicar, Atipo, Avalidacion)
        Else
            resultado = base.MOD_REGLA_COL(_regla.ID, Aaplicar, Atipo, Avalidacion)
        End If
        If IsNothing(resultado) Then
            Mensaje.Fallo("Se produjo un error al procesar la regla")
        Else
            If resultado.COD_ESTADO = 1 Then
                If IsNothing(_regla) Then
                    Mensaje.Info("Se ha ingresado correctamente la regla")
                Else
                    Mensaje.Info("Se ha modificado correctamente la regla")
                End If
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                Mensaje.Fallo(resultado.TXT_ESTADO)
            End If
        End If
    End Sub

    Private Sub btn_off_Click(sender As System.Object, e As System.EventArgs) Handles btn_off.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class