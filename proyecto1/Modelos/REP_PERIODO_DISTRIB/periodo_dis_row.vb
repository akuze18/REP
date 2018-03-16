Public Class periodo_dis_row
    Inherits DataRow

    Friend Sub New(builder As DataRowBuilder)
        MyBase.New(builder)
    End Sub

    Public Overrides Function toString() As String
        Return DESDE.ToString("dd/MM/yyyy") + " - " + HASTA.ToString("dd/MM/yyyy")
    End Function

    Public ReadOnly Property ID As Integer
        Get
            Return CType(MyBase.Item("ID"), Integer)
        End Get
    End Property
    Public ReadOnly Property DISTRIB As Integer
        Get
            Return CType(MyBase.Item("DISTRIB"), Integer)
        End Get
    End Property
    Public ReadOnly Property ACCION As String
        Get
            Return CType(MyBase.Item("ACCION"), String)
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
End Class
