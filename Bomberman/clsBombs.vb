Public Class clsBombs

    Public IsEmpty As Boolean = True
    Public TimeElapsed As Integer
    Public Player As Integer


    Public Sub InsertBomb(ByVal x As Integer)
        IsEmpty = False
        Player = x
    End Sub

    Public Sub RemoveBomb()
        IsEmpty = True
        TimeElapsed = 0
    End Sub



End Class
