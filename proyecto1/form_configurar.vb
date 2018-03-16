Public Class form_configurar
#Region "Variables de clase"
    ''' <summary>
    ''' inicializo clase con configuraciones de INI y Base de Datos
    ''' </summary>
    ''' <remarks></remarks>
    Private base As New base_REP

    Private _Hdif As Integer
    Private _Vdif As Integer
#End Region

#Region "Formulario"
    Private Sub form_configurar_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        form_welcome.Show()
    End Sub
    Private Sub form_configurar_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        _Hdif = Pmostrar.Size.Width - Me.Size.Width
        _Vdif = Pmostrar.Size.Height - Me.Size.Height
        Me.MinimumSize = Me.Size
        Me.WindowState = FormWindowState.Maximized
        If base.estado Then
            Dim datos As dt_tipo_reporte
            'nodo Tipo
            datos = base.TIPO_REPORTE
            For Each fila As dt_tipo_reporte.myRow In datos.Rows
                Dim nodo_reporte As New TreeNode
                nodo_reporte.Text = fila.DESCRIP
                nodo_reporte.Tag = "1:" + fila.ID.ToString
                TVopciones.Nodes.Add(nodo_reporte)
                'agrego detalle de lineas
                Dim nodo_lineas As New TreeNode("Lineas")
                nodo_lineas.Tag = "2:" + fila.ID.ToString
                Dim nodo_clasif As New TreeNode("Clasificaciones")
                nodo_clasif.Tag = "5:" + fila.ID.ToString
                nodo_reporte.Nodes.Add(nodo_lineas)
                nodo_reporte.Nodes.Add(nodo_clasif)
            Next
            'Dim nodo_sector As New TreeNode("Sectores")
            'nodo Vistas
            Dim nodo_vistas As New TreeNode("Vistas")
            nodo_vistas.Tag = "3:"
            Dim datos3 As dt_tipo_reporte
            datos3 = base.TIPO_REPORTE
            For Each rep As dt_tipo_reporte.myRow In datos3.Rows
                Dim single_rep As New TreeNode
                single_rep.Text = rep.DESCRIP
                single_rep.Tag = "3:" + rep.ID.ToString
                nodo_vistas.Nodes.Add(single_rep)
            Next
            'nodo Distribuciones
            Dim nodo_dist As New TreeNode("Distribuciones")
            nodo_dist.Tag = "4:"
            Dim datos2 As tipo_distribucion_table
            datos2 = base.TIPO_DISTRIB
            For Each fila As tipo_distribucion_row In datos2.Rows
                Dim single_distrib As New TreeNode
                single_distrib.Text = fila.DESCRIP
                single_distrib.Tag = "4:" + fila.ID.ToString
                nodo_dist.Nodes.Add(single_distrib)
            Next
            TVopciones.Nodes.AddRange(New TreeNode() {nodo_vistas, nodo_dist})
            TVopciones.ExpandAll()
        Else
            Mensaje.Fallo(base.estado_desc)
            Me.Dispose()
        End If

    End Sub
    Private Sub form_configurar_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        If _Hdif <> 0 And _Vdif <> 0 Then
            Pmostrar.Size = New Size(Me.Width + _Hdif, Me.Height + _Vdif)
        End If
    End Sub

    Private Sub TVopciones_NodeMouseClick(sender As Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TVopciones.NodeMouseClick
        Dim nodo_actual As TreeNode
        Dim valor As String()
        nodo_actual = e.Node
        limpiar_color_opciones()
        nodo_actual.BackColor = SystemColors.MenuHighlight  'Color.Blue
        nodo_actual.ForeColor = SystemColors.Menu       'Color.White
        valor = Split(nodo_actual.Tag, ":")
        Pmostrar.Controls.Clear()
        Select Case valor(0)
            Case "1"    'Corresponde al Tipo de Reporte
                dibujar_tipo_reporte(valor(1))
            Case "2"
                dibujar_filas_reporte(valor(1))
            Case "3"
                If valor(1) <> "" Then
                    dibujar_vista(valor(1))
                End If
            Case "4"
                If valor(1) <> "" Then
                    dibujar_distribucion(valor(1))
                End If
            Case "5"
                If valor(1) <> "" Then
                    dibujar_clasificacion(valor(1))
                End If
        End Select
    End Sub

    Private Sub limpiar_color_opciones()
        For Each nodo1 As TreeNode In TVopciones.Nodes
            nodo1.BackColor = SystemColors.Window
            nodo1.ForeColor = SystemColors.WindowText
            For Each nodo2 As TreeNode In nodo1.Nodes
                nodo2.BackColor = SystemColors.Window
                nodo2.ForeColor = SystemColors.WindowText
                For Each nodo3 As TreeNode In nodo2.Nodes
                    nodo3.BackColor = SystemColors.Window
                    nodo3.ForeColor = SystemColors.WindowText
                Next
            Next
        Next
    End Sub
#End Region

#Region "dibujar ingreso de datos"
    Public Sub cargar_mantenedor(ByVal mantenedor As Control)
        Pmostrar.Controls.Clear()
        If Not IsNothing(mantenedor) Then
            Pmostrar.Controls.Add(mantenedor)
            mantenedor.Dock = DockStyle.Fill
        End If
    End Sub

    Private Sub dibujar_tipo_reporte(Optional ByVal id_reporte As String = "")
        Dim mantenedor As mant_tipo_reporte
        If id_reporte = "" Then
            mantenedor = New mant_tipo_reporte
        Else
            mantenedor = New mant_tipo_reporte(id_reporte)
        End If
        cargar_mantenedor(mantenedor)
    End Sub
    Friend Sub dibujar_filas_reporte(ByVal id_reporte As String, Optional id_fila As String = "")
        Dim mantenedor As mant_filas_reporte
        If id_fila = "" Then
            mantenedor = New mant_filas_reporte(id_reporte)
        Else
            mantenedor = New mant_filas_reporte(id_reporte, id_fila)
        End If
        cargar_mantenedor(mantenedor)
    End Sub
    Friend Sub dibujar_filas_reporte_detalle(ByVal id_fila As Integer)
        Dim fila As dt_fila_reporte.myRow
        fila = base.FILA_REP(id_fila)
        If Not IsNothing(fila) Then
            Dim mantenedor As New mant_filas_reporte_detalle(fila)
            cargar_mantenedor(mantenedor)
        Else
            'No se encontro información de la fila solicitada
            Mensaje.Fallo("No se encontró información de la fila solicitada")
        End If
    End Sub
    Friend Sub dibujar_fila_nueva_reporte_detalle(ByVal id_reporte As Integer)
        Dim reporte As dt_tipo_reporte.myRow
        reporte = base.TIPO_REPORTE(id_reporte)
        If Not IsNothing(reporte) Then
            Dim mantenedor As New mant_filas_reporte_detalle(reporte.ID)
            cargar_mantenedor(mantenedor)
        Else
            'No se encontro información de la fila solicitada
            Mensaje.Fallo("No se encontró información del reporte solicitado")
        End If
    End Sub
    Private Sub dibujar_distribucion(ByVal id_distrib As String)
        Dim fila As tipo_distribucion_row
        fila = base.TIPO_DISTRIB(id_distrib)
        If Not IsNothing(fila) Then
            Dim mantenedor As New mant_distrib(id_distrib)
            cargar_mantenedor(mantenedor)
        Else
            Mensaje.Fallo("No se encontró información de la distribución solicitada")
        End If
    End Sub
    Private Sub dibujar_vista(ByVal id_reporte As Integer)
        Dim reporte As dt_tipo_reporte.myRow
        reporte = base.TIPO_REPORTE(id_reporte)
        If Not IsNothing(reporte) Then
            Dim mantenedor As New mant_lista_vistas(id_reporte)
            cargar_mantenedor(mantenedor)
        Else
            Mensaje.Fallo("No se encontró información del tipo de reporte solicitado")
        End If
    End Sub

    Private Sub dibujar_clasificacion(ByVal id_reporte As Integer)
        Dim reporte As dt_tipo_reporte.myRow
        reporte = base.TIPO_REPORTE(id_reporte)
        If Not IsNothing(reporte) Then
            Dim mantenedor As New mant_clasificacion(id_reporte)
            cargar_mantenedor(mantenedor)
        Else
            Mensaje.Fallo("No se encontró información del tipo de reporte solicitado")
        End If
    End Sub
#End Region

    
End Class

