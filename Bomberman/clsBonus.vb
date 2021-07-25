Public Class clsBonus

    Enum Bonuses
        FIRE = 1
        BOMB = 2
    End Enum

    Public IsEmpty As Boolean = True
    Public BonusType As Bonuses


    Public Sub InsertBonus(ByVal Type As Bonuses)
        IsEmpty = False
        BonusType = Type
    End Sub


    Public Sub RemoveBonus()
        IsEmpty = True
    End Sub

End Class
