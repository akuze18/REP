Public Class mant_distrib

#Region "Variables de clase"
    ''' <summary>
    ''' inicializo clase con configuraciones de INI y Base de Datos
    ''' </summary>
    ''' <remarks></remarks>
    Private base As New base_REP
    Private _id As Integer
#End Region

#Region "Constructores"
    Public Sub New(ByVal id_distribucion As Integer)
        InitializeComponent()
        _id = id_distribucion
    End Sub
#End Region

#Region "Mostrar Informacion"
    Private Sub REFRESCAR_DISTRIB()
        Dim distribucion As tipo_distribucion_row
        distribucion = base.TIPO_DISTRIB(_id)
        With tb_nombre
            .Text = distribucion.DESCRIP
            .Enabled = False
        End With
        tb_sigla.Text = distribucion.SIGLA
    End Sub
    Private Sub REFRESCAR_SECTOR_SALIDA()
        Dim salida As sector_table
        salida = base.SECTORES_SALIDA(_id)
        With lb_salida_sector
            .Items.Clear()
            For Each s As sector_row In salida.Rows
                .Items.Add(s)
            Next
        End With
    End Sub
    Private Sub REFRESCAR_FILAS()
        Dim filas As dt_fila_reporte
        filas = base.DETALLE_FILA_DIST(_id)
        With lb_filas
            .Items.Clear()
            For Each f As dt_fila_reporte.myRow In filas.Rows
                .Items.Add(f)
            Next
        End With
    End Sub
    Private Sub REFRESCAR_PERIODO_ENTRADA()
        Dim periodos As periodo_dis_table
        periodos = base.PERIODO_ENTRADA_DIS(_id)
        With cbPeriodoEntrada
            .Items.Clear()
            For Each f As periodo_dis_row In periodos.Rows
                .Items.Add(f)
            Next
        End With
    End Sub
    Private Sub CLEAN_SECTOR_ENTRADA()
        tv_entrada_sector.Nodes.Clear()
        'dg_entrada_sector.Rows.Clear()
        lbTotalEntrada.Text = "0.00 %"
    End Sub
#End Region

#Region "Formulario"
    Private Sub mant_distrib_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        REFRESCAR_DISTRIB()
        REFRESCAR_FILAS()
        REFRESCAR_SECTOR_SALIDA()
        REFRESCAR_PERIODO_ENTRADA()
        CLEAN_SECTOR_ENTRADA()

        'With dg_entrada_sector
        '    .DataSource = base.cabecera_sector_distrib
        '    .AllowUserToAddRows = False
        '    .AllowUserToDeleteRows = False
        '    .AllowUserToResizeRows = False
        '    .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        '    .MultiSelect = False
        '    .EditMode = DataGridViewEditMode.EditProgrammatically
        'End With

    End Sub
#End Region

#Region "Controles"

#Region "Sector de Origen"
    Private Sub bt_add_sector_salida_Click(sender As System.Object, e As System.EventArgs) Handles bt_add_sector_salida.Click
        Dim marker As selector_sector
        Dim resultado As DialogResult
        marker = New selector_sector
        resultado = marker.ShowDialog()
        If resultado = DialogResult.OK Then
            Dim _sector As Integer = marker.marcado
            Dim ingreso As dt_query_result.myRow = base.NEW_SECTOR_SALIDA(_sector, _id)
            If IsNothing(ingreso) Then
                Mensaje.Fallo("Se produjo un error al ingresar sector a la distribucion")
            Else
                If ingreso.COD_ESTADO < 0 Then
                    Mensaje.Fallo(ingreso.TXT_ESTADO)
                Else
                    Mensaje.Info(ingreso.TXT_ESTADO)
                    REFRESCAR_SECTOR_SALIDA()
                End If
            End If
        End If
        marker = Nothing
    End Sub
    Private Sub bt_off_sector_salida_Click(sender As System.Object, e As System.EventArgs) Handles bt_off_sector_salida.Click
        'reviso que haya algo marcado
        If lb_salida_sector.SelectedItems.Count = 0 Then
            Mensaje.Alerta("No se ha seleccionado ningun sector")
            Exit Sub
        End If
        Dim _sector As sector_row
        _sector = lb_salida_sector.SelectedItem
        'confirmo que se eliminará el sector
        Dim pregunta As DialogResult
        pregunta = Mensaje.Confirma("Seguro que desea eliminar el sector " + _sector.DESCRIP + " como salida?")
        If pregunta = DialogResult.Yes Then
            Dim ingreso As dt_query_result.myRow = base.DROP_SECTOR_SALIDA(_sector.ID, _id)
            If IsNothing(ingreso) Then
                Mensaje.Fallo("Se produjo un error al ingresar sector a la distribucion")
            Else
                If ingreso.COD_ESTADO < 0 Then
                    Mensaje.Fallo(ingreso.TXT_ESTADO)
                Else
                    Mensaje.Info(ingreso.TXT_ESTADO)
                    REFRESCAR_SECTOR_SALIDA()
                End If
            End If
        End If
    End Sub
#End Region
#Region "Sobre Lineas"

#End Region
#Region "Sectores de Entradas"
    Private Sub cbPeriodoEntrada_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbPeriodoEntrada.SelectedIndexChanged
        If cbPeriodoEntrada.SelectedIndex = -1 Then
            CLEAN_SECTOR_ENTRADA()
        Else
            Dim entradas As sector_table
            Dim periodo As periodo_dis_row
            Dim depto, lugar As String
            periodo = cbPeriodoEntrada.SelectedItem
            entradas = base.SECTORES_ENTRADA(periodo.ID)
            depto = ""
            lugar = ""
            Dim nodo_actual As New TreeNode
            For Each entrada As sector_row In entradas.Select("Valor<>0")
                If entrada.COD_DEPTO.Trim <> depto Then
                    depto = entrada.COD_DEPTO
                    Dim nodo_depto As New TreeNode
                    nodo_depto.Text = entrada.COD_DEPTO + ":" + entrada.NOMBRE_DEPTO + " = " + (entrada.CALC_TOTAL_DEPTO * 100).ToString("0.00") + "%"
                    nodo_actual = nodo_depto
                    tv_entrada_sector.Nodes.Add(nodo_depto)
                End If
                Dim nodo_lugar As New TreeNode
                Dim suma_lugar As Double
                If entrada.CALC_TOTAL_DEPTO = 0 Then
                    suma_lugar = 0
                Else
                    suma_lugar = entrada.VALOR / entrada.CALC_TOTAL_DEPTO
                End If
                nodo_lugar.Text = entrada.COD_LUGAR + ":" + entrada.NOMBRE_LUGAR + " = " + (suma_lugar * 100).ToString("0.00") + "%"
                nodo_actual.Nodes.Add(nodo_lugar)
            Next

            lbTotalEntrada.Text = ((entradas.TOTAL_VALOR) * 100).ToString + " %"
        End If
    End Sub
    Private Sub tv_entrada_sector_BeforeExpand(sender As Object, e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tv_entrada_sector.BeforeExpand
        'tv_entrada_sector.CollapseAll()
    End Sub
    Private Sub btn_add_periodo_entrada_Click(sender As System.Object, e As System.EventArgs) Handles btn_add_sector_entrada.Click
        Dim ventana As mant_periodo_dis
        Dim mostrar As DialogResult
        ventana = New mant_periodo_dis(_id)
        mostrar = ventana.ShowDialog
        If mostrar = DialogResult.OK Then
            REFRESCAR_PERIODO_ENTRADA()
        End If
    End Sub
    Private Sub btn_edt_sector_entrada_Click(sender As System.Object, e As System.EventArgs) Handles btn_edt_sector_entrada.Click
        If IsNothing(cbPeriodoEntrada.SelectedItem) Then
            Mensaje.Alerta("No se ha seleccionado un periodo para modificar")
            cbPeriodoEntrada.Focus()
            Exit Sub
        End If

        Dim ventana As mant_periodo_dis
        Dim mostrar As DialogResult
        Dim perDis As periodo_dis_row
        perDis = cbPeriodoEntrada.SelectedItem
        ventana = New mant_periodo_dis(perDis)
        mostrar = ventana.ShowDialog
        If mostrar = DialogResult.OK Then
            REFRESCAR_PERIODO_ENTRADA()
        End If
    End Sub
#End Region

#End Region

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        tv_entrada_sector.ExpandAll()
    End Sub
End Class
