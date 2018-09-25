Public Class nonvegbilling
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        users.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        End
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim sqlConn As New SqlClient.SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=C:\USERS\SALMAN RAJ\DOCUMENTS\VISUAL STUDIO 2008\PROJECTS\WINDOWSAPPLICATION1\CLUBDATABASE.MDF;Integrated Security=True;User Instance=True")
        Dim dap As New SqlClient.SqlDataAdapter("SELECT name,contactno FROM consumer WHERE ID='" & TextBox1.Text & "'", sqlConn)
        Dim ds As New DataSet
        dap.Fill(ds)
        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            TextBox2.Text = ds.Tables(0).Rows(i).Item("name")
            TextBox3.Text = ds.Tables(0).Rows(i).Item("contactno")
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim price, qty, amt As Double
        Try
            price = Convert.ToDouble(TextBox6.Text)
            qty = Convert.ToDouble("0" + TextBox5.Text)
            amt = price * qty
        Catch ex As Exception
            MessageBox.Show("Please enter proper item code, the item code entered is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
        If qty = 0 Then
            MessageBox.Show("Enter Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBox5.Focus()
        Else
            Dim ConnectionString As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\USERS\SALMAN RAJ\DOCUMENTS\VISUAL STUDIO 2008\PROJECTS\WINDOWSAPPLICATION1\CLUBDATABASE.MDF;Integrated Security=True;User Instance=True"
            Dim strUpdate As String = "UPDATE veg SET [Quantity]=[Quantity]-'" + qty.ToString + "' WHERE [Product ID]='" + TextBox7.Text + "'"
            Dim con1 As New SqlClient.SqlConnection(ConnectionString)
            Dim cmdUpdate As New SqlClient.SqlCommand(strUpdate, con1)
            con1.Open()
            cmdUpdate.ExecuteNonQuery()
            Dim nm, cp As String
            Dim tableName As String
            tableName = TextBox1.Text
            Const strInsert As String = "INSERT INTO [{0}]([Name], [Qty], [Price/unit], [Total]) values (@CN,@CD,@PN,@D1)"
            Dim cmdInsert As New SqlClient.SqlCommand(strInsert, con1)
            cmdInsert.CommandText = String.Format(strInsert, tableName)
            nm = TextBox4.Text
            cp = TextBox6.Text

            With cmdInsert
                .Parameters.Clear()
                .Parameters.AddWithValue("@CN", nm)
                .Parameters.AddWithValue("@CD", qty)
                .Parameters.AddWithValue("@PN", cp)
                .Parameters.AddWithValue("@D1", amt)
                .ExecuteNonQuery()
            End With
            Dim sum As Double = 0
            For i As Integer = 0 To DataGridView1.RowCount - 1
                sum += DataGridView1.Rows(i).Cells("dtotal").Value()
            Next
            Label6.Text = sum
            Label5.Text = sum + (sum * (14 / 100))
            con1.Close()
        End If
    End Sub

    Private Sub _111BindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _111BindingNavigatorSaveItem.Click
        Me.Validate()
        Me._111BindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ClubDatabaseDataSet3)

    End Sub

    'Private Sub vegbilling_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    'TODO: This line of code loads data into the 'ClubDatabaseDataSet3._111' table. You can move, or remove it, as needed.
    'Me._111TableAdapter.Fill(Me.ClubDatabaseDataSet3._111)

    'End Sub 


    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged
        Dim id, len As String
        id = TextBox7.Text
        len = id.Length
        If len = 4 Then
            Dim sqlConn As New SqlClient.SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\ClubDatabase.mdf;Integrated Security=True;User Instance=True")
            Dim dap As New SqlClient.SqlDataAdapter("SELECT Name,[Selling Price] FROM nonveg WHERE [Product ID]='" & TextBox7.Text & "'", sqlConn)
            Dim ds As New DataSet
            dap.Fill(ds)
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                TextBox4.Text = ds.Tables(0).Rows(i).Item("Name")
                TextBox6.Text = ds.Tables(0).Rows(i).Item("Selling Price")
            Next
            TextBox5.Focus()
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim amt As Double
        amt = TextBox5.Text * TextBox6.Text
        DataGridView1.Rows.Add(TextBox4.Text, TextBox5.Text, TextBox6.Text, amt)
        Button5.Focus()
    End Sub
End Class