<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mant_servidores
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
        Me.btn_find_serv = New System.Windows.Forms.Button()
        Me.ListServer = New System.Windows.Forms.ListBox()
        Me.btn_sel_serv = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TBServerSet = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TBServerImp = New System.Windows.Forms.TextBox()
        Me.btn_manual = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn_find_serv
        '
        Me.btn_find_serv.Location = New System.Drawing.Point(64, 245)
        Me.btn_find_serv.Name = "btn_find_serv"
        Me.btn_find_serv.Size = New System.Drawing.Size(111, 41)
        Me.btn_find_serv.TabIndex = 5
        Me.btn_find_serv.Text = "Button1"
        Me.btn_find_serv.UseVisualStyleBackColor = True
        '
        'ListServer
        '
        Me.ListServer.FormattingEnabled = True
        Me.ListServer.Location = New System.Drawing.Point(21, 12)
        Me.ListServer.Name = "ListServer"
        Me.ListServer.Size = New System.Drawing.Size(351, 134)
        Me.ListServer.TabIndex = 0
        '
        'btn_sel_serv
        '
        Me.btn_sel_serv.Location = New System.Drawing.Point(219, 245)
        Me.btn_sel_serv.Name = "btn_sel_serv"
        Me.btn_sel_serv.Size = New System.Drawing.Size(107, 41)
        Me.btn_sel_serv.TabIndex = 6
        Me.btn_sel_serv.Text = "Button2"
        Me.btn_sel_serv.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 171)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Servidor Actual"
        '
        'TBServerSet
        '
        Me.TBServerSet.Location = New System.Drawing.Point(143, 167)
        Me.TBServerSet.Name = "TBServerSet"
        Me.TBServerSet.Size = New System.Drawing.Size(155, 20)
        Me.TBServerSet.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 199)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Servidor Elegido"
        '
        'TBServerImp
        '
        Me.TBServerImp.Location = New System.Drawing.Point(143, 199)
        Me.TBServerImp.Name = "TBServerImp"
        Me.TBServerImp.Size = New System.Drawing.Size(155, 20)
        Me.TBServerImp.TabIndex = 4
        '
        'btn_manual
        '
        Me.btn_manual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_manual.Location = New System.Drawing.Point(304, 199)
        Me.btn_manual.Name = "btn_manual"
        Me.btn_manual.Size = New System.Drawing.Size(57, 23)
        Me.btn_manual.TabIndex = 7
        Me.btn_manual.Text = "Button3"
        Me.btn_manual.UseVisualStyleBackColor = True
        '
        'mant_servidores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 312)
        Me.Controls.Add(Me.btn_manual)
        Me.Controls.Add(Me.TBServerImp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TBServerSet)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_sel_serv)
        Me.Controls.Add(Me.ListServer)
        Me.Controls.Add(Me.btn_find_serv)
        Me.Name = "mant_servidores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenedor de Servidor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_find_serv As System.Windows.Forms.Button
    Friend WithEvents ListServer As System.Windows.Forms.ListBox
    Friend WithEvents btn_sel_serv As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TBServerSet As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TBServerImp As System.Windows.Forms.TextBox
    Friend WithEvents btn_manual As System.Windows.Forms.Button
End Class
