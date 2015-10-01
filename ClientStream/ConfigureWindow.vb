
'Imports BarcodeLib.BarcodeReader
Imports AForge.Video.DirectShow
Imports System.Net
Imports ZXing

Public Class ConfigureWindow

    Private webcams As FilterInfoCollection
    Private videoSource As VideoCaptureDevice

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Try
            StartWebcam()
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub

    Private Sub ConfigureWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ScaleBar.Value = 100
        ScaleBar.Value = My.Settings.imgScale
        ScaleLabel.Text = String.Format("Skaluj obraz {0}%", ScaleBar.Value.ToString())
        webcams = New FilterInfoCollection(FilterCategory.VideoInputDevice)
        For Each cam As FilterInfo In webcams
            webcamList.Items.Add(cam.Name)
        Next
        If webcamList.Items.Count.Equals(0) Then
            MessageBox.Show("Brak zainstalowanych kamer", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        Else
            webcamList.SelectedIndex = 0
        End If
    End Sub

    Private Sub StartWebcam()
        videoTimer.Enabled = True
        videoTimer.Start()
        videoSource = New VideoCaptureDevice(webcams(webcamList.SelectedIndex).MonikerString)
        videoPlayer.VideoSource = videoSource
        videoPlayer.Start()
    End Sub

    Private Sub ConfigureWindow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        StopWebcam()
    End Sub

    Private Sub StopWebcam()
        videoTimer.Enabled = False
        videoPlayer.Stop()
        Debug.WriteLine("Zakończono")
    End Sub

    Private Sub videoTimer_Tick(sender As Object, e As EventArgs) Handles videoTimer.Tick
        If videoPlayer.GetCurrentVideoFrame() IsNot Nothing Then
            Dim frame As New Bitmap(videoPlayer.GetCurrentVideoFrame)
            Dim reader As New BarcodeReader()
            If frame IsNot Nothing Then
                Dim result = reader.Decode(frame)
                If result IsNot Nothing Then
                    Invoke(New Action(Of Result)(AddressOf ShowResult), result)
                End If
            End If
            frame.Dispose()
            frame = Nothing
            'Dim address As String() = BarcodeReader.read(frame, BarcodeReader.QRCODE)
            'frame.Dispose()
            'If address IsNot Nothing AndAlso address.Count > 0 Then
            '    'Debug.WriteLine(address(0))
            '    If address(0).StartsWith("http://") Then
            '        Debug.WriteLine(address(0))
            '        Debug.WriteLine(UrlValidate(address(0)))
            '        If (UrlValidate(address(0))) Then
            '            StopWebcam()
            '            Debug.WriteLine("Wszystko ok")
            '            My.Settings.address = address(0)
            '            My.Settings.Save()
            '            Dim streamerForm As Streamer = New Streamer()
            '            Hide()
            '            streamerForm.ShowDialog()
            '            Show()
            '        End If
            '    End If
            'End If
        End If
    End Sub

    Private Sub ShowResult(result As Result)
        'currentResult = result
        'txtBarcodeFormat.Text = result.BarcodeFormat.ToString()
        'txtContent.Text = result.Text
        Debug.WriteLine(result.BarcodeFormat.ToString())
        Debug.WriteLine(result.Text)
        Dim address = result.Text
        If address IsNot Nothing Then
            If address.StartsWith("http://") Then
                If (UrlValidate(address + ":5000")) Then
                    StopWebcam()
                    Debug.WriteLine("Wszystko ok")
                    My.Settings.address = address
                    My.Settings.Save()
                    Dim streamerForm As Streamer = New Streamer()
                    Hide()
                    streamerForm.ShowDialog()
                    Show()
                End If
            End If
        End If
    End Sub

    Public Function UrlValidate(ByVal URL As String) As Boolean
        Try
            Dim request As WebRequest = WebRequest.Create(URL)
            Dim response As WebResponse = request.GetResponse()
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Private Sub ScaleBar_Scroll(sender As Object, e As EventArgs) Handles ScaleBar.Scroll
        ScaleLabel.Text = String.Format("Skaluj obraz {0}%", ScaleBar.Value.ToString())
        My.Settings.imgScale = ScaleBar.Value
        My.Settings.Save()
    End Sub
End Class
