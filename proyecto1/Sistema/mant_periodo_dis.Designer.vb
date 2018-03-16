<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mant_periodo_dis
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mant_periodo_dis))
        Me.lbTitle = New System.Windows.Forms.Label()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.btn_cancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgDepto = New System.Windows.Forms.DataGridView()
        Me.dgLugar = New System.Windows.Forms.DataGridView()
        Me.lb_depto_total = New System.Windows.Forms.Label()
        Me.lb_lugar_total = New System.Windows.Forms.Label()
        Me.Ohasta = New Aplicacion.opciones_fecha()
        Me.Odesde = New Aplicacion.opciones_fecha()
        CType(Me.dgDepto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgLugar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbTitle
        '
        Me.lbTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitle.Location = New System.Drawing.Point(3, 3)
        Me.lbTitle.Name = "lbTitle"
        Me.lbTitle.Size = New System.Drawing.Size(600, 23)
        Me.lbTitle.TabIndex = 2
        Me.lbTitle.Text = "Label1"
        Me.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_save
        '
        Me.btn_save.Location = New System.Drawing.Point(199, 407)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(75, 23)
        Me.btn_save.TabIndex = 3
        Me.btn_save.Text = "Guardar"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'btn_cancel
        '
        Me.btn_cancel.Location = New System.Drawing.Point(324, 407)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancel.TabIndex = 4
        Me.btn_cancel.Text = "Cancelar"
        Me.btn_cancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Departamentos"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(321, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Lugares"
        '
        'dgDepto
        '
        Me.dgDepto.AllowUserToAddRows = False
        Me.dgDepto.AllowUserToDeleteRows = False
        Me.dgDepto.AllowUserToResizeRows = False
        Me.dgDepto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDepto.Location = New System.Drawing.Point(12, 146)
        Me.dgDepto.MultiSelect = False
        Me.dgDepto.Name = "dgDepto"
        Me.dgDepto.ReadOnly = True
        Me.dgDepto.RowHeadersVisible = False
        Me.dgDepto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDepto.Size = New System.Drawing.Size(280, 215)
        Me.dgDepto.TabIndex = 7
        '
        'dgLugar
        '
        Me.dgLugar.AllowUserToAddRows = False
        Me.dgLugar.AllowUserToDeleteRows = False
        Me.dgLugar.AllowUserToResizeRows = False
        Me.dgLugar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLugar.Location = New System.Drawing.Point(310, 146)
        Me.dgLugar.MultiSelect = False
        Me.dgLugar.Name = "dgLugar"
        Me.dgLugar.ReadOnly = True
        Me.dgLugar.RowHeadersVisible = False
        Me.dgLugar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgLugar.Size = New System.Drawing.Size(280, 215)
        Me.dgLugar.TabIndex = 8
        '
        'lb_depto_total
        '
        Me.lb_depto_total.AutoSize = True
        Me.lb_depto_total.Location = New System.Drawing.Point(235, 364)
        Me.lb_depto_total.Name = "lb_depto_total"
        Me.lb_depto_total.Size = New System.Drawing.Size(39, 13)
        Me.lb_depto_total.TabIndex = 9
        Me.lb_depto_total.Text = "Label3"
        '
        'lb_lugar_total
        '
        Me.lb_lugar_total.AutoSize = True
        Me.lb_lugar_total.Location = New System.Drawing.Point(527, 364)
        Me.lb_lugar_total.Name = "lb_lugar_total"
        Me.lb_lugar_total.Size = New System.Drawing.Size(39, 13)
        Me.lb_lugar_total.TabIndex = 10
        Me.lb_lugar_total.Text = "Label4"
        '
        'Ohasta
        '
        Me.Ohasta.Location = New System.Drawing.Point(310, 29)
        Me.Ohasta.Name = "Ohasta"
        Me.Ohasta.opcion_tipo = Aplicacion.opciones_fecha.Ftipo.hasta
        Me.Ohasta.Size = New System.Drawing.Size(196, 95)
        Me.Ohasta.TabIndex = 1
        '
        'Odesde
        '
        Me.Odesde.Location = New System.Drawing.Point(96, 29)
        Me.Odesde.Name = "Odesde"
        Me.Odesde.opcion_tipo = Aplicacion.opciones_fecha.Ftipo.desde
        Me.Odesde.Size = New System.Drawing.Size(196, 95)
        Me.Odesde.TabIndex = 0
        '
        'mant_periodo_dis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 442)
        Me.Controls.Add(Me.lb_lugar_total)
        Me.Controls.Add(Me.lb_depto_total)
        Me.Controls.Add(Me.dgLugar)
        Me.Controls.Add(Me.dgDepto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.lbTitle)
        Me.Controls.Add(Me.Ohasta)
        Me.Controls.Add(Me.Odesde)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "mant_periodo_dis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenedor de Periodos de Entrada en Distribución"
        CType(Me.dgDepto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgLugar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Odesde As Aplicacion.opciones_fecha
    Friend WithEvents Ohasta As Aplicacion.opciones_fecha
    Friend WithEvents lbTitle As System.Windows.Forms.Label
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgDepto As System.Windows.Forms.DataGridView
    Friend WithEvents dgLugar As System.Windows.Forms.DataGridView
    Friend WithEvents lb_depto_total As System.Windows.Forms.Label
    Friend WithEvents lb_lugar_total As System.Windows.Forms.Label
End Class
