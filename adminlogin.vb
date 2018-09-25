Public Class adminlogin

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub signin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles signin.Click
        If UsernameTextBox.Text = "admin" And PasswordTextBox.Text = "admin" Then
            Menuu.Show()
            Me.Close()
        ElseIf UsernameTextBox.Text <> "admin" Then
            MsgBox("Invalid Username!! Try again.")
            UsernameTextBox.Text = ""
        ElseIf PasswordTextBox.Text <> "admin" Then
            MsgBox("Invalid Password!! Try again.")
            PasswordTextBox.Text = ""
        Else
            MsgBox("Invalid Username and Password!! Try again.")
            PasswordTextBox.Text = ""
            UsernameTextBox.Text = ""
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        End
    End Sub
End Class
