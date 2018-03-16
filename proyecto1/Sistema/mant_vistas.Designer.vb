<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mant_vistas
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
        Me.tb_nombre = New System.Windows.Forms.TextBox()
        Me.tb_corto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbColumnas = New System.Windows.Forms.ListBox()
        Me.dgReglas = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_column_up = New System.Windows.Forms.Button()
        Me.btn_column_down = New System.Windows.Forms.Button()
        Me.btn_guarda = New System.Windows.Forms.PictureBox()
        Me.btn_column_off = New System.Windows.Forms.PictureBox()
        Me.btn_column_edit = New System.Windows.Forms.PictureBox()
        Me.btn_column_add = New System.Windows.Forms.PictureBox()
        Me.btb_regla_off = New System.Windows.Forms.PictureBox()
        Me.btn_regla_edit = New System.Windows.Forms.PictureBox()
        Me.btn_regla_add = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pPresent = New System.Windows.Forms.Panel()
        CType(Me.dgReglas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_guarda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_column_off, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_column_edit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_column_add, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btb_regla_off, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_regla_edit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_regla_add, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre de Vista"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre Corto"
        '
        'tb_nombre
        '
        Me.tb_nombre.Location = New System.Drawing.Point(156, 7)
        Me.tb_nombre.MaxLength = 70
        Me.tb_nombre.Name = "tb_nombre"
        Me.tb_nombre.Size = New System.Drawing.Size(208, 20)
        Me.tb_nombre.TabIndex = 2
        '
        'tb_corto
        '
        Me.tb_corto.Location = New System.Drawing.Point(156, 35)
        Me.tb_corto.MaxLength = 10
        Me.tb_corto.Name = "tb_corto"
        Me.tb_corto.Size = New System.Drawing.Size(141, 20)
        Me.tb_corto.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Columnas Definidas"
        '
        'lbColumnas
        '
        Me.lbColumnas.FormattingEnabled = True
        Me.lbColumnas.Location = New System.Drawing.Point(24, 138)
        Me.lbColumnas.Name = "lbColumnas"
        Me.lbColumnas.Size = New System.Drawing.Size(156, 225)
        Me.lbColumnas.TabIndex = 5
        '
        'dgReglas
        '
        Me.dgReglas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgReglas.Location = New System.Drawing.Point(237, 138)
        Me.dgReglas.Name = "dgReglas"
        Me.dgReglas.Size = New System.Drawing.Size(422, 225)
        Me.dgReglas.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(261, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Reglas de la Columna"
        '
        'btn_column_up
        '
        Me.btn_column_up.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_column_up.Location = New System.Drawing.Point(186, 224)
        Me.btn_column_up.Name = "btn_column_up"
        Me.btn_column_up.Size = New System.Drawing.Size(26, 26)
        Me.btn_column_up.TabIndex = 14
        Me.btn_column_up.Text = "↑"
        Me.btn_column_up.UseVisualStyleBackColor = True
        '
        'btn_column_down
        '
        Me.btn_column_down.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_column_down.Location = New System.Drawing.Point(186, 256)
        Me.btn_column_down.Name = "btn_column_down"
        Me.btn_column_down.Size = New System.Drawing.Size(26, 27)
        Me.btn_column_down.TabIndex = 15
        Me.btn_column_down.Text = "↓"
        Me.btn_column_down.UseVisualStyleBackColor = True
        '
        'btn_guarda
        '
        Me.btn_guarda.BackColor = System.Drawing.SystemColors.Control
        Me.btn_guarda.Image = Global.Aplicacion.My.Resources.Resources.save
        Me.btn_guarda.Location = New System.Drawing.Point(384, 7)
        Me.btn_guarda.Name = "btn_guarda"
        Me.btn_guarda.Padding = New System.Windows.Forms.Padding(5)
        Me.btn_guarda.Size = New System.Drawing.Size(50, 50)
        Me.btn_guarda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn_guarda.TabIndex = 16
        Me.btn_guarda.TabStop = False
        '
        'btn_column_off
        '
        Me.btn_column_off.Image = Global.Aplicacion.My.Resources.Resources.remove
        Me.btn_column_off.Location = New System.Drawing.Point(130, 369)
        Me.btn_column_off.Name = "btn_column_off"
        Me.btn_column_off.Size = New System.Drawing.Size(34, 34)
        Me.btn_column_off.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn_column_off.TabIndex = 13
        Me.btn_column_off.TabStop = False
        '
        'btn_column_edit
        '
        Me.btn_column_edit.Image = Global.Aplicacion.My.Resources.Resources.editar
        Me.btn_column_edit.Location = New System.Drawing.Point(81, 370)
        Me.btn_column_edit.Name = "btn_column_edit"
        Me.btn_column_edit.Size = New System.Drawing.Size(34, 34)
        Me.btn_column_edit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn_column_edit.TabIndex = 12
        Me.btn_column_edit.TabStop = False
        '
        'btn_column_add
        '
        Me.btn_column_add.Image = Global.Aplicacion.My.Resources.Resources.increase
        Me.btn_column_add.Location = New System.Drawing.Point(36, 370)
        Me.btn_column_add.Name = "btn_column_add"
        Me.btn_column_add.Size = New System.Drawing.Size(34, 34)
        Me.btn_column_add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn_column_add.TabIndex = 11
        Me.btn_column_add.TabStop = False
        '
        'btb_regla_off
        '
        Me.btb_regla_off.Image = Global.Aplicacion.My.Resources.Resources.remove
        Me.btb_regla_off.Location = New System.Drawing.Point(513, 369)
        Me.btb_regla_off.Name = "btb_regla_off"
        Me.btb_regla_off.Size = New System.Drawing.Size(34, 34)
        Me.btb_regla_off.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btb_regla_off.TabIndex = 10
        Me.btb_regla_off.TabStop = False
        '
        'btn_regla_edit
        '
        Me.btn_regla_edit.Image = Global.Aplicacion.My.Resources.Resources.editar
        Me.btn_regla_edit.Location = New System.Drawing.Point(464, 370)
        Me.btn_regla_edit.Name = "btn_regla_edit"
        Me.btn_regla_edit.Size = New System.Drawing.Size(34, 34)
        Me.btn_regla_edit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn_regla_edit.TabIndex = 9
        Me.btn_regla_edit.TabStop = False
        '
        'btn_regla_add
        '
        Me.btn_regla_add.Image = Global.Aplicacion.My.Resources.Resources.increase
        Me.btn_regla_add.Location = New System.Drawing.Point(419, 370)
        Me.btn_regla_add.Name = "btn_regla_add"
        Me.btn_regla_add.Size = New System.Drawing.Size(34, 34)
        Me.btn_regla_add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn_regla_add.TabIndex = 8
        Me.btn_regla_add.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 15)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Presentaciones"
        '
        'pPresent
        '
        Me.pPresent.Location = New System.Drawing.Point(156, 63)
        Me.pPresent.Name = "pPresent"
        Me.pPresent.Size = New System.Drawing.Size(500, 38)
        Me.pPresent.TabIndex = 18
        '
        'mant_vistas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pPresent)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btn_guarda)
        Me.Controls.Add(Me.btn_column_down)
        Me.Controls.Add(Me.btn_column_up)
        Me.Controls.Add(Me.btn_column_off)
        Me.Controls.Add(Me.btn_column_edit)
        Me.Controls.Add(Me.btn_column_add)
        Me.Controls.Add(Me.btb_regla_off)
        Me.Controls.Add(Me.btn_regla_edit)
        Me.Controls.Add(Me.btn_regla_add)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dgReglas)
        Me.Controls.Add(Me.lbColumnas)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tb_corto)
        Me.Controls.Add(Me.tb_nombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "mant_vistas"
        Me.Size = New System.Drawing.Size(680, 418)
        CType(Me.dgReglas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_guarda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_column_off, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_column_edit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_column_add, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btb_regla_off, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_regla_edit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_regla_add, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tb_nombre As System.Windows.Forms.TextBox
    Friend WithEvents tb_corto As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbColumnas As System.Windows.Forms.ListBox
    Friend WithEvents dgReglas As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_regla_add As System.Windows.Forms.PictureBox
    Friend WithEvents btn_regla_edit As System.Windows.Forms.PictureBox
    Friend WithEvents btb_regla_off As System.Windows.Forms.PictureBox
    Friend WithEvents btn_column_off As System.Windows.Forms.PictureBox
    Friend WithEvents btn_column_edit As System.Windows.Forms.PictureBox
    Friend WithEvents btn_column_add As System.Windows.Forms.PictureBox
    Friend WithEvents btn_column_up As System.Windows.Forms.Button
    Friend WithEvents btn_column_down As System.Windows.Forms.Button
    Friend WithEvents btn_guarda As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pPresent As System.Windows.Forms.Panel

End Class
