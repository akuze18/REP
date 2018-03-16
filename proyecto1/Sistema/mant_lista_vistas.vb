Public Class mant_lista_vistas
    Private _reporte As Integer
    ''' <summary>
    ''' inicializo clase con configuraciones de INI y Base de Datos
    ''' </summary>
    ''' <remarks></remarks>
    Private base As New base_REP

    Public Sub New(ByVal id_reporte As Integer)
        _reporte = id_reporte
        InitializeComponent()
    End Sub

    Private Sub mant_lista_vistas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim Treporte As dt_tipo_reporte.myRow
        Treporte = base.TIPO_REPORTE(_reporte)
        If IsNothing(Treporte) Then
            Mensaje.Fallo("Se ha producido un error con el tipo de reporte solicitado")
            Exit Sub
        End If
        Dim Svista As dt_vista
        Svista = base.VISTAS(Treporte.ID)
        If IsNothing(Svista) Then
            Mensaje.Fallo("Se ha producido un error con las vistas para mostrar")
            Exit Sub
        End If
        For Each v As dt_vista.myRow In Svista.Rows
            Lista_vistas.Items.Add(v)
        Next

        'configurar ListBox
        Lista_vistas.SelectionMode = SelectionMode.One
    End Sub

    Private Sub btn_edit_Click(sender As System.Object, e As System.EventArgs) Handles btn_edit.Click
        'reviso que exista alguna opcion seleccionada
        If IsNothing(Lista_vistas.SelectedItem) Then
            Mensaje.Fallo("No ha seleccionado ninguna vista del listado")
            Lista_vistas.Focus()
            Exit Sub
        End If
        'obtengo valor seleccionado
        Dim sel_vista As dt_vista.myRow
        sel_vista = Lista_vistas.SelectedItem
        Dim mantenedor As New mant_vistas(sel_vista)
        Dim formulario As form_configurar = Me.ParentForm
        formulario.cargar_mantenedor(mantenedor)
    End Sub

    Private Sub btn_add_Click(sender As System.Object, e As System.EventArgs) Handles btn_add.Click
        Dim mantenedor As New mant_vistas(_reporte)
        Dim formulario As form_configurar = Me.ParentForm
        formulario.cargar_mantenedor(mantenedor)
    End Sub

    Private Sub btn_off_Click(sender As System.Object, e As System.EventArgs) Handles btn_off.Click

    End Sub
End Class
