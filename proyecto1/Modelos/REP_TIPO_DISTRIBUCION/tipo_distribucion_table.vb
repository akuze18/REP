Public Class tipo_distribucion_table
    Inherits DataTable

    Protected Overrides Function GetRowType() As Type
        Return GetType(tipo_distribucion_row)
    End Function

    Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
        Return New tipo_distribucion_row(builder)
    End Function

    Public Sub New(ByVal datos As DataTable)
        For Each columna As DataColumn In datos.Columns
            Columns.Add(columna.ColumnName, columna.DataType)
        Next
        For Each fila As DataRow In datos.Rows
            ImportRow(fila)
        Next
    End Sub

    Default Public ReadOnly Property Item(idx As Integer) As tipo_distribucion_row
        Get
            Return DirectCast(Rows(idx), tipo_distribucion_row)
        End Get
    End Property

    Public Sub Add(row As tipo_distribucion_row)
        Rows.Add(row)
    End Sub

    Public Sub Remove(row As tipo_distribucion_row)
        Rows.Remove(row)
    End Sub

    Public Shadows Function NewRow() As tipo_distribucion_row
        Dim row As tipo_distribucion_row = CType(NewRow(), tipo_distribucion_row)

        Return row
    End Function

    Public Function GetNewRow() As tipo_distribucion_row
        Dim row As tipo_distribucion_row = CType(NewRow(), tipo_distribucion_row)

        Return row
    End Function

    Public Function FIND_by_ID(ByVal id As Integer) As tipo_distribucion_row
        Dim seleccionada As tipo_distribucion_row
        seleccionada = Nothing
        For Each sRow As tipo_distribucion_row In Me.Rows
            If sRow.ID = id Then
                seleccionada = sRow
            End If
        Next
        Return seleccionada
    End Function
End Class
