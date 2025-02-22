<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        btnHelp = New Button()
        dlgFolder = New FolderBrowserDialog()
        ttHelp = New ToolTip(components)
        txtExtraArgs = New TextBox()
        lblExtraArgs = New Label()
        nudFontSize = New NumericUpDown()
        lblFontSize = New Label()
        radUnderline = New RadioButton()
        radStrikeout = New RadioButton()
        radItalic = New RadioButton()
        radBold = New RadioButton()
        radRegular = New RadioButton()
        Label4 = New Label()
        Label3 = New Label()
        tvFonts = New TreeView()
        btnFontSelectSome = New Button()
        btnFontSelectNone = New Button()
        btnFontSelectAll = New Button()
        lblOutput = New Label()
        txtFontSizes = New TextBox()
        Label2 = New Label()
        pnlExtraArgs = New Panel()
        btnCreateSpriteFonts = New Button()
        Panel2 = New Panel()
        Panel1 = New Panel()
        scPrimary = New SplitContainer()
        scSecondary = New SplitContainer()
        pnlFontButtons = New Panel()
        Label1 = New Label()
        btnFontManager = New Button()
        lblProgress = New Label()
        pbarCreate = New ProgressBar()
        btnSettings = New Button()
        btnAbout = New Button()
        Panel4 = New Panel()
        cmbOutputTo = New ComboBox()
        Button1 = New Button()
        Panel3 = New Panel()
        chkSharpen = New CheckBox()
        CType(nudFontSize, ComponentModel.ISupportInitialize).BeginInit()
        pnlExtraArgs.SuspendLayout()
        Panel2.SuspendLayout()
        Panel1.SuspendLayout()
        CType(scPrimary, ComponentModel.ISupportInitialize).BeginInit()
        scPrimary.Panel2.SuspendLayout()
        scPrimary.SuspendLayout()
        CType(scSecondary, ComponentModel.ISupportInitialize).BeginInit()
        scSecondary.Panel1.SuspendLayout()
        scSecondary.Panel2.SuspendLayout()
        scSecondary.SuspendLayout()
        pnlFontButtons.SuspendLayout()
        Panel4.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnHelp
        ' 
        btnHelp.Location = New Point(82, 372)
        btnHelp.Name = "btnHelp"
        btnHelp.Size = New Size(75, 23)
        btnHelp.TabIndex = 13
        btnHelp.Text = "Help"
        btnHelp.UseVisualStyleBackColor = True
        ' 
        ' txtExtraArgs
        ' 
        txtExtraArgs.Dock = DockStyle.Fill
        txtExtraArgs.Location = New Point(100, 0)
        txtExtraArgs.Name = "txtExtraArgs"
        txtExtraArgs.Size = New Size(220, 23)
        txtExtraArgs.TabIndex = 1
        txtExtraArgs.Text = "/TextureFormat:CompressedMono"
        ttHelp.SetToolTip(txtExtraArgs, "ADVANCED. Extra arguments to pass to MakeSpriteFont.")
        ' 
        ' lblExtraArgs
        ' 
        lblExtraArgs.Dock = DockStyle.Left
        lblExtraArgs.Location = New Point(0, 0)
        lblExtraArgs.Name = "lblExtraArgs"
        lblExtraArgs.Size = New Size(100, 25)
        lblExtraArgs.TabIndex = 0
        lblExtraArgs.Text = "Extra Arguments:"
        ttHelp.SetToolTip(lblExtraArgs, "ADVANCED. Extra arguments to pass to MakeSpriteFont.")
        ' 
        ' nudFontSize
        ' 
        nudFontSize.Dock = DockStyle.Fill
        nudFontSize.Location = New Point(100, 0)
        nudFontSize.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        nudFontSize.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudFontSize.Name = "nudFontSize"
        nudFontSize.Size = New Size(220, 23)
        nudFontSize.TabIndex = 1
        ttHelp.SetToolTip(nudFontSize, "Size of the font to render out")
        nudFontSize.Value = New Decimal(New Integer() {32, 0, 0, 0})
        ' 
        ' lblFontSize
        ' 
        lblFontSize.Dock = DockStyle.Left
        lblFontSize.Location = New Point(0, 0)
        lblFontSize.Name = "lblFontSize"
        lblFontSize.Size = New Size(100, 25)
        lblFontSize.TabIndex = 0
        lblFontSize.Text = "Font Size:"
        lblFontSize.TextAlign = ContentAlignment.MiddleRight
        ttHelp.SetToolTip(lblFontSize, "Size of the font to render out")
        ' 
        ' radUnderline
        ' 
        radUnderline.AutoSize = True
        radUnderline.Location = New Point(206, 28)
        radUnderline.Name = "radUnderline"
        radUnderline.Size = New Size(76, 19)
        radUnderline.TabIndex = 5
        radUnderline.Text = "Underline"
        ttHelp.SetToolTip(radUnderline, "Sets rendered font as underlined.")
        radUnderline.UseVisualStyleBackColor = True
        ' 
        ' radStrikeout
        ' 
        radStrikeout.AutoSize = True
        radStrikeout.Location = New Point(106, 28)
        radStrikeout.Name = "radStrikeout"
        radStrikeout.Size = New Size(72, 19)
        radStrikeout.TabIndex = 4
        radStrikeout.Text = "Strikeout"
        ttHelp.SetToolTip(radStrikeout, "Sets rendered font as strikeout.")
        radStrikeout.UseVisualStyleBackColor = True
        ' 
        ' radItalic
        ' 
        radItalic.AutoSize = True
        radItalic.Location = New Point(232, 3)
        radItalic.Name = "radItalic"
        radItalic.Size = New Size(50, 19)
        radItalic.TabIndex = 3
        radItalic.Text = "Italic"
        ttHelp.SetToolTip(radItalic, "Sets rendered font as italic.")
        radItalic.UseVisualStyleBackColor = True
        ' 
        ' radBold
        ' 
        radBold.AutoSize = True
        radBold.Location = New Point(177, 3)
        radBold.Name = "radBold"
        radBold.Size = New Size(49, 19)
        radBold.TabIndex = 2
        radBold.Text = "Bold"
        ttHelp.SetToolTip(radBold, "Sets rendered font as bold.")
        radBold.UseVisualStyleBackColor = True
        ' 
        ' radRegular
        ' 
        radRegular.AutoSize = True
        radRegular.Checked = True
        radRegular.Location = New Point(106, 3)
        radRegular.Name = "radRegular"
        radRegular.Size = New Size(65, 19)
        radRegular.TabIndex = 1
        radRegular.TabStop = True
        radRegular.Text = "Regular"
        ttHelp.SetToolTip(radRegular, "Sets rendered font as regular.")
        radRegular.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.Dock = DockStyle.Left
        Label4.Location = New Point(0, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(100, 52)
        Label4.TabIndex = 0
        Label4.Text = "Font Style:"
        Label4.TextAlign = ContentAlignment.MiddleRight
        ttHelp.SetToolTip(Label4, "Font style.")
        ' 
        ' Label3
        ' 
        Label3.Dock = DockStyle.Left
        Label3.Location = New Point(0, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(100, 25)
        Label3.TabIndex = 0
        Label3.Text = "Sharp:"
        Label3.TextAlign = ContentAlignment.MiddleRight
        ttHelp.SetToolTip(Label3, "Font style.")
        ' 
        ' tvFonts
        ' 
        tvFonts.CheckBoxes = True
        tvFonts.Dock = DockStyle.Fill
        tvFonts.Location = New Point(0, 42)
        tvFonts.Name = "tvFonts"
        tvFonts.Size = New Size(254, 365)
        tvFonts.TabIndex = 4
        ttHelp.SetToolTip(tvFonts, "Select fonts to create fonts for Project Quarm's Zeal")
        ' 
        ' btnFontSelectSome
        ' 
        btnFontSelectSome.Dock = DockStyle.Left
        btnFontSelectSome.Location = New Point(170, 0)
        btnFontSelectSome.Name = "btnFontSelectSome"
        btnFontSelectSome.Size = New Size(85, 27)
        btnFontSelectSome.TabIndex = 4
        btnFontSelectSome.Text = "Select Some"
        ttHelp.SetToolTip(btnFontSelectSome, "Selects some fonts. Supports wildcard expressions using asterisk (*) and supports regex.")
        btnFontSelectSome.UseVisualStyleBackColor = True
        ' 
        ' btnFontSelectNone
        ' 
        btnFontSelectNone.Dock = DockStyle.Left
        btnFontSelectNone.Location = New Point(85, 0)
        btnFontSelectNone.Name = "btnFontSelectNone"
        btnFontSelectNone.Size = New Size(85, 27)
        btnFontSelectNone.TabIndex = 3
        btnFontSelectNone.Text = "Select None"
        ttHelp.SetToolTip(btnFontSelectNone, "Deselects all fonts.")
        btnFontSelectNone.UseVisualStyleBackColor = True
        ' 
        ' btnFontSelectAll
        ' 
        btnFontSelectAll.Dock = DockStyle.Left
        btnFontSelectAll.Location = New Point(0, 0)
        btnFontSelectAll.Name = "btnFontSelectAll"
        btnFontSelectAll.Size = New Size(85, 27)
        btnFontSelectAll.TabIndex = 2
        btnFontSelectAll.Text = "Select All"
        ttHelp.SetToolTip(btnFontSelectAll, "Selects all fonts.")
        btnFontSelectAll.UseVisualStyleBackColor = True
        ' 
        ' lblOutput
        ' 
        lblOutput.Dock = DockStyle.Left
        lblOutput.Location = New Point(0, 0)
        lblOutput.Name = "lblOutput"
        lblOutput.Size = New Size(100, 25)
        lblOutput.TabIndex = 0
        lblOutput.Text = "Output To:"
        lblOutput.TextAlign = ContentAlignment.MiddleRight
        ttHelp.SetToolTip(lblOutput, "Font style.")
        ' 
        ' txtFontSizes
        ' 
        txtFontSizes.Dock = DockStyle.Fill
        txtFontSizes.Location = New Point(100, 0)
        txtFontSizes.Name = "txtFontSizes"
        txtFontSizes.Size = New Size(220, 23)
        txtFontSizes.TabIndex = 2
        txtFontSizes.Text = "32;"
        ttHelp.SetToolTip(txtFontSizes, "Semi-colon separated list of numbers to generate fonts.")
        txtFontSizes.Visible = False
        ' 
        ' Label2
        ' 
        Label2.Dock = DockStyle.Top
        Label2.Location = New Point(0, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(327, 15)
        Label2.TabIndex = 1
        Label2.Text = "Settings"
        Label2.TextAlign = ContentAlignment.TopCenter
        ' 
        ' pnlExtraArgs
        ' 
        pnlExtraArgs.Controls.Add(txtExtraArgs)
        pnlExtraArgs.Controls.Add(lblExtraArgs)
        pnlExtraArgs.Location = New Point(3, 135)
        pnlExtraArgs.Name = "pnlExtraArgs"
        pnlExtraArgs.Size = New Size(320, 25)
        pnlExtraArgs.TabIndex = 2
        ' 
        ' btnCreateSpriteFonts
        ' 
        btnCreateSpriteFonts.Location = New Point(124, 197)
        btnCreateSpriteFonts.Name = "btnCreateSpriteFonts"
        btnCreateSpriteFonts.Size = New Size(75, 23)
        btnCreateSpriteFonts.TabIndex = 12
        btnCreateSpriteFonts.Text = "Create"
        btnCreateSpriteFonts.UseVisualStyleBackColor = True
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(radUnderline)
        Panel2.Controls.Add(radStrikeout)
        Panel2.Controls.Add(radItalic)
        Panel2.Controls.Add(radBold)
        Panel2.Controls.Add(radRegular)
        Panel2.Controls.Add(Label4)
        Panel2.Location = New Point(3, 46)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(320, 52)
        Panel2.TabIndex = 4
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(txtFontSizes)
        Panel1.Controls.Add(nudFontSize)
        Panel1.Controls.Add(lblFontSize)
        Panel1.Location = New Point(3, 17)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(320, 25)
        Panel1.TabIndex = 3
        ' 
        ' scPrimary
        ' 
        scPrimary.Dock = DockStyle.Fill
        scPrimary.IsSplitterFixed = True
        scPrimary.Location = New Point(0, 0)
        scPrimary.Name = "scPrimary"
        scPrimary.Orientation = Orientation.Horizontal
        scPrimary.Panel1Collapsed = True
        ' 
        ' scPrimary.Panel2
        ' 
        scPrimary.Panel2.Controls.Add(scSecondary)
        scPrimary.Size = New Size(585, 407)
        scPrimary.SplitterDistance = 57
        scPrimary.TabIndex = 1
        ' 
        ' scSecondary
        ' 
        scSecondary.Dock = DockStyle.Fill
        scSecondary.Location = New Point(0, 0)
        scSecondary.Name = "scSecondary"
        ' 
        ' scSecondary.Panel1
        ' 
        scSecondary.Panel1.Controls.Add(tvFonts)
        scSecondary.Panel1.Controls.Add(pnlFontButtons)
        scSecondary.Panel1.Controls.Add(Label1)
        ' 
        ' scSecondary.Panel2
        ' 
        scSecondary.Panel2.Controls.Add(btnFontManager)
        scSecondary.Panel2.Controls.Add(lblProgress)
        scSecondary.Panel2.Controls.Add(pbarCreate)
        scSecondary.Panel2.Controls.Add(btnSettings)
        scSecondary.Panel2.Controls.Add(btnAbout)
        scSecondary.Panel2.Controls.Add(btnHelp)
        scSecondary.Panel2.Controls.Add(btnCreateSpriteFonts)
        scSecondary.Panel2.Controls.Add(Panel4)
        scSecondary.Panel2.Controls.Add(Panel3)
        scSecondary.Panel2.Controls.Add(Panel2)
        scSecondary.Panel2.Controls.Add(Panel1)
        scSecondary.Panel2.Controls.Add(pnlExtraArgs)
        scSecondary.Panel2.Controls.Add(Label2)
        scSecondary.Size = New Size(585, 407)
        scSecondary.SplitterDistance = 254
        scSecondary.TabIndex = 0
        ' 
        ' pnlFontButtons
        ' 
        pnlFontButtons.Controls.Add(btnFontSelectSome)
        pnlFontButtons.Controls.Add(btnFontSelectNone)
        pnlFontButtons.Controls.Add(btnFontSelectAll)
        pnlFontButtons.Dock = DockStyle.Top
        pnlFontButtons.Location = New Point(0, 15)
        pnlFontButtons.Name = "pnlFontButtons"
        pnlFontButtons.Size = New Size(254, 27)
        pnlFontButtons.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.Dock = DockStyle.Top
        Label1.Location = New Point(0, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(254, 15)
        Label1.TabIndex = 0
        Label1.Text = "Select Font(s)"
        Label1.TextAlign = ContentAlignment.TopCenter
        ' 
        ' btnFontManager
        ' 
        btnFontManager.Location = New Point(97, 272)
        btnFontManager.Name = "btnFontManager"
        btnFontManager.Size = New Size(126, 23)
        btnFontManager.TabIndex = 18
        btnFontManager.Text = "Manage Zeal Fonts"
        btnFontManager.UseVisualStyleBackColor = True
        ' 
        ' lblProgress
        ' 
        lblProgress.Location = New Point(3, 245)
        lblProgress.Name = "lblProgress"
        lblProgress.Size = New Size(320, 18)
        lblProgress.TabIndex = 17
        lblProgress.Text = "0 / 0"
        lblProgress.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pbarCreate
        ' 
        pbarCreate.Location = New Point(3, 226)
        pbarCreate.Name = "pbarCreate"
        pbarCreate.Size = New Size(320, 16)
        pbarCreate.TabIndex = 16
        ' 
        ' btnSettings
        ' 
        btnSettings.Location = New Point(103, 343)
        btnSettings.Name = "btnSettings"
        btnSettings.Size = New Size(114, 23)
        btnSettings.TabIndex = 15
        btnSettings.Text = "Program Settings"
        btnSettings.UseVisualStyleBackColor = True
        ' 
        ' btnAbout
        ' 
        btnAbout.Location = New Point(163, 372)
        btnAbout.Name = "btnAbout"
        btnAbout.Size = New Size(75, 23)
        btnAbout.TabIndex = 14
        btnAbout.Text = "About"
        btnAbout.UseVisualStyleBackColor = True
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(cmbOutputTo)
        Panel4.Controls.Add(Button1)
        Panel4.Controls.Add(lblOutput)
        Panel4.Location = New Point(3, 166)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(320, 25)
        Panel4.TabIndex = 6
        ' 
        ' cmbOutputTo
        ' 
        cmbOutputTo.Dock = DockStyle.Fill
        cmbOutputTo.FormattingEnabled = True
        cmbOutputTo.Location = New Point(100, 0)
        cmbOutputTo.Name = "cmbOutputTo"
        cmbOutputTo.Size = New Size(195, 23)
        cmbOutputTo.TabIndex = 2
        ' 
        ' Button1
        ' 
        Button1.Dock = DockStyle.Right
        Button1.Location = New Point(295, 0)
        Button1.Name = "Button1"
        Button1.Size = New Size(25, 25)
        Button1.TabIndex = 3
        Button1.Text = "..."
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(chkSharpen)
        Panel3.Controls.Add(Label3)
        Panel3.Location = New Point(3, 104)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(320, 25)
        Panel3.TabIndex = 5
        ' 
        ' chkSharpen
        ' 
        chkSharpen.AutoSize = True
        chkSharpen.Location = New Point(106, 6)
        chkSharpen.Name = "chkSharpen"
        chkSharpen.Size = New Size(15, 14)
        chkSharpen.TabIndex = 1
        chkSharpen.UseVisualStyleBackColor = True
        ' 
        ' frmMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(585, 407)
        Controls.Add(scPrimary)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmMain"
        Text = "EQPQ - MakeSpriteFont"
        CType(nudFontSize, ComponentModel.ISupportInitialize).EndInit()
        pnlExtraArgs.ResumeLayout(False)
        pnlExtraArgs.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        scPrimary.Panel2.ResumeLayout(False)
        CType(scPrimary, ComponentModel.ISupportInitialize).EndInit()
        scPrimary.ResumeLayout(False)
        scSecondary.Panel1.ResumeLayout(False)
        scSecondary.Panel2.ResumeLayout(False)
        CType(scSecondary, ComponentModel.ISupportInitialize).EndInit()
        scSecondary.ResumeLayout(False)
        pnlFontButtons.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnHelp As Button
    Friend WithEvents dlgFolder As FolderBrowserDialog
    Friend WithEvents ttHelp As ToolTip
    Friend WithEvents txtExtraArgs As TextBox
    Friend WithEvents lblExtraArgs As Label
    Friend WithEvents nudFontSize As NumericUpDown
    Friend WithEvents lblFontSize As Label
    Friend WithEvents radUnderline As RadioButton
    Friend WithEvents radStrikeout As RadioButton
    Friend WithEvents radItalic As RadioButton
    Friend WithEvents radBold As RadioButton
    Friend WithEvents radRegular As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tvFonts As TreeView
    Friend WithEvents btnFontSelectSome As Button
    Friend WithEvents btnFontSelectNone As Button
    Friend WithEvents btnFontSelectAll As Button
    Friend WithEvents lblOutput As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents pnlExtraArgs As Panel
    Friend WithEvents btnCreateSpriteFonts As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents scPrimary As SplitContainer
    Friend WithEvents scSecondary As SplitContainer
    Friend WithEvents pnlFontButtons As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents cmbOutputTo As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents chkSharpen As CheckBox
    Friend WithEvents btnAbout As Button
    Friend WithEvents btnSettings As Button
    Friend WithEvents txtFontSizes As TextBox
    Friend WithEvents pbarCreate As ProgressBar
    Friend WithEvents lblProgress As Label
    Friend WithEvents btnFontManager As Button

End Class
