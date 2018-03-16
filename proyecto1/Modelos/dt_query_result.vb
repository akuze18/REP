Public Class dt_query_result
    Inherits DataTable

    Protected Overrides Function GetRowType() As Type
        Return GetType(myRow)
    End Function

    Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
        Return New myRow(builder)
    End Function

    Public Sub New(ByVal datos As DataTable)
        For Each columna As DataColumn In datos.Columns
            Columns.Add(columna.ColumnName, columna.DataType)
        Next
        For Each fila As DataRow In datos.Rows
            ImportRow(fila)
        Next
    End Sub

    Default Public ReadOnly Property Item(idx As Integer) As myRow
        Get
            Return DirectCast(Rows(idx), myRow)
        End Get
    End Property

    Public Sub Add(row As myRow)
        Rows.Add(row)
    End Sub

    Public Sub Remove(row As myRow)
        Rows.Remove(row)
    End Sub

    Public Shadows Function NewRow() As myRow
        Dim row As myRow = CType(NewRow(), myRow)

        Return row
    End Function

    Public Function GetNewRow() As myRow
        Dim row As myRow = CType(NewRow(), myRow)

        Return row
    End Function

    Public Class myRow
        Inherits DataRow

        Friend Sub New(builder As DataRowBuilder)
            MyBase.New(builder)
        End Sub

        Public Overrides Function toString() As String
            Return TXT_ESTADO
        End Function

        Public ReadOnly Property COD_ESTADO As Integer
            Get
                Return CType(MyBase.Item("COD_ESTADO"), Integer)
            End Get
        End Property
        Public ReadOnly Property TXT_ESTADO As String
            Get
                Return CType(MyBase.Item("TXT_ESTADO"), String)
            End Get
        End Property
        Public ReadOnly Property ID_NUEVO As Integer
            Get
                Return CType(MyBase.Item("ID_NUEVO"), Integer)
            End Get
        End Property
        Public ReadOnly Property AFECTADAS As Integer
            Get
                Try
                    Return CType(MyBase.Item("AFECTADAS"), Integer)
                Catch ex As Exception
                    'podría no estar definidas en todas consultas
                    Return 0
                End Try
            End Get
        End Property
    End Class

End Class
