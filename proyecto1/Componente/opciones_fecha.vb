Imports System.ComponentModel

Public Class opciones_fecha
    Private _tipo As Ftipo
    Private _siempre As DateTime
    Public Enum Ftipo
        desde
        hasta
    End Enum
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub opciones_fecha_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If _tipo = Ftipo.desde Then
            GroupBox1.Text = "Desde"
            _siempre = New Date(1900, 1, 1)
        ElseIf _tipo = Ftipo.hasta Then
            GroupBox1.Text = "Hasta"
            _siempre = New Date(9999, 12, 31)
        End If
        op3.Checked = True
        op1.Checked = True
    End Sub

    Private Sub op3_CheckedChanged(sender As Object, e As System.EventArgs) Handles op3.CheckedChanged
        dtpOP3.Enabled = op3.Checked
    End Sub

    Public Function marcado() As DateTime
        Dim fecha As DateTime
        For Each ck As RadioButton In GroupBox1.Controls.OfType(Of RadioButton)()
            If ck.Checked Then
                Select Case ck.Name
                    Case "op1"
                        fecha = _siempre
                    Case "op2"
                        fecha = Now
                    Case "op3"
                        fecha = dtpOP3.Value
                End Select
            End If
        Next
        Return fecha
    End Function

    <Browsable(True), _
    EditorBrowsable(EditorBrowsableState.Always), _
    Category("Custom"), _
    Description("Determina la fecha que se ingresará a la fecha Especificar"), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property especificar As DateTime
        Get
            Return dtpOP3.Value
        End Get
        Set(value As DateTime)
            dtpOP3.Value = value
        End Set
    End Property

    <DisplayName("OpcionTipo")> _
    <Category("Custom")> _
    <Description("Determina si el control es de tipo Desde o Hasta")> _
    Public Property opcion_tipo As Ftipo
        Get
            Return _tipo
        End Get
        Set(value As Ftipo)
            _tipo = value
        End Set
    End Property

    Public ReadOnly Property siempre As DateTime
        Get
            Return _siempre
        End Get
    End Property

End Class
