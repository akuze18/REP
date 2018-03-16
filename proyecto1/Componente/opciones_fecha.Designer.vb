<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class opciones_fecha
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
        Me.op1 = New System.Windows.Forms.RadioButton()
        Me.op2 = New System.Windows.Forms.RadioButton()
        Me.op3 = New System.Windows.Forms.RadioButton()
        Me.dtpOP3 = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'op1
        '
        Me.op1.AutoSize = True
        Me.op1.Location = New System.Drawing.Point(6, 19)
        Me.op1.Name = "op1"
        Me.op1.Size = New System.Drawing.Size(63, 17)
        Me.op1.TabIndex = 0
        Me.op1.TabStop = True
        Me.op1.Text = "Siempre"
        Me.op1.UseVisualStyleBackColor = True
        '
        'op2
        '
        Me.op2.AutoSize = True
        Me.op2.Location = New System.Drawing.Point(6, 43)
        Me.op2.Name = "op2"
        Me.op2.Size = New System.Drawing.Size(44, 17)
        Me.op2.TabIndex = 1
        Me.op2.TabStop = True
        Me.op2.Text = "Hoy"
        Me.op2.UseVisualStyleBackColor = True
        '
        'op3
        '
        Me.op3.AutoSize = True
        Me.op3.Location = New System.Drawing.Point(6, 67)
        Me.op3.Name = "op3"
        Me.op3.Size = New System.Drawing.Size(77, 17)
        Me.op3.TabIndex = 2
        Me.op3.TabStop = True
        Me.op3.Text = "Especificar"
        Me.op3.UseVisualStyleBackColor = True
        '
        'dtpOP3
        '
        Me.dtpOP3.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpOP3.Location = New System.Drawing.Point(89, 64)
        Me.dtpOP3.Name = "dtpOP3"
        Me.dtpOP3.Size = New System.Drawing.Size(95, 20)
        Me.dtpOP3.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.op1)
        Me.GroupBox1.Controls.Add(Me.dtpOP3)
        Me.GroupBox1.Controls.Add(Me.op2)
        Me.GroupBox1.Controls.Add(Me.op3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(196, 95)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'opciones_fecha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "opciones_fecha"
        Me.Size = New System.Drawing.Size(196, 95)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dtpOP3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents op3 As System.Windows.Forms.RadioButton
    Friend WithEvents op2 As System.Windows.Forms.RadioButton
    Friend WithEvents op1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

End Class
