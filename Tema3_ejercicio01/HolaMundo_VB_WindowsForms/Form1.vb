
Imports Biblioteca


Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nombre = New clsPersona
        nombre.Nombre = txtNombre.Text
        If nombre.Nombre = "" Or nombre.Nombre = " " Then
            advertencia.Text = "El nombre no puede estar vacío"
        Else
            MessageBox.Show("Hola " & nombre.Nombre)
        End If
    End Sub

End Class
