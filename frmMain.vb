Imports System.Configuration
Imports System.Diagnostics.Eventing.Reader
Imports System.IO
Imports System.IO.Enumeration
Imports System.Security.AccessControl
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.Win32

Public Class frmMain
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load Settings
        LoadAppSettings()

        ' Get Rest of Program Info
        LoadInstalledFonts()
        GetEQInstallDir()
    End Sub

    Public Sub LoadAppSettings()
        For Each ctrl As Control In Me.Controls
            ctrl.Font = My.Settings.AppFont
            ctrl.ForeColor = My.Settings.AppClrForeground
            ctrl.BackColor = My.Settings.AppClrBackground
        Next

        If My.Settings.UseAdvancedFontSize Then
            Me.nudFontSize.Visible = False
            Me.txtFontSizes.Visible = True
        Else
            Me.nudFontSize.Visible = True
            Me.txtFontSizes.Visible = False
        End If
    End Sub

    Private Sub LoadInstalledFonts()
        tvFonts.Nodes.Clear()

        Dim installedFonts As New System.Drawing.Text.InstalledFontCollection
        Dim fontFamilies As FontFamily() = installedFonts.Families()
        For Each font As FontFamily In fontFamilies
            tvFonts.Nodes.Add(font.Name)
        Next

    End Sub

    Private Sub GetEQInstallDir()
        Dim foundLocations As New List(Of String)
        Dim compatStore As RegistryKey
        Dim compatStoreVals As String()

        Try
            ' HKCU - Compatibility
            compatStore = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Compatibility Assistant\Store")
            compatStoreVals = compatStore.GetValueNames()

            For Each subKey As String In compatStoreVals
                Debug.WriteLine("Checking: " & subKey)
                If subKey.Contains("eqgame.exe") Then
                    subKey = subKey.Replace("eqgame.exe", "")
                    foundLocations.Add(subKey)
                End If
            Next

            compatStore.Close()
        Catch ex As Security.SecurityException
            Debug.Print("Could not access HKCU location for checking eqgame path. Permission denied." & Environment.NewLine & ex.Message)
        End Try

        Try
            ' HKLM - Compatibility
            compatStore = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers")
            compatStoreVals = compatStore.GetValueNames()

            For Each subkey As String In compatStoreVals
                Debug.WriteLine("Checking: " & subkey)
                If subkey.Contains("eqgame.exe") Then
                    subkey = subkey.Replace("eqgame.exe", "")
                    foundLocations.Add(subkey)
                End If
            Next

            compatStore.Close()
        Catch ex As Security.SecurityException
            Debug.Print("Could not access HKLM location for checking eqgame path. Permission denied." & Environment.NewLine & ex.Message)
        End Try

        ' Check misc paths
        Dim pathSegments As String() = {
            "\Sony\EverQuest\",
            "\EverQuest\",
            "\EQ\",
            "\Program Files\Sony\EverQuest\",
            "\Program Files\EverQuest\",
            "\Program Files\EQ\",
            "\Program Files (x86)\Sony\EverQuest\",
            "\Program Files (x86)\EverQuest\",
            "\Program Files (x86)\EQ"
            }

        Try
            For Each drive As DriveInfo In DriveInfo.GetDrives()
                If drive.DriveType <> DriveType.CDRom Then ' Cannot write to cd roms (normally) so ignore these drives
                    For Each pathSegment As String In pathSegments
                        Dim cPath As String = drive.Name & pathSegment
                        If Path.Exists(cPath) Then
                            foundLocations.Add(cPath)
                        End If
                    Next
                End If
            Next
        Catch ex As IOException
            Debug.Print("Could Not access drive information! " & Environment.NewLine & ex.Message)
        Catch ex As UnauthorizedAccessException
            Debug.Print("Could Not access drive information! " & Environment.NewLine & ex.Message)
        End Try

        ' Add paths from Settings
        foundLocations.AddRange(My.Settings.PreviousEQPaths.Split(";"))

        ' Remove duplicates
        foundLocations = foundLocations.Distinct().ToList()

        ' Clear and add them to list
        cmbOutputTo.Items.Clear()
        cmbOutputTo.Items.AddRange(foundLocations.ToArray())

        ' Select first option, if available
        If cmbOutputTo.Items.Count > 0 Then
            cmbOutputTo.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnFontSelectAll_Click(sender As Object, e As EventArgs) Handles btnFontSelectAll.Click
        For Each node As TreeNode In tvFonts.Nodes
            node.Checked = True
        Next
    End Sub

    Private Sub btnFontSelectNone_Click(sender As Object, e As EventArgs) Handles btnFontSelectNone.Click
        For Each node As TreeNode In tvFonts.Nodes
            node.Checked = False
        Next
    End Sub

    Private Sub btnFontSelectSome_Click(sender As Object, e As EventArgs) Handles btnFontSelectSome.Click
        Dim searchOn = InputBox("Select items based on entered text. Use wildcard (*) to select multiple. Search pattern accepts Regular Expression." & Environment.NewLine & Environment.NewLine &
                                          "To cancel, Leave blank Or use the cancel button.", "Select Some", "")

        If searchOn.Length = 0 Then
            Return
        End If

        ' Determine search type
        Dim reBasicString As New Regex("^[a-zA-Z0-9 ]{1,}$")
        Dim reWildcardString As New Regex("^[a-z-A-Z0-9 *]{1,}$")
        Dim reRegexString As New Regex(searchOn, RegexOptions.IgnoreCase)
        Dim reSearchOn As Regex
        If My.Settings.AlwaysUseRegex Then
            If reBasicString.IsMatch(searchOn) Then
                Debug.Print("Basic Search")
                reSearchOn = New Regex(searchOn, RegexOptions.IgnoreCase)
            ElseIf reWildcardString.IsMatch(searchOn) Then
                Debug.Print("Wildcard Search")
                reSearchOn = New Regex(searchOn.Replace("*", ".*"), RegexOptions.IgnoreCase)
            Else
                Debug.Print("RegEx Search")
                reSearchOn = reRegexString
            End If

            Debug.Print(searchOn & Environment.NewLine & reSearchOn.ToString)

            For Each node As TreeNode In tvFonts.Nodes
                node.Checked = reSearchOn.IsMatch(node.Text)
            Next
        Else
            If reBasicString.IsMatch(searchOn) Then
                For Each node As TreeNode In tvFonts.Nodes
                    node.Checked = node.Text.Contains(searchOn)
                Next

                Return
            ElseIf reWildcardString.IsMatch(searchOn) Then
                Dim wildcardParts As String() = searchOn.Split("*")
                Dim lastPartIdx As Integer = 0
                Dim found As Boolean = True
                For Each node As TreeNode In tvFonts.Nodes
                    For Each wildcardPart As String In wildcardParts
                        Dim tempIdx As Integer = node.Text.IndexOf(wildcardPart, lastPartIdx)
                        If tempIdx = -1 Then
                            found = False
                            Exit For
                        Else
                            lastPartIdx = tempIdx
                        End If
                    Next
                    If found Then
                        node.Checked = True
                    End If
                    found = True
                    lastPartIdx = 0
                Next
            Else
                reSearchOn = reRegexString
                Debug.Print(searchOn & Environment.NewLine & reSearchOn.ToString)

                For Each node As TreeNode In tvFonts.Nodes
                    node.Checked = reSearchOn.IsMatch(node.Text)
                Next
            End If

        End If
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        frmAbout.ShowDialog()
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        frmHelp.Show()
    End Sub

    Private Sub btnCreateSpriteFonts_Click(sender As Object, e As EventArgs) Handles btnCreateSpriteFonts.Click
        ' Validation
        ' Base Path
        Dim bPath As String = Path.GetFullPath(cmbOutputTo.Text)
        If Not Path.Exists(bPath) Then
            MessageBox.Show(Me, "ERROR 0xF1 - Path Not Valid: The provided path is invalid! Please make sure the path supplied is to the Quarm directory where Zeal is installed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End If

        ' Zeal
        bPath &= "\uifiles\zeal"
        If Not Path.Exists(bPath) Then
            MessageBox.Show(Me, "ERROR 0xF2 - Path Not Valid: The provided path does not seem to have zeal installed! Please make sure the path supplied is to the Quarm directory where Zeal is installed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End If

        ' Zeal Fonts
        bPath &= "\fonts\"
        If Not Path.Exists(bPath) Then
            MessageBox.Show(Me, "ERROR 0xF3 - Path Not Valid: The provided path does not seem to have a zeal fonts folder! Please make sure the path supplied is to the Quarm directory where Zeal is installed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End If

        Dim fontList As New List(Of String)

        For Each node As TreeNode In tvFonts.Nodes
            If node.Checked Then
                fontList.Add(node.Text)
            End If
        Next

        If fontList.Count <= 0 Then
            MessageBox.Show(Me, "ERROR 0x01 - No Fonts Selected: Could not create sprite fonts because there are none selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End If

        Dim fontSize As Integer = nudFontSize.Value
        If fontSize < nudFontSize.Minimum Or fontSize > nudFontSize.Maximum Then
            MessageBox.Show(Me, "ERROR 0x02 - Size Out Of Range: Could not create sprite fonts because the font size is out of range!" & Environment.NewLine &
                            "Got: " & fontSize & ", Expected: " & nudFontSize.Minimum & " to " & nudFontSize.Maximum, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return
        End If

        Dim fontStyleRegular As Boolean = radRegular.Checked,
            fontStyleBold As Boolean = radBold.Checked,
            fontStyleItalic As Boolean = radItalic.Checked,
            fontStyleStrike As Boolean = radStrikeout.Checked,
            fontStyleUnderline As Boolean = radUnderline.Checked
        If Not fontStyleRegular And Not fontStyleBold And Not fontStyleItalic And Not fontStyleStrike And Not fontStyleUnderline Then
            fontStyleRegular = True
        End If

        ' Command setup
        Dim cmdSuffix As String = ""
        Dim filSuffix As String = ""

        If fontStyleRegular Then
            cmdSuffix &= "/FontStyle:Regular "
            filSuffix &= "_regular"
        ElseIf fontStyleBold Then
            cmdSuffix &= "/FontStyle:Bold "
            filSuffix &= "_bold"
        ElseIf fontStyleItalic Then
            cmdSuffix &= "/FontStyle:Italic "
            filSuffix &= "_italic"
        ElseIf fontStyleStrike Then
            cmdSuffix &= "/FontStyle:Strikeout "
            filSuffix &= "_strikeout"
        ElseIf fontStyleUnderline Then
            cmdSuffix &= "/FontStyle:Underline "
            filSuffix &= "_underline"
        End If

        cmdSuffix &= "/FontSize:" & nudFontSize.Value & " "
        filSuffix &= "_" & nudFontSize.Value

        If chkSharpen.Checked Then
            cmdSuffix &= "/Sharp "
            filSuffix &= "_sharp"
        End If

        cmdSuffix &= txtExtraArgs.Text & " "

        AppendPrevEQPath(cmbOutputTo.Text)

        pbarCreate.Value = 0
        pbarCreate.Maximum = fontList.Count
        lblProgress.Text = "0 / " & fontList.Count

        For Each font As String In fontList
            Dim filName As String = font.ToLower().Replace(" ", "_") & filSuffix & ".spritefont"
            Dim outName As String = """" & bPath & filName & """"
            Dim cmd As String = """" & font & """ " & cmdSuffix & outName
            Dim proc As New ProcessStartInfo
            proc.FileName = ".\lib\MakeSpriteFont.exe"
            proc.Arguments = cmd
            proc.UseShellExecute = True
            proc.CreateNoWindow = True
            proc.WindowStyle = ProcessWindowStyle.Hidden
            Dim execProc As Process = Process.Start(proc)
            If Not My.Settings.SuperFastRaster Then
                execProc.WaitForExit()
            End If
            pbarCreate.Value += 1
            lblProgress.Text = pbarCreate.Value & " / " & fontList.Count
        Next
    End Sub

    Private Sub AppendPrevEQPath(ByRef path As String)
        Dim previousPaths As New List(Of String)

        Dim prevPaths As String() = My.Settings.PreviousEQPaths.Split(";")
        For Each prevPath As String In prevPaths
            previousPaths.Add(prevPath)
        Next

        previousPaths.Add(cmbOutputTo.Text)

        previousPaths = previousPaths.Distinct().ToList()

        My.Settings.PreviousEQPaths = String.Join(";", previousPaths.ToArray())
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        frmSettings.Show()
    End Sub
End Class
