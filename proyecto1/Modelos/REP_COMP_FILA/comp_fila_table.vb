Public Class comp_fila_table
    Inherits DataTable

    Protected Overrides Function GetRowType() As Type
        Return GetType(comp_fila_row)
    End Function

    Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
        Return New comp_fila_row(builder)
    End Function

    Public Sub New(ByVal datos As DataTable)
        For Each columna As DataColumn In datos.Columns
            Columns.Add(columna.ColumnName, columna.DataType)
        Next
        For Each fila As DataRow In datos.Rows
            ImportRow(fila)
        Next
    End Sub

    Default Public ReadOnly Property Item(idx As Integer) As comp_fila_row
        Get
            Return DirectCast(Rows(idx), comp_fila_row)
        End Get
    End Property
    Public Sub Add(row As comp_fila_row)
        Rows.Add(row)
    End Sub
    Public Sub Remove(row As comp_fila_row)
        Rows.Remove(row)
    End Sub
    Public Shadows Function NewRow() As comp_fila_row
        Dim row As comp_fila_row = CType(NewRow(), comp_fila_row)

        Return row
    End Function
    Public Function GetNewRow() As comp_fila_row
        Dim row As comp_fila_row = CType(NewRow(), comp_fila_row)

        Return row
    End Function
    Public Function FIND_by_ID(ByVal id As Integer) As comp_fila_row
        Dim seleccionada As comp_fila_row
        seleccionada = Nothing
        For Each sRow As comp_fila_row In Me.Rows
            If sRow.ID = id Then
                seleccionada = sRow
            End If
        Next
        Return seleccionada
    End Function

    Public Function JOIN_CUENTAS(ByVal tCuentas As indice_cuenta_table) As Boolean
        Try
            For Each fila As comp_fila_row In Me.Rows
                fila.INDICE_CUENTA = tCuentas.FIND_by_ID(fila.CUENTA_COMP)
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function JOIN_FILAS_REPORTE(ByVal tFilas As dt_fila_reporte) As Boolean
        Try
            For Each fila As comp_fila_row In Me.Rows
                fila.FILA_REPORTE = tFilas.FIND_by_ID(fila.FILA_TOTAL)
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
