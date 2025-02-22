Imports System.Configuration
Imports System.IO
Imports System.Threading

Public Class frmFontManager
#Region "UI Handlers"
    Private Sub frmFontManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetEQInstallDir()
    End Sub

    Private Sub cmbPaths_TextChanged(sender As Object, e As EventArgs) Handles cmbPaths.TextChanged
        Dim zealFound As Boolean = EQPaths.IsZealHere(cmbPaths.Text, True)
        If Not zealFound Then
            cmbPaths.BackColor = SystemColors.Highlight
            cmbPaths.ForeColor = SystemColors.HighlightText
            Return
        End If

        cmbPaths.BackColor = SystemColors.Window
        cmbPaths.ForeColor = SystemColors.WindowText

        ' Load up the fonts - we can trust path exists due to EQPaths.IsZealHere
        RefreshFonts(True)
    End Sub

    Private Sub btnShowExtra_CheckedChanged(sender As Object, e As EventArgs) Handles btnShowExtra.CheckedChanged
        RefreshFonts()
    End Sub

    Private Sub btnReloadFonts_Click(sender As Object, e As EventArgs) Handles btnReloadFonts.Click
        RefreshFonts(True)
    End Sub

    Private Sub btnSelectNone_Click(sender As Object, e As EventArgs) Handles btnSelectNone.Click
        None(tvFonts)
    End Sub

    Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
        Selector.All(tvFonts)
    End Sub

    Private Sub btnSelectSome_Click(sender As Object, e As EventArgs) Handles btnSelectSome.Click
        Some(tvFonts)
    End Sub

    Private Sub btnDeleteSelected_Click(sender As Object, e As EventArgs) Handles btnDeleteSelected.Click
        Dim selectedItems = GetChecked(tvFonts)

        If selectedItems.Count = 0 Then
            ShowError("ERROR 0x11 - No Fonts Selected: Could not delete fonts because no fonts are selected!")
            Return
        End If

        Dim response = ShowQuestion("Are you absolutely sure you wish to continue and delete the selected font files? This process can be reversed by restoring them from the recycle bin.")

        If response = DialogResult.No Then
            Return
        End If

        Dim path = cmbPaths.Text

        If btnShowExtra.Checked Then
            path &= UI_ZEAL_FONTS_EXTRA
        Else
            path &= UI_ZEAL_FONTS
        End If

        Try
            For Each selectedItem In selectedItems
                My.Computer.FileSystem.DeleteFile(path & selectedItem.Text, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
                tvFonts.Nodes.Remove(selectedItem)
            Next

            ShowAlert("Successfully deleted " & selectedItems.Count & " font files from " & path & Environment.NewLine & Environment.NewLine &
                      "If you need to restore them at all, you can restore them from your Recycle Bin")

            RefreshFonts(True)
        Catch ex As Exception When _
                TypeOf ex Is Security.SecurityException OrElse
                TypeOf ex Is UnauthorizedAccessException
            ShowError("ERROR 0x13 - Failed To Delete: Could not delete a font file due to permission issues! Make sure the file exists and the user account is able to manage these files.")
        Catch ex As PathTooLongException
            ShowError("ERROR 0x1F - Path Too Long: Could not delete a font file due to the path being too long!")
        End Try
    End Sub

    Private Sub btnMoveToExtra_Click(sender As Object, e As EventArgs) Handles btnMoveToExtra.Click
        Dim selectedItems = GetCheckedValues(tvFonts)

        If selectedItems.Count = 0 Then
            ShowError("ERROR 0x21 - No Fonts Selected: Could not move fonts because no fonts are selected!")
            Return
        End If

        Dim pathFrom = cmbPaths.Text,
            pathTo = cmbPaths.Text

        If btnShowExtra.Checked Then
            pathFrom &= UI_ZEAL_FONTS_EXTRA
            pathTo &= UI_ZEAL_FONTS
        Else
            pathFrom &= UI_ZEAL_FONTS
            pathTo &= UI_ZEAL_FONTS_EXTRA
        End If

        For Each selectedItem In selectedItems
            My.Computer.FileSystem.MoveFile(pathFrom & selectedItem, pathTo & selectedItem)
        Next

        RefreshFonts(True)
    End Sub

    Private Sub btnOpenDir_Click(sender As Object, e As EventArgs) Handles btnOpenDir.Click
        If IsZealHere(cmbPaths.Text) Then
            Process.Start("explorer.exe", """" & cmbPaths.Text & UI_ZEAL_FONTS & """")
        End If
    End Sub

    Private Sub cmbPaths_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPaths.SelectedIndexChanged
        RefreshFonts()
    End Sub
#End Region

#Region "Methods"
    Private Sub GetEQInstallDir()
        Dim foundLocations As List(Of String) = EQPaths.GetPaths()

        ' Clear and add them to list
        cmbPaths.Items.Clear()
        cmbPaths.Items.AddRange(foundLocations.ToArray())

        ' Select first option, if available
        If cmbPaths.Items.Count > 0 Then
            cmbPaths.SelectedIndex = 0
        End If
    End Sub

    Private Sub LoadFontList(ByRef fonts As List(Of String))
        tvFonts.Nodes.Clear()
        For Each fontFile As String In fonts
            Dim filInfo As New FileInfo(fontFile)
            tvFonts.Nodes.Add(filInfo.Name)
        Next
    End Sub

    Private Sub RefreshFonts(Optional ByVal clearCache As Boolean = False)
        If btnShowExtra.Checked Then
            btnMoveToExtra.Text = "Move to Fonts"
            LoadFontList(EQPaths.GetZealExtraFonts(cmbPaths.Text & EQPaths.UI_ZEAL_FONTS_EXTRA, clearCache))
        Else
            btnMoveToExtra.Text = "Move to Extra"
            LoadFontList(EQPaths.GetZealFonts(cmbPaths.Text & EQPaths.UI_ZEAL_FONTS, clearCache))
        End If
    End Sub
#End Region
End Class