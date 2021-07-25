Public Class clsFire

    Public IsEmpty As Boolean = True
    Public Direction As String
    Public State As Integer = 1


    Public Sub InsertFire(ByVal D As String)
        IsEmpty = False
        Direction = D
    End Sub

    Public Sub RemoveFire()
        IsEmpty = True
        State = 1
    End Sub

End Class
