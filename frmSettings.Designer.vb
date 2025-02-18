<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        tcSettings = New TabControl()
        tpGeneral = New TabPage()
        GroupBox2 = New GroupBox()
        chkAlwaysUseRegex = New CheckBox()
        Label4 = New Label()
        chkAllowMultiple = New CheckBox()
        Label3 = New Label()
        btnDefaults = New Button()
        GroupBox1 = New GroupBox()
        btnAppClrBackground = New Button()
        txtAppClrBackground = New TextBox()
        btnAppClrForeground = New Button()
        txtAppClrForeground = New TextBox()
        btnAppFont = New Button()
        txtAppFont = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        lblAppFont = New Label()
        dlgFont = New FontDialog()
        dlgColor = New ColorDialog()
        ttInfo = New ToolTip(components)
        tcSettings.SuspendLayout()
        tpGeneral.SuspendLayout()
        GroupBox2.SuspendLayout()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' tcSettings
        ' 
        tcSettings.Controls.Add(tpGeneral)
        tcSettings.Dock = DockStyle.Fill
        tcSettings.Location = New Point(0, 0)
        tcSettings.Name = "tcSettings"
        tcSettings.SelectedIndex = 0
        tcSettings.Size = New Size(518, 179)
        tcSettings.TabIndex = 0
        ' 
        ' tpGeneral
        ' 
        tpGeneral.Controls.Add(GroupBox2)
        tpGeneral.Controls.Add(btnDefaults)
        tpGeneral.Controls.Add(GroupBox1)
        tpGeneral.Location = New Point(4, 24)
        tpGeneral.Name = "tpGeneral"
        tpGeneral.Padding = New Padding(3)
        tpGeneral.Size = New Size(510, 151)
        tpGeneral.TabIndex = 0
        tpGeneral.Text = "General"
        tpGeneral.UseVisualStyleBackColor = True
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(chkAlwaysUseRegex)
        GroupBox2.Controls.Add(Label4)
        GroupBox2.Controls.Add(chkAllowMultiple)
        GroupBox2.Controls.Add(Label3)
        GroupBox2.Location = New Point(257, 6)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(245, 109)
        GroupBox2.TabIndex = 4
        GroupBox2.TabStop = False
        GroupBox2.Text = "Extra"
        ' 
        ' chkAlwaysUseRegex
        ' 
        chkAlwaysUseRegex.AutoSize = True
        chkAlwaysUseRegex.Location = New Point(127, 40)
        chkAlwaysUseRegex.Name = "chkAlwaysUseRegex"
        chkAlwaysUseRegex.Size = New Size(15, 14)
        chkAlwaysUseRegex.TabIndex = 3
        ttInfo.SetToolTip(chkAlwaysUseRegex, "Forces always using Regular Expressions when it comes to ""Select Some""")
        chkAlwaysUseRegex.UseVisualStyleBackColor = True
        chkAlwaysUseRegex.Visible = False
        ' 
        ' Label4
        ' 
        Label4.Location = New Point(6, 39)
        Label4.Name = "Label4"
        Label4.Size = New Size(115, 15)
        Label4.TabIndex = 2
        Label4.Text = "Always Use RegEx:"
        Label4.TextAlign = ContentAlignment.MiddleRight
        ttInfo.SetToolTip(Label4, "Forces always using Regular Expressions when it comes to ""Select Some""")
        Label4.Visible = False
        ' 
        ' chkAllowMultiple
        ' 
        chkAllowMultiple.AutoSize = True
        chkAllowMultiple.Location = New Point(127, 20)
        chkAllowMultiple.Name = "chkAllowMultiple"
        chkAllowMultiple.Size = New Size(15, 14)
        chkAllowMultiple.TabIndex = 1
        ttInfo.SetToolTip(chkAllowMultiple, "Lets you enter multiple font sizes for generation purposes.")
        chkAllowMultiple.UseVisualStyleBackColor = True
        chkAllowMultiple.Visible = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(6, 19)
        Label3.Name = "Label3"
        Label3.Size = New Size(115, 15)
        Label3.TabIndex = 0
        Label3.Text = "Allow Multiple Sizes:"
        ttInfo.SetToolTip(Label3, "Lets you enter multiple font sizes for generation purposes.")
        Label3.Visible = False
        ' 
        ' btnDefaults
        ' 
        btnDefaults.Location = New Point(8, 121)
        btnDefaults.Name = "btnDefaults"
        btnDefaults.Size = New Size(107, 23)
        btnDefaults.TabIndex = 3
        btnDefaults.Text = "Restore Defaults"
        btnDefaults.UseVisualStyleBackColor = True
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(btnAppClrBackground)
        GroupBox1.Controls.Add(txtAppClrBackground)
        GroupBox1.Controls.Add(btnAppClrForeground)
        GroupBox1.Controls.Add(txtAppClrForeground)
        GroupBox1.Controls.Add(btnAppFont)
        GroupBox1.Controls.Add(txtAppFont)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(lblAppFont)
        GroupBox1.Location = New Point(8, 6)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(243, 109)
        GroupBox1.TabIndex = 2
        GroupBox1.TabStop = False
        GroupBox1.Text = "Program"
        ' 
        ' btnAppClrBackground
        ' 
        btnAppClrBackground.Location = New Point(214, 77)
        btnAppClrBackground.Name = "btnAppClrBackground"
        btnAppClrBackground.Size = New Size(23, 23)
        btnAppClrBackground.TabIndex = 9
        btnAppClrBackground.Text = "..."
        btnAppClrBackground.UseVisualStyleBackColor = True
        ' 
        ' txtAppClrBackground
        ' 
        txtAppClrBackground.Location = New Point(81, 77)
        txtAppClrBackground.Name = "txtAppClrBackground"
        txtAppClrBackground.Size = New Size(127, 23)
        txtAppClrBackground.TabIndex = 8
        ' 
        ' btnAppClrForeground
        ' 
        btnAppClrForeground.Location = New Point(214, 48)
        btnAppClrForeground.Name = "btnAppClrForeground"
        btnAppClrForeground.Size = New Size(23, 23)
        btnAppClrForeground.TabIndex = 7
        btnAppClrForeground.Text = "..."
        btnAppClrForeground.UseVisualStyleBackColor = True
        ' 
        ' txtAppClrForeground
        ' 
        txtAppClrForeground.Location = New Point(81, 48)
        txtAppClrForeground.Name = "txtAppClrForeground"
        txtAppClrForeground.Size = New Size(127, 23)
        txtAppClrForeground.TabIndex = 6
        ' 
        ' btnAppFont
        ' 
        btnAppFont.Location = New Point(214, 19)
        btnAppFont.Name = "btnAppFont"
        btnAppFont.Size = New Size(23, 23)
        btnAppFont.TabIndex = 5
        btnAppFont.Text = "..."
        btnAppFont.UseVisualStyleBackColor = True
        ' 
        ' txtAppFont
        ' 
        txtAppFont.Location = New Point(81, 19)
        txtAppFont.Name = "txtAppFont"
        txtAppFont.ReadOnly = True
        txtAppFont.Size = New Size(127, 23)
        txtAppFont.TabIndex = 4
        ' 
        ' Label1
        ' 
        Label1.Location = New Point(6, 77)
        Label1.Name = "Label1"
        Label1.Size = New Size(69, 23)
        Label1.TabIndex = 3
        Label1.Text = "Back Color:"
        Label1.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Label2
        ' 
        Label2.Location = New Point(6, 48)
        Label2.Name = "Label2"
        Label2.Size = New Size(69, 23)
        Label2.TabIndex = 2
        Label2.Text = "Text Color:"
        Label2.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblAppFont
        ' 
        lblAppFont.Location = New Point(6, 19)
        lblAppFont.Name = "lblAppFont"
        lblAppFont.Size = New Size(69, 23)
        lblAppFont.TabIndex = 0
        lblAppFont.Text = "Font:"
        lblAppFont.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' dlgFont
        ' 
        dlgFont.AllowVerticalFonts = False
        dlgFont.MaxSize = 100
        dlgFont.MinSize = 6
        dlgFont.ShowEffects = False
        ' 
        ' dlgColor
        ' 
        dlgColor.AnyColor = True
        dlgColor.FullOpen = True
        dlgColor.SolidColorOnly = True
        ' 
        ' frmSettings
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(518, 179)
        Controls.Add(tcSettings)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "frmSettings"
        Text = "EQPQ - MakeSpriteFont - Settings"
        tcSettings.ResumeLayout(False)
        tpGeneral.ResumeLayout(False)
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents tcSettings As TabControl
    Friend WithEvents tpGeneral As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblAppFont As Label
    Friend WithEvents dlgFont As FontDialog
    Friend WithEvents dlgColor As ColorDialog
    Friend WithEvents btnAppClrBackground As Button
    Friend WithEvents txtAppClrBackground As TextBox
    Friend WithEvents btnAppClrForeground As Button
    Friend WithEvents txtAppClrForeground As TextBox
    Friend WithEvents btnAppFont As Button
    Friend WithEvents txtAppFont As TextBox
    Friend WithEvents btnDefaults As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents chkAllowMultiple As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents chkAlwaysUseRegex As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ttInfo As ToolTip
End Class
