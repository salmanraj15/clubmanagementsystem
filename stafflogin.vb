

Public Class stafflogin
    Private Sub signin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles signin.Click, signin.Click
        Dim connection As New SqlClient.SqlConnection
        Dim command As New SqlClient.SqlCommand
        Dim adaptor As New SqlClient.SqlDataAdapter
        Dim dataset As New DataSet

        connection.ConnectionString = ("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\ClubDatabase.mdf;Integrated Security=True;User Instance=True")
        command.CommandText = "SELECT * FROM [StaffLogin] WHERE Username= '" & UsernameTextBox.Text & "'AND Password='" & PasswordTextBox.Text & "';"
        connection.Open()
        command.Connection = connection
        adaptor.SelectCommand = command
        adaptor.Fill(dataset, "0")
        Dim count = dataset.Tables(0).Rows.Count
        If count > 0 Then
            Menuu.Show()
            Menuu.LinkLabel1.Hide()
            Menuu.LinkLabel2.Hide()
            Me.Close()
        Else
            Label4.Text = "Invalid Username or Password"
            UsernameTextBox.Clear()
            PasswordTextBox.Clear()
        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        End
    End Sub
End Class
