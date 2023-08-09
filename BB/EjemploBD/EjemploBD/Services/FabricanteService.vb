Imports System.Data
Imports System.Data.SqlClient

Module FabricanteService

    Dim cn As Conexion = New Conexion()

    Function ListarFabricantes() As List(Of Fabricante)

        Dim listaFabricantes As List(Of Fabricante) = New List(Of Fabricante)
        Dim conexion As SqlConnection = cn.Conectar()

        Try

            Dim query As String = "SELECT * FROM Fabricantes"
            Dim command As New SqlCommand(query, conexion)

            Dim adapter As New SqlDataAdapter(command)
            Dim dataTable As New DataTable()
            adapter.Fill(dataTable)

            If dataTable.Rows.Count = 0 Then
                Console.WriteLine("No se encontraron registros de Fabricantes.")
            End If

            For Each row As DataRow In dataTable.Rows

                listaFabricantes.Add(New Fabricante(
                    Convert.ToInt32(row("idFabricante")),
                    row("nombre").ToString()
                ))

            Next

        Catch ex As Exception

            Console.WriteLine("Error al ejecutar la consulta: " & ex.Message)

        Finally

            cn.Desconectar()

        End Try

        ListarFabricantes = listaFabricantes

    End Function



    Function ConsultarFabricantePorId(idFabricante As Integer) As Fabricante

        Dim fabricanteEncontrado As Fabricante = Nothing
        Dim conexion As SqlConnection = cn.Conectar()

        Try

            Dim query As String = "SELECT * FROM Fabricantes WHERE idFabricante = @IdFabricante"
            Dim command As New SqlCommand(query, conexion)
            command.Parameters.AddWithValue("@IdFabricante", idFabricante)

            Dim adapter As New SqlDataAdapter(command)
            Dim dataTable As New DataTable()
            adapter.Fill(dataTable)

            If dataTable.Rows.Count > 0 Then

                Dim row As DataRow = dataTable.Rows(0)
                fabricanteEncontrado = New Fabricante(
                    Convert.ToInt32(row("idFabricante")),
                    row("nombre").ToString()
                )

            End If

        Catch ex As Exception
            Console.WriteLine("Error al ejecutar la consulta: " & ex.Message)
        Finally
            cn.Desconectar()
        End Try

        Return fabricanteEncontrado

    End Function



    Function InsertarFabricante(Fabricante As Fabricante) As Boolean

        Dim conexion As SqlConnection = cn.Conectar()

        Try
            Dim query As String = "INSERT INTO Fabricantes (nombre) VALUES (@nombre)"
            Dim command As New SqlCommand(query, conexion)
            command.Parameters.AddWithValue("@nombre", Fabricante.Nombre)
            command.ExecuteNonQuery()

        Catch ex As Exception

            Console.WriteLine("Error al insertar el Fabricante: " & ex.Message)
            Return False

        Finally

            cn.Desconectar()

        End Try

        Return True

    End Function



End Module
