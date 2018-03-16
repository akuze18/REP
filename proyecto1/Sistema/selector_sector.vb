Public Class selector_sector
    ''' <summary>
    ''' inicializo clase con configuraciones de INI y Base de Datos
    ''' </summary>
    ''' <remarks></remarks>
    Private base As New base_REP

    Private _marcado As Integer

    Private Sub selector_sector_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.MinimumSize = Me.Size
        Me.MaximumSize = Me.Size
        Dim _sectores As sector_table
        _sectores = base.SECTORES
        For Each s As sector_row In _sectores.Rows
            lista_sect.Items.Add(s)
        Next
    End Sub

    Public ReadOnly Property marcado As Integer
        Get
            Return _marcado
        End Get
    End Property

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'reviso que haya algo marcado
        If lista_sect.SelectedItems.Count = 0 Then
            Mensaje.Alerta("No se ha seleccionado ningun sector")
            Exit Sub
        End If
        Dim sel As sector_row
        sel = lista_sect.SelectedItem
        _marcado = sel.ID
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class