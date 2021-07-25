Public Module General


    'VARIABLES FOR HOLDING BITMAP IMAGES
    Public imgFireEast(8) As Bitmap
    Public imgFireWest(8) As Bitmap
    Public imgFireNorth(8) As Bitmap
    Public imgFireSouth(8) As Bitmap
    Public imgFireHorizontal(8) As Bitmap
    Public imgFireVertical(8) As Bitmap
    Public imgFireCenter(8) As Bitmap
    Public imgBomb1 As Bitmap
    Public imgBomb2 As Bitmap
    Public imgBrick As Bitmap
    Public imgFireBricks(5) As Bitmap
    Public imgWall As Bitmap
    Public imgBonusFire As Bitmap
    Public imgBonusBomb As Bitmap


    'SOME CONSTANTS
    Public Const SCRN_WIDTH = 304
    Public Const SCRN_HEIGHT = 304
    Public Const BLOCK_WIDTH = 16
    Public Const BLOCK_HEIGHT = 16
    Public Const TOTAL_BLOCKS = (SCRN_WIDTH / BLOCK_WIDTH) * (SCRN_HEIGHT / BLOCK_HEIGHT)
    Public Const BLOCKS_PER_LINE = SCRN_WIDTH / BLOCK_WIDTH
    Public Const TOTAL_LINES = SCRN_HEIGHT / BLOCK_HEIGHT

    Public Const BOMBERMAN_WIDTH = 16
    Public Const BOMBERMAN_HEIGHT = 25


    'GRID OF EACH ELEMENT
    Public BombGrid(TOTAL_BLOCKS) As clsBombs
    Public FireGrid(TOTAL_BLOCKS) As clsFire
    Public BricksGrid(TOTAL_BLOCKS) As clsBricks
    Public WallGrid(TOTAL_BLOCKS) As clsWalls
    Public BonusGrid(TOTAL_BLOCKS) As clsBonus


    Public BomberMan(4) As clsBomberman
    'PLAYERS THAT ARE CURRENTLY PLAYING:
    Public TotalPlayers As Integer
    'GAME TIMER USED IN MAIN 'Timer' TO HANDLE OTHER EVENTS AND ANIMATIONS
    Public GameTimer As Long
    Public GameOver As Boolean



    '====================================================================================

    'CONVERTS A BLOCK NUMBER TO ITS X, Y COORDINATES (FOR DRAWING IT)
    Function GetBlockFromXY(ByVal X As Integer, ByVal Y As Integer) As Integer
        Dim BlocksFromTop As Integer
        Dim BlocksFromLeft As Integer

        BlocksFromTop = Y / BLOCK_HEIGHT
        BlocksFromLeft = X / BLOCK_WIDTH

        Return (BlocksFromTop * BLOCKS_PER_LINE) + BlocksFromLeft

    End Function


    'CONVERTS X, Y COORDINATES OF A BLOCK TO A NUMBER (OPPOSITE)
    Function GetXYFromBlock(ByVal Block As Integer) As Point
        Dim BlocksFromTop As Integer
        Dim BlocksFromLeft As Integer
        Dim XY As Point

        BlocksFromLeft = (Block Mod BLOCKS_PER_LINE)
        BlocksFromTop = Math.Floor(Block / BLOCKS_PER_LINE)

        XY.X = BlocksFromLeft * BLOCK_WIDTH
        XY.Y = BlocksFromTop * BLOCK_HEIGHT

        Return XY

    End Function


    'EMPTY ALL THE GRIDS
    Public Sub EmptyGrids()

        For i As Integer = 0 To TOTAL_BLOCKS
            BricksGrid(i).RemoveBrick()
            WallGrid(i).RemoveWall()
            BonusGrid(i).RemoveBonus()
            BombGrid(i).RemoveBomb()
            FireGrid(i).RemoveFire()
        Next

    End Sub


    'FILL THE WALL GRID
    Public Sub FillWalls()

        For i As Integer = 0 To TOTAL_BLOCKS

            If (i \ BLOCKS_PER_LINE) Mod 2 = 0 Then WallGrid(i).InsertWall()
            If i Mod 2 = 1 Then WallGrid(i).RemoveWall()

            If (i Mod BLOCKS_PER_LINE = 0) Or (i Mod BLOCKS_PER_LINE = BLOCKS_PER_LINE - 1) _
             Or (i < BLOCKS_PER_LINE) Or (i > TOTAL_BLOCKS - BLOCKS_PER_LINE) Then
                WallGrid(i).InsertWall()
            End If
        Next

    End Sub


    'FILL THE BRICKS GRID RANDOMLY
    Public Sub FillBricks()

        Dim r As New Random()
        Dim x As Integer

        For i As Integer = 0 To TOTAL_BLOCKS

            If (WallGrid(i).IsEmpty = True) Then
                x = r.Next(0, 2)
                If x = 0 Then
                    BricksGrid(i).InsertBrick()
                End If
            End If

        Next i


        'MAKE SOME SPACE FOR EACH BOMBERMAN IN THE CORNERS
        BricksGrid(340).RemoveBrick()
        BricksGrid(339).RemoveBrick()
        BricksGrid(321).RemoveBrick()

        BricksGrid(20).RemoveBrick()
        BricksGrid(21).RemoveBrick()
        BricksGrid(39).RemoveBrick()

        BricksGrid(36).RemoveBrick()
        BricksGrid(35).RemoveBrick()
        BricksGrid(55).RemoveBrick()

        BricksGrid(324).RemoveBrick()
        BricksGrid(325).RemoveBrick()
        BricksGrid(305).RemoveBrick()

    End Sub


    'FILL THE BONUSES GRID (I.E FIRE AND BOMB BONUSES)
    Public Sub FillBonus()

        Dim TotalBonuses As Integer = 6 * TotalPlayers
        Dim r As New Random()
        Dim x As Integer

        For i As Integer = 1 To TotalBonuses
            Do
                x = r.Next(0, TOTAL_BLOCKS)
            Loop Until ((BricksGrid(x).IsEmpty = False) And (WallGrid(x).IsEmpty = True) And (BonusGrid(x).IsEmpty = True))

            BonusGrid(x).InsertBonus(clsBonus.Bonuses.BOMB)

            Do
                x = r.Next(0, TOTAL_BLOCKS)
            Loop Until ((BricksGrid(x).IsEmpty = False) And (WallGrid(x).IsEmpty = True) And (BonusGrid(x).IsEmpty = True))

            BonusGrid(x).InsertBonus(clsBonus.Bonuses.FIRE)
        Next


    End Sub


    'RESET SETTINGS OF EACH BOMBERMAN
    Public Sub InitializeBombermans()

        For i As Integer = 0 To 3
            BomberMan(i).Strength = 1
            BomberMan(i).BombsLeft = 1
            BomberMan(i).State = 0
            BomberMan(i).IsAlive = True
        Next


        BomberMan(0).X = 16
        BomberMan(0).Y = 16
        BomberMan(0).Direction = clsBomberman.Directions.DOWN

        BomberMan(1).X = 272
        BomberMan(1).Y = 262
        BomberMan(1).Direction = clsBomberman.Directions.UP

        BomberMan(2).X = 272
        BomberMan(2).Y = 16
        BomberMan(2).Direction = clsBomberman.Directions.DOWN

        BomberMan(3).X = 16
        BomberMan(3).Y = 262
        BomberMan(3).Direction = clsBomberman.Directions.UP


    End Sub


    'LOAD KEY CONFIGURATION OF EACH BOMBERMAN
    Public Sub LoadKeyConfiguration()

        BomberMan(0).KEY_UP = Keys.Up
        BomberMan(0).KEY_DOWN = Keys.Down
        BomberMan(0).KEY_LEFT = Keys.Left
        BomberMan(0).KEY_RIGHT = Keys.Right
        BomberMan(0).KEY_BOMB = Keys.Enter

        BomberMan(1).KEY_UP = Keys.W
        BomberMan(1).KEY_DOWN = Keys.S
        BomberMan(1).KEY_LEFT = Keys.A
        BomberMan(1).KEY_RIGHT = Keys.D
        BomberMan(1).KEY_BOMB = Keys.Space

        BomberMan(2).KEY_UP = Keys.I
        BomberMan(2).KEY_DOWN = Keys.K
        BomberMan(2).KEY_LEFT = Keys.J
        BomberMan(2).KEY_RIGHT = Keys.L
        BomberMan(2).KEY_BOMB = Keys.ControlKey

        BomberMan(3).KEY_UP = Keys.NumPad8
        BomberMan(3).KEY_DOWN = Keys.NumPad2
        BomberMan(3).KEY_LEFT = Keys.NumPad4
        BomberMan(3).KEY_RIGHT = Keys.NumPad6
        BomberMan(3).KEY_BOMB = Keys.Insert


    End Sub


    'INITIALIZE THE GRID ARRAYS
    Public Sub InitializeArrays()
        For i As Integer = 0 To TOTAL_BLOCKS
            BombGrid(i) = New clsBombs
            WallGrid(i) = New clsWalls
            BricksGrid(i) = New clsBricks
            FireGrid(i) = New clsFire
            BonusGrid(i) = New clsBonus
        Next
        For i As Integer = 0 To 3
            BomberMan(i) = New clsBomberman
        Next
    End Sub



    'IS BOMBERMAN COLLIDING WITH ANY WALL OR BRICK
    Function IsBombermanColliding(ByVal x As Integer, ByVal y As Integer) As Boolean

        Dim XY As Point

        For i As Integer = 0 To TOTAL_BLOCKS
            If (BricksGrid(i).IsEmpty = False) Or (WallGrid(i).IsEmpty = False) Then
                XY = GetXYFromBlock(i)
                If ((y + 14 <= XY.Y + BLOCK_HEIGHT) And (y + BOMBERMAN_HEIGHT > XY.Y)) And ((x + BOMBERMAN_WIDTH >= XY.X + 4) And (x + 4 <= XY.X + BLOCK_WIDTH)) Then
                    Return True
                End If
            End If
        Next

        Return False

    End Function


    'IS BOMBERMAN COLLIDING WITH FIRE
    Function IsBombermanCollidingWithFire(ByVal x As Integer, ByVal y As Integer) As Boolean

        Dim XY As Point

        For i As Integer = 0 To TOTAL_BLOCKS
            If FireGrid(i).IsEmpty = False Then
                XY = GetXYFromBlock(i)
                If ((y + 14 <= XY.Y + BLOCK_HEIGHT) And (y + BOMBERMAN_HEIGHT > XY.Y)) And ((x + BOMBERMAN_WIDTH >= XY.X) And (x <= XY.X + BLOCK_WIDTH)) Then
                    Return True
                End If
            End If
        Next

        Return False

    End Function


End Module
