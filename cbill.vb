Public Class cbill

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ConnectionString As String = ("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\USERS\SALMAN RAJ\DOCUMENTS\VISUAL STUDIO 2008\PROJECTS\WINDOWSAPPLICATION1\CLUBDATABASE.MDF;Integrated Security=True;User Instance=True")
        Dim con1 As New SqlClient.SqlConnection(ConnectionString)
        con1.Open()
        Dim tableName As String
        tableName = TextBox1.Text
        Const strInsert As String = "SELECT * FROM [{0}]"
        Dim cmdInsert As New SqlClient.SqlCommand(strInsert, con1)
        cmdInsert.CommandText = String.Format(strInsert, tableName)
        Dim dt As New DataTable
        dt.Load(cmdInsert.ExecuteReader)
        With DataGridView1
            .DataSource = dt
        End With
        Dim sum As Double = 0
        For i As Integer = 0 To DataGridView1.RowCount - 1
            sum += DataGridView1.Rows(i).Cells("TotalDataGridViewTextBoxColumn").Value()
        Next
        Label6.Text = sum
        Label5.Text = sum + (sum * (14 / 100))
        con1.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim sqlConn As New SqlClient.SqlConnection("Data Source=10.0.0.187\SQLEXPRESS;AttachDbFilename=C:\USERS\SALMAN RAJ\DOCUMENTS\VISUAL STUDIO 2008\PROJECTS\WINDOWSAPPLICATION1\CLUBDATABASE.MDF;Integrated Security=True;User Instance=True")
        Dim dap As New SqlClient.SqlDataAdapter("SELECT name,contactno FROM consumer WHERE ID='" & TextBox1.Text & "'", sqlConn)
        Dim ds As New DataSet
        dap.Fill(ds)
        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            TextBox2.Text = ds.Tables(0).Rows(i).Item("name")
            TextBox3.Text = ds.Tables(0).Rows(i).Item("contactno")
        Next
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        End
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        users.Show()
        Me.Close()
    End Sub
End Class