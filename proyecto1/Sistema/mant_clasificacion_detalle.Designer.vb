<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mant_clasificacion_detalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mant_clasificacion_detalle))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbTipo = New System.Windows.Forms.ComboBox()
        Me.tbValid1 = New System.Windows.Forms.TextBox()
        Me.tbValid2 = New System.Windows.Forms.TextBox()
        Me.cbFila = New System.Windows.Forms.ComboBox()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.btn_off = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo de Regla"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Regla de Validacion"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Fila a la que clasifica"
        '
        'cbTipo
        '
        Me.cbTipo.FormattingEnabled = True
        Me.cbTipo.Location = New System.Drawing.Point(134, 23)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Size = New System.Drawing.Size(233, 21)
        Me.cbTipo.TabIndex = 3
        '
        'tbValid1
        '
        Me.tbValid1.Location = New System.Drawing.Point(134, 59)
        Me.tbValid1.Name = "tbValid1"
        Me.tbValid1.Size = New System.Drawing.Size(150, 21)
        Me.tbValid1.TabIndex = 4
        '
        'tbValid2
        '
        Me.tbValid2.Location = New System.Drawing.Point(314, 59)
        Me.tbValid2.Name = "tbValid2"
        Me.tbValid2.Size = New System.Drawing.Size(150, 21)
        Me.tbValid2.TabIndex = 5
        '
        'cbFila
        '
        Me.cbFila.FormattingEnabled = True
        Me.cbFila.Location = New System.Drawing.Point(134, 99)
        Me.cbFila.Name = "cbFila"
        Me.cbFila.Size = New System.Drawing.Size(233, 21)
        Me.cbFila.TabIndex = 6
        '
        'btn_guardar
        '
        Me.btn_guardar.Location = New System.Drawing.Point(134, 153)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(75, 23)
        Me.btn_guardar.TabIndex = 7
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'btn_off
        '
        Me.btn_off.Location = New System.Drawing.Point(245, 152)
        Me.btn_off.Name = "btn_off"
        Me.btn_off.Size = New System.Drawing.Size(75, 23)
        Me.btn_off.TabIndex = 8
        Me.btn_off.Text = "Cancelar"
        Me.btn_off.UseVisualStyleBackColor = True
        '
        'mant_clasificacion_detalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 200)
        Me.Controls.Add(Me.btn_off)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.cbFila)
        Me.Controls.Add(Me.tbValid2)
        Me.Controls.Add(Me.tbValid1)
        Me.Controls.Add(Me.cbTipo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "mant_clasificacion_detalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "de Reglas de Clasificación"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents tbValid1 As System.Windows.Forms.TextBox
    Friend WithEvents tbValid2 As System.Windows.Forms.TextBox
    Friend WithEvents cbFila As System.Windows.Forms.ComboBox
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_off As System.Windows.Forms.Button
End Class
