<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHelp
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHelp))
        wb = New WebBrowser()
        SuspendLayout()
        ' 
        ' wb
        ' 
        wb.Dock = DockStyle.Fill
        wb.Location = New Point(0, 0)
        wb.Name = "wb"
        wb.ScriptErrorsSuppressed = True
        wb.Size = New Size(569, 450)
        wb.TabIndex = 0
        ' 
        ' frmHelp
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(569, 450)
        Controls.Add(wb)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmHelp"
        Text = "EQPQ - MakeSpriteFont - Help"
        ResumeLayout(False)
    End Sub

    Friend WithEvents wb As WebBrowser
End Class
