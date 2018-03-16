<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class inputbox_avz
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.t_usuario = New System.Windows.Forms.TextBox()
        Me.t_contrasena = New System.Windows.Forms.TextBox()
        Me.b_cancelar = New System.Windows.Forms.Button()
        Me.b_aceptar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "usuario"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "contraseña"
        '
        't_usuario
        '
        Me.t_usuario.Location = New System.Drawing.Point(120, 25)
        Me.t_usuario.Name = "t_usuario"
        Me.t_usuario.Size = New System.Drawing.Size(152, 20)
        Me.t_usuario.TabIndex = 2
        '
        't_contrasena
        '
        Me.t_contrasena.Location = New System.Drawing.Point(120, 52)
        Me.t_contrasena.Name = "t_contrasena"
        Me.t_contrasena.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.t_contrasena.Size = New System.Drawing.Size(152, 20)
        Me.t_contrasena.TabIndex = 3
        '
        'b_cancelar
        '
        Me.b_cancelar.Location = New System.Drawing.Point(62, 97)
        Me.b_cancelar.Name = "b_cancelar"
        Me.b_cancelar.Size = New System.Drawing.Size(75, 23)
        Me.b_cancelar.TabIndex = 4
        Me.b_cancelar.Text = "cancelar"
        Me.b_cancelar.UseVisualStyleBackColor = True
        '
        'b_aceptar
        '
        Me.b_aceptar.Location = New System.Drawing.Point(182, 97)
        Me.b_aceptar.Name = "b_aceptar"
        Me.b_aceptar.Size = New System.Drawing.Size(75, 23)
        Me.b_aceptar.TabIndex = 5
        Me.b_aceptar.Text = "aceptar"
        Me.b_aceptar.UseVisualStyleBackColor = True
        '
        'inputbox_avz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(324, 132)
        Me.Controls.Add(Me.b_aceptar)
        Me.Controls.Add(Me.b_cancelar)
        Me.Controls.Add(Me.t_contrasena)
        Me.Controls.Add(Me.t_usuario)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "inputbox_avz"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "inputbox_avz"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents t_usuario As System.Windows.Forms.TextBox
    Friend WithEvents t_contrasena As System.Windows.Forms.TextBox
    Friend WithEvents b_cancelar As System.Windows.Forms.Button
    Friend WithEvents b_aceptar As System.Windows.Forms.Button
End Class
