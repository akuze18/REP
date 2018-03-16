Imports ActDir = System.DirectoryServices
Imports System.Data.Sql
Imports System.Data.SqlClient



Public Class mant_servidores
    Dim base As New base_REP
    Private Sub server_test_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btn_find_serv.Text = "Buscar Servidores"
        btn_sel_serv.Text = "Seleccionar Servidor"
        btn_manual.Text = "Manual"
        TBServerSet.Text = base.servidor
        TBServerSet.Enabled = False
        TBServerImp.Enabled = False
    End Sub

    Private Function GetProperty(ByVal searchResult As ActDir.SearchResult, ByVal PropertyName As String) As String
        Dim propertyKey, resultado As String
        Dim caca As String
        resultado = String.Empty
        For Each propertyKey In searchResult.Properties.PropertyNames

            Dim valueCollection As ActDir.ResultPropertyValueCollection = searchResult.Properties(propertyKey)
            Dim propertyValue As Object
            For Each propertyValue In valueCollection
                If propertyKey = PropertyName Then
                    resultado = propertyValue.ToString()
                Else
                    caca = propertyValue.ToString()
                End If
            Next propertyValue

        Next propertyKey
        Return resultado
    End Function

    Private Sub buscar_servidores(Optional ByVal alerta As Boolean = False)
        Dim elemento As String
        Try
            Dim entry As New ActDir.DirectoryEntry("LDAP://nhfoodschile.cl/OU=SERVIDORES,DC=nhfoodschile,DC=cl")  'CN=Contenedor, OU= Unidad Organizativa
            Dim Dsearch As New ActDir.DirectorySearcher(entry)
            Dsearch.Filter = "(objectclass=contact)"
            For Each sResultSet As ActDir.SearchResult In Dsearch.FindAll()
                elemento = GetProperty(sResultSet, "name")
                ListServer.Items.Add(elemento.Replace(" ", "\"))
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        If alerta Then
            MessageBox.Show("Servidores obtenidos.")
        End If
    End Sub

    Private Sub btn_find_serv_Click(sender As System.Object, e As System.EventArgs) Handles btn_find_serv.Click
        buscar_servidores(True)
    End Sub

    Private Sub btn_sel_serv_Click(sender As System.Object, e As System.EventArgs) Handles btn_sel_serv.Click
        If Not String.IsNullOrWhiteSpace(TBServerImp.Text) Then
            base.servidor = TBServerImp.Text
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            MessageBox.Show("No se ha seleccionado ningun servidor")
        End If
    End Sub

    Private Sub btn_manual_Click(sender As System.Object, e As System.EventArgs) Handles btn_manual.Click

    End Sub

    Private Sub ListServer_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListServer.SelectedIndexChanged
        If ListServer.SelectedItems.Count = 1 Then
            TBServerImp.Text = ListServer.SelectedItem
        End If
    End Sub


End Class