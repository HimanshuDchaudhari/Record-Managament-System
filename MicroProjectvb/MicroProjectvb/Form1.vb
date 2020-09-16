Public Class Form1

    Private textfile As String = Application.StartupPath & "\textfile.txt"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbcourse.Items.Add("Computer")
        cbcourse.Items.Add("Mechanical")
        cbcourse.Items.Add("EN & TC")
        cbcourse.Items.Add("Eletrical")
        cbcourse.Items.Add("civil")
        cbcourse.Items.Add("Chemical")
        cbcourse.Items.Add("Degsin")

        cbyear.Items.Add("First")
        cbyear.Items.Add("Second")
        cbyear.Items.Add("third")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ListView1.Items.Count = 0 Then
            Dim item1 As ListViewItem
            item1 = ListView1.Items.Add(TextBox1.Text)
            item1.SubItems.Add(TextBox2.Text)
            item1.SubItems.Add(cbcourse.Text)
            item1.SubItems.Add(cbyear.Text)
            item1 = Nothing
        Else
            With ListView1
                Dim additem As ListViewItem
                additem = .FindItemWithText(TextBox1.Text, True, 0, True)
                If Not additem Is Nothing Then
                    MessageBox.Show("student" & TextBox1.Text & "already in the course", "course list", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Else

                    Dim item1 As ListViewItem
                    item1 = ListView1.Items.Add(TextBox1.Text)
                    item1.SubItems.Add(TextBox2.Text)
                    item1.SubItems.Add(cbcourse.Text)
                    item1.SubItems.Add(cbyear.Text)
                    item1 = Nothing

                End If
            End With
        End If
        clear()

    End Sub
    Private Sub clear()
        TextBox1.Clear()
        TextBox2.Clear()
        cbcourse.Text = ""
        cbyear.Text = ""

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim iexit As DialogResult
        iexit = MessageBox.Show("conform if you want to exit ", "close application", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If iexit = DialogResult.Yes Then
            Application.Exit()

        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim item1 As ListViewItem
        item1 = ListView1.SelectedItems(0)
        item1.Remove()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim mywriter As New IO.StreamWriter(textfile)
        For Each item1 As ListViewItem In ListView1.Items
            mywriter.WriteLine(item1.Text & " * " & item1.SubItems(1).Text & " * " & item1.SubItems(2).Text & " * " & item1.SubItems(3).Text)
        Next
        mywriter.Close()
    End Sub
End Class
