


Public Class TestMethods

	Public Shared Sub ReturnVoid()
		Return
	End Sub

	Public Shared Function ReturnString() As String
		Return "Ok"
	End Function

    Public Shared Function Identity(ByVal s As String) As String
        Return s
	End Function

	Public Shared Sub OnError()
		Console.WriteLine("ok")
		'On Error Resume Next
		Console.WriteLine("ok")
	End Sub

    Public Shared Sub SimpleIfElse(ByVal i As Integer)

		If True Then
			Console.WriteLine("Grand")
		Else
			Console.WriteLine("Petit")
		End If

	End Sub

	Public Shared Sub SimpleIfElse2(ByVal i As Integer)

		If 0 <> 1 Then
			Console.WriteLine("Grand")
		Else
			Console.WriteLine("Petit")
		End If

	End Sub

	Public Shared Function Addition(ByVal a As Integer, ByVal b As Integer) As Integer

		Dim result As Integer = a + b
		Return result

	End Function

	Public Shared Function Addition2(ByVal a As Integer, ByVal b As Integer) As Integer

		Dim result As Integer
		result = a + b
		Return result

	End Function

	Public Shared Sub MyWhile()

		Dim myString As String = "un chat fait du bruit en dormant !"
		While (myString.Length > 0)
			myString = myString.Substring(1)
		End While

	End Sub

	Public Shared Sub MyWhileX2()
		Dim myString As String = "le ventre de Patou fait du bruit aussi !"
		While (myString.Length > 0)
			myString = myString.Substring(1)
			While (myString.Length.CompareTo(New Object()) = 0)
				Console.Write(myString)
			End While
		End While
	End Sub

	Public Shared Sub MyDoWhile()
		Dim s As String
		s = "Maran"
		Do
			s = String.Concat(s, s)
			'Console.WriteLine("ca boucle")
		Loop While True
	End Sub

	Public Shared Sub MyDoUntil()
		Do
			Console.WriteLine("ca boucle")
		Loop Until True
	End Sub

	Public Sub PublicSub()
		'nothing
	End Sub

End Class
