Public Class sector_table
    Inherits DataTable
    Public Enum display
        full = 1
        depto = 2
        lugar = 3
    End Enum
    Private _mostrar As display

    Protected Overrides Function GetRowType() As Type
        Return GetType(sector_row)
    End Function

    Protected Overrides Function NewRowFromBuilder(builder As DataRowBuilder) As DataRow
        Return New sector_row(builder)
    End Function

    Public Sub New(ByVal datos As DataTable, ByVal mostrar As display)
        _mostrar = mostrar
        For Each columna As DataColumn In datos.Columns
            Columns.Add(columna.ColumnName, columna.DataType)
        Next
        For Each fila As DataRow In datos.Rows
            ImportRow(fila)
        Next
        'agrego un campo calculado para calculo de porcentajes de distribucion
        Columns.Add("total_depto_calc", Type.GetType("System.Double"))
        For Each fila As DataRow In Rows
            Try
                fila("total_depto_calc") = Me.Compute("SUM(VALOR)", "DEPTO='" + fila("DEPTO") + "'")
            Catch ex As Exception
                fila("total_depto_calc") = 0
            End Try

        Next
    End Sub

    Default Public ReadOnly Property Item(idx As Integer) As sector_row
        Get
            Return DirectCast(Rows(idx), sector_row)
        End Get
    End Property

    Public Sub Add(row As sector_row)
        Rows.Add(row)
    End Sub

    Public Sub Remove(row As sector_row)
        Rows.Remove(row)
    End Sub

    Public Shadows Function NewRow() As sector_row
        Dim row As sector_row = CType(NewRow(), sector_row)

        Return row
    End Function

    Public Function GetNewRow() As sector_row
        Dim row As sector_row = CType(NewRow(), sector_row)

        Return row
    End Function

    Public Function FIND_by_ID(ByVal id As Integer) As sector_row
        Dim seleccionada As sector_row
        seleccionada = Nothing
        For Each sRow As sector_row In Me.Rows
            If sRow.ID = id Then
                seleccionada = sRow
            End If
        Next
        Return seleccionada
    End Function

    Public ReadOnly Property TOTAL_VALOR As Double
        Get
            Dim suma As Double = 0

            For Each fila As sector_row In Me.Rows
                suma = suma + fila.VALOR
            Next
            Return Math.Round(suma, 5)
        End Get
    End Property

    Public Function TOTAL_DEPTO_VALOR(ByVal cod_depto As String) As Double
        Dim valor As Double
        valor = MyBase.Compute("SUM(VALOR)", "DEPTO='" + cod_depto + "'")
        Return valor
    End Function

    Public Function DETALLE_DEPTO(ByVal cod_depto As String) As sector_row()
        Return MyBase.Select("DEPTO='" + cod_depto + "'")
    End Function

    Public ReadOnly Property MOSTRAR As display
        Get
            Return _mostrar
        End Get
    End Property
End Class
