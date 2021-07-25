Imports System.IO

Public Class frmMain

    'FUNCTIONS TO CHECK KEYBOARD INPUT
    Private Declare Function apiGetKeyboardState Lib "user32" Alias "GetKeyboardState" (ByVal vKeys() As Byte) As Int32
    Private Declare Function apiSetKeyboardState Lib "user32" Alias "SetKeyboardState" (ByVal vKeys() As Byte) As Int32
    Private VK(255) As Byte   'STORES THE CURRENT KEYBOARD STATE
    Private VK1(255) As Byte  'STORES THE PREVIOUS TOGGLE STATE (For IsKeyToggled() )

    'STORES IMAGE OF THE GAME AREA (TEMPORARILY)
    Dim imgGameArea As Bitmap = New Bitmap(SCRN_WIDTH, SCRN_HEIGHT)
    'AND ITS GRAPHICS HANDLE FOR DRAWING
    Dim g As Graphics = Graphics.FromImage(imgGameArea)


    'MENU BUTTONS
    Private Sub mnu2PlayerGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu2PlayerGame.Click
        TotalPlayers = 2
        StartNewGame()
    End Sub

    Private Sub mnu3PlayerGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu3PlayerGame.Click
        TotalPlayers = 3
        StartNewGame()
    End Sub

    Private Sub mnu4PlayerGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu4PlayerGame.Click
        TotalPlayers = 4
        StartNewGame()
    End Sub

    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        Me.Close()
        End
    End Sub


    Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
        Dim about As String = "BomberMan" & vbCrLf & "*********" & vbCrLf & "Developed by: Hassan Ahmad" & vbCrLf & "Date developed: 09, Dec 2008" & vbCrLf & "Email ID: hassan_pk92@yahoo.com"
        MsgBox(about, MsgBoxStyle.Information, "About Bomberman!")
    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'INITIALIZE THE GRID ARRAYS
        InitializeArrays()
        'LOAD THE KEY CONFIGURATION FOR EACH BOMBERMAN
        LoadKeyConfiguration()
        'LOAD ALL THE IMAGES FROM THE IMAGELIST CONTROLS
        LoadImages()

    End Sub



    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick

        Dim XY As Point

        If GameOver Then Exit Sub

        If GameTimer Mod 3 = 0 Then UpdateFire()
        If GameTimer Mod 10 = 0 Then UpdateBomb()
        If GameTimer Mod 10 = 0 Then UpdateFireBrick()
        If GameTimer Mod 10 = 0 Then UpdateDeadBombermans()
        If GameTimer Mod 150 = 0 Then CheckIsGameFinished()
        HandleInput()


        For i As Integer = 0 To TotalPlayers - 1

            Dim x As Integer = BomberMan(i).X
            Dim y As Integer = BomberMan(i).Y

            'IS ANY BOMBERMAN COLLIDING WITH FIRE THEN KILL HIM
            If BomberMan(i).IsAlive = True Then
                If IsBombermanCollidingWithFire(BomberMan(i).X, BomberMan(i).Y) Then
                    BomberMan(i).Die()
                End If
            End If

            'CHECK IF ITS COLLIDING WITH A BONUS, IF SO THEN DO THE APPROPRIATE ACTIONS
            For a As Integer = 0 To TOTAL_BLOCKS
                If BonusGrid(a).IsEmpty = False Then

                    XY = GetXYFromBlock(a)
                    If ((y + 14 <= XY.Y + BLOCK_HEIGHT) And (y + BOMBERMAN_HEIGHT > XY.Y)) And ((x + BOMBERMAN_WIDTH >= XY.X + 4) And (x + 4 <= XY.X + BLOCK_WIDTH)) Then
                        If BonusGrid(a).BonusType = clsBonus.Bonuses.BOMB Then
                            BomberMan(i).BombsLeft += 1
                        Else
                            BomberMan(i).Strength += 1
                        End If
                        BonusGrid(a).RemoveBonus()
                    End If

                End If
            Next a

        Next i


        GameTimer += 1

        'AND FINALLY DRAW THE GAME AREA AFTER EACH ONE MILLISECOND
        Draw()

    End Sub


    'RESET ALL THE VALUES AND START A NEW GAME
    Public Sub StartNewGame()

        EmptyGrids()
        FillWalls()
        FillBricks()
        FillBonus()
        'RESET BOMBERMAN VALUES
        InitializeBombermans()

        GameOver = False
        GameTimer = 0

        GameArea.Show()
        Timer.Enabled = True

    End Sub


    'DRAWS THE GAME AREA. ALL ELEMENTS ARE DRAWN IN A SEQUENCE
    Private Sub Draw()

        Dim XY As Point
        g.Clear(Color.Transparent)


        'DRAW: BOMBS
        For i As Integer = 0 To TOTAL_BLOCKS
            If BombGrid(i).IsEmpty = False Then
                XY = GetXYFromBlock(i)

                If BombGrid(i).TimeElapsed Mod 2 = 0 Then
                    g.DrawImage(imgBomb1, XY.X, XY.Y)
                Else
                    g.DrawImage(imgBomb2, XY.X, XY.Y)
                End If
            End If
        Next


        'DRAW: BONUSES
        For i As Integer = 0 To TOTAL_BLOCKS
            If BonusGrid(i).IsEmpty = False Then
                XY = GetXYFromBlock(i)
                If BonusGrid(i).BonusType = clsBonus.Bonuses.BOMB Then
                    g.DrawImage(imgBonusBomb, XY.X, XY.Y, 16, 16)
                Else
                    g.DrawImage(imgBonusFire, XY.X, XY.Y, 16, 16)
                End If
            End If
        Next i


        'DRAW: FIRE
        For i As Integer = 0 To TOTAL_BLOCKS
            If FireGrid(i).IsEmpty = False Then
                Dim direction As String = FireGrid(i).Direction
                Dim state As Integer = FireGrid(i).State

                XY = GetXYFromBlock(i)

                Select Case direction
                    Case "C" : g.DrawImage(imgFireCenter(state - 1), XY.X, XY.Y)
                    Case "H" : g.DrawImage(imgFireHorizontal(state - 1), XY.X, XY.Y)
                    Case "V" : g.DrawImage(imgFireVertical(state - 1), XY.X, XY.Y)
                    Case "E" : g.DrawImage(imgFireEast(state - 1), XY.X, XY.Y)
                    Case "W" : g.DrawImage(imgFireWest(state - 1), XY.X, XY.Y)
                    Case "S" : g.DrawImage(imgFireSouth(state - 1), XY.X, XY.Y)
                    Case "N" : g.DrawImage(imgFireNorth(state - 1), XY.X, XY.Y)
                End Select

            End If
        Next


        'DRAW: BRICKS
        For i As Integer = 0 To TOTAL_BLOCKS
            If BricksGrid(i).IsEmpty = False Then
                XY = GetXYFromBlock(i)

                If BricksGrid(i).IsOnFire = True Then
                    g.DrawImage(imgFireBricks(BricksGrid(i).FireState), XY.X, XY.Y)
                Else
                    g.DrawImage(imgBrick, XY.X, XY.Y)
                End If
            End If
        Next


        'DRAW: WALLS
        For i As Integer = 0 To TOTAL_BLOCKS
            If WallGrid(i).IsEmpty = False Then
                XY = GetXYFromBlock(i)
                g.DrawImage(imgWall, XY.X, XY.Y, 16, 16)
            End If
        Next i



        'DRAW: BOMBERMANS
        For i As Integer = 0 To TotalPlayers - 1
            Dim state As Integer = BomberMan(i).State
            Dim X As Integer = BomberMan(i).X
            Dim Y As Integer = BomberMan(i).Y

            If BomberMan(i).IsAlive = True Then
                If BomberMan(i).Direction = clsBomberman.Directions.UP Then g.DrawImage(BomberMan(i).imgUp(state), X, Y, BOMBERMAN_WIDTH, BOMBERMAN_HEIGHT)
                If BomberMan(i).Direction = clsBomberman.Directions.DOWN Then g.DrawImage(BomberMan(i).imgDown(state), X, Y, BOMBERMAN_WIDTH, BOMBERMAN_HEIGHT)
                If BomberMan(i).Direction = clsBomberman.Directions.LEFT Then g.DrawImage(BomberMan(i).imgLeft(state), X, Y, BOMBERMAN_WIDTH, BOMBERMAN_HEIGHT)
                If BomberMan(i).Direction = clsBomberman.Directions.RIGHT Then g.DrawImage(BomberMan(i).imgRight(state), X, Y, BOMBERMAN_WIDTH, BOMBERMAN_HEIGHT)
            Else
                'IF ITS DEAD THEN ANIMATE IT A LITTLE
                If state < 5 Then
                    g.DrawImage(BomberMan(i).imgDie(state), X, Y, BOMBERMAN_WIDTH, BOMBERMAN_HEIGHT)
                End If
            End If
        Next


        'AND FINALLY DISPLAY THE IMAGE IN THE PICTUREBOX
        GameArea.Image = imgGameArea

    End Sub



    'ANIMATE THE FIRE BRICKS, I.E CHANGE THEIR ANIMATION STATE
    Private Sub UpdateFireBrick()

        For i As Integer = 0 To TOTAL_BLOCKS
            If BricksGrid(i).IsEmpty = False Then

                If BricksGrid(i).IsOnFire = True Then
                    If BricksGrid(i).FireState < 4 Then
                        BricksGrid(i).FireState += 1
                    Else
                        BricksGrid(i).RemoveBrick()
                    End If
                End If

            End If
        Next

    End Sub


    'ANIMATE THE FIRE, I.E CHANGE THEIR ANIMATION STATE
    Private Sub UpdateFire()

        For i As Integer = 0 To TOTAL_BLOCKS
            If FireGrid(i).IsEmpty = False Then
                If FireGrid(i).State < 8 Then
                    FireGrid(i).State += 1
                Else
                    FireGrid(i).RemoveFire()
                End If
            End If
        Next

    End Sub


    'UPDATE BOMB'S TIME ELAPSED
    Private Sub UpdateBomb()
        For i As Integer = 0 To TOTAL_BLOCKS
            If BombGrid(i).IsEmpty = False Then
                If BombGrid(i).TimeElapsed < 8 Then
                    BombGrid(i).TimeElapsed += 1
                Else
                    BlastBomb(i)
                End If
            End If
        Next

    End Sub


    'ANIMATE DYING BOMBERMANS, I.E CHANGE THEIR ANIMATION STATE
    Public Sub UpdateDeadBombermans()

        For i As Integer = 0 To TotalPlayers - 1
            If (BomberMan(i).IsAlive = False) And (BomberMan(i).State < 5) Then
                BomberMan(i).State += 1
            End If
        Next

    End Sub


    '*BLASTS BOMB
    '*DISPLAYS THE FIRE IN APPROPRIATE DIRECTIONS
    '*DESTROY BRICKS ALSO IF PRESENT
    '*AND BLAST OTHER BOMBS ALSO ON THE WAY
    Private Sub BlastBomb(ByVal block As Integer)

        Dim canMoveN As Boolean = True, canMoveS = True, canMoveE = True, canMoveW = True
        Dim NewBlock As Integer
        Dim Player As Integer

        'FIND THE OWNER OF THE BOMB
        Player = BombGrid(block).Player
        'NOW REMOVE THE BOMB
        BombGrid(block).RemoveBomb()
        BomberMan(Player).BombsLeft += 1
        'AND PUT FIRE
        FireGrid(block).InsertFire("C")


        'NOW GO THAT NUMBER OF BLOCKS IN ALL DIRECTIONS WHICH IS EQUAL TO HIS STRENGTH
        For x As Integer = 1 To BomberMan(Player).Strength
            If canMoveN = True Then
                NewBlock = block - (BLOCKS_PER_LINE * x) 'GET UPPER BLOCK

                'IF THERE IS ANY BRICK THERE, THEN PUT IT ON FIRE AND DONT MOVE FURTHER UP!
                If BricksGrid(NewBlock).IsEmpty = False Then
                    BricksGrid(NewBlock).IsOnFire = True
                    canMoveN = False
                End If

                'IF THERE IS A BOMB, THEN BLAST IT
                If BombGrid(NewBlock).IsEmpty = False Then
                    BlastBomb(NewBlock)
                End If

                'IF THERE IS NO WALL
                If WallGrid(NewBlock).IsEmpty = True Then
                    'AND NO FIRE ALREADY THERE ALSO
                    If FireGrid(NewBlock).IsEmpty = True Then
                        'THEN IF ITS NOT THE LAST FIRE THEN USE VERTICAL FIRE IMAGE
                        'ELSE PUT THE RESPECTIVE CORNER IMAGE
                        If (x <> BomberMan(Player).Strength) Then
                            FireGrid(NewBlock).InsertFire("V")
                        Else
                            FireGrid(NewBlock).InsertFire("N")
                        End If
                    End If
                Else
                    canMoveN = False 'DONT MOVE IF THERE'S A WALL
                End If
            End If


            '(CARRY OUT ALMOST SAME PROCEDURE IN THE REST OF DIRECTIONS....)
            If canMoveS = True Then
                NewBlock = block + (BLOCKS_PER_LINE * x)

                If BricksGrid(NewBlock).IsEmpty = False Then
                    BricksGrid(NewBlock).IsOnFire = True
                    canMoveS = False
                End If

                If BombGrid(NewBlock).IsEmpty = False Then
                    BlastBomb(NewBlock)
                End If

                If WallGrid(NewBlock).IsEmpty = True Then
                    If FireGrid(NewBlock).IsEmpty = True Then
                        If (x <> BomberMan(Player).Strength) Then
                            FireGrid(NewBlock).InsertFire("V")
                        Else
                            FireGrid(NewBlock).InsertFire("S")
                        End If
                    End If
                Else
                    canMoveS = False
                End If
            End If


            If canMoveE = True Then
                NewBlock = block + x

                If BricksGrid(NewBlock).IsEmpty = False Then
                    BricksGrid(NewBlock).IsOnFire = True
                    canMoveE = False
                End If

                If BombGrid(NewBlock).IsEmpty = False Then
                    BlastBomb(NewBlock)
                End If

                If WallGrid(NewBlock).IsEmpty = True Then
                    If FireGrid(NewBlock).IsEmpty = True Then
                        If (x <> BomberMan(Player).Strength) Then
                            FireGrid(NewBlock).InsertFire("H")
                        Else
                            FireGrid(NewBlock).InsertFire("E")
                        End If
                    End If
                Else
                    canMoveE = False
                End If
            End If


            If canMoveW = True Then
                NewBlock = block - x

                If BricksGrid(NewBlock).IsEmpty = False Then
                    BricksGrid(NewBlock).IsOnFire = True
                    canMoveW = False
                End If

                If BombGrid(NewBlock).IsEmpty = False Then
                    BlastBomb(NewBlock)
                End If

                If WallGrid(NewBlock).IsEmpty = True Then
                    If FireGrid(NewBlock).IsEmpty = True Then
                        If (x <> BomberMan(Player).Strength) Then
                            FireGrid(NewBlock).InsertFire("H")
                        Else
                            FireGrid(NewBlock).InsertFire("W")
                        End If
                    End If
                Else
                    canMoveW = False
                End If
            End If

        Next


    End Sub


    'DETECTS THE INPUT FOR EACH BOMBERMAN, AND THEN HANDLES IT
    Public Sub HandleInput()

        Dim NewX As Integer
        Dim NewY As Integer
        Dim Move As Integer = 3

        For i As Integer = 0 To TotalPlayers - 1

            If BomberMan(i).IsAlive = True Then

                If IsKeyPressed(BomberMan(i).KEY_UP) Then
                    NewX = BomberMan(i).X
                    NewY = BomberMan(i).Y - Move

                    If IsBombermanColliding(NewX, NewY) = False Then

                        'IF ITS ALREADY IN UPWARD DIRECTION THEN CHANGE ITS ANIMATION STATE 
                        If BomberMan(i).Direction = clsBomberman.Directions.UP Then
                            BomberMan(i).State += 1
                            BomberMan(i).State = BomberMan(i).State Mod 5
                        Else
                            BomberMan(i).Direction = clsBomberman.Directions.UP
                            BomberMan(i).State = 0
                        End If

                        BomberMan(i).X = NewX
                        BomberMan(i).Y = NewY
                    End If
                End If

                If IsKeyPressed(BomberMan(i).KEY_DOWN) Then
                    NewX = BomberMan(i).X
                    NewY = BomberMan(i).Y + Move

                    If IsBombermanColliding(NewX, NewY) = False Then

                        If BomberMan(i).Direction = clsBomberman.Directions.DOWN Then
                            BomberMan(i).State += 1
                            BomberMan(i).State = BomberMan(i).State Mod 5
                        Else
                            BomberMan(i).Direction = clsBomberman.Directions.DOWN
                            BomberMan(i).State = 0
                        End If

                        BomberMan(i).X = NewX
                        BomberMan(i).Y = NewY
                    End If
                End If


                If IsKeyPressed(BomberMan(i).KEY_LEFT) Then
                    NewX = BomberMan(i).X - Move
                    NewY = BomberMan(i).Y

                    If IsBombermanColliding(NewX, NewY) = False Then

                        If BomberMan(i).Direction = clsBomberman.Directions.LEFT Then
                            BomberMan(i).State += 1
                            BomberMan(i).State = BomberMan(i).State Mod 5
                        Else
                            BomberMan(i).Direction = clsBomberman.Directions.LEFT
                            BomberMan(i).State = 0
                        End If

                        BomberMan(i).X = NewX
                        BomberMan(i).Y = NewY
                    End If
                End If


                If IsKeyPressed(BomberMan(i).KEY_RIGHT) Then
                    NewX = BomberMan(i).X + Move
                    NewY = BomberMan(i).Y

                    If IsBombermanColliding(NewX, NewY) = False Then

                        If BomberMan(i).Direction = clsBomberman.Directions.RIGHT Then
                            BomberMan(i).State += 1
                            BomberMan(i).State = BomberMan(i).State Mod 5
                        Else
                            BomberMan(i).Direction = clsBomberman.Directions.RIGHT
                            BomberMan(i).State = 0
                        End If

                        BomberMan(i).X = NewX
                        BomberMan(i).Y = NewY
                    End If
                End If


                If IsKeyToggled(BomberMan(i).KEY_BOMB) Then
                    If BomberMan(i).BombsLeft > 0 Then
                        Dim BomberBlock As Integer = GetBlockFromXY(BomberMan(i).X, BomberMan(i).Y + 12)
                        BombGrid(BomberBlock).InsertBomb(i)
                        BomberMan(i).BombsLeft -= 1
                    End If
                End If

            End If
        Next i
    End Sub


    Public Function IsKeyPressed(ByVal key As Keys) As Boolean

        apiGetKeyboardState(VK) 'Get status of all 256 virtual keys
        If (VK(key) = 128) Or (VK(key) = 129) Then
            Return True
        Else
            Return False
        End If

    End Function


    'CHECK IF THE KEY IS TOGGLED, MEANS WHETHER IT WAS 'UP' BEFORE BEING PRESSED AGAIN
    'IT STORES PREVIOUS STATE IN 'VK1'
    '(used in putting bombs)
    Public Function IsKeyToggled(ByVal key As Keys) As Boolean

        apiGetKeyboardState(VK) 'Get status of all 256 virtual keys
        If (VK(key) = 128) Or (VK(key) = 129) Then
            If (VK(key) <> VK1(key)) Or (VK1(key) = 0) Then
                VK1(key) = VK(key)
                Return True
            End If
        End If

        Return False

    End Function


    'CHECK IF GAME IS OVER
    Public Sub CheckIsGameFinished()

        Dim PlayersLeft As Integer = 0
        Dim Player As Integer

        For i As Integer = 0 To TotalPlayers - 1
            If BomberMan(i).IsAlive = True Then
                PlayersLeft += 1
                Player = i
            End If
        Next

        If PlayersLeft = 1 Then
            Timer.Enabled = False
            GameArea.Hide()
            MainScreen.BackgroundImage = ImageList2.Images(Player)
            GameOver = True
        End If

        If PlayersLeft = 0 Then
            Timer.Enabled = False
            GameArea.Hide()
            MainScreen.BackgroundImage = ImageList2.Images("draw")
            GameOver = True
        End If



    End Sub


    'LOAD ALL THE IMAGES
    Public Sub LoadImages()

        'Load Fire Images from the imagelist control into BITMAP variables
        For i As Integer = 0 To 7
            imgFireWest(i) = New Bitmap(ImageList.Images("W" & i + 1 & ".gif"))
            imgFireEast(i) = New Bitmap(ImageList.Images("E" & i + 1 & ".gif"))
            imgFireNorth(i) = New Bitmap(ImageList.Images("N" & i + 1 & ".gif"))
            imgFireSouth(i) = New Bitmap(ImageList.Images("S" & i + 1 & ".gif"))
            imgFireHorizontal(i) = New Bitmap(ImageList.Images("H" & i + 1 & ".gif"))
            imgFireVertical(i) = New Bitmap(ImageList.Images("V" & i + 1 & ".gif"))
            imgFireCenter(i) = New Bitmap(ImageList.Images("C" & i + 1 & ".gif"))
        Next

        'LOAD BOMB IMAGES
        imgBomb1 = New Bitmap(ImageList.Images("bomb1"))
        imgBomb2 = New Bitmap(ImageList.Images("bomb2"))

        'LOAD BRICK
        imgBrick = New Bitmap(ImageList.Images("brick"))
        'AND FIRE BRICKS
        For i As Integer = 0 To 4
            imgFireBricks(i) = New Bitmap(ImageList.Images("firebrick" & i))
        Next

        'WALL...
        imgWall = New Bitmap(ImageList.Images("wall"))


        'AND LOAD ALL THE BOMBERMAN IMAGES AS WELL
        For x As Integer = 0 To 3
            For i As Integer = 1 To 5
                BomberMan(x).imgUp(i - 1) = New Bitmap(ImageList1.Images(x & i & ".gif"))
            Next i
            For i As Integer = 6 To 10
                BomberMan(x).imgDown(i - 6) = New Bitmap(ImageList1.Images(x & i & ".gif"))
            Next i
            For i As Integer = 11 To 15
                BomberMan(x).imgLeft(i - 11) = New Bitmap(ImageList1.Images(x & i & ".gif"))
            Next i
            For i As Integer = 16 To 20
                BomberMan(x).imgRight(i - 16) = New Bitmap(ImageList1.Images(x & i & ".gif"))
            Next i
            For i As Integer = 21 To 25
                BomberMan(x).imgDie(i - 21) = New Bitmap(ImageList1.Images(x & i & ".gif"))
            Next i
        Next x


        'LOAD BONUS IMAGES
        imgBonusBomb = New Bitmap(ImageList.Images("bonusbomb1"))
        imgBonusFire = New Bitmap(ImageList.Images("bonusfire1"))

    End Sub


   
End Class
