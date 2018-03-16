<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mant_regla_columna
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mant_regla_columna))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbColumna = New System.Windows.Forms.TextBox()
        Me.cbAplicar = New System.Windows.Forms.ComboBox()
        Me.cbTipo = New System.Windows.Forms.ComboBox()
        Me.tbValor = New System.Windows.Forms.TextBox()
        Me.cbValor1 = New System.Windows.Forms.ComboBox()
        Me.cbValor2 = New System.Windows.Forms.ComboBox()
        Me.btn_ok = New System.Windows.Forms.Button()
        Me.btn_off = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Para la Columna"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Tipo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Aplica Sobre"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Valor"
        '
        'tbColumna
        '
        Me.tbColumna.Location = New System.Drawing.Point(123, 13)
        Me.tbColumna.Name = "tbColumna"
        Me.tbColumna.Size = New System.Drawing.Size(187, 20)
        Me.tbColumna.TabIndex = 1
        '
        'cbAplicar
        '
        Me.cbAplicar.FormattingEnabled = True
        Me.cbAplicar.Location = New System.Drawing.Point(123, 55)
        Me.cbAplicar.Name = "cbAplicar"
        Me.cbAplicar.Size = New System.Drawing.Size(187, 21)
        Me.cbAplicar.TabIndex = 3
        '
        'cbTipo
        '
        Me.cbTipo.FormattingEnabled = True
        Me.cbTipo.Location = New System.Drawing.Point(123, 85)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Size = New System.Drawing.Size(187, 21)
        Me.cbTipo.TabIndex = 5
        '
        'tbValor
        '
        Me.tbValor.Location = New System.Drawing.Point(123, 119)
        Me.tbValor.MaxLength = 30
        Me.tbValor.Name = "tbValor"
        Me.tbValor.Size = New System.Drawing.Size(187, 20)
        Me.tbValor.TabIndex = 7
        '
        'cbValor1
        '
        Me.cbValor1.FormattingEnabled = True
        Me.cbValor1.Location = New System.Drawing.Point(123, 119)
        Me.cbValor1.Name = "cbValor1"
        Me.cbValor1.Size = New System.Drawing.Size(187, 21)
        Me.cbValor1.TabIndex = 8
        '
        'cbValor2
        '
        Me.cbValor2.FormattingEnabled = True
        Me.cbValor2.Location = New System.Drawing.Point(125, 156)
        Me.cbValor2.Name = "cbValor2"
        Me.cbValor2.Size = New System.Drawing.Size(187, 21)
        Me.cbValor2.TabIndex = 9
        '
        'btn_ok
        '
        Me.btn_ok.Location = New System.Drawing.Point(81, 212)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(75, 23)
        Me.btn_ok.TabIndex = 10
        Me.btn_ok.Text = "Guardar"
        Me.btn_ok.UseVisualStyleBackColor = True
        '
        'btn_off
        '
        Me.btn_off.Location = New System.Drawing.Point(192, 212)
        Me.btn_off.Name = "btn_off"
        Me.btn_off.Size = New System.Drawing.Size(75, 23)
        Me.btn_off.TabIndex = 11
        Me.btn_off.Text = "Cancelar"
        Me.btn_off.UseVisualStyleBackColor = True
        '
        'mant_regla_columna
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(362, 262)
        Me.Controls.Add(Me.btn_off)
        Me.Controls.Add(Me.btn_ok)
        Me.Controls.Add(Me.cbValor2)
        Me.Controls.Add(Me.cbValor1)
        Me.Controls.Add(Me.tbValor)
        Me.Controls.Add(Me.cbTipo)
        Me.Controls.Add(Me.cbAplicar)
        Me.Controls.Add(Me.tbColumna)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "mant_regla_columna"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Mantenedor de Reglas de Columna"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbColumna As System.Windows.Forms.TextBox
    Friend WithEvents cbAplicar As System.Windows.Forms.ComboBox
    Friend WithEvents cbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents tbValor As System.Windows.Forms.TextBox
    Friend WithEvents cbValor1 As System.Windows.Forms.ComboBox
    Friend WithEvents cbValor2 As System.Windows.Forms.ComboBox
    Friend WithEvents btn_ok As System.Windows.Forms.Button
    Friend WithEvents btn_off As System.Windows.Forms.Button
End Class
