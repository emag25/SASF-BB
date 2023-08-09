Imports System

Module Program
    Sub Main()

        While True
            Console.WriteLine("--------------------------------")
            Console.WriteLine(" MENU ")
            Console.WriteLine("1. Agregar producto")
            Console.WriteLine("2. Editar producto")
            Console.WriteLine("3. Eliminar producto")
            Console.WriteLine("4. Consultar productos")
            Console.WriteLine("5. Salir")
            Console.Write("Seleccione una opcion: ")

            Dim opcion As Integer
            Try
                opcion = Integer.Parse(Console.ReadLine())
            Catch ex As Exception
                Console.WriteLine("Error. Debe ingresar un numero.")
                Continue While
            End Try


            Select Case opcion
                Case 1
                    AgregarProducto()
                Case 2
                    ''EditarProducto()
                Case 3
                    ''EliminarProducto()
                Case 4
                    ConsultarProductos()
                Case 5
                    Exit Sub
                Case Else
                    Console.WriteLine("Opción inválida. Intente nuevamente.")
            End Select

            Console.WriteLine()

        End While


    End Sub


#Region "AgregarProducto"

    Private Sub AgregarProducto()

        Console.WriteLine("--------------------------------")
        Console.WriteLine("       INSERTAR PRODUCTO    ")
        Console.WriteLine("--------------------------------")

        Console.Write("Nombre del producto: ")
        Dim nombreProducto As String = Console.ReadLine()

        Console.Write("Precio del producto: ")
        Dim precioProducto As Decimal
        Try
            precioProducto = Decimal.Parse(Console.ReadLine())
        Catch ex As Exception
            Console.Write("Error. Debe ingresar un numero.")
            Return
        End Try

        ConsultarFabricantes()

        Console.Write("ID del fabricante: ")
        Dim idFabricante As Integer
        Try
            idFabricante = Integer.Parse(Console.ReadLine())
        Catch ex As Exception
            Console.Write("Error. Debe ingresar un numero.")
            Return
        End Try

        If ConsultarFabricantePorId(idFabricante) Is Nothing Then
            Console.WriteLine("No se encontró un fabricante con ese ID.")
            Return
        End If

        Dim producto As New Producto(nombreProducto, precioProducto, idFabricante)

        If ProductoService.InsertarProducto(producto) Then
            Console.WriteLine("Producto ingresado exitosamente!")
        End If

    End Sub

#End Region



#Region "ConsultarProductos"

    Private Sub ConsultarProductos()

        Console.WriteLine("--------------------------------")
        Console.WriteLine("      CONSULTAR PRODUCTOS    ")
        Console.WriteLine("--------------------------------")

        Dim listaProductos As List(Of Producto) = ProductoService.ListarProductos()

        For Each p As Producto In listaProductos
            Console.WriteLine(p)
        Next

    End Sub

#End Region


#Region "ConsultarFabricantes"

    Private Sub ConsultarFabricantes()

        Console.WriteLine("  ----   FABRICANTES   ---- ")

        Dim listaFabricantes As List(Of Fabricante) = FabricanteService.ListarFabricantes()

        For Each f As Fabricante In listaFabricantes
            Console.WriteLine(f)
        Next

    End Sub

#End Region


End Module

