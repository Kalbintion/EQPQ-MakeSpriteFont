<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFontManager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFontManager))
        Panel1 = New Panel()
        cmbPaths = New ComboBox()
        lblPath = New Label()
        sc = New SplitContainer()
        btnReloadFonts = New Button()
        btnOpenDir = New Button()
        lblSpacer3 = New Label()
        btnMoveToExtra = New Button()
        btnDeleteSelected = New Button()
        lblSpacer2 = New Label()
        btnShowExtra = New CheckBox()
        lblSpacer = New Label()
        btnSelectSome = New Button()
        btnSelectNone = New Button()
        btnSelectAll = New Button()
        tvFonts = New TreeView()
        Panel1.SuspendLayout()
        CType(sc, ComponentModel.ISupportInitialize).BeginInit()
        sc.Panel1.SuspendLayout()
        sc.Panel2.SuspendLayout()
        sc.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(cmbPaths)
        Panel1.Controls.Add(lblPath)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(450, 29)
        Panel1.TabIndex = 0
        ' 
        ' cmbPaths
        ' 
        cmbPaths.Dock = DockStyle.Fill
        cmbPaths.FormattingEnabled = True
        cmbPaths.Location = New Point(60, 0)
        cmbPaths.Name = "cmbPaths"
        cmbPaths.Size = New Size(390, 23)
        cmbPaths.TabIndex = 1
        ' 
        ' lblPath
        ' 
        lblPath.Dock = DockStyle.Left
        lblPath.Location = New Point(0, 0)
        lblPath.Name = "lblPath"
        lblPath.Size = New Size(60, 29)
        lblPath.TabIndex = 0
        lblPath.Text = "EQ Path:"
        ' 
        ' sc
        ' 
        sc.Dock = DockStyle.Fill
        sc.FixedPanel = FixedPanel.Panel1
        sc.Location = New Point(0, 29)
        sc.Name = "sc"
        ' 
        ' sc.Panel1
        ' 
        sc.Panel1.Controls.Add(btnReloadFonts)
        sc.Panel1.Controls.Add(btnOpenDir)
        sc.Panel1.Controls.Add(lblSpacer3)
        sc.Panel1.Controls.Add(btnMoveToExtra)
        sc.Panel1.Controls.Add(btnDeleteSelected)
        sc.Panel1.Controls.Add(lblSpacer2)
        sc.Panel1.Controls.Add(btnShowExtra)
        sc.Panel1.Controls.Add(lblSpacer)
        sc.Panel1.Controls.Add(btnSelectSome)
        sc.Panel1.Controls.Add(btnSelectNone)
        sc.Panel1.Controls.Add(btnSelectAll)
        sc.Panel1MinSize = 120
        ' 
        ' sc.Panel2
        ' 
        sc.Panel2.Controls.Add(tvFonts)
        sc.Panel2MinSize = 250
        sc.Size = New Size(450, 246)
        sc.SplitterDistance = 120
        sc.TabIndex = 1
        ' 
        ' btnReloadFonts
        ' 
        btnReloadFonts.Dock = DockStyle.Top
        btnReloadFonts.Location = New Point(0, 222)
        btnReloadFonts.Name = "btnReloadFonts"
        btnReloadFonts.Size = New Size(120, 23)
        btnReloadFonts.TabIndex = 39
        btnReloadFonts.Text = "Refresh Listing"
        btnReloadFonts.UseVisualStyleBackColor = True
        ' 
        ' btnOpenDir
        ' 
        btnOpenDir.Dock = DockStyle.Top
        btnOpenDir.Location = New Point(0, 199)
        btnOpenDir.Name = "btnOpenDir"
        btnOpenDir.Size = New Size(120, 23)
        btnOpenDir.TabIndex = 38
        btnOpenDir.Text = "Open Font Folder"
        btnOpenDir.UseVisualStyleBackColor = True
        ' 
        ' lblSpacer3
        ' 
        lblSpacer3.Dock = DockStyle.Top
        lblSpacer3.Location = New Point(0, 177)
        lblSpacer3.Name = "lblSpacer3"
        lblSpacer3.Size = New Size(120, 22)
        lblSpacer3.TabIndex = 37
        ' 
        ' btnMoveToExtra
        ' 
        btnMoveToExtra.Dock = DockStyle.Top
        btnMoveToExtra.Location = New Point(0, 154)
        btnMoveToExtra.Name = "btnMoveToExtra"
        btnMoveToExtra.Size = New Size(120, 23)
        btnMoveToExtra.TabIndex = 36
        btnMoveToExtra.Text = "Move to Extra"
        btnMoveToExtra.UseVisualStyleBackColor = True
        ' 
        ' btnDeleteSelected
        ' 
        btnDeleteSelected.Dock = DockStyle.Top
        btnDeleteSelected.Location = New Point(0, 131)
        btnDeleteSelected.Name = "btnDeleteSelected"
        btnDeleteSelected.Size = New Size(120, 23)
        btnDeleteSelected.TabIndex = 35
        btnDeleteSelected.Text = "Delete Selected"
        btnDeleteSelected.UseVisualStyleBackColor = True
        ' 
        ' lblSpacer2
        ' 
        lblSpacer2.Dock = DockStyle.Top
        lblSpacer2.Location = New Point(0, 109)
        lblSpacer2.Name = "lblSpacer2"
        lblSpacer2.Size = New Size(120, 22)
        lblSpacer2.TabIndex = 34
        ' 
        ' btnShowExtra
        ' 
        btnShowExtra.Appearance = Appearance.Button
        btnShowExtra.AutoSize = True
        btnShowExtra.Dock = DockStyle.Top
        btnShowExtra.Location = New Point(0, 84)
        btnShowExtra.Name = "btnShowExtra"
        btnShowExtra.Size = New Size(120, 25)
        btnShowExtra.TabIndex = 33
        btnShowExtra.Text = "Show Extra Fonts"
        btnShowExtra.TextAlign = ContentAlignment.MiddleCenter
        btnShowExtra.UseVisualStyleBackColor = True
        ' 
        ' lblSpacer
        ' 
        lblSpacer.Dock = DockStyle.Top
        lblSpacer.Location = New Point(0, 69)
        lblSpacer.Name = "lblSpacer"
        lblSpacer.Size = New Size(120, 15)
        lblSpacer.TabIndex = 32
        ' 
        ' btnSelectSome
        ' 
        btnSelectSome.Dock = DockStyle.Top
        btnSelectSome.Location = New Point(0, 46)
        btnSelectSome.Name = "btnSelectSome"
        btnSelectSome.Size = New Size(120, 23)
        btnSelectSome.TabIndex = 31
        btnSelectSome.Text = "Select Some"
        btnSelectSome.UseVisualStyleBackColor = True
        ' 
        ' btnSelectNone
        ' 
        btnSelectNone.Dock = DockStyle.Top
        btnSelectNone.Location = New Point(0, 23)
        btnSelectNone.Name = "btnSelectNone"
        btnSelectNone.Size = New Size(120, 23)
        btnSelectNone.TabIndex = 30
        btnSelectNone.Text = "Select None"
        btnSelectNone.UseVisualStyleBackColor = True
        ' 
        ' btnSelectAll
        ' 
        btnSelectAll.Dock = DockStyle.Top
        btnSelectAll.Location = New Point(0, 0)
        btnSelectAll.Name = "btnSelectAll"
        btnSelectAll.Size = New Size(120, 23)
        btnSelectAll.TabIndex = 1
        btnSelectAll.Text = "Select All"
        btnSelectAll.UseVisualStyleBackColor = True
        ' 
        ' tvFonts
        ' 
        tvFonts.CheckBoxes = True
        tvFonts.Dock = DockStyle.Fill
        tvFonts.Location = New Point(0, 0)
        tvFonts.Name = "tvFonts"
        tvFonts.Size = New Size(326, 246)
        tvFonts.TabIndex = 0
        ' 
        ' frmFontManager
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(450, 275)
        Controls.Add(sc)
        Controls.Add(Panel1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MinimumSize = New Size(463, 314)
        Name = "frmFontManager"
        Text = "EQPQ - MakeSpriteFont - Font Manager"
        Panel1.ResumeLayout(False)
        sc.Panel1.ResumeLayout(False)
        sc.Panel1.PerformLayout()
        sc.Panel2.ResumeLayout(False)
        CType(sc, ComponentModel.ISupportInitialize).EndInit()
        sc.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents sc As SplitContainer
    Friend WithEvents btnSelectAll As Button
    Friend WithEvents tvFonts As TreeView
    Friend WithEvents lblPath As Label
    Friend WithEvents cmbPaths As ComboBox
    Friend WithEvents btnReloadFonts As Button
    Friend WithEvents btnOpenDir As Button
    Friend WithEvents lblSpacer3 As Label
    Friend WithEvents btnMoveToExtra As Button
    Friend WithEvents btnDeleteSelected As Button
    Friend WithEvents lblSpacer2 As Label
    Friend WithEvents btnShowExtra As CheckBox
    Friend WithEvents lblSpacer As Label
    Friend WithEvents btnSelectSome As Button
    Friend WithEvents btnSelectNone As Button
End Class
