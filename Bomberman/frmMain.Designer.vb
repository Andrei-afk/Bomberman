<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.GameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu2PlayerGame = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu3PlayerGame = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu4PlayerGame = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.GameArea = New System.Windows.Forms.PictureBox()
        Me.MainScreen = New System.Windows.Forms.PictureBox()
        Me.MenuStrip.SuspendLayout()
        CType(Me.GameArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainScreen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "bomb1")
        Me.ImageList.Images.SetKeyName(1, "bomb2")
        Me.ImageList.Images.SetKeyName(2, "bonusbomb1")
        Me.ImageList.Images.SetKeyName(3, "bonusbomb2")
        Me.ImageList.Images.SetKeyName(4, "bonusfire1")
        Me.ImageList.Images.SetKeyName(5, "bonusfire2")
        Me.ImageList.Images.SetKeyName(6, "firebrick0")
        Me.ImageList.Images.SetKeyName(7, "firebrick1")
        Me.ImageList.Images.SetKeyName(8, "firebrick2")
        Me.ImageList.Images.SetKeyName(9, "firebrick3")
        Me.ImageList.Images.SetKeyName(10, "firebrick4")
        Me.ImageList.Images.SetKeyName(11, "wall")
        Me.ImageList.Images.SetKeyName(12, "C1.gif")
        Me.ImageList.Images.SetKeyName(13, "C2.gif")
        Me.ImageList.Images.SetKeyName(14, "C3.gif")
        Me.ImageList.Images.SetKeyName(15, "C4.gif")
        Me.ImageList.Images.SetKeyName(16, "C5.gif")
        Me.ImageList.Images.SetKeyName(17, "C6.gif")
        Me.ImageList.Images.SetKeyName(18, "C7.gif")
        Me.ImageList.Images.SetKeyName(19, "C8.gif")
        Me.ImageList.Images.SetKeyName(20, "E1.gif")
        Me.ImageList.Images.SetKeyName(21, "E2.gif")
        Me.ImageList.Images.SetKeyName(22, "E3.gif")
        Me.ImageList.Images.SetKeyName(23, "E4.gif")
        Me.ImageList.Images.SetKeyName(24, "E5.gif")
        Me.ImageList.Images.SetKeyName(25, "E6.gif")
        Me.ImageList.Images.SetKeyName(26, "E7.gif")
        Me.ImageList.Images.SetKeyName(27, "E8.gif")
        Me.ImageList.Images.SetKeyName(28, "H1.gif")
        Me.ImageList.Images.SetKeyName(29, "H2.gif")
        Me.ImageList.Images.SetKeyName(30, "H3.gif")
        Me.ImageList.Images.SetKeyName(31, "H4.gif")
        Me.ImageList.Images.SetKeyName(32, "H5.gif")
        Me.ImageList.Images.SetKeyName(33, "H6.gif")
        Me.ImageList.Images.SetKeyName(34, "H7.gif")
        Me.ImageList.Images.SetKeyName(35, "H8.gif")
        Me.ImageList.Images.SetKeyName(36, "N1.gif")
        Me.ImageList.Images.SetKeyName(37, "N2.gif")
        Me.ImageList.Images.SetKeyName(38, "N3.gif")
        Me.ImageList.Images.SetKeyName(39, "N4.gif")
        Me.ImageList.Images.SetKeyName(40, "N5.gif")
        Me.ImageList.Images.SetKeyName(41, "N6.gif")
        Me.ImageList.Images.SetKeyName(42, "N7.gif")
        Me.ImageList.Images.SetKeyName(43, "N8.gif")
        Me.ImageList.Images.SetKeyName(44, "S1.gif")
        Me.ImageList.Images.SetKeyName(45, "S2.gif")
        Me.ImageList.Images.SetKeyName(46, "S3.gif")
        Me.ImageList.Images.SetKeyName(47, "S4.gif")
        Me.ImageList.Images.SetKeyName(48, "S5.gif")
        Me.ImageList.Images.SetKeyName(49, "S6.gif")
        Me.ImageList.Images.SetKeyName(50, "S7.gif")
        Me.ImageList.Images.SetKeyName(51, "S8.gif")
        Me.ImageList.Images.SetKeyName(52, "V1.gif")
        Me.ImageList.Images.SetKeyName(53, "V2.gif")
        Me.ImageList.Images.SetKeyName(54, "V3.gif")
        Me.ImageList.Images.SetKeyName(55, "V4.gif")
        Me.ImageList.Images.SetKeyName(56, "V5.gif")
        Me.ImageList.Images.SetKeyName(57, "V6.gif")
        Me.ImageList.Images.SetKeyName(58, "V7.gif")
        Me.ImageList.Images.SetKeyName(59, "V8.gif")
        Me.ImageList.Images.SetKeyName(60, "W1.gif")
        Me.ImageList.Images.SetKeyName(61, "W2.gif")
        Me.ImageList.Images.SetKeyName(62, "W3.gif")
        Me.ImageList.Images.SetKeyName(63, "W4.gif")
        Me.ImageList.Images.SetKeyName(64, "W5.gif")
        Me.ImageList.Images.SetKeyName(65, "W6.gif")
        Me.ImageList.Images.SetKeyName(66, "W7.gif")
        Me.ImageList.Images.SetKeyName(67, "W8.gif")
        Me.ImageList.Images.SetKeyName(68, "brick")
        '
        'Timer
        '
        Me.Timer.Interval = 1
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "01.gif")
        Me.ImageList1.Images.SetKeyName(1, "02.gif")
        Me.ImageList1.Images.SetKeyName(2, "03.gif")
        Me.ImageList1.Images.SetKeyName(3, "04.gif")
        Me.ImageList1.Images.SetKeyName(4, "05.gif")
        Me.ImageList1.Images.SetKeyName(5, "06.gif")
        Me.ImageList1.Images.SetKeyName(6, "07.gif")
        Me.ImageList1.Images.SetKeyName(7, "08.gif")
        Me.ImageList1.Images.SetKeyName(8, "09.gif")
        Me.ImageList1.Images.SetKeyName(9, "010.gif")
        Me.ImageList1.Images.SetKeyName(10, "011.gif")
        Me.ImageList1.Images.SetKeyName(11, "012.gif")
        Me.ImageList1.Images.SetKeyName(12, "013.gif")
        Me.ImageList1.Images.SetKeyName(13, "014.gif")
        Me.ImageList1.Images.SetKeyName(14, "015.gif")
        Me.ImageList1.Images.SetKeyName(15, "016.gif")
        Me.ImageList1.Images.SetKeyName(16, "017.gif")
        Me.ImageList1.Images.SetKeyName(17, "018.gif")
        Me.ImageList1.Images.SetKeyName(18, "019.gif")
        Me.ImageList1.Images.SetKeyName(19, "020.gif")
        Me.ImageList1.Images.SetKeyName(20, "021.gif")
        Me.ImageList1.Images.SetKeyName(21, "022.gif")
        Me.ImageList1.Images.SetKeyName(22, "023.gif")
        Me.ImageList1.Images.SetKeyName(23, "024.gif")
        Me.ImageList1.Images.SetKeyName(24, "025.gif")
        Me.ImageList1.Images.SetKeyName(25, "11.gif")
        Me.ImageList1.Images.SetKeyName(26, "12.gif")
        Me.ImageList1.Images.SetKeyName(27, "13.gif")
        Me.ImageList1.Images.SetKeyName(28, "14.gif")
        Me.ImageList1.Images.SetKeyName(29, "15.gif")
        Me.ImageList1.Images.SetKeyName(30, "16.gif")
        Me.ImageList1.Images.SetKeyName(31, "17.gif")
        Me.ImageList1.Images.SetKeyName(32, "18.gif")
        Me.ImageList1.Images.SetKeyName(33, "19.gif")
        Me.ImageList1.Images.SetKeyName(34, "110.gif")
        Me.ImageList1.Images.SetKeyName(35, "111.gif")
        Me.ImageList1.Images.SetKeyName(36, "112.gif")
        Me.ImageList1.Images.SetKeyName(37, "113.gif")
        Me.ImageList1.Images.SetKeyName(38, "114.gif")
        Me.ImageList1.Images.SetKeyName(39, "115.gif")
        Me.ImageList1.Images.SetKeyName(40, "116.gif")
        Me.ImageList1.Images.SetKeyName(41, "117.gif")
        Me.ImageList1.Images.SetKeyName(42, "118.gif")
        Me.ImageList1.Images.SetKeyName(43, "119.gif")
        Me.ImageList1.Images.SetKeyName(44, "120.gif")
        Me.ImageList1.Images.SetKeyName(45, "121.gif")
        Me.ImageList1.Images.SetKeyName(46, "122.gif")
        Me.ImageList1.Images.SetKeyName(47, "123.gif")
        Me.ImageList1.Images.SetKeyName(48, "124.gif")
        Me.ImageList1.Images.SetKeyName(49, "125.gif")
        Me.ImageList1.Images.SetKeyName(50, "21.gif")
        Me.ImageList1.Images.SetKeyName(51, "22.gif")
        Me.ImageList1.Images.SetKeyName(52, "23.gif")
        Me.ImageList1.Images.SetKeyName(53, "24.gif")
        Me.ImageList1.Images.SetKeyName(54, "25.gif")
        Me.ImageList1.Images.SetKeyName(55, "26.gif")
        Me.ImageList1.Images.SetKeyName(56, "27.gif")
        Me.ImageList1.Images.SetKeyName(57, "28.gif")
        Me.ImageList1.Images.SetKeyName(58, "29.gif")
        Me.ImageList1.Images.SetKeyName(59, "210.gif")
        Me.ImageList1.Images.SetKeyName(60, "211.gif")
        Me.ImageList1.Images.SetKeyName(61, "212.gif")
        Me.ImageList1.Images.SetKeyName(62, "213.gif")
        Me.ImageList1.Images.SetKeyName(63, "214.gif")
        Me.ImageList1.Images.SetKeyName(64, "215.gif")
        Me.ImageList1.Images.SetKeyName(65, "216.gif")
        Me.ImageList1.Images.SetKeyName(66, "217.gif")
        Me.ImageList1.Images.SetKeyName(67, "218.gif")
        Me.ImageList1.Images.SetKeyName(68, "219.gif")
        Me.ImageList1.Images.SetKeyName(69, "220.gif")
        Me.ImageList1.Images.SetKeyName(70, "221.gif")
        Me.ImageList1.Images.SetKeyName(71, "222.gif")
        Me.ImageList1.Images.SetKeyName(72, "223.gif")
        Me.ImageList1.Images.SetKeyName(73, "224.gif")
        Me.ImageList1.Images.SetKeyName(74, "225.gif")
        Me.ImageList1.Images.SetKeyName(75, "31.gif")
        Me.ImageList1.Images.SetKeyName(76, "32.gif")
        Me.ImageList1.Images.SetKeyName(77, "33.gif")
        Me.ImageList1.Images.SetKeyName(78, "34.gif")
        Me.ImageList1.Images.SetKeyName(79, "35.gif")
        Me.ImageList1.Images.SetKeyName(80, "36.gif")
        Me.ImageList1.Images.SetKeyName(81, "37.gif")
        Me.ImageList1.Images.SetKeyName(82, "38.gif")
        Me.ImageList1.Images.SetKeyName(83, "39.gif")
        Me.ImageList1.Images.SetKeyName(84, "310.gif")
        Me.ImageList1.Images.SetKeyName(85, "311.gif")
        Me.ImageList1.Images.SetKeyName(86, "312.gif")
        Me.ImageList1.Images.SetKeyName(87, "313.gif")
        Me.ImageList1.Images.SetKeyName(88, "314.gif")
        Me.ImageList1.Images.SetKeyName(89, "315.gif")
        Me.ImageList1.Images.SetKeyName(90, "316.gif")
        Me.ImageList1.Images.SetKeyName(91, "317.gif")
        Me.ImageList1.Images.SetKeyName(92, "318.gif")
        Me.ImageList1.Images.SetKeyName(93, "319.gif")
        Me.ImageList1.Images.SetKeyName(94, "320.gif")
        Me.ImageList1.Images.SetKeyName(95, "321.gif")
        Me.ImageList1.Images.SetKeyName(96, "322.gif")
        Me.ImageList1.Images.SetKeyName(97, "323.gif")
        Me.ImageList1.Images.SetKeyName(98, "324.gif")
        Me.ImageList1.Images.SetKeyName(99, "325.gif")
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "0")
        Me.ImageList2.Images.SetKeyName(1, "1")
        Me.ImageList2.Images.SetKeyName(2, "2")
        Me.ImageList2.Images.SetKeyName(3, "3")
        Me.ImageList2.Images.SetKeyName(4, "draw")
        Me.ImageList2.Images.SetKeyName(5, "Enter to Continue.jpg")
        '
        'MenuStrip
        '
        Me.MenuStrip.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GameToolStripMenuItem, Me.mnuAbout})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(304, 24)
        Me.MenuStrip.TabIndex = 2
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'GameToolStripMenuItem
        '
        Me.GameToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu2PlayerGame, Me.mnu3PlayerGame, Me.mnu4PlayerGame, Me.mnuExit})
        Me.GameToolStripMenuItem.Name = "GameToolStripMenuItem"
        Me.GameToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.GameToolStripMenuItem.Text = "Game"
        '
        'mnu2PlayerGame
        '
        Me.mnu2PlayerGame.BackColor = System.Drawing.Color.Beige
        Me.mnu2PlayerGame.Name = "mnu2PlayerGame"
        Me.mnu2PlayerGame.Size = New System.Drawing.Size(152, 22)
        Me.mnu2PlayerGame.Text = "2 Player Game"
        '
        'mnu3PlayerGame
        '
        Me.mnu3PlayerGame.BackColor = System.Drawing.Color.Beige
        Me.mnu3PlayerGame.Name = "mnu3PlayerGame"
        Me.mnu3PlayerGame.Size = New System.Drawing.Size(152, 22)
        Me.mnu3PlayerGame.Text = "3 Player Game"
        '
        'mnu4PlayerGame
        '
        Me.mnu4PlayerGame.BackColor = System.Drawing.Color.Beige
        Me.mnu4PlayerGame.Name = "mnu4PlayerGame"
        Me.mnu4PlayerGame.Size = New System.Drawing.Size(152, 22)
        Me.mnu4PlayerGame.Text = "4 Player Game"
        '
        'mnuExit
        '
        Me.mnuExit.BackColor = System.Drawing.Color.Beige
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(152, 22)
        Me.mnuExit.Text = "Exit"
        '
        'mnuAbout
        '
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Size = New System.Drawing.Size(52, 20)
        Me.mnuAbout.Text = "About"
        '
        'GameArea
        '
        Me.GameArea.BackColor = System.Drawing.SystemColors.ControlText
        Me.GameArea.BackgroundImage = Global.Bomberman.My.Resources.Resources.floor
        Me.GameArea.Location = New System.Drawing.Point(0, 24)
        Me.GameArea.Margin = New System.Windows.Forms.Padding(0)
        Me.GameArea.Name = "GameArea"
        Me.GameArea.Size = New System.Drawing.Size(304, 304)
        Me.GameArea.TabIndex = 0
        Me.GameArea.TabStop = False
        Me.GameArea.Visible = False
        '
        'MainScreen
        '
        Me.MainScreen.BackColor = System.Drawing.SystemColors.ControlText
        Me.MainScreen.BackgroundImage = CType(resources.GetObject("MainScreen.BackgroundImage"), System.Drawing.Image)
        Me.MainScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MainScreen.Location = New System.Drawing.Point(0, 24)
        Me.MainScreen.Name = "MainScreen"
        Me.MainScreen.Size = New System.Drawing.Size(304, 304)
        Me.MainScreen.TabIndex = 1
        Me.MainScreen.TabStop = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(304, 328)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.GameArea)
        Me.Controls.Add(Me.MainScreen)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BomberMan - (by Hassan Ahmad)"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        CType(Me.GameArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainScreen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents GameArea As System.Windows.Forms.PictureBox
    Friend WithEvents Timer As System.Windows.Forms.Timer
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents MainScreen As System.Windows.Forms.PictureBox
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents GameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu2PlayerGame As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu3PlayerGame As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu4PlayerGame As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAbout As System.Windows.Forms.ToolStripMenuItem

End Class
