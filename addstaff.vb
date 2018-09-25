Public Class addstaff

    Private Sub StaffLoginBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StaffLoginBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.StaffLoginBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ClubDatabaseDataSet2)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ConnectionString As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\USERS\SALMAN RAJ\DOCUMENTS\VISUAL STUDIO 2008\PROJECTS\WINDOWSAPPLICATION1\CLUBDATABASE.MDF;Integrated Security=True;User Instance=True"
        Dim name, pass As String
        Const strInsert As String = "INSERT INTO StaffLogin([Username], [password]) values (@CN,@CD)"
        Dim con1 As New SqlClient.SqlConnection(ConnectionString)
        Dim cmdInsert As New SqlClient.SqlCommand(strInsert, con1)
        con1.Open()
        For Each DGR As DataGridViewRow In StaffLoginDataGridView.Rows
            If Not DGR.IsNewRow Then
                name = DGR.Cells(0).Value.ToString()
                pass = DGR.Cells(1).Value.ToString()
                With cmdInsert
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@CN", name)
                    .Parameters.AddWithValue("@CD", pass)
                    .ExecuteNonQuery()
                End With
            End If
        Next
        con1.Close()
    End Sub
End Class