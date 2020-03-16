Public Class Form1

    '/////////////////////////////////////////////////////////////////////////////////////////
    'Real Progress Bar . (se muestra el Progreso Real)
    '
    'Se necesita :
    '1 Progressbar.

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ProgressBar1.Value = 0 ' resetiamos la barra de progreso.
        Dim input As Integer() = {1, 2, 3, 5, 7}

        Dim output As New List(Of Integer)

        Dim Progresodebarra As Integer = 0

        ProgressBar1.Maximum = input.Count
        output.Clear()
        For i As Integer = 0 To input.Length - 1
            For j As Integer = 0 To input.Length - 1
                If input(i) <> input(j) AndAlso input(i) < 5 Then
                    Dim result As Integer = (input(i) * 10 + input(j))
                    output.Add(result)
                End If
            Next j
            Progresodebarra += 1
            ProgressBar1.Value = Progresodebarra
        Next i

        ListBox1.Items.AddRange(output.Cast(Of Object).Distinct().ToArray)
        Progresodebarra = 0 'Ponemos en 0 como estaba al principio por si acaso volvemos a presionar.
    End Sub

    '/////////////////////////////////////////////////////////////////////////////////////////
    'Fake Progress Bar . (se muestra un Progreso Falso)
    '
    'Se necesita :
    '1 Timer .
    '1 Progressbar.

    Dim Fake_output As New List(Of Integer)
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ProgressBar1.Value = 0 ' resetiamos la barra de progreso.
        ProgressBar1.Maximum = 100 ' Viene por defecto establecido en la barra de Progreso. pero igual lo declaramos.

        Dim input As Integer() = {1, 2, 3, 5, 7}



        For i As Integer = 0 To input.Length - 1
            For j As Integer = 0 To input.Length - 1
                If input(i) <> input(j) AndAlso input(i) < 5 Then
                    Dim result As Integer = (input(i) * 10 + input(j))
                    Fake_output.Add(result)
                End If
            Next j

        Next i
        Timer1.Enabled = True ' Iniciamos la barra de Progreso
        Timer1.Interval = 100 ' Velocidad con la que carga la barra, con un numero mayor carga mas lento , y con un numero menor carga mas rapido .

    End Sub


    Dim Fake_Progresodebarra As Integer = 0

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Fake_Progresodebarra += 1
        If Fake_Progresodebarra = ProgressBar1.Maximum Then
            'aca  va lo que sucedera cuando la barra este llena. osea lo final.
            ProgressBar1.Value = Fake_Progresodebarra
            ListBox1.Items.AddRange(Fake_output.Cast(Of Object).Distinct().ToArray)
            Fake_Progresodebarra = 0
            Fake_output.Clear()
            Timer1.Enabled = False ' detenemos la timer.
        Else
            ProgressBar1.Value = Fake_Progresodebarra
        End If

    End Sub

End Class
