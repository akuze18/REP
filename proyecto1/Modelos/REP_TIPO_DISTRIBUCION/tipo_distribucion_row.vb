Public Class tipo_distribucion_row
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
            Return CType(MyBase.Item("DESCRIPCION"), String)
        End Get
    End Property
    Public ReadOnly Property SIGLA As String
        Get
            Return CType(MyBase.Item("SIGLA"), String)
        End Get
    End Property
End Class
