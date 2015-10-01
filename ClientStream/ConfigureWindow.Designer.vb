<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigureWindow
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
        Me.components = New System.ComponentModel.Container()
        Me.webcamList = New MetroFramework.Controls.MetroComboBox()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.MetroButton1 = New MetroFramework.Controls.MetroButton()
        Me.videoPlayer = New AForge.Controls.VideoSourcePlayer()
        Me.videoTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ScaleBar = New System.Windows.Forms.TrackBar()
        Me.ScaleLabel = New MetroFramework.Controls.MetroLabel()
        CType(Me.ScaleBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'webcamList
        '
        Me.webcamList.FormattingEnabled = True
        Me.webcamList.ItemHeight = 23
        Me.webcamList.Location = New System.Drawing.Point(126, 12)
        Me.webcamList.Name = "webcamList"
        Me.webcamList.Size = New System.Drawing.Size(206, 29)
        Me.webcamList.TabIndex = 0
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(12, 22)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(108, 19)
        Me.MetroLabel1.TabIndex = 1
        Me.MetroLabel1.Text = "Wybierz kamerę:"
        '
        'MetroButton1
        '
        Me.MetroButton1.Location = New System.Drawing.Point(199, 293)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(133, 50)
        Me.MetroButton1.TabIndex = 2
        Me.MetroButton1.Text = "Uruchom kamerę"
        '
        'videoPlayer
        '
        Me.videoPlayer.Location = New System.Drawing.Point(12, 47)
        Me.videoPlayer.Name = "videoPlayer"
        Me.videoPlayer.Size = New System.Drawing.Size(320, 240)
        Me.videoPlayer.TabIndex = 3
        Me.videoPlayer.Text = "VideoSourcePlayer1"
        Me.videoPlayer.VideoSource = Nothing
        '
        'videoTimer
        '
        '
        'ScaleBar
        '
        Me.ScaleBar.Location = New System.Drawing.Point(12, 293)
        Me.ScaleBar.Maximum = 100
        Me.ScaleBar.Minimum = 10
        Me.ScaleBar.Name = "ScaleBar"
        Me.ScaleBar.Size = New System.Drawing.Size(181, 45)
        Me.ScaleBar.TabIndex = 4
        Me.ScaleBar.TickFrequency = 10
        Me.ScaleBar.Value = 10
        '
        'ScaleLabel
        '
        Me.ScaleLabel.AutoSize = True
        Me.ScaleLabel.Location = New System.Drawing.Point(45, 324)
        Me.ScaleLabel.Name = "ScaleLabel"
        Me.ScaleLabel.Size = New System.Drawing.Size(110, 19)
        Me.ScaleLabel.TabIndex = 5
        Me.ScaleLabel.Text = "Skaluj obraz {0}%"
        '
        'ConfigureWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(344, 351)
        Me.Controls.Add(Me.ScaleLabel)
        Me.Controls.Add(Me.ScaleBar)
        Me.Controls.Add(Me.videoPlayer)
        Me.Controls.Add(Me.MetroButton1)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Controls.Add(Me.webcamList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ConfigureWindow"
        Me.Text = "Ustawienia"
        CType(Me.ScaleBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents webcamList As MetroFramework.Controls.MetroComboBox
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroButton1 As MetroFramework.Controls.MetroButton
    Friend WithEvents videoPlayer As AForge.Controls.VideoSourcePlayer
    Friend WithEvents videoTimer As Timer
    Friend WithEvents ScaleBar As TrackBar
    Friend WithEvents ScaleLabel As MetroFramework.Controls.MetroLabel
End Class
