Public Class dt_fila_reporte
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
        Public ReadOnly Property DESCRIP As String
            Get
                Return CType(MyBase.Item("DESCRIP"), String)
            End Get
        End Property
        Public ReadOnly Property REPORTE As Integer
            Get
                Return CType(MyBase.Item("REPORTE"), Integer)
            End Get
        End Property
        Public ReadOnly Property ORDEN As String
            Get
                Return CType(MyBase.Item("ORDEN"), String)
            End Get
        End Property
        Public ReadOnly Property CAMBIAR As Boolean
            Get
                Return CBool(MyBase.Item("CAMBIAR"))
            End Get
        End Property
        Public ReadOnly Property DISTRIB As Boolean
            Get
                Return CBool(MyBase.Item("DISTRIB"))
            End Get
        End Property
        Public ReadOnly Property TOTALIZAR As Boolean
            Get
                Return CBool(MyBase.Item("TOTALIZAR"))
            End Get
        End Property
        Public ReadOnly Property CCODE As String
            Get
                Return CType(MyBase.Item("CCODE"), String)
            End Get
        End Property
        Public ReadOnly Property TOTAL_PINTA As Integer
            Get
                Return CType(MyBase.Item("TOTAL_PINTA"), Integer)
            End Get
        End Property

        Public ReadOnly Property ID_COMP_FILA As Integer
            Get
                Dim salida As Integer
                Try
                    salida = CInt(MyBase.Item("ID_COMP_FILA"))
                Catch ex As Exception
                    'El campo podría no estar definido, solo tendrá sentido cuando las filas consultadas esten relacionadas con una composicion
                    salida = 0
                End Try
                Return salida
            End Get
        End Property

    End Class


End Class
