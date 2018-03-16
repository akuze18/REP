Public Class regla_clasif_row
    Inherits DataRow

    Friend Sub New(builder As DataRowBuilder)
        MyBase.New(builder)
    End Sub

    Public Overrides Function toString() As String
        Return TIPO_TEXT + ": " + VALIDACION + " = " + FILA_TEXT
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
    Public ReadOnly Property TIPO As String
        Get
            Return Strings.Trim(CType(MyBase.Item("TIPO"), String))
        End Get
    End Property
    Public ReadOnly Property VALIDACION As String
        Get
            Return Strings.Trim(CType(MyBase.Item("VALIDACION"), String))
        End Get
    End Property
    Public ReadOnly Property FILA As Integer
        Get
            Return Strings.Trim(CType(MyBase.Item("FILA"), Integer))
        End Get
    End Property

    Public ReadOnly Property FILA_TEXT As String
        Get
            Return Strings.Trim(CType(MyBase.Item("TXT_FILA"), String))
        End Get
    End Property
    Public ReadOnly Property TIPO_TEXT As String
        Get
            Return Strings.Trim(CType(MyBase.Item("TXT_TIPO"), String))
        End Get
    End Property
End Class
