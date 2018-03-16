Public Class regla_clasif_table
    Inherits DataTable

    Protected Overrides Function GetRowType() As Type
        Return GetType(regla_clasif_row)
    End Function

    Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
        Return New regla_clasif_row(builder)
    End Function

    Public Sub New(ByVal datos As DataTable)
        For Each columna As DataColumn In datos.Columns
            Columns.Add(columna.ColumnName, columna.DataType)
        Next
        For Each fila As DataRow In datos.Rows
            ImportRow(fila)
        Next
    End Sub

    Default Public ReadOnly Property Item(idx As Integer) As regla_clasif_row
        Get
            Return DirectCast(Rows(idx), regla_clasif_row)
        End Get
    End Property
    Public Sub Add(row As regla_clasif_row)
        Rows.Add(row)
    End Sub
    Public Sub Remove(row As regla_clasif_row)
        Rows.Remove(row)
    End Sub
    Public Shadows Function NewRow() As regla_clasif_row
        Dim row As regla_clasif_row = CType(NewRow(), regla_clasif_row)

        Return row
    End Function
    Public Function GetNewRow() As regla_clasif_row
        Dim row As regla_clasif_row = CType(NewRow(), regla_clasif_row)

        Return row
    End Function

    Public Function FIND_by_ID(ByVal id As Integer) As regla_clasif_row
        Dim seleccionada As regla_clasif_row
        seleccionada = Nothing
        For Each sRow As regla_clasif_row In Me.Rows
            If sRow.ID = id Then
                seleccionada = sRow
            End If
        Next
        Return seleccionada
    End Function
End Class
