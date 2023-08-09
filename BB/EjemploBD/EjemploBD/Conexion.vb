Imports System.Data.SqlClient
Imports System.Data

Public Class Conexion

    Dim connectionString As String = "Data Source=DESK-SASF-061\MSSQLSERVER01;Initial Catalog=tienda;User ID=sa;Password=12345;"
    Dim connection As New SqlConnection(connectionString)


    Function Conectar() As SqlConnection

        Try

            If connection.State = System.Data.ConnectionState.Closed Then
                connection.Open()
            End If

            Conectar = connection

        Catch ex As Exception

            Console.WriteLine("Error al conectar... " & ex.Message)
            Conectar = connection

        End Try

    End Function


    Function Desconectar() As SqlConnection

        Try

            If connection.State = System.Data.ConnectionState.Open Then
                connection.Close()
            End If

            Desconectar = connection

        Catch ex As Exception

            Console.WriteLine("Error al desconectar... " & ex.Message)
            Desconectar = connection

        End Try

    End Function


End Class
