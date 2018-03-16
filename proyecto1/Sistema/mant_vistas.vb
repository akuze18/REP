Public Class mant_vistas
    ''' <summary>
    ''' inicializo clase con configuraciones de INI y Base de Datos
    ''' </summary>
    ''' <remarks></remarks>
    Private base As New base_REP
    Private _id_reporte As Integer
    Private _vista As dt_vista.myRow

#Region "Constructores"
    Public Sub New(ByVal vista_single As dt_vista.myRow)
        InitializeComponent()
        _vista = vista_single
        _id_reporte = vista_single.REPORTE
    End Sub
    Public Sub New(ByVal id_reporte As Integer)
        InitializeComponent()
        _vista = Nothing
        _id_reporte = id_reporte
    End Sub
#End Region

    Private Sub mant_vistas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'creo opciones para presentaciones
        Dim tPresenta As DataTable
        Dim Xused, Yused As Integer
        Xused = 0
        Yused = 0
        tPresenta = base.VALOR_PRESENTACION
        For Each fPresenta As DataRow In tPresenta.Rows
            Dim nueva_opcion As New CheckBox
            nueva_opcion.Text = fPresenta("DESCRIP")
            nueva_opcion.Name = "Pop" + fPresenta("ID").ToString
            nueva_opcion.Tag = fPresenta("ID").ToString
            nueva_opcion.AutoSize = True
            pPresent.Controls.Add(nueva_opcion)
            If Xused + nueva_opcion.Width >= pPresent.Width Then
                Yused = Yused + 20
                Xused = 0
            End If
            nueva_opcion.Location = New Point(Xused, Yused)
            Xused = Xused + nueva_opcion.Width + 30
            
        Next

        If IsNothing(_vista) Then
            tb_nombre.Text = String.Empty
            tb_corto.Text = String.Empty
            btn_guarda.BackColor = Color.Red
        Else
            tb_nombre.Text = _vista.DESCRIP
            tb_corto.Text = _vista.N_CORTO
            btn_guarda.BackColor = SystemColors.Control
            Dim act_pres As DataTable
            act_pres = base.VALOR_PRESENTACIONxVISTA(_vista.ID)
            For Each sPres As DataRow In act_pres.Rows
                For Each opcion As CheckBox In pPresent.Controls.OfType(Of CheckBox)()
                    If opcion.Tag = sPres("ID") Then
                        opcion.Checked = True
                    End If
                Next
            Next
        End If
        lbColumnas.SelectionMode = SelectionMode.One
        cargar_columnas()
        'crear cabeceras de grilla reglas
        With dgReglas
            Dim col1, col2, col3, col4 As New DataGridViewTextBoxColumn()
            With col1
                .Name = "Aplica sobre"
                .Width = 150
            End With
            With col2
                .Name = "Forma"
                .Width = 100
            End With
            With col3
                .Name = "Validacion"
                .Width = 150
            End With
            With col4
                .Name = "id_regla"
                .Width = 0
                .Visible = False
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
            .EditMode = DataGridViewEditMode.EditProgrammatically
        End With
    End Sub

    Private Sub cargar_columnas()
        lbColumnas.Items.Clear()
        dgReglas.Rows.Clear()
        If Not IsNothing(_vista) Then
            Dim det_col As dt_columnas
            det_col = base.COLUMNAS(_vista.ID)
            If IsNothing(det_col) Then
                Mensaje.Fallo("Error al cargar información de las columnas de la vista")
                Exit Sub
            End If
            For Each col As dt_columnas.myRow In det_col.Rows
                lbColumnas.Items.Add(col)
            Next
        End If
    End Sub
    Private Sub cargar_reglas()
        If Not IsNothing(lbColumnas.SelectedItem) Then
            Dim sCol As dt_columnas.myRow
            Dim allReglas As regla_columna_table
            sCol = lbColumnas.SelectedItem
            allReglas = base.REGLAS_COLUMNA(sCol.ID)
            dgReglas.Rows.Clear()
            For Each iRegla As regla_columna_row In allReglas.Rows
                Dim fila As Integer
                fila = dgReglas.Rows.Count
                dgReglas.Rows.Add()
                dgReglas.Item(0, fila).Value = iRegla.APLICAR_TEXT
                dgReglas.Item(1, fila).Value = iRegla.TIPO_TEXT
                dgReglas.Item(2, fila).Value = iRegla.VALIDACION_TEXT
                dgReglas.Item(3, fila).Value = iRegla.ID
            Next
        End If
    End Sub

#Region "Columnas Definidas"
    Private Sub lbColumnas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lbColumnas.SelectedIndexChanged
        cargar_reglas()
    End Sub

    Private Sub btn_column_add_Click(sender As System.Object, e As System.EventArgs) Handles btn_column_add.Click
        If Not IsNothing(_vista) Then
            Dim nuevo As New mant_columas(_vista.ID)
            Dim resulta As DialogResult
            resulta = nuevo.ShowDialog
            If resulta = DialogResult.OK Then
                cargar_columnas()
            End If
            nuevo = Nothing
        End If

    End Sub

    Private Sub btn_column_edit_Click(sender As System.Object, e As System.EventArgs) Handles btn_column_edit.Click
        If IsNothing(lbColumnas.SelectedItem) Then
            Mensaje.Alerta("No ha seleccionado ningúna columna para modificar")
            Exit Sub
        End If
        Dim sel_col As dt_columnas.myRow
        sel_col = lbColumnas.SelectedItem
        Dim edita As New mant_columas(sel_col)
        Dim resulta As DialogResult
        resulta = edita.ShowDialog
        If resulta = DialogResult.OK Then
            cargar_columnas()
        End If
        edita = Nothing
    End Sub

    Private Sub btn_column_off_Click(sender As System.Object, e As System.EventArgs) Handles btn_column_off.Click
        If IsNothing(lbColumnas.SelectedItem) Then
            Mensaje.Alerta("No ha seleccionado ningúna columna para eliminar")
            Exit Sub
        End If
        Dim consulta As DialogResult
        Dim sel_col As dt_columnas.myRow
        sel_col = lbColumnas.SelectedItem
        consulta = Mensaje.Confirma("¿Está seguro que desea eliminar la columna " + sel_col.DESCRIP + "?")
        If consulta = DialogResult.Yes Then
            Dim ejecuta As dt_query_result.myRow
            ejecuta = base.DROP_COLUMNAS(sel_col.ID)
            If IsNothing(ejecuta) Then
                Mensaje.Fallo("Se produjo un error al eliminar la columna")
            Else
                If ejecuta.COD_ESTADO = 1 Then
                    Mensaje.Info("Se eliminó correctamente la columna")
                    cargar_columnas()
                Else
                    Mensaje.Fallo(ejecuta.TXT_ESTADO)
                End If
            End If
        End If
    End Sub

    Private Sub btn_column_up_Click(sender As System.Object, e As System.EventArgs) Handles btn_column_up.Click
        If Not IsNothing(lbColumnas.SelectedItem) Then
            Dim indx As Integer
            indx = lbColumnas.SelectedIndex
            If indx > 0 Then
                'si es 0 es el primero y ya no puede subir mas
                Dim actual, superior As dt_columnas.myRow
                actual = lbColumnas.SelectedItem
                superior = lbColumnas.Items(indx - 1)
                Dim cambio1, cambio2 As dt_query_result.myRow
                cambio1 = base.MOD_COLUMNAS(actual.ID, actual.COD, actual.DESCRIP, superior.ORDEN, actual.TOTALIZA)
                cambio2 = base.MOD_COLUMNAS(superior.ID, superior.COD, superior.DESCRIP, actual.ORDEN, superior.TOTALIZA)
                If IsNothing(cambio1) Or IsNothing(cambio2) Then
                    Mensaje.Fallo("Se produjo un error al subir la columna")
                Else
                    cargar_columnas()
                    lbColumnas.SelectedIndex = indx - 1
                End If

            End If
        End If
    End Sub
    Private Sub btn_column_down_Click(sender As System.Object, e As System.EventArgs) Handles btn_column_down.Click
        If Not IsNothing(lbColumnas.SelectedItem) Then
            Dim indx, total As Integer
            indx = lbColumnas.SelectedIndex
            total = lbColumnas.Items.Count
            If indx < total - 1 Then
                'si es total -1 es el ultimo y ya no puede bajar mas
                Dim actual, inferior As dt_columnas.myRow
                actual = lbColumnas.SelectedItem
                inferior = lbColumnas.Items(indx + 1)
                Dim cambio1, cambio2 As dt_query_result.myRow
                cambio1 = base.MOD_COLUMNAS(actual.ID, actual.COD, actual.DESCRIP, inferior.ORDEN, actual.TOTALIZA)
                cambio2 = base.MOD_COLUMNAS(inferior.ID, inferior.COD, inferior.DESCRIP, actual.ORDEN, inferior.TOTALIZA)
                If IsNothing(cambio1) Or IsNothing(cambio2) Then
                    Mensaje.Fallo("Se produjo un error al bajar la columna")
                Else
                    cargar_columnas()
                    lbColumnas.SelectedIndex = indx + 1
                End If

            End If
        End If
    End Sub
#End Region

#Region "Reglas Definidas"
    Private Sub btn_regla_add_Click(sender As System.Object, e As System.EventArgs) Handles btn_regla_add.Click
        If Not IsNothing(lbColumnas.SelectedItem) Then
            Dim sel_col As dt_columnas.myRow
            sel_col = lbColumnas.SelectedItem
            Dim nuevo As New mant_regla_columna(sel_col.ID)
            Dim resulta As DialogResult
            resulta = nuevo.ShowDialog
            If resulta = DialogResult.OK Then
                cargar_reglas()
            End If
            nuevo = Nothing
        End If

    End Sub
    Private Sub btn_regla_edit_Click(sender As System.Object, e As System.EventArgs) Handles btn_regla_edit.Click
        If (dgReglas.SelectedRows.Count = 0) Then
            Mensaje.Alerta("No ha seleccionado una regla para modificar")
            dgReglas.Focus()
        Else
            Dim sel_regla As regla_columna_row
            Dim id_col As Integer
            For Each elemento As DataGridViewRow In dgReglas.SelectedRows
                id_col = elemento.Cells(3).Value
            Next
            sel_regla = base.REGLA_COLUMNA(id_col)
            Dim edita As New mant_regla_columna(sel_regla)
            Dim resulta As DialogResult
            resulta = edita.ShowDialog
            If resulta = DialogResult.OK Then
                cargar_reglas()
            End If
            edita = Nothing
        End If
    End Sub
    Private Sub btb_regla_off_Click(sender As System.Object, e As System.EventArgs) Handles btb_regla_off.Click
        If (dgReglas.SelectedRows.Count = 0) Then
            Mensaje.Alerta("No ha seleccionado una regla para eliminar")
            dgReglas.Focus()
            Exit Sub
        End If
        Dim consulta As DialogResult
        Dim sel_row As regla_columna_row
        Dim indice_regla As Integer
        For Each fila As DataGridViewRow In dgReglas.SelectedRows
            indice_regla = fila.Cells(3).Value
        Next
        sel_row = base.REGLA_COLUMNA(indice_regla)
        If IsNothing(sel_row) Then
            Mensaje.Fallo("Se produjo un error al obtener la información de la regla de columna")
            Exit Sub
        End If

        consulta = Mensaje.Confirma("¿Está seguro que desea eliminar la regla " + sel_row.toString + "?")
        If consulta = DialogResult.Yes Then
            Dim ejecuta As dt_query_result.myRow
            ejecuta = base.DROP_REGLA_COL(sel_row.ID)
            If IsNothing(ejecuta) Then
                Mensaje.Fallo("Se produjo un error al eliminar la regla de columna")
            Else
                If ejecuta.COD_ESTADO = 1 Then
                    Mensaje.Info("Se eliminó correctamente la regla de columna")
                    cargar_reglas()
                Else
                    Mensaje.Fallo(ejecuta.TXT_ESTADO)
                End If
            End If
        End If
    End Sub
#End Region

    Private Sub btn_guarda_Click(sender As System.Object, e As System.EventArgs) Handles btn_guarda.Click
        'valido campos
        If String.IsNullOrEmpty(tb_nombre.Text) Then
            Mensaje.Alerta("Debe ingresar el nombre de la vista")
            tb_nombre.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(tb_corto.Text) Then
            Mensaje.Alerta("Debe ingresar el nombre corta para la vista")
            tb_corto.Focus()
            Exit Sub
        End If
        Dim contar As Integer = 0
        For Each opcion As CheckBox In pPresent.Controls.OfType(Of CheckBox)()
            If opcion.Checked Then
                contar = contar + 1
            End If
        Next
        If contar = 0 Then
            Mensaje.Alerta("Debe seleccionar al menos 1 tipo de presentación")
            pPresent.Focus()
            Exit Sub
        End If
        'inicio proceso de vista
        Dim resultado As dt_query_result.myRow
        If IsNothing(_vista) Then
            'vamos a guardar una vista nueva
            resultado = base.NEW_VISTA(_id_reporte, tb_nombre.Text, tb_corto.Text)
            If IsNothing(resultado) Then
                Mensaje.Fallo("Se produjo un error al crear la vista")
                Exit Sub
            Else
                If resultado.COD_ESTADO = 1 Then
                    Mensaje.Info("Se ha creado correctamente la vista")
                    btn_guarda.BackColor = SystemColors.Control
                    _vista = base.VISTA(resultado.ID_NUEVO)
                Else
                    Mensaje.Fallo(resultado.TXT_ESTADO)
                    Exit Sub
                End If
            End If
        Else
            'vamos a guardar una vista existente (modificacion)
            resultado = base.MOD_VISTA(_vista.ID, tb_nombre.Text, tb_corto.Text)
            If IsNothing(resultado) Then
                Mensaje.Fallo("Se produjo un error al modificar la vista")
                Exit Sub
            Else
                If resultado.COD_ESTADO = 1 Then
                    Mensaje.Info("Se ha modificado correctamente la vista")
                    'cargar_columnas()
                Else
                    Mensaje.Fallo(resultado.TXT_ESTADO)
                    Exit Sub
                End If
            End If
        End If
        'inicio proceso de presentaciones por vista
        For Each opcion As CheckBox In pPresent.Controls.OfType(Of CheckBox)()
            If opcion.Checked Then
                'si esta marcada, debo crear la relación en la base
                resultado = base.NEW_VISTAxPRESENT(opcion.Tag, _vista.ID)
            Else
                'si no esta marcada, debo eliminar la relacion en la base
                resultado = base.DROP_VISTAxPRESENT(opcion.Tag, _vista.ID)
            End If
            If IsNothing(resultado) Then
                Mensaje.Fallo("Se produjo un error al guardar la opción " + opcion.Text)
                Exit Sub
            Else
                If resultado.COD_ESTADO < 0 Then
                    Mensaje.Fallo(resultado.TXT_ESTADO)
                    Exit Sub
                End If
            End If
        Next
    End Sub
End Class
