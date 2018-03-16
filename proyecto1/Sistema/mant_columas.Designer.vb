<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mant_columas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mant_columas))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tb_vista = New System.Windows.Forms.TextBox()
        Me.tb_txt_columna = New System.Windows.Forms.TextBox()
        Me.btn_ok = New System.Windows.Forms.Button()
        Me.btn_off = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tb_cod_columna = New System.Windows.Forms.TextBox()
        Me.ckTotal = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Nombre de Columna"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Pertenece a la vista"
        '
        'tb_vista
        '
        Me.tb_vista.Location = New System.Drawing.Point(144, 9)
        Me.tb_vista.Name = "tb_vista"
        Me.tb_vista.Size = New System.Drawing.Size(200, 20)
        Me.tb_vista.TabIndex = 1
        '
        'tb_txt_columna
        '
        Me.tb_txt_columna.Location = New System.Drawing.Point(144, 69)
        Me.tb_txt_columna.MaxLength = 50
        Me.tb_txt_columna.Name = "tb_txt_columna"
        Me.tb_txt_columna.Size = New System.Drawing.Size(200, 20)
        Me.tb_txt_columna.TabIndex = 5
        '
        'btn_ok
        '
        Me.btn_ok.Location = New System.Drawing.Point(85, 150)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(75, 23)
        Me.btn_ok.TabIndex = 7
        Me.btn_ok.Text = "Guardar"
        Me.btn_ok.UseVisualStyleBackColor = True
        '
        'btn_off
        '
        Me.btn_off.Location = New System.Drawing.Point(201, 150)
        Me.btn_off.Name = "btn_off"
        Me.btn_off.Size = New System.Drawing.Size(75, 23)
        Me.btn_off.TabIndex = 8
        Me.btn_off.Text = "Cancelar"
        Me.btn_off.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Codigo de Columna"
        '
        'tb_cod_columna
        '
        Me.tb_cod_columna.Location = New System.Drawing.Point(144, 41)
        Me.tb_cod_columna.MaxLength = 10
        Me.tb_cod_columna.Name = "tb_cod_columna"
        Me.tb_cod_columna.Size = New System.Drawing.Size(100, 20)
        Me.tb_cod_columna.TabIndex = 3
        '
        'ckTotal
        '
        Me.ckTotal.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckTotal.Location = New System.Drawing.Point(15, 94)
        Me.ckTotal.Margin = New System.Windows.Forms.Padding(0)
        Me.ckTotal.Name = "ckTotal"
        Me.ckTotal.Size = New System.Drawing.Size(145, 24)
        Me.ckTotal.TabIndex = 6
        Me.ckTotal.Text = "Totaliza"
        Me.ckTotal.UseVisualStyleBackColor = True
        '
        'mant_columas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(365, 194)
        Me.Controls.Add(Me.ckTotal)
        Me.Controls.Add(Me.tb_cod_columna)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_off)
        Me.Controls.Add(Me.btn_ok)
        Me.Controls.Add(Me.tb_txt_columna)
        Me.Controls.Add(Me.tb_vista)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "mant_columas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenedor de Columnas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tb_vista As System.Windows.Forms.TextBox
    Friend WithEvents tb_txt_columna As System.Windows.Forms.TextBox
    Friend WithEvents btn_ok As System.Windows.Forms.Button
    Friend WithEvents btn_off As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_cod_columna As System.Windows.Forms.TextBox
    Friend WithEvents ckTotal As System.Windows.Forms.CheckBox
End Class
