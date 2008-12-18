Public Class LoopTests

    Public Sub MyWhile()

        Dim myString As String = "un chat fait du bruit en dormant !"
        While (myString.Length > 0)
            myString = myString.Substring(1)
        End While

    End Sub
End Class
