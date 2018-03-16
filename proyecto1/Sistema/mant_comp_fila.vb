Public Class mant_comp_fila
    Private _tipo_comp As composicion
    Private _fila As dt_fila_reporte.myRow
    Private base As New base_REP

    Public Enum composicion
        cuenta = 1
        fila = 2
    End Enum

    Public Sub New(ByVal fila As Integer, ByVal tipo_composicion As composicion)
        _tipo_comp = tipo_composicion
        _fila = base.FILA_REP(fila)
        InitializeComponent()
    End Sub

    Private Sub mant_comp_fila_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim detalle_comp As DataTable
        tbFilaOrigen.Enabled = False
        tbFilaOrigen.Text = _fila.DESCRIP

        If _tipo_comp = composicion.cuenta Then
            detalle_comp = base.CUENTAS
        ElseIf _tipo_comp = composicion.fila Then
            detalle_comp = base.FILAS_REPORTE(_fila.REPORTE)
        Else
            detalle_comp = Nothing
            Mensaje.Fallo("Error en el tipo de composicion")
        End If

        If Not IsNothing(detalle_comp) Then
            With cbComp
                .Items.Clear()
                For Each f As DataRow In detalle_comp.Rows
                    .Items.Add(f)
                Next
                .SelectedIndex = -1
            End With
        End If

        Dim last_month As ACode.Vperiodo
        last_month = New ACode.Vperiodo(Year(Now), Month(Now))
        last_month = last_month - 1
        Odesde.especificar = last_month.first
        Ohasta.especificar = last_month.last
    End Sub

    Private Sub btn_cancel_Click(sender As System.Object, e As System.EventArgs) Handles btn_cancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btn_ok_Click(sender As System.Object, e As System.EventArgs) Handles btn_ok.Click
        'valido que se haya completado toda la información
        If cbComp.SelectedIndex < 0 Then
            Mensaje.Alerta("No se ha indicado la composición de la fila")
            Exit Sub
        End If


        Dim base As New base_REP
        Dim infoResult As dt_query_result.myRow

        If _tipo_comp = composicion.cuenta Then
            Dim cuenta_comp As indice_cuenta_row
            cuenta_comp = cbComp.SelectedItem
            infoResult = base.NEW_DETALLE_CUENTA_COMP(_fila.ID, cuenta_comp.ID, Odesde.marcado, Ohasta.marcado)
        ElseIf _tipo_comp = composicion.fila Then
            Dim fila_comp As dt_fila_reporte.myRow
            fila_comp = cbComp.SelectedItem
            infoResult = base.NEW_DETALLE_FILA_COMP(_fila.ID, fila_comp.ID, Odesde.marcado, Ohasta.marcado)
        Else
            infoResult = Nothing
        End If
        If IsNothing(infoResult) Then
            Mensaje.Fallo("Error en el tipo de composicion")
        Else
            If infoResult.COD_ESTADO = 1 Then
                Mensaje.Info("Se ha ingresado correctamente la " + _tipo_comp.ToString + " para la distribucion " + _fila.DESCRIP)
                DialogResult = Windows.Forms.DialogResult.OK
            Else
                Mensaje.Fallo(infoResult.TXT_ESTADO)
            End If
        End If
    End Sub

End Class