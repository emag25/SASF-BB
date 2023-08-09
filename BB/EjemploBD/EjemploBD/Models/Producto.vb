Public Class Producto

    Private _idProducto As Integer
    Private _nombre As String
    Private _precio As Decimal
    Private _idFabricante As Integer


    Public Sub New(ByVal idProducto As Integer, ByVal nombre As String, ByVal precio As Decimal, ByVal idFabricante As Integer)
        _idProducto = idProducto
        _nombre = nombre
        _precio = precio
        _idFabricante = idFabricante
    End Sub


    Public Sub New(ByVal nombre As String, ByVal precio As Decimal, ByVal idFabricante As Integer)
        _nombre = nombre
        _precio = precio
        _idFabricante = idFabricante
    End Sub


    Public Property IdProducto As Integer
        Get
            Return _idProducto
        End Get
        Set(value As Integer)
            _idProducto = value
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

    Public Property Precio As Decimal
        Get
            Return _precio
        End Get
        Set(value As Decimal)
            _precio = value
        End Set
    End Property

    Public Property IdFabricante As Integer
        Get
            Return _idFabricante
        End Get
        Set(value As Integer)
            _idFabricante = value
        End Set
    End Property


    Public Overrides Function ToString() As String
        Return $"ID: {IdProducto} - NOMBRE: {Nombre} - PRECIO: {Precio} - FABRICANTE: {IdFabricante}"
    End Function


End Class
