Imports System

Module Program
    Private personas As List(Of Persona) = New List(Of Persona)()
    Sub Main(args As String())
        While True
            Console.WriteLine("----------------------------------------------------------------------")
            Console.WriteLine("menu dowhile")
            Console.WriteLine("1. Agregar persona")
            Console.WriteLine("2. Agregar notas")
            Console.WriteLine("3. Editar notass")
            Console.WriteLine("4. Ver notas")
            Console.WriteLine("5. Salir")
            Console.Write("Seleccione una opcion: ")

            Dim opcion As Integer = Integer.Parse(Console.ReadLine())

            Select Case opcion
                Case 1
                    AgregarNotas()
                Case 2
                    EditarNotas()
                Case 3
                    VerNotas()
                Case 5
                    Exit Sub
                Case Else
                    Console.WriteLine("Opción inválida. Intente nuevamente.")
            End Select

            Console.WriteLine()
        End While
    End Sub


#Region "AgregarNotas"

    Private Sub AgregarNotas()

        If personas.Count = 0 Then
            Console.WriteLine("No hay personas registradas. Agregue una persona primero.")
            Return
        End If

        Console.Write("Ingrese el ID de la persona: ")
        Dim id As Integer = Integer.Parse(Console.ReadLine())

        Dim persona As Persona = personas.FirstOrDefault(Function(p) p.ID = id)

        If persona Is Nothing Then
            Console.WriteLine("No se encontró ninguna persona con ese ID.")
            Return
        End If

        Console.Write("Ingrese la nota: ")
        Dim nota As Integer = Integer.Parse(Console.ReadLine())

        persona.Notas.Add(nota)
        Console.WriteLine("Nota agregada exitosamente.")

    End Sub

#End Region



#Region "Visualizar notas por id"

    Private Sub VerNotas()

        Console.Write("Ingrese el ID de la persona: ")
        Dim id As Integer = Integer.Parse(Console.ReadLine())

        Dim persona As Persona = personas.FirstOrDefault(Function(p) p.ID = id)

        If persona Is Nothing Then
            Console.WriteLine("No se encontró ninguna persona con ese ID.")
            Return
        End If

        Console.WriteLine("INFORME DE NOTAS")
        Console.WriteLine("ID: " & persona.ID)
        Console.WriteLine("Nombre: " & persona.Nombre)
        Console.WriteLine("Notas actuales:")
        For i As Integer = 0 To persona.Notas.Count - 1
            Console.WriteLine(persona.Notas(i))
        Next

    End Sub

#End Region



#Region "Editar Notas"
    Private Sub EditarNotas()

        If personas.Count = 0 Then
            Console.WriteLine("No hay personas registradas. Agregue una persona primero.")
            Return
        End If

        Console.Write("Ingrese el ID de la persona: ")
        Dim id As Integer = Integer.Parse(Console.ReadLine())

        Dim persona As Persona = personas.FirstOrDefault(Function(p) p.ID = id)

        If persona Is Nothing Then
            Console.WriteLine("No se encontró ninguna persona con ese ID.")
            Return
        End If

        Console.WriteLine("Notas actuales:")
        For i As Integer = 0 To persona.Notas.Count - 1
            Console.WriteLine("INDICE/NOTA")
            Console.WriteLine(i & "  /   " & persona.Notas(i))
        Next

        Console.WriteLine()
        Console.Write("Ingrese el índice de la nota que desea editar: ")
        Dim indice As Integer = Integer.Parse(Console.ReadLine())

        If indice >= 0 AndAlso indice < persona.Notas.Count Then
            Console.Write("Ingrese la nueva nota: ")
            Dim nuevaNota As Integer = Integer.Parse(Console.ReadLine())

            persona.Notas(indice) = nuevaNota
            Console.WriteLine("Nota editada exitosamente.")
        Else
            Console.WriteLine("Índice inválido. Intente nuevamente.")
        End If

    End Sub

#End Region

End Module
