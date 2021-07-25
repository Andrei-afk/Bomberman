Public Class clsBricks

    Public IsEmpty As Boolean = True
    Public IsOnFire As Boolean = False
    Public FireState As Integer = 1


    Public Sub InsertBrick()
        IsEmpty = False
    End Sub

    Public Sub RemoveBrick()
        IsEmpty = True
        FireState = 1
        IsOnFire = False
    End Sub



End Class
