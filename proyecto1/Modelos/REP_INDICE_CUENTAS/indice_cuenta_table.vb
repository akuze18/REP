Public Class indice_cuenta_table
    Inherits DataTable
    Public Enum display
        full = 1
        cuenta = 2
        depto = 3
        lugar = 4
    End Enum
    Private _mostrar As display
    Protected Overrides Function GetRowType() As Type
        Return GetType(indice_cuenta_row)
    End Function

    Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
        Return New indice_cuenta_row(builder)
    End Function

    Public Function MOSTRAR() As display
        Return _mostrar
    End Function

    Public Sub New(ByVal datos As DataTable, ByVal mostrar As display)
        _mostrar = mostrar
        For Each columna As DataColumn In datos.Columns
            Columns.Add(columna.ColumnName, columna.DataType)
        Next
        For Each fila As DataRow In datos.Rows
            ImportRow(fila)
        Next
    End Sub

    Default Public ReadOnly Property Item(idx As Integer) As indice_cuenta_row
        Get
            Return DirectCast(Rows(idx), indice_cuenta_row)
        End Get
    End Property

    Public Sub Add(row As indice_cuenta_row)
        Rows.Add(row)
    End Sub

    Public Sub Remove(row As indice_cuenta_row)
        Rows.Remove(row)
    End Sub

    Public Shadows Function NewRow() As indice_cuenta_row
        Dim row As indice_cuenta_row = CType(NewRow(), indice_cuenta_row)

        Return row
    End Function

    Public Function GetNewRow() As indice_cuenta_row
        Dim row As indice_cuenta_row = CType(NewRow(), indice_cuenta_row)

        Return row
    End Function

    Public Function FIND_by_ID(ByVal id As Integer) As indice_cuenta_row
        Dim seleccionada As indice_cuenta_row
        seleccionada = Nothing
        For Each sRow As indice_cuenta_row In Me.Rows
            If sRow.ID = id Then
                seleccionada = sRow
            End If
        Next
        Return seleccionada
    End Function

End Class
