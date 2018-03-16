Public Class comp_fila_row
    Inherits DataRow
    Private _indice_cuenta As indice_cuenta_row
    Private _fila_reporte As dt_fila_reporte.myRow

    Friend Sub New(builder As DataRowBuilder)
        MyBase.New(builder)
    End Sub

    Public Overrides Function toString() As String
        If Not IsNothing(_indice_cuenta) And Not IsNothing(_fila_reporte) Then
            Return _indice_cuenta.toString() + ":" + _fila_reporte.toString
        Else
            Return FILA_TOTAL.ToString + ":" + CUENTA_COMP.ToString
        End If
    End Function

    Public ReadOnly Property ID As Integer
        Get
            Return CType(MyBase.Item("ID"), Integer)
        End Get
    End Property
    Public ReadOnly Property FILA_TOTAL As Integer
        Get
            Return CType(MyBase.Item("FILA_TOTAL"), Integer)
        End Get
    End Property
    Public ReadOnly Property FILA_COMP As Integer
        Get
            Return CType(MyBase.Item("FILA_COMP"), Integer)
        End Get
    End Property
    Public ReadOnly Property CUENTA_COMP As Integer
        Get
            Try
                Return CType(MyBase.Item("CUENTA_COMP"), Integer)
            Catch ex As Exception
                Return 0
            End Try

        End Get
    End Property
    Public ReadOnly Property REPORTE As Integer
        Get
            Return CType(MyBase.Item("REPORTE"), Integer)
        End Get
    End Property

    Public ReadOnly Property DESDE As DateTime
        Get
            Return CType(MyBase.Item("DESDE"), DateTime)
        End Get
    End Property
    Public ReadOnly Property HASTA As DateTime
        Get
            Return CType(MyBase.Item("HASTA"), DateTime)
        End Get
    End Property

    Public Property INDICE_CUENTA As indice_cuenta_row
        Get
            Return _indice_cuenta
        End Get
        Set(value As indice_cuenta_row)
            _indice_cuenta = value
        End Set
    End Property

    Public Property FILA_REPORTE As dt_fila_reporte.myRow
        Get
            Return _fila_reporte
        End Get
        Set(value As dt_fila_reporte.myRow)
            _fila_reporte = value
        End Set
    End Property
End Class
