Public Class frmHelp
    Private Sub frmHelp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        wb.Navigate("file:///" & IO.Path.GetFullPath(".\help\index.html"))
    End Sub
End Class