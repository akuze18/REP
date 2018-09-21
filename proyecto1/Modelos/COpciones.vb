Public Class COpciones
    Private _id As Integer
    Private _descrip As String

    Public Sub New(id As Integer, descripcion As String)
        _id = id
        _descrip = descripcion
    End Sub

    Public Overrides Function ToString() As String
        Return _descrip
    End Function

    Public ReadOnly Property codigo As Integer
        Get
            Return _id
        End Get
    End Property
    Public ReadOnly Property descripcion As String
        Get
            Return _descrip
        End Get
    End Property
End Class
