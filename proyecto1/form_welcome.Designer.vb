<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_welcome
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form_welcome))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Panel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Pdistant = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSConfig = New System.Windows.Forms.ToolStripDropDownButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ConfiguracionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CompañiaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ServidorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Panel1, Me.Panel2, Me.Pdistant, Me.Panel3, Me.Panel4, Me.TSConfig})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 285)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(403, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Panel1
        '
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(47, 17)
        Me.Panel1.Text = "Usuario"
        '
        'Panel2
        '
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(38, 17)
        Me.Panel2.Text = "Fecha"
        '
        'Pdistant
        '
        Me.Pdistant.AutoSize = False
        Me.Pdistant.Name = "Pdistant"
        Me.Pdistant.Size = New System.Drawing.Size(168, 17)
        Me.Pdistant.Spring = True
        '
        'Panel3
        '
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(50, 17)
        Me.Panel3.Text = "Servidor"
        '
        'Panel4
        '
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(56, 17)
        Me.Panel4.Text = "BaseDato"
        '
        'TSConfig
        '
        Me.TSConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSConfig.Image = Global.Aplicacion.My.Resources.Resources.process_32x32_32
        Me.TSConfig.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSConfig.Name = "TSConfig"
        Me.TSConfig.Size = New System.Drawing.Size(29, 20)
        Me.TSConfig.Text = "ToolStripDropDownButton1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfiguracionesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(403, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ConfiguracionesToolStripMenuItem
        '
        Me.ConfiguracionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReportesToolStripMenuItem, Me.ToolStripSeparator1, Me.CompañiaToolStripMenuItem, Me.ServidorToolStripMenuItem})
        Me.ConfiguracionesToolStripMenuItem.Name = "ConfiguracionesToolStripMenuItem"
        Me.ConfiguracionesToolStripMenuItem.Size = New System.Drawing.Size(106, 20)
        Me.ConfiguracionesToolStripMenuItem.Text = "Configuraciones"
        '
        'ReportesToolStripMenuItem
        '
        Me.ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        Me.ReportesToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ReportesToolStripMenuItem.Text = "Reportes"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'CompañiaToolStripMenuItem
        '
        Me.CompañiaToolStripMenuItem.Enabled = False
        Me.CompañiaToolStripMenuItem.Name = "CompañiaToolStripMenuItem"
        Me.CompañiaToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CompañiaToolStripMenuItem.Text = "Compañia"
        '
        'ServidorToolStripMenuItem
        '
        Me.ServidorToolStripMenuItem.Name = "ServidorToolStripMenuItem"
        Me.ServidorToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ServidorToolStripMenuItem.Text = "Servidor"
        '
        'form_welcome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 307)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximumSize = New System.Drawing.Size(419, 345)
        Me.Name = "form_welcome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reportes de Estado Financiero"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Panel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Panel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Pdistant As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Panel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Panel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSConfig As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ConfiguracionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CompañiaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ServidorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
