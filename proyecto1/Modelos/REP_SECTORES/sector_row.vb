Public Class sector_row
    Inherits DataRow

    Friend Sub New(builder As DataRowBuilder)
        MyBase.New(builder)
    End Sub

    Public Overrides Function toString() As String
        Select Case MOSTRAR
            Case sector_table.display.depto
                Return COD_DEPTO + ": " + NOMBRE_DEPTO
            Case sector_table.display.lugar
                Return COD_LUGAR + ": " + NOMBRE_LUGAR
            Case Else
                Return COD + ": " + DESCRIP
        End Select

    End Function

    Public ReadOnly Property ID As Integer
        Get
            Return CType(MyBase.Item("ID"), Integer)
        End Get
    End Property
    Public ReadOnly Property COD_DEPTO As String
        Get
            Return CType(MyBase.Item("DEPTO"), String)
        End Get
    End Property
    Public ReadOnly Property COD_LUGAR As String
        Get
            Return CType(MyBase.Item("LUGAR"), String)
        End Get
    End Property
    Public ReadOnly Property NOMBRE_DEPTO As String
        Get
            Return Strings.Trim(CType(MyBase.Item("NOMBRE_DEPTO"), String))
        End Get
    End Property
    Public ReadOnly Property NOMBRE_LUGAR As String
        Get
            Return Strings.Trim(CType(MyBase.Item("NOMBRE_LUGAR"), String))
        End Get
    End Property
    Public ReadOnly Property DESCRIP As String
        Get
            Return NOMBRE_DEPTO + " / " + NOMBRE_LUGAR
        End Get
    End Property
    Public ReadOnly Property COD As String
        Get
            Return COD_DEPTO + "-" + COD_LUGAR
        End Get
    End Property
    Public ReadOnly Property MOSTRAR As sector_table.display
        Get
            Dim tabla As sector_table
            tabla = CType(MyBase.Table, sector_table)
            Return tabla.MOSTRAR
        End Get
    End Property

#Region "Tienen relación con DISTRIBxPERIODO"
    Public ReadOnly Property DISTRIBxSECTOR As Integer
        Get
            'El campo podría no estar definido
            'solo tendrá sentido cuando los sectores consultados esten relacionadas con una distribucion
            Dim salida As Integer
            Try
                salida = CInt(MyBase.Item("DISTRIBxSECTOR"))
            Catch ex As Exception
                salida = 0
            End Try

            Return salida
        End Get
    End Property
    Public Property VALOR As Decimal
        Get
            'El campo podría no estar definido
            'solo tendrá sentido cuando los sectores consultados esten relacionadas con una distribucion
            Dim salida As Double
            Try
                salida = Decimal.Parse(MyBase.Item("VALOR"))
            Catch ex As Exception
                salida = 0
            End Try

            Return salida
        End Get
        Set(value As Decimal)
            Try
                MyBase.Item("VALOR") = value
            Catch ex As Exception
                'si falla es porque la columna valor no esta definida, en dicho caso, 
                'asignar esta variable no produce efecto ya que siempre retornara 0 en su Get
            End Try

        End Set
    End Property
    Public ReadOnly Property PERIODO As Integer
        Get
            'El campo podría no estar definido
            'solo tendrá sentido cuando los sectores consultados esten relacionadas con una distribucion
            Dim salida As Integer
            Try
                salida = CInt(MyBase.Item("PERIODO"))
            Catch ex As Exception
                salida = 0
            End Try

            Return salida
        End Get
    End Property
    Public Property CALC_TOTAL_DEPTO As Decimal
        Get
            Return CType(MyBase.Item("total_depto_calc"), Decimal)
        End Get
        Set(ByVal value As Decimal)
            Try
                MyBase.Item("total_depto_calc") = value
            Catch ex As Exception

            End Try
        End Set
    End Property
#End Region

End Class
