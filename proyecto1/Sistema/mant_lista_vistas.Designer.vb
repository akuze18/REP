<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mant_lista_vistas
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
        Me.Lista_vistas = New System.Windows.Forms.ListBox()
        Me.btn_off = New System.Windows.Forms.PictureBox()
        Me.btn_edit = New System.Windows.Forms.PictureBox()
        Me.btn_add = New System.Windows.Forms.PictureBox()
        CType(Me.btn_off, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_edit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_add, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Vistas Disponibles"
        '
        'Lista_vistas
        '
        Me.Lista_vistas.FormattingEnabled = True
        Me.Lista_vistas.Location = New System.Drawing.Point(13, 40)
        Me.Lista_vistas.Name = "Lista_vistas"
        Me.Lista_vistas.Size = New System.Drawing.Size(322, 173)
        Me.Lista_vistas.TabIndex = 1
        '
        'btn_off
        '
        Me.btn_off.Image = Global.Aplicacion.My.Resources.Resources.remove
        Me.btn_off.Location = New System.Drawing.Point(203, 230)
        Me.btn_off.Name = "btn_off"
        Me.btn_off.Size = New System.Drawing.Size(36, 36)
        Me.btn_off.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn_off.TabIndex = 4
        Me.btn_off.TabStop = False
        '
        'btn_edit
        '
        Me.btn_edit.Image = Global.Aplicacion.My.Resources.Resources.editar
        Me.btn_edit.Location = New System.Drawing.Point(130, 230)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(36, 36)
        Me.btn_edit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn_edit.TabIndex = 3
        Me.btn_edit.TabStop = False
        '
        'btn_add
        '
        Me.btn_add.Image = Global.Aplicacion.My.Resources.Resources.increase
        Me.btn_add.Location = New System.Drawing.Point(58, 230)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(36, 36)
        Me.btn_add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn_add.TabIndex = 2
        Me.btn_add.TabStop = False
        '
        'mant_lista_vistas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btn_off)
        Me.Controls.Add(Me.btn_edit)
        Me.Controls.Add(Me.btn_add)
        Me.Controls.Add(Me.Lista_vistas)
        Me.Controls.Add(Me.Label1)
        Me.Name = "mant_lista_vistas"
        Me.Size = New System.Drawing.Size(377, 319)
        CType(Me.btn_off, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_edit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_add, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Lista_vistas As System.Windows.Forms.ListBox
    Friend WithEvents btn_add As System.Windows.Forms.PictureBox
    Friend WithEvents btn_edit As System.Windows.Forms.PictureBox
    Friend WithEvents btn_off As System.Windows.Forms.PictureBox

End Class
