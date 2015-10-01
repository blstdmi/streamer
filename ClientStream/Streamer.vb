Imports System.Net.Sockets
Imports System.Threading
Imports System.Runtime.Serialization.Formatters.Binary
Public Class Streamer
    Private tcpClient As New TcpClient
    Private networkStream As NetworkStream
    Private port As Integer = 1337
    Private start As Boolean = True

    Private Sub PerformStreaming()
        Try
            tcpClient.Connect(addressLabel.Text, port)
            'MsgBox("Client connected !")
            streamingTimer.Start()
        Catch ex As Exception
            'MsgBox("Failed to connect...")
            Debug.WriteLine(ex.ToString())
        End Try
    End Sub

    Private Sub StartStream(sender As Object, e As EventArgs) Handles performBtn.Click
        If start.Equals(True) Then
            performBtn.Text = "Stop"
            start = False
            Me.WindowState = FormWindowState.Minimized
            PerformStreaming()
        Else
            tcpClient.Close()
            streamingTimer.Stop()
            Close()
        End If
    End Sub

    Private Sub Streamer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Debug.WriteLine("Skala: " + My.Settings.imgScale.ToString())
        addressLabel.Text = My.Settings.address.Replace("http://", "")
    End Sub

    Public Function CatchDesktop() As Image
        Dim frame As Rectangle = Nothing
        Dim image As System.Drawing.Bitmap = Nothing
        Dim graph As Graphics = Nothing
        frame = Screen.PrimaryScreen.Bounds
        image = New Bitmap(frame.Width, frame.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        graph = Graphics.FromImage(image)
        graph.CopyFromScreen(frame.X, frame.Y, 0, 0, frame.Size, CopyPixelOperation.SourceCopy)
        Dim imgScale = My.Settings.imgScale / 100
        Dim scale As New Size(frame.Width * imgScale, frame.Height * imgScale)
        Dim resized As New Bitmap(image, scale)
        'Return image
        Return resized
    End Function

    Private Sub SendDesktop()
        Dim bf As New BinaryFormatter
        networkStream = tcpClient.GetStream
        bf.Serialize(networkStream, CatchDesktop())
        If tcpClient.ReceiveTimeout Then
            tcpClient.Close()
        End If
    End Sub

    Private Sub streamingTimer_Tick(sender As Object, e As EventArgs) Handles streamingTimer.Tick
        SendDesktop()
        Thread.Sleep(500)
    End Sub
End Class