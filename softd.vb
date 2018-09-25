Public Class softd

    Private Sub SoftdrinksBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoftdrinksBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.SoftdrinksBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ClubDatabaseDataSet2)

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim ConnectionString As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\USERS\SALMAN RAJ\DOCUMENTS\VISUAL STUDIO 2008\PROJECTS\WINDOWSAPPLICATION1\CLUBDATABASE.MDF;Integrated Security=True;User Instance=True"
        Dim pid, name, qty, cp, sp As String
        Const strInsert As String = "INSERT INTO Softdrinks([Product ID], [Name], [Quantity], [Cost Price], [Selling Price]) values (@CN,@CD,@PN,@D1,@t1)"
        Dim con1 As New SqlClient.SqlConnection(ConnectionString)
        Dim cmdInsert As New SqlClient.SqlCommand(strInsert, con1)
        con1.Open()
        For Each DGR As DataGridViewRow In SoftdrinksDataGridView.Rows
            If Not DGR.IsNewRow Then
                pid = DGR.Cells(0).Value.ToString()
                name = DGR.Cells(1).Value.ToString()
                qty = DGR.Cells(2).Value.ToString()
                cp = DGR.Cells(3).Value.ToString()
                sp = DGR.Cells(4).Value.ToString()

                With cmdInsert
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@CN", pid)
                    .Parameters.AddWithValue("@CD", name)
                    .Parameters.AddWithValue("@PN", qty)
                    .Parameters.AddWithValue("@D1", cp)
                    .Parameters.AddWithValue("@T1", sp)
                    .ExecuteNonQuery()
                End With
            End If
        Next
        con1.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        additem.Show()
        Me.Close()
    End Sub

End Class