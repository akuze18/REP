Public Class mant_clasificacion
    Private _reporte As dt_tipo_reporte.myRow
    ''' <summary>
    ''' inicializo clase con configuraciones de INI y Base de Datos
    ''' </summary>
    ''' <remarks></remarks>
    Private base As New base_REP
    Public Sub New(ByVal id_reporte As Integer)
        InitializeComponent()
        _reporte = base.TIPO_REPORTE(id_reporte)
    End Sub

    Private Sub mant_clasificacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Label1.Text = Label1.Text + " " + _reporte.DESCRIP
        Label2.Text = Label2.Text + " " + _reporte.DESCRIP

        With dgReglas
            Dim col1, col2, col3, col4 As New DataGridViewTextBoxColumn()
            With col1
                .Name = "Tipo Regla"
                .Width = 150
                '.SortMode = DataGridViewColumnSortMode.Programmatic
            End With
            With col2
                .Name = "Validación"
                .Width = 150
                '.SortMode = DataGridViewColumnSortMode.Programmatic
            End With
            With col3
                .Name = "Fila Asociada"
                .Width = 150
                '.SortMode = DataGridViewColumnSortMode.Programmatic
            End With
            With col4
                .Name = "id_regla"
                .Width = 0
                .Visible = False
                '.SortMode = DataGridViewColumnSortMode.Programmatic
            End With
            .Columns.AddRange(New DataGridViewTextBoxColumn() {col1, col2, col3, col4})
            .RowHeadersVisible = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = False
            '.SortOrder = SortOrder.None
            .EditMode = DataGridViewEditMode.EditProgrammatically
        End With
        With dgClasifica
            Dim col1, col4 As New DataGridViewTextBoxColumn()
            Dim col3 As New DataGridViewComboBoxColumn
            With col1
                .Name = "Cuenta"
                .Width = 200
                .ReadOnly = True
            End With
            With col3
                .Name = "Fila Asociada"
                .DataSource = base.FILAS_REPORTE(_reporte.ID)
                .ValueMember = .DataSource.Columns(0).ColumnName
                .DisplayMember = .DataSource.Columns(1).ColumnName
                .Width = 150
                .MaxDropDownItems = 6
                .DropDownWidth = 6
            End With
            With col4
                .Name = "id_regla"
                .Width = 0
                .Visible = False
            End With
            .Columns.Add(col1)
            .Columns.Add(col3)
            .Columns.Add(col4)
            .RowHeadersVisible = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = False
            '.EditMode = DataGridViewEditMode.EditProgrammatically
        End With
        cargar_reglas()
        cargar_clasificacion()
    End Sub

    Private Sub cargar_reglas()
        If Not IsNothing(_reporte) Then
            Dim allReglas As regla_clasif_table
            allReglas = base.REGLAS_CLASIFICACION(_reporte.ID)
            With dgReglas
                .Rows.Clear()
                For Each iRegla As regla_clasif_row In allReglas.Rows
                    Dim fila As Integer
                    fila = .Rows.Count
                    .Rows.Add()
                    .Item(0, fila).Value = iRegla.TIPO_TEXT
                    .Item(1, fila).Value = iRegla.VALIDACION
                    .Item(2, fila).Value = iRegla.FILA_TEXT
                    .Item(3, fila).Value = iRegla.ID
                Next
            End With

        End If
    End Sub
    Private Sub cargar_clasificacion()
        If Not IsNothing(_reporte) Then
            Dim allClasif As comp_fila_table
            allClasif = base.COMPOSICION_CUENTAS(_reporte.ID)
            With dgClasifica
                .Rows.Clear()
                For Each iClasif As comp_fila_row In allClasif.Rows
                    'iClasif.FILA_CLASIF = base.comp
                    Dim fila As Integer
                    fila = .Rows.Count
                    .Rows.Add()
                    .Item(0, fila).Value = iClasif.INDICE_CUENTA.DESCRIP
                    .Item(1, fila).Value = iClasif.FILA_REPORTE.ID
                    .Item(2, fila).Value = iClasif.ID
                Next
            End With
        End If
    End Sub

    Private Sub btn_autoclasificar_Click(sender As System.Object, e As System.EventArgs) Handles btn_autoclasificar.Click
        Dim confirm As DialogResult
        confirm = Mensaje.Confirma("¿Esta seguro que desea aplicar las reglas de clasificación?")
        If confirm = DialogResult.Yes Then
            Dim aclas As DataTable()
            aclas = base.AUTOCLASIFICAR(Now.Year, Now.Month, 1, _reporte.ID)
            If aclas.Count = 2 Then
                Mensaje.Info("Se procesaron " + aclas(0).Rows.Count.ToString + " nuevas clasificaciones")
                cargar_clasificacion()
            Else
                Mensaje.Fallo("Se produjo un resultado inesperado al momento de aplicar las clasificaciones")
            End If
        End If

    End Sub

    Private Sub btn_add_Click(sender As System.Object, e As System.EventArgs) Handles btn_add.Click
        Dim nuevo As New mant_clasificacion_detalle(_reporte.ID)
        Dim resulta As DialogResult
        resulta = nuevo.ShowDialog
        If resulta = DialogResult.OK Then
            cargar_reglas()
        End If
        nuevo = Nothing
    End Sub

    Private Sub btn_mod_Click(sender As System.Object, e As System.EventArgs) Handles btn_mod.Click
        If dgReglas.SelectedRows.Count > 0 Then
            Dim sel_regla As regla_clasif_row
            Dim fila As DataGridViewRow = dgReglas.SelectedRows(0)
            sel_regla = base.REGLAS_CLASIFICACION(_reporte.ID).FIND_by_ID(fila.Cells(3).Value)
            If IsNothing(sel_regla) Then
                Mensaje.Fallo("Regla indicada no es valida")
                Exit Sub
            End If
            Dim nuevo As New mant_clasificacion_detalle(sel_regla)
            Dim resulta As DialogResult
            resulta = nuevo.ShowDialog
            If resulta = DialogResult.OK Then
                cargar_reglas()
            End If
            nuevo = Nothing
        Else
            Mensaje.Alerta("No ha seleccionado ninguna regla para modificar")
            dgReglas.Focus()
        End If
    End Sub

    Private Sub btn_off_Click(sender As System.Object, e As System.EventArgs) Handles btn_off.Click
        If dgReglas.SelectedRows.Count > 0 Then
            Dim consulta As DialogResult
            Dim sel_row As regla_clasif_row
            Dim indice_regla As Integer
            For Each fila As DataGridViewRow In dgReglas.SelectedRows
                indice_regla = fila.Cells(3).Value
            Next
            sel_row = base.REGLA_CLASIFICACION(indice_regla)
            If IsNothing(sel_row) Then
                Mensaje.Fallo("Se produjo un error al obtener la información de la regla de clasificacion")
                Exit Sub
            End If

            consulta = Mensaje.Confirma("¿Está seguro que desea eliminar la regla " + sel_row.toString + "?")
            If consulta = DialogResult.Yes Then
                Dim ejecuta As dt_query_result.myRow
                ejecuta = base.DROP_REGLA_CLASIFICACION(sel_row.ID)
                If IsNothing(ejecuta) Then
                    Mensaje.Fallo("Se produjo un error al eliminar la regla de clasificacion")
                Else
                    If ejecuta.COD_ESTADO = 1 Then
                        Mensaje.Info("Se eliminó correctamente la regla de clasificacion")
                        cargar_reglas()
                    Else
                        Mensaje.Fallo(ejecuta.TXT_ESTADO)
                    End If
                End If
            End If
        Else
            Mensaje.Alerta("No ha seleccionado ninguna regla para eliminar")
            dgReglas.Focus()
        End If
    End Sub

    Private Sub dgReglas_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgReglas.CellDoubleClick
        If e.RowIndex = -1 And e.ColumnIndex = 1 Then
            Dim filt_validacion As String = Mensaje.Digite("Ingrese la validacion")
            If Not String.IsNullOrEmpty(filt_validacion) Then
                For Each fila As DataGridViewRow In dgReglas.Rows
                    If fila.Cells(1).Value = filt_validacion Then
                        fila.Visible = True
                    Else
                        fila.Visible = False
                    End If
                Next
            Else
                'quito filtro
                For Each fila As DataGridViewRow In dgReglas.Rows
                    fila.Visible = True
                Next
            End If
        End If
    End Sub
End Class
