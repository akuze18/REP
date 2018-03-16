'------------------------------------------------------------------------------
' Prueba de acceso a ficheros INIs                                  (17/Feb/99)
'
' Usando funciones que devuelven arrays de tipo String.
'
' Revisado para Visual Basic .NET                                   (19/Ene/04)
'
' ©Guillermo 'guille' Som, 1999-2004
'------------------------------------------------------------------------------
Option Strict On
Option Explicit On 
Imports ACode
Public Class frmProfileIni
    Inherits System.Windows.Forms.Form
    '
    Private inicializando As Boolean = True
    '
    '
    Public Sub New()
        MyBase.New()
        '
        Application.EnableVisualStyles()
        '
        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
    End Sub
    '
#Region "Código generado por el Diseñador de Windows Forms "
    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer
    Public WithEvents cmdExaminar As System.Windows.Forms.Button
    Public WithEvents cmdSalir As System.Windows.Forms.Button
    Public WithEvents cboClaves As System.Windows.Forms.ComboBox
    Public WithEvents cboSecciones As System.Windows.Forms.ComboBox
    Public WithEvents cmdLeer As System.Windows.Forms.Button
    Public WithEvents cmdAdd As System.Windows.Forms.Button
    Public WithEvents txtValor As System.Windows.Forms.TextBox
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents txtFicIni As System.Windows.Forms.TextBox
    'NOTA: el siguiente procedimiento es necesario para el Diseñador de Windows Forms
    'Se puede modificar mediante el Diseñador de Windows Forms.
    'No lo modifique con el editor de código.
    Public WithEvents cmdBorrarClave As System.Windows.Forms.Button
    Public WithEvents cmdBorrarSeccion As System.Windows.Forms.Button
    Public WithEvents Label1_3 As System.Windows.Forms.Label
    Public WithEvents Label1_2 As System.Windows.Forms.Label
    Public WithEvents Label1_1 As System.Windows.Forms.Label
    Public WithEvents Label1_0 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdExaminar = New System.Windows.Forms.Button
        Me.cmdSalir = New System.Windows.Forms.Button
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.cboClaves = New System.Windows.Forms.ComboBox
        Me.cboSecciones = New System.Windows.Forms.ComboBox
        Me.cmdLeer = New System.Windows.Forms.Button
        Me.cmdBorrarClave = New System.Windows.Forms.Button
        Me.cmdBorrarSeccion = New System.Windows.Forms.Button
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.txtValor = New System.Windows.Forms.TextBox
        Me.Label1_3 = New System.Windows.Forms.Label
        Me.Label1_2 = New System.Windows.Forms.Label
        Me.Label1_1 = New System.Windows.Forms.Label
        Me.txtFicIni = New System.Windows.Forms.TextBox
        Me.Label1_0 = New System.Windows.Forms.Label
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdExaminar
        '
        Me.cmdExaminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExaminar.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExaminar.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdExaminar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExaminar.Location = New System.Drawing.Point(381, 14)
        Me.cmdExaminar.Name = "cmdExaminar"
        Me.cmdExaminar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExaminar.Size = New System.Drawing.Size(87, 25)
        Me.cmdExaminar.TabIndex = 2
        Me.cmdExaminar.Text = "Examinar..."
        '
        'cmdSalir
        '
        Me.cmdSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSalir.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSalir.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSalir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSalir.Location = New System.Drawing.Point(376, 204)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSalir.Size = New System.Drawing.Size(87, 25)
        Me.cmdSalir.TabIndex = 4
        Me.cmdSalir.Text = "Salir"
        '
        'Frame1
        '
        Me.Frame1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Frame1.Controls.Add(Me.cboClaves)
        Me.Frame1.Controls.Add(Me.cboSecciones)
        Me.Frame1.Controls.Add(Me.cmdLeer)
        Me.Frame1.Controls.Add(Me.cmdBorrarClave)
        Me.Frame1.Controls.Add(Me.cmdBorrarSeccion)
        Me.Frame1.Controls.Add(Me.cmdAdd)
        Me.Frame1.Controls.Add(Me.txtValor)
        Me.Frame1.Controls.Add(Me.Label1_3)
        Me.Frame1.Controls.Add(Me.Label1_2)
        Me.Frame1.Controls.Add(Me.Label1_1)
        Me.Frame1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(18, 50)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(334, 182)
        Me.Frame1.TabIndex = 3
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Secciones y claves:"
        '
        'cboClaves
        '
        Me.cboClaves.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboClaves.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboClaves.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboClaves.Location = New System.Drawing.Point(102, 52)
        Me.cboClaves.Name = "cboClaves"
        Me.cboClaves.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboClaves.Size = New System.Drawing.Size(218, 21)
        Me.cboClaves.TabIndex = 3
        Me.cboClaves.Text = "Combo1"
        '
        'cboSecciones
        '
        Me.cboSecciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSecciones.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboSecciones.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboSecciones.Location = New System.Drawing.Point(102, 24)
        Me.cboSecciones.Name = "cboSecciones"
        Me.cboSecciones.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboSecciones.Size = New System.Drawing.Size(218, 21)
        Me.cboSecciones.TabIndex = 1
        Me.cboSecciones.Text = "cboSecciones"
        '
        'cmdLeer
        '
        Me.cmdLeer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdLeer.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdLeer.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdLeer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLeer.Location = New System.Drawing.Point(232, 144)
        Me.cmdLeer.Name = "cmdLeer"
        Me.cmdLeer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLeer.Size = New System.Drawing.Size(87, 25)
        Me.cmdLeer.TabIndex = 9
        Me.cmdLeer.Text = "Leer"
        '
        'cmdBorrarClave
        '
        Me.cmdBorrarClave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdBorrarClave.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBorrarClave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdBorrarClave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBorrarClave.Location = New System.Drawing.Point(100, 144)
        Me.cmdBorrarClave.Name = "cmdBorrarClave"
        Me.cmdBorrarClave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBorrarClave.Size = New System.Drawing.Size(87, 25)
        Me.cmdBorrarClave.TabIndex = 7
        Me.cmdBorrarClave.Text = "Borrar Clave"
        '
        'cmdBorrarSeccion
        '
        Me.cmdBorrarSeccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdBorrarSeccion.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBorrarSeccion.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdBorrarSeccion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBorrarSeccion.Location = New System.Drawing.Point(100, 112)
        Me.cmdBorrarSeccion.Name = "cmdBorrarSeccion"
        Me.cmdBorrarSeccion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBorrarSeccion.Size = New System.Drawing.Size(87, 25)
        Me.cmdBorrarSeccion.TabIndex = 6
        Me.cmdBorrarSeccion.Text = "Borrar Sección"
        '
        'cmdAdd
        '
        Me.cmdAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAdd.Location = New System.Drawing.Point(232, 112)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAdd.Size = New System.Drawing.Size(87, 25)
        Me.cmdAdd.TabIndex = 8
        Me.cmdAdd.Text = "Añadir"
        '
        'txtValor
        '
        Me.txtValor.AcceptsReturn = True
        Me.txtValor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtValor.AutoSize = False
        Me.txtValor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtValor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtValor.Location = New System.Drawing.Point(102, 80)
        Me.txtValor.MaxLength = 0
        Me.txtValor.Name = "txtValor"
        Me.txtValor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtValor.Size = New System.Drawing.Size(218, 21)
        Me.txtValor.TabIndex = 5
        Me.txtValor.Text = "Valor1"
        '
        'Label1_3
        '
        Me.Label1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1_3.Location = New System.Drawing.Point(14, 82)
        Me.Label1_3.Name = "Label1_3"
        Me.Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1_3.Size = New System.Drawing.Size(83, 17)
        Me.Label1_3.TabIndex = 4
        Me.Label1_3.Text = "Valor:"
        '
        'Label1_2
        '
        Me.Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1_2.Location = New System.Drawing.Point(16, 54)
        Me.Label1_2.Name = "Label1_2"
        Me.Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1_2.Size = New System.Drawing.Size(83, 17)
        Me.Label1_2.TabIndex = 2
        Me.Label1_2.Text = "Claves:"
        '
        'Label1_1
        '
        Me.Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1_1.Location = New System.Drawing.Point(16, 26)
        Me.Label1_1.Name = "Label1_1"
        Me.Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1_1.Size = New System.Drawing.Size(83, 17)
        Me.Label1_1.TabIndex = 0
        Me.Label1_1.Text = "Secciones:"
        '
        'txtFicIni
        '
        Me.txtFicIni.AcceptsReturn = True
        Me.txtFicIni.AllowDrop = True
        Me.txtFicIni.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFicIni.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFicIni.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFicIni.Location = New System.Drawing.Point(72, 16)
        Me.txtFicIni.MaxLength = 0
        Me.txtFicIni.Name = "txtFicIni"
        Me.txtFicIni.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFicIni.Size = New System.Drawing.Size(304, 20)
        Me.txtFicIni.TabIndex = 1
        Me.txtFicIni.Text = "Prueba.ini"
        '
        'Label1_0
        '
        Me.Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1_0.Location = New System.Drawing.Point(18, 18)
        Me.Label1_0.Name = "Label1_0"
        Me.Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1_0.Size = New System.Drawing.Size(51, 17)
        Me.Label1_0.TabIndex = 0
        Me.Label1_0.Text = "Fichero:"
        '
        'frmProfileIni
        '
        Me.AllowDrop = True
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdSalir
        Me.ClientSize = New System.Drawing.Size(480, 243)
        Me.Controls.Add(Me.cmdExaminar)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.txtFicIni)
        Me.Controls.Add(Me.Label1_0)
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1024, 300)
        Me.MinimumSize = New System.Drawing.Size(470, 270)
        Me.Name = "frmProfileIni"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prueba de Ficheros INIs en .NET"
        Me.Frame1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region
    '
    '
    Private mINI As New cIniArray
    '
    '------------------------------------------------------------------------------
    ' Procedimientos de eventos del formulario
    '------------------------------------------------------------------------------
    Private Sub cboSecciones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSecciones.SelectedIndexChanged, cboSecciones.TextChanged
        ' Mostrar las claves de esta sección
        If inicializando Then Exit Sub
        '
        Dim tContenidos() As String
        '
        tContenidos = mINI.IniGetSection(txtFicIni.Text, cboSecciones.Text)
        If tContenidos.Length > 0 And Not (IsNothing(tContenidos(0))) Then
            cboClaves.Items.Clear()
            Dim i As Integer
            For i = 0 To tContenidos.Length - 1 Step 2
                cboClaves.Items.Add(tContenidos(i))
            Next
            txtValor.Text = ""
            cboClaves.SelectedIndex = 0
        End If
    End Sub
    '
    Private Sub cboClaves_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClaves.SelectedIndexChanged, cboClaves.TextChanged
        If inicializando Then Exit Sub
        '
        cmdLeer_Click(cmdLeer, EventArgs.Empty)
    End Sub
    '
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        ' Añadir la sección, clave y/o valor
        '
        Dim sFicINI As String = txtFicIni.Text.Trim
        Dim sSeccion As String = cboSecciones.Text.Trim
        Dim sClave As String = cboClaves.Text.Trim
        Dim sValor As String = txtValor.Text.Trim
        '
        mINI.IniWrite(sFicINI, sSeccion, sClave, sValor)
    End Sub
    '
    Private Sub cmdBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBorrarClave.Click, cmdBorrarSeccion.Click
        ' Borrar sección o clave
        Dim sFicINI As String
        Dim sSeccion As String
        Dim sClave As String
        '
        sFicINI = txtFicIni.Text.Trim
        sSeccion = cboSecciones.Text.Trim
        sClave = cboClaves.Text.Trim
        '
        If CType(sender, Button).Name = "cmdBorrarSeccion" Then
            ' Borrar sección
            mINI.IniDeleteSection(sFicINI, sSeccion)
            ' Releer las secciones disponibles
            leerSecciones()
        Else
            ' Borrar clave
            mINI.IniDeleteKey(sFicINI, sSeccion, sClave)
            ' Leer las claves de esta sección
            cboSecciones_SelectedIndexChanged(cboSecciones, New System.EventArgs)
        End If
    End Sub
    '
    Private Sub cmdExaminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExaminar.Click
        ' Seleccionar el archivo a abrir o guardar
        Dim mCD As New SaveFileDialog
        '
        With mCD
            .Title = "Seleccionar archivos"
            .Filter = "Ficheros INIs (*.ini)|*.ini|Todos los Archivos (*.*)|*.*"
            .FileName = txtFicIni.Text.Trim
            If .ShowDialog = DialogResult.OK Then
                txtFicIni.Text = .FileName
                leerSecciones()
            End If
        End With
    End Sub
    '
    Private Sub cmdLeer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLeer.Click
        ' Leer del fichero INI
        '
        Dim sFicINI As String = txtFicIni.Text.Trim
        Dim sSeccion As String = cboSecciones.Text.Trim
        Dim sClave As String = cboClaves.Text.Trim
        Dim sValor As String = txtValor.Text.Trim
        '
        txtValor.Text = mINI.IniGet(sFicINI, sSeccion, sClave, sValor)
    End Sub
    '
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub
    '
    Private Sub frmProfileIni_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sFicINI As String
        '
        sFicINI = Application.StartupPath & "\Prueba.ini"
        txtFicIni.Text = sFicINI
        mINI.IniWrite(sFicINI, "Seccion1", "Clave1", "Valor1")
        mINI.IniWrite(sFicINI, "Seccion1", "Clave2", "Valor2")
        mINI.IniWrite(sFicINI, "Seccion2", "Clave21", "Valor21")
        mINI.IniWrite(sFicINI, "Seccion2", "Clave22", "Valor22")
        mINI.IniWrite(sFicINI, "Seccion2", "Clave23", "Valor23")
        ' Añadir algunas secciones que ya existen
        With cboSecciones
            .Items.Clear()
            .Items.Add("Seccion1")
            .Items.Add("Seccion2")
        End With
        '
        inicializando = False
        '
        cboSecciones.SelectedIndex = 0
    End Sub
    '
    Private Sub leerSecciones()
        Dim tContenidos() As String
        '
        inicializando = True
        '
        ' Llenar las secciones de este fichero
        tContenidos = mINI.IniGetSections(txtFicIni.Text)
        If tContenidos.Length > 0 Then
            cboSecciones.Items.Clear()
            Dim i As Integer
            For i = 0 To tContenidos.Length - 1
                If Not tContenidos(i) Is Nothing Then
                    cboSecciones.Items.Add(tContenidos(i))
                End If
            Next
            txtValor.Text = ""
            cboSecciones.SelectedIndex = 0
        End If
        inicializando = False
    End Sub
    '
    Private Sub txtFicIni_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtFicIni.DragEnter, MyBase.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    '
    Private Sub txtFicIni_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtFicIni.DragDrop, MyBase.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            txtFicIni.Text = CType(e.Data.GetData(DataFormats.FileDrop, True), String())(0)
            leerSecciones()
        End If
    End Sub
End Class