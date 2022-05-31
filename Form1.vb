Imports System.Math
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports ComputeSharp


Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadDefaultSettings()
        Randomize()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Static running As Boolean = False

        Dim canvasSize As Size
        Dim agentNum As Integer

        Try
            canvasSize = New Size(CInt(txtCanvasWidth.Text), CInt(txtCanvasHeight.Text))
            Agent.SetBounds(canvasSize)
            agentNum = CInt(txtAgentNum.Text)
            Agent.SetRadius(txtRadius.Text)
        Catch ex As Exception
            MsgBox("Incorrect paramater(s): " + ex.Message)
            Exit Sub
        End Try

        Static mapholder As New PictureBox()
        Static t As Threading.Thread

        If running Then
            End
        Else
            mapholder = New PictureBox()
            mapholder.Size = New Size(canvasSize.Width, canvasSize.Height)
            mapholder.Location = New Point(150, 0)
            Me.Controls.Add(mapholder)
            t = New Threading.Thread(Sub() Run(agentNum, mapholder, canvasSize))
            t.Start()
            Button2.Text = "End Sim"
            running = True
        End If

    End Sub

    Sub Run(numAgents As Integer, mapHolder As PictureBox, CanvasSize As Size)
        Dim agents(numAgents - 1) As Agent

        Dim canvas As New Bitmap(CanvasSize.Width, CanvasSize.Height)
        Dim cTools As New AgentCanvasTools()

        Dim l = Graphics.FromImage(canvas)
        mapHolder.Image = canvas

        For i = 0 To agents.Length - 1
            agents(i) = New Agent
        Next
        For j = 0 To 100
            For i = 0 To agents.Length - 1
                agents(i).Move(agents, 1 * 60 / framerate)
                agents(i).Draw(l)
            Next

            'Threading.Thread.Sleep(1 / framerate * 1000)
            'l.FillRectangle(New SolidBrush(Color.FromArgb(255 / 8, Color.Black)), New Rectangle(0, 0, CanvasSize.Width, CanvasSize.Height))
            Threading.Thread.Sleep(10) '
            canvas = cTools.Blur(canvas, TrailDiffusionSpeed)

            mapHolder.Image = canvas
        Next

        'AFTER SIM 

        Dim myform As New Form
        myform.Size = New Size(400, 400)


        Dim rtb As New ListBox
        rtb.Location = New Point(0, 0)
        rtb.Size = myform.Size
        rtb.ScrollAlwaysVisible = True
        myform.Controls.Add(rtb)

        Dim pb As New PictureBox
        pb.Size = canvas.Size
        myform.Controls.Add(pb)



        Dim s1 = canvas.Size
        Dim fmt1 = canvas.PixelFormat
        Dim fmt = New Imaging.PixelFormat()
        Dim rect = New Rectangle(0, 0, s1.Width, s1.Height)
        Dim bmp1Data = canvas.LockBits(rect, Imaging.ImageLockMode.ReadOnly, fmt1)
        Dim bpp1 As Byte = 4
        If fmt1 = Imaging.PixelFormat.Format24bppRgb Then bpp1 = 3 Else If fmt1 = Imaging.PixelFormat.Format32bppArgb Then bpp1 = 4

        Dim size1 = bmp1Data.Stride * bmp1Data.Height
        Dim data1(size1 - 1) As Byte
        System.Runtime.InteropServices.Marshal.Copy(bmp1Data.Scan0, data1, 0, size1)

        rtb.Items.Add(data1.Length.ToString)
        For Each b As Byte In data1
            rtb.Items.Add(b.ToString)
        Next

        'do stuff!!

        'method 1
        'Using ms As New IO.MemoryStream(data1)
        '    pb.Image = Image.FromStream(ms, True, False) 'error
        'End Using

        'method 2
        pb.Image = New ImageConverter().ConvertFrom(data1) 'error

        myform.ShowDialog()

    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        End
    End Sub

    Private Sub BtnSelectColour_Click(sender As Object, e As EventArgs) Handles btnSelectColour.Click
        Using myColDialog = New ColorDialog()
            myColDialog.ShowHelp = True
            If myColDialog.ShowDialog() = DialogResult.OK Then btnSelectColour.BackColor = myColDialog.Color : btnSelectColour.ForeColor = Color.FromArgb(255 - myColDialog.Color.R, 255 - myColDialog.Color.G, 255 - myColDialog.Color.B) : Agent.SetColour(myColDialog.Color)
        End Using
    End Sub

    Private Sub LoadDefaultSettings()
        Agent.SetColour(Color.White)
        btnSelectColour.ForeColor = Color.Black
        btnSelectColour.BackColor = Color.White
        btnSelectColour.Text = ""

        Button1.Text = "#####"
        Button2.Text = "Start Sim"

        txtAgentNum.Text = "100"
        txtRadius.Text = "7"
        txtCanvasWidth.Text = "100"
        txtCanvasHeight.Text = "100"
    End Sub
End Class