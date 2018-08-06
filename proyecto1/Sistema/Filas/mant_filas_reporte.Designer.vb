<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mant_filas_reporte
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
        Me.LB1 = New System.Windows.Forms.Label()
        Me.DGfilas = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descipcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Orden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cambiar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Totalizar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Distrib = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.btn_up = New System.Windows.Forms.Button()
        Me.btn_down = New System.Windows.Forms.Button()
        Me.btn_edit = New System.Windows.Forms.Button()
        Me.btn_new = New System.Windows.Forms.Button()
        Me.btn_drop = New System.Windows.Forms.Button()
        CType(Me.DGfilas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LB1
        '
        Me.LB1.AutoSize = True
        Me.LB1.Location = New System.Drawing.Point(10, 10)
        Me.LB1.Name = "LB1"
        Me.LB1.Size = New System.Drawing.Size(131, 13)
        Me.LB1.TabIndex = 0
        Me.LB1.Text = "Filas de [NAME REPORT]"
        '
        'DGfilas
        '
        Me.DGfilas.AllowUserToAddRows = False
        Me.DGfilas.AllowUserToDeleteRows = False
        Me.DGfilas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGfilas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Descipcion, Me.Orden, Me.Cambiar, Me.Totalizar, Me.Distrib})
        Me.DGfilas.Location = New System.Drawing.Point(20, 35)
        Me.DGfilas.Name = "DGfilas"
        Me.DGfilas.ReadOnly = True
        Me.DGfilas.Size = New System.Drawing.Size(577, 200)
        Me.DGfilas.TabIndex = 1
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'Descipcion
        '
        Me.Descipcion.HeaderText = "Descipcion"
        Me.Descipcion.MinimumWidth = 180
        Me.Descipcion.Name = "Descipcion"
        Me.Descipcion.ReadOnly = True
        Me.Descipcion.Width = 180
        '
        'Orden
        '
        Me.Orden.HeaderText = "Orden"
        Me.Orden.Name = "Orden"
        Me.Orden.ReadOnly = True
        Me.Orden.Width = 80
        '
        'Cambiar
        '
        Me.Cambiar.HeaderText = "Cambiar"
        Me.Cambiar.Name = "Cambiar"
        Me.Cambiar.ReadOnly = True
        Me.Cambiar.Width = 80
        '
        'Totalizar
        '
        Me.Totalizar.HeaderText = "Totalizar"
        Me.Totalizar.Name = "Totalizar"
        Me.Totalizar.ReadOnly = True
        Me.Totalizar.Width = 80
        '
        'Distrib
        '
        Me.Distrib.HeaderText = "Distribuir"
        Me.Distrib.Name = "Distrib"
        Me.Distrib.ReadOnly = True
        Me.Distrib.Width = 80
        '
        'btn_up
        '
        Me.btn_up.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_up.Location = New System.Drawing.Point(72, 246)
        Me.btn_up.Name = "btn_up"
        Me.btn_up.Size = New System.Drawing.Size(30, 30)
        Me.btn_up.TabIndex = 2
        Me.btn_up.Text = "↑"
        Me.btn_up.UseVisualStyleBackColor = True
        '
        'btn_down
        '
        Me.btn_down.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_down.Location = New System.Drawing.Point(118, 246)
        Me.btn_down.Name = "btn_down"
        Me.btn_down.Size = New System.Drawing.Size(30, 30)
        Me.btn_down.TabIndex = 3
        Me.btn_down.Text = "↓"
        Me.btn_down.UseVisualStyleBackColor = True
        '
        'btn_edit
        '
        Me.btn_edit.Location = New System.Drawing.Point(389, 246)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(100, 30)
        Me.btn_edit.TabIndex = 4
        Me.btn_edit.Text = "Editar"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'btn_new
        '
        Me.btn_new.Location = New System.Drawing.Point(271, 246)
        Me.btn_new.Name = "btn_new"
        Me.btn_new.Size = New System.Drawing.Size(100, 30)
        Me.btn_new.TabIndex = 5
        Me.btn_new.Text = "Nueva"
        Me.btn_new.UseVisualStyleBackColor = True
        '
        'btn_drop
        '
        Me.btn_drop.Location = New System.Drawing.Point(507, 246)
        Me.btn_drop.Name = "btn_drop"
        Me.btn_drop.Size = New System.Drawing.Size(100, 30)
        Me.btn_drop.TabIndex = 6
        Me.btn_drop.Text = "Eliminar"
        Me.btn_drop.UseVisualStyleBackColor = True
        '
        'mant_filas_reporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btn_drop)
        Me.Controls.Add(Me.btn_new)
        Me.Controls.Add(Me.btn_edit)
        Me.Controls.Add(Me.btn_down)
        Me.Controls.Add(Me.btn_up)
        Me.Controls.Add(Me.DGfilas)
        Me.Controls.Add(Me.LB1)
        Me.Name = "mant_filas_reporte"
        Me.Size = New System.Drawing.Size(660, 322)
        CType(Me.DGfilas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LB1 As System.Windows.Forms.Label
    Friend WithEvents DGfilas As System.Windows.Forms.DataGridView
    Friend WithEvents btn_up As System.Windows.Forms.Button
    Friend WithEvents btn_down As System.Windows.Forms.Button
    Friend WithEvents btn_edit As System.Windows.Forms.Button
    Friend WithEvents btn_new As System.Windows.Forms.Button
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descipcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Orden As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cambiar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Totalizar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Distrib As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btn_drop As System.Windows.Forms.Button

End Class
