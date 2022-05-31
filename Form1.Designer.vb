<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.btnSelectColour = New System.Windows.Forms.Button()
        Me.txtAgentNum = New System.Windows.Forms.TextBox()
        Me.txtCanvasWidth = New System.Windows.Forms.TextBox()
        Me.txtCanvasHeight = New System.Windows.Forms.TextBox()
        Me.lblWidth = New System.Windows.Forms.Label()
        Me.lblHeight = New System.Windows.Forms.Label()
        Me.lblAgentNum = New System.Windows.Forms.Label()
        Me.lblColSelect = New System.Windows.Forms.Label()
        Me.lblRadius = New System.Windows.Forms.Label()
        Me.txtRadius = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 415)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnSelectColour
        '
        Me.btnSelectColour.Location = New System.Drawing.Point(4, 57)
        Me.btnSelectColour.Name = "btnSelectColour"
        Me.btnSelectColour.Size = New System.Drawing.Size(86, 23)
        Me.btnSelectColour.TabIndex = 2
        Me.btnSelectColour.Text = "SelectColour"
        Me.btnSelectColour.UseVisualStyleBackColor = True
        '
        'txtAgentNum
        '
        Me.txtAgentNum.Location = New System.Drawing.Point(6, 101)
        Me.txtAgentNum.Name = "txtAgentNum"
        Me.txtAgentNum.Size = New System.Drawing.Size(100, 23)
        Me.txtAgentNum.TabIndex = 3
        '
        'txtCanvasWidth
        '
        Me.txtCanvasWidth.Location = New System.Drawing.Point(4, 150)
        Me.txtCanvasWidth.Name = "txtCanvasWidth"
        Me.txtCanvasWidth.Size = New System.Drawing.Size(42, 23)
        Me.txtCanvasWidth.TabIndex = 4
        '
        'txtCanvasHeight
        '
        Me.txtCanvasHeight.Location = New System.Drawing.Point(52, 150)
        Me.txtCanvasHeight.Name = "txtCanvasHeight"
        Me.txtCanvasHeight.Size = New System.Drawing.Size(42, 23)
        Me.txtCanvasHeight.TabIndex = 5
        '
        'lblWidth
        '
        Me.lblWidth.AutoSize = True
        Me.lblWidth.Location = New System.Drawing.Point(5, 132)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.Size = New System.Drawing.Size(42, 15)
        Me.lblWidth.TabIndex = 6
        Me.lblWidth.Text = "Width:"
        '
        'lblHeight
        '
        Me.lblHeight.AutoSize = True
        Me.lblHeight.Location = New System.Drawing.Point(53, 132)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(46, 15)
        Me.lblHeight.TabIndex = 7
        Me.lblHeight.Text = "Height:"
        '
        'lblAgentNum
        '
        Me.lblAgentNum.AutoSize = True
        Me.lblAgentNum.Location = New System.Drawing.Point(4, 83)
        Me.lblAgentNum.Name = "lblAgentNum"
        Me.lblAgentNum.Size = New System.Drawing.Size(91, 15)
        Me.lblAgentNum.TabIndex = 8
        Me.lblAgentNum.Text = "Num of Agents:"
        '
        'lblColSelect
        '
        Me.lblColSelect.AutoSize = True
        Me.lblColSelect.Location = New System.Drawing.Point(6, 39)
        Me.lblColSelect.Name = "lblColSelect"
        Me.lblColSelect.Size = New System.Drawing.Size(81, 15)
        Me.lblColSelect.TabIndex = 9
        Me.lblColSelect.Text = "Agent Colour:"
        '
        'lblRadius
        '
        Me.lblRadius.AutoSize = True
        Me.lblRadius.Location = New System.Drawing.Point(6, 176)
        Me.lblRadius.Name = "lblRadius"
        Me.lblRadius.Size = New System.Drawing.Size(45, 15)
        Me.lblRadius.TabIndex = 11
        Me.lblRadius.Text = "Radius:"
        '
        'txtRadius
        '
        Me.txtRadius.Location = New System.Drawing.Point(5, 194)
        Me.txtRadius.Name = "txtRadius"
        Me.txtRadius.Size = New System.Drawing.Size(42, 23)
        Me.txtRadius.TabIndex = 10
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.lblRadius)
        Me.Controls.Add(Me.txtRadius)
        Me.Controls.Add(Me.lblColSelect)
        Me.Controls.Add(Me.lblAgentNum)
        Me.Controls.Add(Me.lblHeight)
        Me.Controls.Add(Me.lblWidth)
        Me.Controls.Add(Me.txtCanvasHeight)
        Me.Controls.Add(Me.txtCanvasWidth)
        Me.Controls.Add(Me.txtAgentNum)
        Me.Controls.Add(Me.btnSelectColour)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents btnSelectColour As Button
    Friend WithEvents txtAgentNum As TextBox
    Friend WithEvents txtCanvasWidth As TextBox
    Friend WithEvents txtCanvasHeight As TextBox
    Friend WithEvents lblWidth As Label
    Friend WithEvents lblHeight As Label
    Friend WithEvents lblAgentNum As Label
    Friend WithEvents lblColSelect As Label
    Friend WithEvents lblRadius As Label
    Friend WithEvents txtRadius As TextBox
End Class
