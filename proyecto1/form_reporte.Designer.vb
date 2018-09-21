<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_reporte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form_reporte))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbVista = New System.Windows.Forms.ComboBox()
        Me.cbPeriodo = New System.Windows.Forms.ComboBox()
        Me.Pcantidad = New System.Windows.Forms.Panel()
        Me.op2 = New System.Windows.Forms.RadioButton()
        Me.op1 = New System.Windows.Forms.RadioButton()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbPresentacion = New System.Windows.Forms.ComboBox()
        Me.hiloSegundoPlano = New System.ComponentModel.BackgroundWorker()
        Me.cbAcum = New System.Windows.Forms.ComboBox()
        Me.Pcantidad.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Vista"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Periodo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 208)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Cantidad"
        '
        'cbVista
        '
        Me.cbVista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVista.FormattingEnabled = True
        Me.cbVista.Location = New System.Drawing.Point(178, 30)
        Me.cbVista.Name = "cbVista"
        Me.cbVista.Size = New System.Drawing.Size(258, 21)
        Me.cbVista.TabIndex = 7
        '
        'cbPeriodo
        '
        Me.cbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriodo.FormattingEnabled = True
        Me.cbPeriodo.Location = New System.Drawing.Point(178, 69)
        Me.cbPeriodo.Name = "cbPeriodo"
        Me.cbPeriodo.Size = New System.Drawing.Size(258, 21)
        Me.cbPeriodo.TabIndex = 9
        '
        'Pcantidad
        '
        Me.Pcantidad.Controls.Add(Me.op2)
        Me.Pcantidad.Controls.Add(Me.op1)
        Me.Pcantidad.Location = New System.Drawing.Point(178, 208)
        Me.Pcantidad.Name = "Pcantidad"
        Me.Pcantidad.Size = New System.Drawing.Size(184, 30)
        Me.Pcantidad.TabIndex = 11
        '
        'op2
        '
        Me.op2.AutoSize = True
        Me.op2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.op2.Location = New System.Drawing.Point(108, 3)
        Me.op2.Name = "op2"
        Me.op2.Size = New System.Drawing.Size(55, 19)
        Me.op2.TabIndex = 1
        Me.op2.TabStop = True
        Me.op2.Tag = "1000"
        Me.op2.Text = "Miles"
        Me.op2.UseVisualStyleBackColor = True
        '
        'op1
        '
        Me.op1.AutoSize = True
        Me.op1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.op1.Location = New System.Drawing.Point(3, 3)
        Me.op1.Name = "op1"
        Me.op1.Size = New System.Drawing.Size(65, 19)
        Me.op1.TabIndex = 0
        Me.op1.TabStop = True
        Me.op1.Tag = "1"
        Me.op1.Text = "Unidad"
        Me.op1.UseVisualStyleBackColor = True
        '
        'btnGenerar
        '
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Location = New System.Drawing.Point(165, 268)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Padding = New System.Windows.Forms.Padding(20, 2, 20, 2)
        Me.btnGenerar.Size = New System.Drawing.Size(100, 43)
        Me.btnGenerar.TabIndex = 12
        Me.btnGenerar.Text = "Generar Reporte"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 16)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Presentación"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(24, 158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Acumulado"
        '
        'cbPresentacion
        '
        Me.cbPresentacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPresentacion.FormattingEnabled = True
        Me.cbPresentacion.Location = New System.Drawing.Point(178, 109)
        Me.cbPresentacion.Name = "cbPresentacion"
        Me.cbPresentacion.Size = New System.Drawing.Size(258, 21)
        Me.cbPresentacion.TabIndex = 15
        '
        'hiloSegundoPlano
        '
        Me.hiloSegundoPlano.WorkerReportsProgress = True
        '
        'cbAcum
        '
        Me.cbAcum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAcum.FormattingEnabled = True
        Me.cbAcum.Location = New System.Drawing.Point(178, 155)
        Me.cbAcum.Name = "cbAcum"
        Me.cbAcum.Size = New System.Drawing.Size(258, 21)
        Me.cbAcum.TabIndex = 17
        '
        'form_reporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 339)
        Me.Controls.Add(Me.cbAcum)
        Me.Controls.Add(Me.cbPresentacion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.Pcantidad)
        Me.Controls.Add(Me.cbPeriodo)
        Me.Controls.Add(Me.cbVista)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "form_reporte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "form_reporte"
        Me.Pcantidad.ResumeLayout(False)
        Me.Pcantidad.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbVista As System.Windows.Forms.ComboBox
    Friend WithEvents cbPeriodo As System.Windows.Forms.ComboBox
    Friend WithEvents Pcantidad As System.Windows.Forms.Panel
    Friend WithEvents op2 As System.Windows.Forms.RadioButton
    Friend WithEvents op1 As System.Windows.Forms.RadioButton
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbPresentacion As System.Windows.Forms.ComboBox
    Friend WithEvents hiloSegundoPlano As System.ComponentModel.BackgroundWorker
    Friend WithEvents cbAcum As System.Windows.Forms.ComboBox
End Class
