Imports System.Net.Sockets
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Threading
Imports System.Drawing.Bitmap
Imports System.Deployment
Imports System.IO

Module Module1
    Dim client As New TcpClient
    Dim port As Integer
    Dim server As TcpListener
    Dim ns As NetworkStream
    Dim listening As New Thread(AddressOf Listen)
    Dim GetImage As New Thread(AddressOf ReceiveImage)

    Private Function DelFile(number As Integer) As Boolean
        Try
            For index As Integer = 0 To number - 1 Step 1
                Dim fileName As String = String.Format("resources\{0}.jpg", number.ToString())
                If File.Exists(fileName) = True Then
                    File.Delete(fileName)
                    Debug.WriteLine("Usunieto: " + fileName)
                End If
            Next
        Catch ex As Exception

        End Try
    End Function

    Private Sub ReceiveImage()
        Dim bf As New BinaryFormatter
        Dim counter As Integer = 0
        While client.Connected = True
            Try
                If counter = 4 Then
                    counter = 0
                    DelFile(counter)
                End If
                Dim fileName As String = String.Format("resources//{0}.jpg", counter.ToString())
                Debug.WriteLine(fileName)
                ns = client.GetStream
                Dim bm As System.Drawing.Bitmap
                bm = bf.Deserialize(ns)
                bm.Save(fileName)
                'Console.WriteLine(bm.GetType)
                'PictureBox1.Image = bm
                counter += 1
                client.SendTimeout = 1
            Catch
                Debug.WriteLine("przerwano")
                DelFile(0)
                Environment.Exit(1)
            Finally
                Debug.WriteLine("Ok")
            End Try

        End While
    End Sub

    Private Sub Listen()
        While client.Connected = False
            server.Start()
            client = server.AcceptTcpClient
        End While
        GetImage.Start()
    End Sub

    Sub Main()
        port = Integer.Parse("1337")
        server = New TcpListener(port)
        listening.Start()
    End Sub

End Module
