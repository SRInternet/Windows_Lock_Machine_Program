Imports System.Security.Principal
Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TopMost = True
        Timer1.Enabled = True
    End Sub

    Private Sub Form3_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        e.Cancel = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim identity = WindowsIdentity.GetCurrent()
        Dim principal = New WindowsPrincipal(identity)
        Dim isElevated As Boolean = principal.IsInRole(WindowsBuiltInRole.Administrator)
        If isElevated Then
            Timer1.Enabled = False
            Form4.Show()
            Dim unused1 = Shell("cmd /c taskkill /f /im taskmgr.exe", vbHide)
            Hide()
        Else
            Timer1.Enabled = False
            Dim unused = MsgBox("请求的操作需要提升。", vbCritical, "错误")
            End
        End If
    End Sub

    Private Sub Form3_DpiChangedBeforeParent(sender As Object, e As EventArgs) Handles Me.DpiChangedBeforeParent

    End Sub

    Private Sub Form3_Shown(sender As Object, e As EventArgs) Handles Me.Shown
    End Sub
End Class