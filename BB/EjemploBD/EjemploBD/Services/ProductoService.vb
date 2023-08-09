
Imports System.Data
Imports System.Data.SqlClient

Module ProductoService

    Dim cn As Conexion = New Conexion()

    Function ListarProductos() As List(Of Producto)

        Dim listaProductos As List(Of Producto) = New List(Of Producto)
        Dim conexion As SqlConnection = cn.Conectar()

        Try

            Dim query As String = "SELECT * FROM productos"
            Dim command As New SqlCommand(query, conexion)

            Dim adapter As New SqlDataAdapter(command)
            Dim dataTable As New DataTable()
            adapter.Fill(dataTable)

            If dataTable.Rows.Count = 0 Then
                Console.WriteLine("No se encontraron registros de Productos.")
            End If

            For Each row As DataRow In dataTable.Rows

                listaProductos.Add(New Producto(
                    Convert.ToInt32(row("idProducto")),
                    row("nombre").ToString(),
                    Convert.ToDecimal(row("precio")),
                    Convert.ToInt32(row("idFabricante"))
                ))

            Next

        Catch ex As Exception

            Console.WriteLine("Error al ejecutar la consulta: " & ex.Message)

        Finally

            cn.Desconectar()

        End Try

        ListarProductos = listaProductos

    End Function



    Function InsertarProducto(producto As Producto) As Boolean

        Dim conexion As SqlConnection = cn.Conectar()

        Try

            Dim query As String = "INSERT INTO productos (nombre, precio, idFabricante) VALUES (@nombre, @precio, @idFabricante)"
            Dim command As New SqlCommand(query, conexion)

            command.Parameters.AddWithValue("@nombre", producto.Nombre)
            command.Parameters.AddWithValue("@precio", producto.Precio)
            command.Parameters.AddWithValue("@idFabricante", producto.IdFabricante)
            command.ExecuteNonQuery()

        Catch ex As Exception

            Console.WriteLine("Error al insertar el producto: " & ex.Message)
            Return False

        Finally

            cn.Desconectar()

        End Try

        Return True

    End Function



End Module
