<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mant_filas_reporte_detalle
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
        Me.lb1 = New System.Windows.Forms.Label()
        Me.lb5 = New System.Windows.Forms.Label()
        Me.tb_descrip = New System.Windows.Forms.TextBox()
        Me.ck_camb = New System.Windows.Forms.CheckBox()
        Me.ck_dist = New System.Windows.Forms.CheckBox()
        Me.lst_composicion = New System.Windows.Forms.ListBox()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.btn_canc = New System.Windows.Forms.Button()
        Me.btn_new = New System.Windows.Forms.Button()
        Me.btn_off = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lb_titulo = New System.Windows.Forms.Label()
        Me.ck_total = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbCcode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.P_total_pinta = New System.Windows.Forms.Panel()
        Me.op3 = New System.Windows.Forms.RadioButton()
        Me.op2 = New System.Windows.Forms.RadioButton()
        Me.op1 = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.P_total_pinta.SuspendLayout()
        Me.SuspendLayout()
        '
        'lb1
        '
        Me.lb1.AutoSize = True
        Me.lb1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb1.Location = New System.Drawing.Point(10, 38)
        Me.lb1.Name = "lb1"
        Me.lb1.Size = New System.Drawing.Size(74, 13)
        Me.lb1.TabIndex = 4
        Me.lb1.Text = "Descripción"
        '
        'lb5
        '
        Me.lb5.AutoSize = True
        Me.lb5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb5.Location = New System.Drawing.Point(10, 158)
        Me.lb5.Name = "lb5"
        Me.lb5.Size = New System.Drawing.Size(127, 13)
        Me.lb5.TabIndex = 13
        Me.lb5.Text = "Contenido de la linea"
        '
        'tb_descrip
        '
        Me.tb_descrip.Location = New System.Drawing.Point(100, 38)
        Me.tb_descrip.Name = "tb_descrip"
        Me.tb_descrip.Size = New System.Drawing.Size(400, 20)
        Me.tb_descrip.TabIndex = 5
        '
        'ck_camb
        '
        Me.ck_camb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ck_camb.Location = New System.Drawing.Point(13, 108)
        Me.ck_camb.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.ck_camb.Name = "ck_camb"
        Me.ck_camb.Size = New System.Drawing.Size(103, 17)
        Me.ck_camb.TabIndex = 8
        Me.ck_camb.Text = "Cambiar Signo"
        Me.ck_camb.UseVisualStyleBackColor = True
        '
        'ck_dist
        '
        Me.ck_dist.AutoSize = True
        Me.ck_dist.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ck_dist.Location = New System.Drawing.Point(295, 108)
        Me.ck_dist.Name = "ck_dist"
        Me.ck_dist.Size = New System.Drawing.Size(66, 17)
        Me.ck_dist.TabIndex = 10
        Me.ck_dist.Text = "Distribuir"
        Me.ck_dist.UseVisualStyleBackColor = True
        '
        'lst_composicion
        '
        Me.lst_composicion.FormattingEnabled = True
        Me.lst_composicion.HorizontalScrollbar = True
        Me.lst_composicion.Location = New System.Drawing.Point(10, 20)
        Me.lst_composicion.Name = "lst_composicion"
        Me.lst_composicion.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lst_composicion.Size = New System.Drawing.Size(590, 173)
        Me.lst_composicion.TabIndex = 1
        '
        'btn_guardar
        '
        Me.btn_guardar.Location = New System.Drawing.Point(448, 104)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(80, 25)
        Me.btn_guardar.TabIndex = 11
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'btn_canc
        '
        Me.btn_canc.Location = New System.Drawing.Point(554, 104)
        Me.btn_canc.Name = "btn_canc"
        Me.btn_canc.Size = New System.Drawing.Size(80, 25)
        Me.btn_canc.TabIndex = 12
        Me.btn_canc.Text = "Cancelar"
        Me.btn_canc.UseVisualStyleBackColor = True
        '
        'btn_new
        '
        Me.btn_new.Location = New System.Drawing.Point(66, 200)
        Me.btn_new.Name = "btn_new"
        Me.btn_new.Size = New System.Drawing.Size(75, 23)
        Me.btn_new.TabIndex = 2
        Me.btn_new.Text = "Agregar"
        Me.btn_new.UseVisualStyleBackColor = True
        '
        'btn_off
        '
        Me.btn_off.Location = New System.Drawing.Point(169, 200)
        Me.btn_off.Name = "btn_off"
        Me.btn_off.Size = New System.Drawing.Size(75, 23)
        Me.btn_off.TabIndex = 3
        Me.btn_off.Text = "Quitar"
        Me.btn_off.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lb_titulo)
        Me.Panel1.Controls.Add(Me.btn_off)
        Me.Panel1.Controls.Add(Me.lst_composicion)
        Me.Panel1.Controls.Add(Me.btn_new)
        Me.Panel1.Location = New System.Drawing.Point(16, 178)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(631, 235)
        Me.Panel1.TabIndex = 14
        '
        'lb_titulo
        '
        Me.lb_titulo.AutoSize = True
        Me.lb_titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_titulo.Location = New System.Drawing.Point(21, 4)
        Me.lb_titulo.Name = "lb_titulo"
        Me.lb_titulo.Size = New System.Drawing.Size(52, 15)
        Me.lb_titulo.TabIndex = 0
        Me.lb_titulo.Text = "Cuentas"
        '
        'ck_total
        '
        Me.ck_total.AutoSize = True
        Me.ck_total.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ck_total.Location = New System.Drawing.Point(171, 108)
        Me.ck_total.Name = "ck_total"
        Me.ck_total.Size = New System.Drawing.Size(63, 17)
        Me.ck_total.TabIndex = 9
        Me.ck_total.Text = "Totaliza"
        Me.ck_total.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo Int."
        '
        'tbID
        '
        Me.tbID.Location = New System.Drawing.Point(100, 10)
        Me.tbID.Name = "tbID"
        Me.tbID.Size = New System.Drawing.Size(115, 20)
        Me.tbID.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(269, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Codigo Personalizado"
        '
        'tbCcode
        '
        Me.tbCcode.Location = New System.Drawing.Point(404, 7)
        Me.tbCcode.Name = "tbCcode"
        Me.tbCcode.Size = New System.Drawing.Size(144, 20)
        Me.tbCcode.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Remarcar Linea"
        '
        'P_total_pinta
        '
        Me.P_total_pinta.Controls.Add(Me.op3)
        Me.P_total_pinta.Controls.Add(Me.op2)
        Me.P_total_pinta.Controls.Add(Me.op1)
        Me.P_total_pinta.Location = New System.Drawing.Point(120, 64)
        Me.P_total_pinta.Name = "P_total_pinta"
        Me.P_total_pinta.Size = New System.Drawing.Size(459, 25)
        Me.P_total_pinta.TabIndex = 7
        '
        'op3
        '
        Me.op3.AutoSize = True
        Me.op3.Location = New System.Drawing.Point(196, 5)
        Me.op3.Name = "op3"
        Me.op3.Size = New System.Drawing.Size(53, 17)
        Me.op3.TabIndex = 2
        Me.op3.TabStop = True
        Me.op3.Tag = "2"
        Me.op3.Text = "Doble"
        Me.op3.UseVisualStyleBackColor = True
        '
        'op2
        '
        Me.op2.AutoSize = True
        Me.op2.Location = New System.Drawing.Point(89, 5)
        Me.op2.Name = "op2"
        Me.op2.Size = New System.Drawing.Size(56, 17)
        Me.op2.TabIndex = 1
        Me.op2.TabStop = True
        Me.op2.Tag = "1"
        Me.op2.Text = "Simple"
        Me.op2.UseVisualStyleBackColor = True
        '
        'op1
        '
        Me.op1.AutoSize = True
        Me.op1.Location = New System.Drawing.Point(5, 5)
        Me.op1.Name = "op1"
        Me.op1.Size = New System.Drawing.Size(39, 17)
        Me.op1.TabIndex = 0
        Me.op1.TabStop = True
        Me.op1.Tag = "0"
        Me.op1.Text = "No"
        Me.op1.UseVisualStyleBackColor = True
        '
        'mant_filas_reporte_detalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.P_total_pinta)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbCcode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ck_total)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btn_canc)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.ck_dist)
        Me.Controls.Add(Me.ck_camb)
        Me.Controls.Add(Me.tb_descrip)
        Me.Controls.Add(Me.lb5)
        Me.Controls.Add(Me.lb1)
        Me.Name = "mant_filas_reporte_detalle"
        Me.Size = New System.Drawing.Size(679, 421)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.P_total_pinta.ResumeLayout(False)
        Me.P_total_pinta.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lb1 As System.Windows.Forms.Label
    Friend WithEvents lb5 As System.Windows.Forms.Label
    Friend WithEvents tb_descrip As System.Windows.Forms.TextBox
    Friend WithEvents ck_camb As System.Windows.Forms.CheckBox
    Friend WithEvents ck_dist As System.Windows.Forms.CheckBox
    Friend WithEvents lst_composicion As System.Windows.Forms.ListBox
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_canc As System.Windows.Forms.Button
    Friend WithEvents btn_new As System.Windows.Forms.Button
    Friend WithEvents btn_off As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lb_titulo As System.Windows.Forms.Label
    Friend WithEvents ck_total As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbCcode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents P_total_pinta As System.Windows.Forms.Panel
    Friend WithEvents op3 As System.Windows.Forms.RadioButton
    Friend WithEvents op2 As System.Windows.Forms.RadioButton
    Friend WithEvents op1 As System.Windows.Forms.RadioButton

End Class
