Imports System.IO
Imports System.Text.RegularExpressions
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
        Dim foundLocations As List(Of String) = EQPaths.GetPaths()

        ' Clear and add them to list
        cmbOutputTo.Items.Clear()
        cmbOutputTo.Items.AddRange(foundLocations.ToArray())

        ' Select first option, if available
        If cmbOutputTo.Items.Count > 0 Then
            cmbOutputTo.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnFontSelectAll_Click(sender As Object, e As EventArgs) Handles btnFontSelectAll.Click
        Selector.All(tvFonts)
    End Sub

    Private Sub btnFontSelectNone_Click(sender As Object, e As EventArgs) Handles btnFontSelectNone.Click
        Selector.None(tvFonts)
        For Each node As TreeNode In tvFonts.Nodes
            node.Checked = False
        Next
    End Sub

    Private Sub btnFontSelectSome_Click(sender As Object, e As EventArgs) Handles btnFontSelectSome.Click
        Selector.Some(tvFonts)
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

        Dim zealFound As Boolean = EQPaths.IsZealHere(bPath)
        If Not zealFound Then Return

        Dim fontList As New List(Of String)

        For Each node As TreeNode In tvFonts.Nodes
            If node.Checked Then
                fontList.Add(node.Text)
            End If
        Next

        If fontList.Count <= 0 Then
            ShowError("ERROR 0x01 - No Fonts Selected: Could not create sprite fonts because there are none selected!")
            Return
        End If

        Dim fontSize As Integer = nudFontSize.Value
        If fontSize < nudFontSize.Minimum Or fontSize > nudFontSize.Maximum Then
            ShowError("ERROR 0x02 - Size Out Of Range: Could not create sprite fonts because the font size is out of range!" & Environment.NewLine &
                      "Got: " & fontSize & ", Expected: " & nudFontSize.Minimum & " to " & nudFontSize.Maximum)
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
        Dim fontStyle As String = "REGULAR"

        If fontStyleRegular Then
            fontStyle = "Regular"
        ElseIf fontStyleBold Then
            fontStyle = "Bold"
        ElseIf fontStyleItalic Then
            fontStyle = "Italic"
        ElseIf fontStyleStrike Then
            fontStyle = "Strikeout"
        ElseIf fontStyleUnderline Then
            fontStyle = "Underline"
        End If

        ' Progress Indicators
        Dim pMult As Integer = 1
        If My.Settings.UseAdvancedFontSize Then
            pMult = txtFontSizes.Text.Split(";").Length
        End If
        Dim pMax As Integer = fontList.Count * pMult

        AppendPrevEQPath(cmbOutputTo.Text)
        SetProgress(0, pMax)

        ' Do the actual handling
        Dim fontSizes As String() = nudFontSize.Value.ToString().Split(";")
        If My.Settings.UseAdvancedFontSize Then
            fontSizes = txtFontSizes.Text.Split(";")
        End If

        For Each font As String In fontList
            Dim cmdString As String
            For Each curFontSize As String In fontSizes
                cmdString = MakeCommandArguments(font, curFontSize, fontStyle, chkSharpen.Checked, bPath)

                ExecuteMakeSpriteFont(cmdString)
                UpdateProgress(pbarCreate.Value + 1, pMax)
            Next
        Next
    End Sub

    Private Function MakeCommandArguments(ByRef fontName As String, ByRef fontSize As String, ByRef fontStyle As String, ByRef fontSharp As Boolean, ByRef basePath As String) As String
        Dim out As String = ""

        out = """" & fontName & """ "
        Select Case fontStyle.ToLower()
            Case "regular"
                out &= "/FontStyle:Regular "
            Case "bold"
                out &= "/FontStyle:Bold "
            Case "italic"
                out &= "/FontStyle:Italic "
            Case "strikeout"
                out &= "/FontStyle:Strikeout "
            Case "underline"
                out &= "/FontStyle:Underline "
        End Select

        out &= "/FontSize:" & fontSize & " "

        If fontSharp Then
            out &= "/Sharp "
        End If

        out &= MakeOutputFileName(fontName, fontSize, fontStyle, fontSharp, basePath)

        Return out
    End Function

    Private Function MakeOutputFileName(ByRef fontName As String, ByRef fontSize As String, ByRef fontStyle As String, ByRef fontSharp As Boolean, ByRef basePath As String) As String
        Dim out As String = ""

        out = fontName.Replace(" ", "_")
        out &= "_" & fontStyle
        out &= "_" & fontSize
        If fontSharp Then
            out &= "_sharp"
        End If

        out &= ".spritefont"

        out = """" & basePath & out.ToLower() & """"

        Return out
    End Function

    Private Sub ExecuteMakeSpriteFont(ByVal command As String)
        Dim proc As New ProcessStartInfo
        proc.FileName = ".\lib\MakeSpriteFont.exe"
        proc.Arguments = command
        proc.UseShellExecute = True
        proc.CreateNoWindow = True
        proc.WindowStyle = ProcessWindowStyle.Hidden
        Dim execproc As Process = Process.Start(proc)
        If Not My.Settings.SuperFastRaster Then
            execproc.WaitForExit(My.Settings.ProcessTimeout * 1000)
        End If
    End Sub

    Private Sub SetProgress(ByVal cur As Integer, ByVal max As Integer)
        pbarCreate.Maximum = max
        UpdateProgress(cur, max)
    End Sub

    Private Sub UpdateProgress(ByVal cur As Integer, ByVal max As Integer)
        pbarCreate.Value = cur
        lblProgress.Text = cur & " / " & max
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

    Private Sub btnFontManager_Click(sender As Object, e As EventArgs) Handles btnFontManager.Click
        frmFontManager.Show()
    End Sub
End Class
