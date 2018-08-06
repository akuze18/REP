<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mant_clasificacion
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
        Me.dgReglas = New System.Windows.Forms.DataGridView()
        Me.btn_add = New System.Windows.Forms.PictureBox()
        Me.btn_mod = New System.Windows.Forms.PictureBox()
        Me.btn_off = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgClasifica = New System.Windows.Forms.DataGridView()
        Me.btn_autoclasificar = New System.Windows.Forms.Button()
        Me.dtFechaAplica = New System.Windows.Forms.DateTimePicker()
        CType(Me.dgReglas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_add, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_mod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_off, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgClasifica, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Reglas de Clasificacion de Cuentas"
        '
        'dgReglas
        '
        Me.dgReglas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgReglas.Location = New System.Drawing.Point(13, 43)
        Me.dgReglas.Name = "dgReglas"
        Me.dgReglas.Size = New System.Drawing.Size(545, 268)
        Me.dgReglas.TabIndex = 1
        '
        'btn_add
        '
        Me.btn_add.Image = Global.Aplicacion.My.Resources.Resources.increase
        Me.btn_add.Location = New System.Drawing.Point(373, 8)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(34, 33)
        Me.btn_add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn_add.TabIndex = 2
        Me.btn_add.TabStop = False
        '
        'btn_mod
        '
        Me.btn_mod.Image = Global.Aplicacion.My.Resources.Resources.editar
        Me.btn_mod.Location = New System.Drawing.Point(442, 8)
        Me.btn_mod.Name = "btn_mod"
        Me.btn_mod.Size = New System.Drawing.Size(34, 33)
        Me.btn_mod.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn_mod.TabIndex = 3
        Me.btn_mod.TabStop = False
        '
        'btn_off
        '
        Me.btn_off.Image = Global.Aplicacion.My.Resources.Resources.remove
        Me.btn_off.Location = New System.Drawing.Point(506, 8)
        Me.btn_off.Name = "btn_off"
        Me.btn_off.Size = New System.Drawing.Size(34, 33)
        Me.btn_off.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn_off.TabIndex = 4
        Me.btn_off.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 337)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Clasificaciones"
        '
        'dgClasifica
        '
        Me.dgClasifica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgClasifica.Location = New System.Drawing.Point(13, 362)
        Me.dgClasifica.Name = "dgClasifica"
        Me.dgClasifica.Size = New System.Drawing.Size(545, 203)
        Me.dgClasifica.TabIndex = 6
        '
        'btn_autoclasificar
        '
        Me.btn_autoclasificar.Location = New System.Drawing.Point(586, 288)
        Me.btn_autoclasificar.Name = "btn_autoclasificar"
        Me.btn_autoclasificar.Size = New System.Drawing.Size(75, 23)
        Me.btn_autoclasificar.TabIndex = 7
        Me.btn_autoclasificar.Text = "Aplicar"
        Me.btn_autoclasificar.UseVisualStyleBackColor = True
        '
        'dtFechaAplica
        '
        Me.dtFechaAplica.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFechaAplica.Location = New System.Drawing.Point(575, 262)
        Me.dtFechaAplica.Name = "dtFechaAplica"
        Me.dtFechaAplica.Size = New System.Drawing.Size(124, 20)
        Me.dtFechaAplica.TabIndex = 8
        '
        'mant_clasificacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dtFechaAplica)
        Me.Controls.Add(Me.btn_autoclasificar)
        Me.Controls.Add(Me.dgClasifica)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn_off)
        Me.Controls.Add(Me.btn_mod)
        Me.Controls.Add(Me.btn_add)
        Me.Controls.Add(Me.dgReglas)
        Me.Controls.Add(Me.Label1)
        Me.Name = "mant_clasificacion"
        Me.Size = New System.Drawing.Size(710, 588)
        CType(Me.dgReglas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_add, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_mod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_off, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgClasifica, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgReglas As System.Windows.Forms.DataGridView
    Friend WithEvents btn_add As System.Windows.Forms.PictureBox
    Friend WithEvents btn_mod As System.Windows.Forms.PictureBox
    Friend WithEvents btn_off As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgClasifica As System.Windows.Forms.DataGridView
    Friend WithEvents btn_autoclasificar As System.Windows.Forms.Button
    Friend WithEvents dtFechaAplica As System.Windows.Forms.DateTimePicker

End Class
