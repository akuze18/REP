Public Class mant_filas_reporte
#Region "Variables de clase"
    ''' <summary>
    ''' inicializo clase con configuraciones de INI y Base de Datos
    ''' </summary>
    ''' <remarks></remarks>
    Private base As New base_REP

    Private _id_reporte As Integer
    Private _id_fila As Integer
#End Region

#Region "Constructores"
    Public Sub New(ByVal id_reporte As Integer)
        InitializeComponent()
        _id_reporte = id_reporte
        _id_fila = 0
    End Sub

    Public Sub New(ByVal id_reporte As Integer, ByVal id_fila As Integer)
        InitializeComponent()
        _id_reporte = id_reporte
        _id_fila = id_fila
    End Sub
#End Region

#Region "Formulario"
    Private Sub mant_filas_reporte_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim datos As dt_fila_reporte
        datos = base.FILAS_REPORTE(_id_reporte)

        With LB1
            .Text = "Filas de " + base.TIPO_REPORTE(_id_reporte).DESCRIP
        End With

        With DGfilas
            .RowHeadersVisible = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .Size = New Size(Me.Size.Width - 100, 200)

            Dim select_ind As Integer

            For Each registro As dt_fila_reporte.myRow In datos.Rows
                Dim indice_fila As Integer
                .Rows.Add()
                indice_fila = .Rows.Count - 1
                .Item(0, indice_fila).Value = registro.ID
                .Item(1, indice_fila).Value = registro.DESCRIP
                .Item(2, indice_fila).Value = registro.ORDEN
                .Item(3, indice_fila).Value = registro.CAMBIAR
                .Item(4, indice_fila).Value = registro.TOTALIZAR
                .Item(5, indice_fila).Value = registro.DISTRIB
                If registro.ID = _id_fila Then
                    select_ind = indice_fila
                End If
            Next
            If _id_fila = 0 Then
                .ClearSelection()
            Else
                .FirstDisplayedScrollingRowIndex = select_ind
                .Rows(select_ind).Selected = True
            End If

        End With

        With btn_down
            .Location = New Point(80, DGfilas.Location.Y + DGfilas.Size.Height + 20)
        End With
        With btn_up
            .Location = New Point(btn_down.Location.X + btn_down.Size.Width + 20, DGfilas.Location.Y + DGfilas.Size.Height + 20)
        End With
        With btn_edit
            .Location = New Point(btn_up.Location.X + btn_up.Size.Width + 70, DGfilas.Location.Y + DGfilas.Size.Height + 20)
        End With
        With btn_new
            .Location = New Point(btn_edit.Location.X + btn_edit.Size.Width + 20, DGfilas.Location.Y + DGfilas.Size.Height + 20)
        End With
    End Sub
#End Region

#Region "Funciones de los botones"
    Private Sub modificar_linea(sender As System.Object, e As System.EventArgs) Handles btn_up.Click, btn_edit.Click, btn_down.Click, btn_new.Click
        'Checkeos de control respecto a los objetos necesarios
        If Not (TypeOf sender Is Button) Then
            'sender solo debe ser Button para continuar
            Exit Sub
        End If
        Dim accion As Button = CType(sender, Button)
        If DGfilas.SelectedRows.Count > 0 Then
            Dim fila, otra_fila As DataGridViewRow
            fila = DGfilas.SelectedRows(0)
            'Genero una copia de la fila seleccionada para procesar su movimiento
            otra_fila = fila.Clone
            For i = 0 To fila.Cells.Count - 1
                otra_fila.Cells(i).Value = fila.Cells(i).Value
            Next
            Select Case accion.Name
                Case "btn_up"
                    If fila.Index > 0 Then  'si es 0, quiere decir que es la primera y no puede subir mas
                        Dim prev_fila As DataGridViewRow

                        prev_fila = DGfilas.Rows(fila.Index - 1)

                        DGfilas.Rows.Insert(fila.Index - 1, otra_fila)
                        DGfilas.Rows.RemoveAt(fila.Index)

                        otra_fila.Cells("Orden").Value = otra_fila.Cells("Orden").Value - 1
                        prev_fila.Cells("Orden").Value = prev_fila.Cells("Orden").Value + 1

                        Dim resultado As dt_query_result.myRow
                        resultado = base.MOD_ORDEN_FILA_REPORTE(otra_fila.Cells(0).Value, otra_fila.Cells("Orden").Value)
                        If IsNothing(resultado) Then
                            Mensaje.Fallo("Se produjo un error al cambiar de posición la fila " + otra_fila.Cells(1).Value)
                            Exit Sub
                        Else
                            If resultado.COD_ESTADO < 0 Then
                                Mensaje.Fallo(resultado.TXT_ESTADO)
                                Exit Sub
                            End If
                        End If
                        resultado = base.MOD_ORDEN_FILA_REPORTE(prev_fila.Cells(0).Value, prev_fila.Cells("Orden").Value)
                        If IsNothing(resultado) Then
                            Mensaje.Fallo("Se produjo un error al cambiar de posición la fila " + prev_fila.Cells(1).Value)
                            Exit Sub
                        Else
                            If resultado.COD_ESTADO < 0 Then
                                Mensaje.Fallo(resultado.TXT_ESTADO)
                                Exit Sub
                            End If
                        End If

                        otra_fila.Selected = True
                    End If
                Case "btn_down"
                    If fila.Index < DGfilas.Rows.Count - 1 Then  'grilla.Rows.Count-1 representa la ultima fila y no puede bajar mas
                        Dim post_fila As DataGridViewRow
                        post_fila = DGfilas.Rows(fila.Index + 1)
                        DGfilas.Rows.Insert(fila.Index + 2, otra_fila)
                        DGfilas.Rows.RemoveAt(fila.Index)

                        otra_fila.Cells("Orden").Value = otra_fila.Cells("Orden").Value + 1
                        post_fila.Cells("Orden").Value = post_fila.Cells("Orden").Value - 1

                        Dim resultado As dt_query_result.myRow
                        resultado = base.MOD_ORDEN_FILA_REPORTE(otra_fila.Cells(0).Value, otra_fila.Cells("Orden").Value)
                        If IsNothing(resultado) Then
                            Mensaje.Fallo("Se produjo un error al cambiar de posición la fila " + otra_fila.Cells(1).Value)
                            Exit Sub
                        Else
                            If resultado.COD_ESTADO < 0 Then
                                Mensaje.Fallo(resultado.TXT_ESTADO)
                                Exit Sub
                            End If
                        End If
                        resultado = base.MOD_ORDEN_FILA_REPORTE(post_fila.Cells(0).Value, post_fila.Cells("Orden").Value)
                        If IsNothing(resultado) Then
                            Mensaje.Fallo("Se produjo un error al cambiar de posición la fila " + post_fila.Cells(1).Value)
                            Exit Sub
                        Else
                            If resultado.COD_ESTADO < 0 Then
                                Mensaje.Fallo(resultado.TXT_ESTADO)
                                Exit Sub
                            End If
                        End If

                        otra_fila.Selected = True
                    End If
                Case "btn_edit"
                    Dim form_parent As form_configurar
                    form_parent = Me.ParentForm
                    form_parent.TVopciones.Enabled = False
                    form_parent.dibujar_filas_reporte_detalle(fila.Cells("ID").Value)
                Case "btn_new"
                    Dim form_parent As form_configurar
                    form_parent = Me.ParentForm
                    form_parent.TVopciones.Enabled = False
                    form_parent.dibujar_fila_nueva_reporte_detalle(_id_reporte)
            End Select
            'Si la fila copiada fue insertada su indice estará entre 0 y la cantidad maxima de filas
            If otra_fila.Index >= 0 Then
                Dim dif_visual As Integer
                dif_visual = otra_fila.Index - DGfilas.FirstDisplayedScrollingRowIndex
                If dif_visual < 8 Then
                    If dif_visual < 0 Then
                        DGfilas.FirstDisplayedScrollingRowIndex = otra_fila.Index
                    End If
                Else
                    DGfilas.FirstDisplayedScrollingRowIndex = otra_fila.Index - 7
                End If
            End If
        Else
            If accion.Name = "btn_new" Then
                Dim form_parent As form_configurar
                form_parent = Me.ParentForm
                form_parent.TVopciones.Enabled = False
                form_parent.dibujar_fila_nueva_reporte_detalle(_id_reporte)
            End If
        End If

    End Sub

#End Region




End Class
