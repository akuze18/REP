Public Class indice_cuenta_row
    Inherits DataRow

    Friend Sub New(builder As DataRowBuilder)
        MyBase.New(builder)
    End Sub

    Public Overrides Function toString() As String
        Select Case MOSTRAR
            Case indice_cuenta_table.display.full
                Return DESCRIP
            Case indice_cuenta_table.display.depto
                Return COD_DEPTO
            Case indice_cuenta_table.display.cuenta
                Return NUM_CUENTA
            Case indice_cuenta_table.display.lugar
                Return COD_LUGAR
            Case Else   'FULL
                Return DESCRIP
        End Select

    End Function

    Public ReadOnly Property ID As Integer
        Get
            Return CType(MyBase.Item("ID"), Integer)
        End Get
    End Property
    Public ReadOnly Property DESCRIP As String
        Get
            Return NUM_CUENTA + "-" + COD_DEPTO + "-" + COD_LUGAR + "-" + COD_GESTN
        End Get
    End Property
    Public ReadOnly Property COD_DEPTO As String
        Get
            Return CType(MyBase.Item("COD_DEPTO"), String)
        End Get
    End Property
    Public ReadOnly Property COD_LUGAR As String
        Get
            Return CType(MyBase.Item("COD_LUGAR"), String)
        End Get
    End Property
    Public ReadOnly Property COD_GESTN As String
        Get
            Return CType(MyBase.Item("COD_GESTN"), String)
        End Get
    End Property
    Public ReadOnly Property NUM_CUENTA As String
        Get
            Return CType(MyBase.Item("NUM_CUENTA"), String)
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

    Public ReadOnly Property MOSTRAR As indice_cuenta_table.display
        Get
            Dim tabla As indice_cuenta_table
            tabla = CType(MyBase.Table, indice_cuenta_table)
            Return tabla.MOSTRAR
        End Get
    End Property

End Class
