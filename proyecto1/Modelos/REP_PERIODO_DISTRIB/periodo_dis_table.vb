Public Class periodo_dis_table
    Inherits DataTable

    Protected Overrides Function GetRowType() As Type
        Return GetType(periodo_dis_row)
    End Function

    Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
        Return New periodo_dis_row(builder)
    End Function

    Public Sub New(ByVal datos As DataTable)
        For Each columna As DataColumn In datos.Columns
            Columns.Add(columna.ColumnName, columna.DataType)
        Next
        For Each fila As DataRow In datos.Rows
            ImportRow(fila)
        Next
    End Sub

    Default Public ReadOnly Property Item(idx As Integer) As periodo_dis_row
        Get
            Return DirectCast(Rows(idx), periodo_dis_row)
        End Get
    End Property

    Public Sub Add(row As periodo_dis_row)
        Rows.Add(row)
    End Sub

    Public Sub Remove(row As periodo_dis_row)
        Rows.Remove(row)
    End Sub

    Public Shadows Function NewRow() As periodo_dis_row
        Dim row As periodo_dis_row = CType(NewRow(), periodo_dis_row)

        Return row
    End Function

    Public Function GetNewRow() As periodo_dis_row
        Dim row As periodo_dis_row = CType(NewRow(), periodo_dis_row)

        Return row
    End Function

    Public Function FIND_by_ID(ByVal id As Integer) As periodo_dis_row
        Dim seleccionada As periodo_dis_row
        seleccionada = Nothing
        For Each sRow As periodo_dis_row In Me.Rows
            If sRow.ID = id Then
                seleccionada = sRow
            End If
        Next
        Return seleccionada
    End Function
End Class
