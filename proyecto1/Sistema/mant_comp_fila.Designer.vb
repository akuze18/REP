<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mant_comp_fila
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mant_comp_fila))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbFilaOrigen = New System.Windows.Forms.TextBox()
        Me.cbComp = New System.Windows.Forms.ComboBox()
        Me.btn_ok = New System.Windows.Forms.Button()
        Me.btn_cancel = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Ohasta = New Aplicacion.opciones_fecha()
        Me.Odesde = New Aplicacion.opciones_fecha()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fila Origen"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Composicion"
        '
        'tbFilaOrigen
        '
        Me.tbFilaOrigen.Location = New System.Drawing.Point(118, 9)
        Me.tbFilaOrigen.Name = "tbFilaOrigen"
        Me.tbFilaOrigen.Size = New System.Drawing.Size(281, 20)
        Me.tbFilaOrigen.TabIndex = 2
        '
        'cbComp
        '
        Me.cbComp.FormattingEnabled = True
        Me.cbComp.Location = New System.Drawing.Point(118, 42)
        Me.cbComp.Name = "cbComp"
        Me.cbComp.Size = New System.Drawing.Size(281, 21)
        Me.cbComp.TabIndex = 3
        '
        'btn_ok
        '
        Me.btn_ok.Location = New System.Drawing.Point(108, 215)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(88, 25)
        Me.btn_ok.TabIndex = 4
        Me.btn_ok.Text = "Guardar"
        Me.btn_ok.UseVisualStyleBackColor = True
        '
        'btn_cancel
        '
        Me.btn_cancel.Location = New System.Drawing.Point(225, 215)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(75, 25)
        Me.btn_cancel.TabIndex = 5
        Me.btn_cancel.Text = "Cancelar"
        Me.btn_cancel.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(178, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Valido"
        '
        'Ohasta
        '
        Me.Ohasta.Location = New System.Drawing.Point(214, 103)
        Me.Ohasta.Name = "Ohasta"
        Me.Ohasta.opcion_tipo = Aplicacion.opciones_fecha.Ftipo.hasta
        Me.Ohasta.Size = New System.Drawing.Size(196, 95)
        Me.Ohasta.TabIndex = 8
        '
        'Odesde
        '
        Me.Odesde.Location = New System.Drawing.Point(12, 103)
        Me.Odesde.Name = "Odesde"
        Me.Odesde.opcion_tipo = Aplicacion.opciones_fecha.Ftipo.desde
        Me.Odesde.Size = New System.Drawing.Size(196, 95)
        Me.Odesde.TabIndex = 7
        '
        'mant_comp_fila
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(427, 261)
        Me.Controls.Add(Me.Ohasta)
        Me.Controls.Add(Me.Odesde)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.btn_ok)
        Me.Controls.Add(Me.cbComp)
        Me.Controls.Add(Me.tbFilaOrigen)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "mant_comp_fila"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenedor Detalle de Fila"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbFilaOrigen As System.Windows.Forms.TextBox
    Friend WithEvents cbComp As System.Windows.Forms.ComboBox
    Friend WithEvents btn_ok As System.Windows.Forms.Button
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Odesde As Aplicacion.opciones_fecha
    Friend WithEvents Ohasta As Aplicacion.opciones_fecha
End Class
