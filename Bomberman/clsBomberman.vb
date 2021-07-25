Public Class clsBomberman

    Enum Directions
        UP = 0
        DOWN = 1
        LEFT = 2
        RIGHT = 3
        DEAD = 4
    End Enum


    Public X As Integer
    Public Y As Integer
    Public Strength As Integer = 1
    Public BombsLeft As Integer = 1
    Public IsAlive As Boolean = True
    Public Direction As Directions
    Public State As Integer = 0

    Public KEY_UP As Keys
    Public KEY_DOWN As Keys
    Public KEY_LEFT As Keys
    Public KEY_RIGHT As Keys
    Public KEY_BOMB As Keys


    Public imgLeft(5) As Bitmap
    Public imgRight(5) As Bitmap
    Public imgUp(5) As Bitmap
    Public imgDown(5) As Bitmap
    Public imgDie(5) As Bitmap


    Public Sub Die()
        IsAlive = False
        State = 0
    End Sub


End Class
