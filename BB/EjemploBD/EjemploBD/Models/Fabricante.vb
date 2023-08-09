Public Class Fabricante

    Private _idFabricante As Integer
    Private _nombre As String

    Public Sub New(ByVal idFabricante As Integer, ByVal nombre As String)
        _idFabricante = idFabricante
        _nombre = nombre
    End Sub


    Public Sub New(ByVal nombre As String)
        _nombre = nombre
    End Sub


    Public Property IdFabricante As Integer
        Get
            Return _idFabricante
        End Get
        Set(value As Integer)
            _idFabricante = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return $"ID: {IdFabricante} - NOMBRE: {Nombre}"
    End Function

End Class
