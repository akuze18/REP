<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form_configurar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form_configurar))
        Me.TVopciones = New System.Windows.Forms.TreeView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pmostrar = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'TVopciones
        '
        Me.TVopciones.Location = New System.Drawing.Point(12, 29)
        Me.TVopciones.Name = "TVopciones"
        Me.TVopciones.Size = New System.Drawing.Size(188, 370)
        Me.TVopciones.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Configuraciones"
        '
        'Pmostrar
        '
        Me.Pmostrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pmostrar.Location = New System.Drawing.Point(217, 10)
        Me.Pmostrar.Name = "Pmostrar"
        Me.Pmostrar.Size = New System.Drawing.Size(679, 389)
        Me.Pmostrar.TabIndex = 2
        '
        'form_configurar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(908, 413)
        Me.Controls.Add(Me.Pmostrar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TVopciones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "form_configurar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración de los Reportes Financieros"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TVopciones As System.Windows.Forms.TreeView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Pmostrar As System.Windows.Forms.Panel
End Class
