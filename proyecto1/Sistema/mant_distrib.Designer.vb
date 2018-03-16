<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mant_distrib
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tb_nombre = New System.Windows.Forms.TextBox()
        Me.tb_sigla = New System.Windows.Forms.TextBox()
        Me.lb_filas = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbPeriodoEntrada = New System.Windows.Forms.ComboBox()
        Me.lbTotalEntrada = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lb_salida_sector = New System.Windows.Forms.ListBox()
        Me.bt_add_sector_salida = New System.Windows.Forms.Button()
        Me.bt_off_sector_salida = New System.Windows.Forms.Button()
        Me.btn_off_sector_entrada = New System.Windows.Forms.PictureBox()
        Me.btn_edt_sector_entrada = New System.Windows.Forms.PictureBox()
        Me.btn_add_sector_entrada = New System.Windows.Forms.PictureBox()
        Me.tv_entrada_sector = New System.Windows.Forms.TreeView()
        Me.Button3 = New System.Windows.Forms.Button()
        CType(Me.btn_off_sector_entrada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_edt_sector_entrada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_add_sector_entrada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre de Distribución"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Sigla de Distribución"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Sobre las lineas"
        '
        'tb_nombre
        '
        Me.tb_nombre.Location = New System.Drawing.Point(158, 12)
        Me.tb_nombre.Name = "tb_nombre"
        Me.tb_nombre.Size = New System.Drawing.Size(244, 20)
        Me.tb_nombre.TabIndex = 3
        '
        'tb_sigla
        '
        Me.tb_sigla.Location = New System.Drawing.Point(158, 38)
        Me.tb_sigla.Name = "tb_sigla"
        Me.tb_sigla.Size = New System.Drawing.Size(244, 20)
        Me.tb_sigla.TabIndex = 4
        '
        'lb_filas
        '
        Me.lb_filas.FormattingEnabled = True
        Me.lb_filas.Location = New System.Drawing.Point(17, 111)
        Me.lb_filas.Name = "lb_filas"
        Me.lb_filas.Size = New System.Drawing.Size(171, 160)
        Me.lb_filas.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(24, 284)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Agregar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(105, 284)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(61, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Quitar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(302, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Valores de Porcentajes"
        '
        'cbPeriodoEntrada
        '
        Me.cbPeriodoEntrada.FormattingEnabled = True
        Me.cbPeriodoEntrada.Location = New System.Drawing.Point(270, 159)
        Me.cbPeriodoEntrada.Name = "cbPeriodoEntrada"
        Me.cbPeriodoEntrada.Size = New System.Drawing.Size(275, 21)
        Me.cbPeriodoEntrada.TabIndex = 9
        '
        'lbTotalEntrada
        '
        Me.lbTotalEntrada.Location = New System.Drawing.Point(541, 429)
        Me.lbTotalEntrada.Name = "lbTotalEntrada"
        Me.lbTotalEntrada.Size = New System.Drawing.Size(137, 12)
        Me.lbTotalEntrada.TabIndex = 12
        Me.lbTotalEntrada.Text = "SUMA"
        Me.lbTotalEntrada.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(462, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Sectores Origen"
        '
        'lb_salida_sector
        '
        Me.lb_salida_sector.FormattingEnabled = True
        Me.lb_salida_sector.Location = New System.Drawing.Point(450, 30)
        Me.lb_salida_sector.Name = "lb_salida_sector"
        Me.lb_salida_sector.Size = New System.Drawing.Size(254, 56)
        Me.lb_salida_sector.TabIndex = 14
        '
        'bt_add_sector_salida
        '
        Me.bt_add_sector_salida.Location = New System.Drawing.Point(479, 92)
        Me.bt_add_sector_salida.Name = "bt_add_sector_salida"
        Me.bt_add_sector_salida.Size = New System.Drawing.Size(75, 23)
        Me.bt_add_sector_salida.TabIndex = 15
        Me.bt_add_sector_salida.Text = "Agregar"
        Me.bt_add_sector_salida.UseVisualStyleBackColor = True
        '
        'bt_off_sector_salida
        '
        Me.bt_off_sector_salida.Location = New System.Drawing.Point(583, 92)
        Me.bt_off_sector_salida.Name = "bt_off_sector_salida"
        Me.bt_off_sector_salida.Size = New System.Drawing.Size(75, 23)
        Me.bt_off_sector_salida.TabIndex = 16
        Me.bt_off_sector_salida.Text = "Quitar"
        Me.bt_off_sector_salida.UseVisualStyleBackColor = True
        '
        'btn_off_sector_entrada
        '
        Me.btn_off_sector_entrada.Image = Global.Aplicacion.My.Resources.Resources.remove
        Me.btn_off_sector_entrada.Location = New System.Drawing.Point(648, 155)
        Me.btn_off_sector_entrada.Name = "btn_off_sector_entrada"
        Me.btn_off_sector_entrada.Size = New System.Drawing.Size(30, 27)
        Me.btn_off_sector_entrada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn_off_sector_entrada.TabIndex = 19
        Me.btn_off_sector_entrada.TabStop = False
        '
        'btn_edt_sector_entrada
        '
        Me.btn_edt_sector_entrada.Image = Global.Aplicacion.My.Resources.Resources.editar
        Me.btn_edt_sector_entrada.Location = New System.Drawing.Point(604, 155)
        Me.btn_edt_sector_entrada.Name = "btn_edt_sector_entrada"
        Me.btn_edt_sector_entrada.Size = New System.Drawing.Size(30, 27)
        Me.btn_edt_sector_entrada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn_edt_sector_entrada.TabIndex = 18
        Me.btn_edt_sector_entrada.TabStop = False
        '
        'btn_add_sector_entrada
        '
        Me.btn_add_sector_entrada.Image = Global.Aplicacion.My.Resources.Resources.increase
        Me.btn_add_sector_entrada.Location = New System.Drawing.Point(560, 155)
        Me.btn_add_sector_entrada.Name = "btn_add_sector_entrada"
        Me.btn_add_sector_entrada.Size = New System.Drawing.Size(31, 27)
        Me.btn_add_sector_entrada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn_add_sector_entrada.TabIndex = 17
        Me.btn_add_sector_entrada.TabStop = False
        '
        'tv_entrada_sector
        '
        Me.tv_entrada_sector.Location = New System.Drawing.Point(270, 188)
        Me.tv_entrada_sector.Name = "tv_entrada_sector"
        Me.tv_entrada_sector.Size = New System.Drawing.Size(408, 231)
        Me.tv_entrada_sector.TabIndex = 20
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(270, 427)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(30, 23)
        Me.Button3.TabIndex = 21
        Me.Button3.Text = "+"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'mant_distrib
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.tv_entrada_sector)
        Me.Controls.Add(Me.btn_off_sector_entrada)
        Me.Controls.Add(Me.btn_edt_sector_entrada)
        Me.Controls.Add(Me.btn_add_sector_entrada)
        Me.Controls.Add(Me.bt_off_sector_salida)
        Me.Controls.Add(Me.bt_add_sector_salida)
        Me.Controls.Add(Me.lb_salida_sector)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lbTotalEntrada)
        Me.Controls.Add(Me.cbPeriodoEntrada)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lb_filas)
        Me.Controls.Add(Me.tb_sigla)
        Me.Controls.Add(Me.tb_nombre)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "mant_distrib"
        Me.Size = New System.Drawing.Size(730, 471)
        CType(Me.btn_off_sector_entrada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_edt_sector_entrada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_add_sector_entrada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_nombre As System.Windows.Forms.TextBox
    Friend WithEvents tb_sigla As System.Windows.Forms.TextBox
    Friend WithEvents lb_filas As System.Windows.Forms.ListBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbPeriodoEntrada As System.Windows.Forms.ComboBox
    Friend WithEvents lbTotalEntrada As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lb_salida_sector As System.Windows.Forms.ListBox
    Friend WithEvents bt_add_sector_salida As System.Windows.Forms.Button
    Friend WithEvents bt_off_sector_salida As System.Windows.Forms.Button
    Friend WithEvents btn_add_sector_entrada As System.Windows.Forms.PictureBox
    Friend WithEvents btn_edt_sector_entrada As System.Windows.Forms.PictureBox
    Friend WithEvents btn_off_sector_entrada As System.Windows.Forms.PictureBox
    Friend WithEvents tv_entrada_sector As System.Windows.Forms.TreeView
    Friend WithEvents Button3 As System.Windows.Forms.Button

End Class
