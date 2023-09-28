Public Class Form1
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BotonSaludo_Click(sender As Object, e As EventArgs) Handles btnSaludar.Click
        MessageBox.Show("Hola Mundo", "saluditos")

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles LabelNombre.Click

    End Sub
End Class
