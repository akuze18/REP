Imports ACode

Public Class form_welcome

#Region "Variables de clase"
    ''' <summary>
    ''' inicializo clase con configuraciones de INI y Base de Datos
    ''' </summary>
    ''' <remarks></remarks>
    Private base As base_REP
#End Region

#Region "Constructor"
    Public Sub New()
        InitializeComponent()
        base = New base_REP
    End Sub
#End Region

#Region "Formulario"
    Private Sub form_welcome_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub
    Private Sub form_welcome_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If base.estado Then
            cargar_panel()
            cargar_configuracion()
            Dim datos As dt_tipo_reporte = base.TIPO_REPORTE
            For Each registro As dt_tipo_reporte.myRow In datos.Rows
                Dim btn_tipo As New Button
                btn_tipo.Text = registro.DESCRIP
                btn_tipo.Tag = registro.ID
                btn_tipo.Size = New Size(230, 44)
                AddHandler btn_tipo.Click, AddressOf mostrar_tipo_reporte
                'Cuento cuantos botones existen en el formulario para determinar su posicion
                Dim contar As Integer
                contar = 0
                For Each elemento In Me.Controls.OfType(Of Button)()
                    contar = contar + 1
                Next
                Me.Controls.Add(btn_tipo)
                btn_tipo.Location = New Point(85, 40 + (btn_tipo.Size.Height + 10) * (contar))
            Next

        Else
            MessageBox.Show(base.estado_desc, "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End If
    End Sub
#End Region

#Region "Controles"
    Private Sub cargar_panel()
        Panel1.Text = general.ObtenerUsuarioActual
        Panel2.Text = Now.ToString("dd MMMM yyyy")
        Panel3.Text = base.servidor
        Panel4.Text = base.base_dato
    End Sub

    Private Sub mostrar_tipo_reporte(sender As System.Object, e As System.EventArgs)
        If TypeOf sender Is Button Then
            Dim accion As Button
            accion = CType(sender, Button)
            Dim formulario As New form_reporte(accion.Tag, Me)
            formulario.Show()
        End If
    End Sub

#End Region

#Region "Configuracion de Conexion"
    ''' <summary>
    ''' Funcion que obtiene la configuracion del archivo INI y la muestra en una ventana para modificar
    ''' </summary>
    ''' <remarks>Levanta ventana de configuración del INI, solo para Administradores</remarks>
    Private Sub cargar_configuracion()
        Dim user As String = general.ObtenerUsuarioActual
        If user = "aquispe" Or user = "rgallardo" Then
            TSConfig.DropDownItems.Clear()
            AddHandler TSConfig.Click, AddressOf mostrar_conf
        Else
            TSConfig.Visible = False
        End If
    End Sub
    Private Sub mostrar_conf(sender As System.Object, e As System.EventArgs)
        Dim controlador As ControlIni
        controlador = New ControlIni()

        If controlador.ShowDialog = Windows.Forms.DialogResult.OK Then
            cargar_panel()
        End If
    End Sub
    ''' <summary>
    ''' Rutina para configurar a que servidor Conectarse, pensado para todo usuario
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OpenServidorConf(sender As System.Object, e As System.EventArgs) Handles ServidorToolStripMenuItem.Click
        Dim resultado As DialogResult
        Dim vista As Form
        vista = New mant_servidores
        Me.Hide()
        resultado = vista.ShowDialog
        If resultado = Windows.Forms.DialogResult.OK Then
            MessageBox.Show("Se cambio el servidor")
            cargar_panel()
        End If
        vista.Dispose()
        Me.Show()
    End Sub
#End Region

#Region "Configuraciones de Reportes"
    Private Sub OpenReporteConf(sender As System.Object, e As System.EventArgs) Handles ReportesToolStripMenuItem.Click
        form_configurar.Show()
        Me.Hide()
    End Sub
#End Region

End Class
