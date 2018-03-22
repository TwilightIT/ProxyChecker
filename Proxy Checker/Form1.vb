Imports System.Net
Imports System.Threading
Imports System.Xml
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.ApplicationServices
Imports Newtonsoft.Json.Linq

Public Class Form1
    Dim good, bad, remaining, loaded As Integer
    Dim log As System.IO.StreamWriter
    Dim file As System.IO.StreamWriter
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label124.Text = DateTime.Now.ToString("dd MMMM yyyy, h:mm:ss tt")
        Control.CheckForIllegalCrossThreadCalls = False
        Timer1.Start()
    End Sub
    ' Time & Date
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label124.Text = DateTime.Now.ToString("dd MMMM yyyy, h:mm:ss tt")
    End Sub
    ' Min & Close
    Private Sub NsLabel13_Click(sender As Object, e As EventArgs) Handles NsLabel13.Click
        Me.Close()
    End Sub
    ' Minimize
    Private Sub NsLabel2_Click(sender As Object, e As EventArgs) Handles NsLabel2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    ' Proxy Tester Start
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NsButton1.Click
        If BackgroundWorker1.WorkerSupportsCancellation Then
            BackgroundWorker1.CancelAsync()
        End If
        Try
            BackgroundWorker1.RunWorkerAsync()
            Label3.Text = "Loaded: " & TextBox1.Lines.Count
        Catch ex As Exception
            If BackgroundWorker1.WorkerSupportsCancellation Then
                BackgroundWorker1.CancelAsync()
            End If
        End Try
    End Sub
    ' Pull free Proxies
    ' US
    Private Sub NsButton4_Click(sender As Object, e As EventArgs)
        Dim c As New WebClient
        c.Proxy = Nothing
        Dim str As String = c.DownloadString("http://pubproxy.com/api/proxy?country=us&limit=20&format=txt&https=true&level=elite&last_check=240")
        TextBox1.Text = str
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim webAddress As String = "http://www.twilightit.co.uk/"
        Process.Start(webAddress)
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Dim webAddress As String = "http://www.twilightit.co.uk/"
        Process.Start(webAddress)
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Dim webAddress As String = "http://www.twilightit.co.uk/"
        Process.Start(webAddress)
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Dim webAddress As String = "http://www.twilightit.co.uk/"
        Process.Start(webAddress)
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Dim webAddress As String = "http://www.twilightit.co.uk/"
        Process.Start(webAddress)
    End Sub

    Private Sub Label124_Click(sender As Object, e As EventArgs) Handles Label124.Click
        Dim webAddress As String = "http://www.twilightit.co.uk/"
        Process.Start(webAddress)
    End Sub

    Private Sub NsLabel8_Click(sender As Object, e As EventArgs) Handles NsLabel8.Click
        Dim webAddress As String = "http://www.twilightit.co.uk/"
        Process.Start(webAddress)
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Dim webAddress As String = "http://www.twilightit.co.uk/"
        Process.Start(webAddress)
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Dim webAddress As String = "http://www.twilightit.co.uk/"
        Process.Start(webAddress)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Dim webAddress As String = "http://www.twilightit.co.uk/"
        Process.Start(webAddress)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Dim webAddress As String = "http://www.twilightit.co.uk/"
        Process.Start(webAddress)
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        For Each line As String In TextBox1.Text.Split(vbCrLf)
            line = line.Replace(vbCr, "").Replace(vbLf, "")
            Try
                Dim myproxy As WebProxy
                myproxy = New WebProxy(line)
                Dim request As HttpWebRequest = HttpWebRequest.Create("https://www.google.com")
                request.Proxy = myproxy
                request.Timeout = 4000
                Dim response As HttpWebResponse = request.GetResponse
                good += 1
                TextBox2.Text += line & vbNewLine
                Label1.Text = "Good: " & TextBox2.Lines.Count - 1
                log = My.Computer.FileSystem.OpenTextFileWriter("C:\log.txt", True)
                log.WriteLine(Label124.Text + ": Checked Proxy - " + line + " this proxy is live! live proxy count: " + good.ToString + " - http://www.twilightit.co.uk")
                log.Close()
            Catch ex As Exception
                bad += 1
                TextBox3.Text += line & vbNewLine
                Label2.Text = "Bad: " & TextBox3.Lines.Count - 1
                log = My.Computer.FileSystem.OpenTextFileWriter("C:\log.txt", True)
                log.WriteLine(Label124.Text + ": Checked Proxy - " + line + " this proxy is Dead! Dead proxy count: " + bad.ToString + " - http://www.twilightit.co.uk")
                log.Close()
            End Try
            remaining = loaded - (good + bad)
            Label4.Text = "Checked: " & remaining.ToString
        Next
        log = My.Computer.FileSystem.OpenTextFileWriter("C:\log.txt", True)
        log.WriteLine(Label124.Text + ": Proxy check completed - Dead proxy count: " + bad.ToString + " Good proxy count: " + good.ToString + " - http://www.twilightit.co.uk")
        log.Close()
        MsgBox("Finished! Good proxies: " & good.ToString)
    End Sub
    ' Proxy Tester End
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NsButton2.Click
        If BackgroundWorker1.WorkerSupportsCancellation Then
            BackgroundWorker1.CancelAsync()
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""

        Label4.Text = "Checked: 0"
        Label3.Text = "Loaded: 0"
        Label2.Text = "Bad: 0"
        Label1.Text = "Good: 0"
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NsButton3.Click
        If BackgroundWorker1.WorkerSupportsCancellation Then
            BackgroundWorker1.CancelAsync()
        End If
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            System.IO.File.WriteAllText(SaveFileDialog1.FileName, TextBox2.Text)
            log = My.Computer.FileSystem.OpenTextFileWriter("C:\log.txt", True)
            log.WriteLine(Label124.Text + ": Succesfully saved good proxys to file " + SaveFileDialog1.FileName + " - http://www.twilightit.co.uk")
            log.Close()
        End If
    End Sub
    ' Proxy Tester End
End Class

