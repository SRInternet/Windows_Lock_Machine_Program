Imports System.ComponentModel
Public Class Form4
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Form2.Show()
        Form2.TextBox2.Text = Form2.TextBox1.Text
        Form2.Text = "Windows 锁机程序（正在锁机，限制为 " & Form2.TextBox1.Text & “ 秒）”
        Form2.Timer1.Enabled = True
        Dim unused = Shell("cmd /c taskkill /f /im taskmgr.exe", vbHide)
        Hide()
    End Sub

    Private Sub Form4_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles Me.Load
        TopMost = True
        Timer1.Enabled = True
    End Sub
End Class