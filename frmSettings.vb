Public Class frmSettings
    Private Sub updateFormSettings()
        For Each ctrl As Control In frmMain.Controls
            ctrl.Font = My.Settings.AppFont
            ctrl.ForeColor = My.Settings.AppClrForeground
            ctrl.BackColor = My.Settings.AppClrBackground
        Next
    End Sub

    Private Sub setFormSettings()
        txtAppFont.Text = My.Settings.AppFont.ToString()

        Dim tempColor As Color = My.Settings.AppClrForeground
        txtAppClrForeground.Text = String.Format("{0:X2}{1:X2}{2:X2}", tempColor.R, tempColor.G, tempColor.B)

        tempColor = My.Settings.AppClrBackground
        txtAppClrBackground.Text = String.Format("{0:X2}{1:X2}{2:X2}", tempColor.R, tempColor.G, tempColor.B)

        chkAllowMultiple.Checked = My.Settings.UseAdvancedFontSize
        chkAlwaysUseRegex.Checked = My.Settings.AlwaysUseRegex
        chkSuperFastRaster.Checked = My.Settings.SuperFastRaster
        nudProcTimeout.Value = My.Settings.ProcessTimeout
    End Sub

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setFormSettings()
    End Sub

    Private Sub btnAppFont_Click(sender As Object, e As EventArgs) Handles btnAppFont.Click
        dlgFont.Font = My.Settings.AppFont

        dlgFont.ShowDialog()
        My.Settings.AppFont = dlgFont.Font()
        txtAppFont.Text = dlgFont.Font().ToString()

        My.Settings.Save()

        updateFormSettings()
    End Sub

    Private Sub btnAppClrForeground_Click(sender As Object, e As EventArgs) Handles btnAppClrForeground.Click
        dlgColor.Color = My.Settings.AppClrForeground

        dlgColor.ShowDialog()
        My.Settings.AppClrForeground = dlgColor.Color()
        txtAppClrForeground.Text = String.Format("{0:X2}{1:X2}{2:X2}", dlgColor.Color.R, dlgColor.Color.G, dlgColor.Color.B)

        My.Settings.Save()

        updateFormSettings()
    End Sub

    Private Sub btnAppClrBackground_Click(sender As Object, e As EventArgs) Handles btnAppClrBackground.Click
        dlgColor.Color = My.Settings.AppClrBackground

        dlgColor.ShowDialog()
        My.Settings.AppClrBackground = dlgColor.Color()
        txtAppClrBackground.Text = String.Format("{0:X2}{1:X2}{2:X2}", dlgColor.Color.R, dlgColor.Color.G, dlgColor.Color.B)

        My.Settings.Save()

        updateFormSettings()
    End Sub

    Private Sub btnDefaults_Click(sender As Object, e As EventArgs) Handles btnDefaults.Click
        Dim res As DialogResult = MessageBox.Show(Me, "Are you sure you wish to reset settings back to default?", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If res = DialogResult.Yes Then
            My.Settings.AppFont = New Font("Segoe UI", 9)
            My.Settings.AppClrForeground = SystemColors.ControlText
            My.Settings.AppClrBackground = SystemColors.Control

            My.Settings.UseAdvancedFontSize = False
            My.Settings.AlwaysUseRegex = True
            My.Settings.SuperFastRaster = True
            My.Settings.ProcessTimeout = 60

            My.Settings.Save()

            updateFormSettings()
            setFormSettings()
        End If
    End Sub

    Private Sub txtAppClrForeground_TextChanged(sender As Object, e As EventArgs) Handles txtAppClrForeground.TextChanged
        Dim chkString As String = txtAppClrForeground.Text
        If chkString.StartsWith("#") Then
            chkString = chkString.Substring(1)
        End If

        If chkString.Length <> 3 And chkString.Length <> 6 Then
            txtAppClrForeground.BackColor = SystemColors.Highlight
            txtAppClrForeground.ForeColor = SystemColors.HighlightText
            Return
        Else
            txtAppClrForeground.BackColor = SystemColors.Window
            txtAppClrForeground.ForeColor = SystemColors.WindowText
        End If

        ' Convert Hex to RGB
        If chkString.Length = 3 Then
            chkString = chkString.Substring(0) & chkString.Substring(0) &
                        chkString.Substring(1) & chkString.Substring(1) &
                        chkString.Substring(2) & chkString.Substring(2)
        End If

        Dim R As Integer = Convert.ToInt32(chkString.Substring(0, 2), 16)
        Dim G As Integer = Convert.ToInt32(chkString.Substring(2, 2), 16)
        Dim B As Integer = Convert.ToInt32(chkString.Substring(4, 2), 16)

        Dim n As Color = Color.FromArgb(255, R, G, B)
        My.Settings.AppClrForeground = n

        updateFormSettings()
    End Sub

    Private Sub txtAppClrBackground_TextChanged(sender As Object, e As EventArgs) Handles txtAppClrBackground.TextChanged
        Dim chkString As String = txtAppClrBackground.Text
        If chkString.StartsWith("#") Then
            chkString = chkString.Substring(1)
        End If

        If chkString.Length <> 3 And chkString.Length <> 6 Then
            txtAppClrBackground.BackColor = SystemColors.Highlight
            txtAppClrBackground.ForeColor = SystemColors.HighlightText
            Return
        Else
            txtAppClrBackground.BackColor = SystemColors.Window
            txtAppClrBackground.ForeColor = SystemColors.WindowText
        End If

        ' Convert Hex to RGB
        If chkString.Length = 3 Then
            chkString = chkString.Substring(0) & chkString.Substring(0) &
                        chkString.Substring(1) & chkString.Substring(1) &
                        chkString.Substring(2) & chkString.Substring(2)
        End If

        Dim R As Integer = Convert.ToInt32(chkString.Substring(0, 2), 16)
        Dim G As Integer = Convert.ToInt32(chkString.Substring(2, 2), 16)
        Dim B As Integer = Convert.ToInt32(chkString.Substring(4, 2), 16)

        Dim n As Color = Color.FromArgb(255, R, G, B)
        My.Settings.AppClrBackground = n

        updateFormSettings()

    End Sub

    Private Sub chkAllowMultiple_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllowMultiple.CheckedChanged
        My.Settings.UseAdvancedFontSize = chkAllowMultiple.Checked
        My.Settings.Save()

        If My.Settings.UseAdvancedFontSize Then
            frmMain.nudFontSize.Visible = False
            frmMain.txtFontSizes.Visible = True
        Else
            frmMain.nudFontSize.Visible = True
            frmMain.txtFontSizes.Visible = False
        End If
    End Sub

    Private Sub chkAlwaysUseRegex_CheckedChanged(sender As Object, e As EventArgs) Handles chkAlwaysUseRegex.CheckedChanged
        My.Settings.AlwaysUseRegex = chkAlwaysUseRegex.Checked
        My.Settings.Save()
    End Sub

    Private Sub nudProcTimeout_ValueChanged(sender As Object, e As EventArgs) Handles nudProcTimeout.ValueChanged
        My.Settings.ProcessTimeout = nudProcTimeout.Value
        My.Settings.Save()
    End Sub

    Private Sub chkSuperFastRaster_CheckedChanged(sender As Object, e As EventArgs) Handles chkSuperFastRaster.CheckedChanged
        My.Settings.SuperFastRaster = chkSuperFastRaster.Checked
        My.Settings.Save()
    End Sub
End Class