<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Streamer
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
        Me.components = New System.ComponentModel.Container()
        Me.addressLabel = New MetroFramework.Controls.MetroLabel()
        Me.performBtn = New MetroFramework.Controls.MetroButton()
        Me.streamingTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'addressLabel
        '
        Me.addressLabel.AutoSize = True
        Me.addressLabel.Location = New System.Drawing.Point(12, 9)
        Me.addressLabel.Name = "addressLabel"
        Me.addressLabel.Size = New System.Drawing.Size(85, 19)
        Me.addressLabel.TabIndex = 0
        Me.addressLabel.Text = "addressLabel"
        '
        'performBtn
        '
        Me.performBtn.Location = New System.Drawing.Point(12, 31)
        Me.performBtn.Name = "performBtn"
        Me.performBtn.Size = New System.Drawing.Size(155, 35)
        Me.performBtn.TabIndex = 1
        Me.performBtn.Text = "Start"
        'Me.performBtn.UseSelectable = True
        '
        'streamingTimer
        '
        '
        'Streamer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(179, 78)
        Me.Controls.Add(Me.performBtn)
        Me.Controls.Add(Me.addressLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Streamer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Streamer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents addressLabel As MetroFramework.Controls.MetroLabel
    Friend WithEvents performBtn As MetroFramework.Controls.MetroButton
    Friend WithEvents streamingTimer As Timer
End Class
