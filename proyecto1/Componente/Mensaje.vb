Public Class Mensaje
    Shared _compañia = "NH Foods Chile"

    Public Shared Sub Alerta(ByVal mensaje As String)
        MessageBox.Show(mensaje, _compañia, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Public Shared Sub Fallo(ByVal mensaje As String)
        MessageBox.Show(mensaje, _compañia, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public Shared Sub Info(ByVal mensaje As String)
        MessageBox.Show(mensaje, _compañia, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Shared Function Confirma(ByVal mensaje As String) As DialogResult
        Return MessageBox.Show(mensaje, _compañia, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
    End Function
    Public Shared Function Digite(ByVal mensaje As String) As String
        Return InputBox(mensaje, _compañia)
    End Function
End Class
