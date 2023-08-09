Imports System.Data
Imports System.Data.SqlClient

Module TiendaServiceSP

    Dim cn As Conexion = New Conexion()

    Function ListarProductos() As List(Of Producto)

        Dim listaProductos As List(Of Producto) = New List(Of Producto)
        Dim conexion As SqlConnection = cn.Conectar()

        Try
            ' Crear un comando para ejecutar el procedimiento almacenado
            Dim command As New SqlCommand()
            command.Connection = conexion
            command.CommandType = CommandType.StoredProcedure
            command.CommandText = "ListarProductos"

            ' Crear un SqlDataAdapter para obtener los resultados del procedimiento almacenado
            Dim adapter As New SqlDataAdapter(command)
            Dim dataTable As New DataTable()
            adapter.Fill(dataTable)

            ' Recorrer las filas del DataTable
            For Each row As DataRow In dataTable.Rows
                listaProductos.Add(New Producto(
                    Convert.ToInt32(row("idProducto")),
                    row("nombre").ToString(),
                    Convert.ToDecimal(row("precio")),
                    Convert.ToInt32(row("idFabricante"))
                ))
            Next

        Catch ex As Exception
            Console.WriteLine("Error al ejecutar el procedimiento almacenado: " & ex.Message)
        Finally
            cn.Desconectar()
        End Try

        ListarProductos = listaProductos

    End Function

    Function InsertarProducto(producto As Producto) As Boolean

        Dim conexion As SqlConnection = cn.Conectar()

        Try
            ' Crear un comando para ejecutar el procedimiento almacenado
            Dim command As New SqlCommand()
            command.Connection = conexion
            command.CommandType = CommandType.StoredProcedure
            command.CommandText = "InsertarProducto"

            ' Agregar los parámetros al comando
            command.Parameters.AddWithValue("@nombre", producto.Nombre)
            command.Parameters.AddWithValue("@precio", producto.Precio)
            command.Parameters.AddWithValue("@idFabricante", producto.IdFabricante)

            ' Ejecutar el comando
            command.ExecuteNonQuery()

            Console.WriteLine("Producto insertado correctamente")

        Catch ex As Exception
            Console.WriteLine("Error al insertar el producto: " & ex.Message)
            Return False
        Finally
            cn.Desconectar()
        End Try

        Return True

    End Function

End Module
