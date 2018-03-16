Public Class regla_columna_row
    Inherits DataRow

    Friend Sub New(builder As DataRowBuilder)
        MyBase.New(builder)
    End Sub

    Public Overrides Function toString() As String
        Return APLICAR + " " + TIPO + " " + VALIDACION
    End Function

    Public ReadOnly Property ID As Integer
        Get
            Return CType(MyBase.Item("ID"), Integer)
        End Get
    End Property
    Public ReadOnly Property COLUMNA As Integer
        Get
            Return CType(MyBase.Item("COLUMNA"), Integer)
        End Get
    End Property
    Public ReadOnly Property TIPO As String
        Get
            Return Strings.Trim(CType(MyBase.Item("TIPO"), String))
        End Get
    End Property
    Public ReadOnly Property APLICAR As String
        Get
            Return Strings.Trim(CType(MyBase.Item("APLICAR"), String))
        End Get
    End Property
    Public ReadOnly Property VALIDACION As String
        Get
            Return Strings.Trim(CType(MyBase.Item("VALIDACION"), String))
        End Get
    End Property

    Public ReadOnly Property APLICAR_TEXT As String
        Get
            Return Strings.Trim(CType(MyBase.Item("TXT_APLICAR"), String))
        End Get
    End Property
    Public ReadOnly Property TIPO_TEXT As String
        Get
            Return Strings.Trim(CType(MyBase.Item("TXT_TIPO"), String))
        End Get
    End Property
    Public ReadOnly Property VALIDACION_TEXT As String
        Get
            Try
                Return Strings.Trim(CType(MyBase.Item("TXT_VALIDACION"), String))
            Catch ex As Exception
                Return VALIDACION
            End Try

        End Get
    End Property

End Class
