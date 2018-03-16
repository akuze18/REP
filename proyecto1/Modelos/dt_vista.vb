Public Class dt_vista
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
    Public Function FIND_by_ID(ByVal id As Integer) As myRow
        Dim seleccionada As myRow
        seleccionada = Nothing
        For Each sRow As myRow In Me.Rows
            If sRow.ID = id Then
                seleccionada = sRow
            End If
        Next
        Return seleccionada
    End Function

    Public Class myRow
        Inherits DataRow

        Friend Sub New(builder As DataRowBuilder)
            MyBase.New(builder)
        End Sub

        Public Overrides Function toString() As String
            Return DESCRIP
        End Function

        Public ReadOnly Property ID As Integer
            Get
                Return CType(MyBase.Item("ID"), Integer)
            End Get
        End Property
        Public ReadOnly Property REPORTE As Integer
            Get
                Return CType(MyBase.Item("REPORTE"), Integer)
            End Get
        End Property
        Public ReadOnly Property DESCRIP As String
            Get
                Return CType(MyBase.Item("DISPLAY_NAME"), String)
            End Get
        End Property
        Public ReadOnly Property N_CORTO As String
            Get
                Return Strings.Trim(CType(MyBase.Item("SHORT_NAME"), String))
            End Get
        End Property

        Public ReadOnly Property ORDEN As Integer
            Get
                Return CType(MyBase.Item("ORDEN"), Integer)
            End Get
        End Property


    End Class


End Class
