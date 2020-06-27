<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Main_Pic = New System.Windows.Forms.Panel
        Me.MT_Pic = New System.Windows.Forms.PictureBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ControlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox_ZVal = New System.Windows.Forms.TextBox
        Me.Button_SetVals = New System.Windows.Forms.Button
        Me.Label_ZVal = New System.Windows.Forms.Label
        Me.ComboBox_ZVal = New System.Windows.Forms.ComboBox
        Me.Main_Pic.SuspendLayout()
        CType(Me.MT_Pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Main_Pic
        '
        Me.Main_Pic.BackColor = System.Drawing.Color.White
        Me.Main_Pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Main_Pic.Controls.Add(Me.MT_Pic)
        Me.Main_Pic.Location = New System.Drawing.Point(13, 28)
        Me.Main_Pic.Margin = New System.Windows.Forms.Padding(4)
        Me.Main_Pic.Name = "Main_Pic"
        Me.Main_Pic.Size = New System.Drawing.Size(800, 850)
        Me.Main_Pic.TabIndex = 0
        '
        'MT_Pic
        '
        Me.MT_Pic.BackColor = System.Drawing.Color.Transparent
        Me.MT_Pic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MT_Pic.Enabled = False
        Me.MT_Pic.Location = New System.Drawing.Point(0, 0)
        Me.MT_Pic.Name = "MT_Pic"
        Me.MT_Pic.Size = New System.Drawing.Size(796, 846)
        Me.MT_Pic.TabIndex = 0
        Me.MT_Pic.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ControlToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1184, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ControlToolStripMenuItem
        '
        Me.ControlToolStripMenuItem.Name = "ControlToolStripMenuItem"
        Me.ControlToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ControlToolStripMenuItem.Text = "Control"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 890)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1184, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(829, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Z ="
        '
        'TextBox_ZVal
        '
        Me.TextBox_ZVal.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_ZVal.Location = New System.Drawing.Point(866, 56)
        Me.TextBox_ZVal.Multiline = True
        Me.TextBox_ZVal.Name = "TextBox_ZVal"
        Me.TextBox_ZVal.Size = New System.Drawing.Size(306, 132)
        Me.TextBox_ZVal.TabIndex = 4
        '
        'Button_SetVals
        '
        Me.Button_SetVals.Location = New System.Drawing.Point(910, 194)
        Me.Button_SetVals.Name = "Button_SetVals"
        Me.Button_SetVals.Size = New System.Drawing.Size(211, 54)
        Me.Button_SetVals.TabIndex = 5
        Me.Button_SetVals.Text = "Generate Z Function"
        Me.Button_SetVals.UseVisualStyleBackColor = True
        '
        'Label_ZVal
        '
        Me.Label_ZVal.AutoSize = True
        Me.Label_ZVal.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ZVal.Location = New System.Drawing.Point(829, 302)
        Me.Label_ZVal.Name = "Label_ZVal"
        Me.Label_ZVal.Size = New System.Drawing.Size(0, 18)
        Me.Label_ZVal.TabIndex = 6
        '
        'ComboBox_ZVal
        '
        Me.ComboBox_ZVal.FormattingEnabled = True
        Me.ComboBox_ZVal.Items.AddRange(New Object() {"1", "0.1", "0.01", "0.001", "0.0001"})
        Me.ComboBox_ZVal.Location = New System.Drawing.Point(1034, 296)
        Me.ComboBox_ZVal.Name = "ComboBox_ZVal"
        Me.ComboBox_ZVal.Size = New System.Drawing.Size(138, 24)
        Me.ComboBox_ZVal.TabIndex = 7
        Me.ComboBox_ZVal.Text = "0.1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 912)
        Me.Controls.Add(Me.ComboBox_ZVal)
        Me.Controls.Add(Me.Label_ZVal)
        Me.Controls.Add(Me.Button_SetVals)
        Me.Controls.Add(Me.TextBox_ZVal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Main_Pic)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "Line Integral Visualization"
        Me.Main_Pic.ResumeLayout(False)
        CType(Me.MT_Pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Main_Pic As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ControlToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MT_Pic As System.Windows.Forms.PictureBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox_ZVal As System.Windows.Forms.TextBox
    Friend WithEvents Button_SetVals As System.Windows.Forms.Button
    Friend WithEvents Label_ZVal As System.Windows.Forms.Label
    Friend WithEvents ComboBox_ZVal As System.Windows.Forms.ComboBox

End Class
