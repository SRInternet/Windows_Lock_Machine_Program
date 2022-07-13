Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim yesno
        yesno = MsgBox("注意，一旦开始锁机，则不能终止，请注意保存您的重要文件。锁机期间您将不能使用您的PC！", vbExclamation + vbYesNo, "真的要开始吗？")
        If yesno = vbYes Then
            Form3.Show()
            Hide()
        End If
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form2_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles Me.HelpRequested

    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim unused = MsgBox("本次操作由于这台计算机的限制而被取消，请与您的系统管理员联系。", vbCritical, "限制")
        e.Cancel = True
    End Sub

    Private Sub Form2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim time As Integer
        Dim original_time As Integer
        TextBox1.Enabled = False
        Button2.Enabled = False
        Button1.Enabled = False
        Label1.Visible = False
        Label4.Visible = True
        Label5.Visible = True
        PictureBox1.Visible = True
        Form1.TopMost = True
        Dim unused2 = Shell("cmd /c taskkill /f /im taskmgr.exe", vbHide)
        Try
            original_time = CInt(TextBox2.Text)
            ProgressBar1.Maximum = original_time
            time = CInt(TextBox1.Text)
            time -= 1
            TextBox1.Text = time
            ProgressBar1.Value = ProgressBar1.Value + 1
            If time <= 0 Then
                Timer1.Enabled = True
                TextBox1.Enabled = True
                Button2.Enabled = True
                Button1.Enabled = True
                Label4.Visible = False
                Label5.Text = "锁机已结束"
                PictureBox1.Visible = False
                PictureBox2.Visible = True
                Form1.TopMost = False
                Timer1.Enabled = False
                Me.Text = "Windows 锁机程序（锁机结束） "
                Dim unused1 = MsgBox("锁机已结束！", vbInformation, "时间限制已到")
                End
            End If
        Catch
            Timer1.Enabled = False
            Dim unused = MsgBox("锁机时发生错误，请输入正确的时间！", vbCritical, "错误")
            End
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        e.Handled = Not Char.IsDigit(e.KeyChar) And e.KeyChar <> Chr(8)
    End Sub

    Private Sub Form2_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim unused = Shell("cmd /c taskkill /f /im taskmgr.exe", vbHide)
    End Sub
End Class