Module MessageBoxEx
    Public Sub ShowError(ByVal message As String, Optional ByVal title As String = "Error", Optional ByVal buttons As MessageBoxButtons = MessageBoxButtons.OK, Optional ByVal defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1)
        MessageBox.Show(message, title, buttons, MessageBoxIcon.Error, defaultButton)
    End Sub

    Public Sub ShowAlert(ByVal message As String, Optional ByVal title As String = "Alert", Optional ByVal buttons As MessageBoxButtons = MessageBoxButtons.OK, Optional ByVal defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1)
        MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, defaultButton)
    End Sub

    Public Function ShowQuestion(ByVal message As String, Optional ByVal title As String = "Question", Optional ByVal buttons As MessageBoxButtons = MessageBoxButtons.YesNo, Optional ByVal defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button2) As DialogResult
        Return MessageBox.Show(message, title, buttons, MessageBoxIcon.Question, defaultButton)
    End Function
End Module
