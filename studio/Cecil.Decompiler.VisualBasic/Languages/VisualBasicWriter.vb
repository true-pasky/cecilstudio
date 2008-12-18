Imports Cecil.Decompiler.Languages
Imports Mono.Cecil
Imports Cecil.Decompiler.Ast

Namespace Languages

	Public Enum BlockType
		[Sub]
		[Function]
	End Enum

	Public Class VisualBasicWriter
		Inherits BaseLanguageWriter

		Public Sub New(ByVal language As ILanguage, ByVal formatter As IFormatter)
			MyBase.New(language, formatter)
		End Sub

		Public Overloads Overrides Sub Write(ByVal expression As Ast.Expression)
			Visit(expression)
		End Sub

		Public Overloads Overrides Sub Write(ByVal statement As Ast.Statement)
			Visit(statement)
			'WriteLine()
		End Sub

		Public Overrides Sub VisitExpressionStatement(ByVal node As ExpressionStatement)
			Visit(node.Expression)
			WriteLine()
		End Sub

		Public Overrides Sub VisitAssignExpression(ByVal node As AssignExpression)
			Visit(node.Target)
			WriteSpace()
			WriteToken("=")
			WriteSpace()
			Visit(node.Expression)
		End Sub

		Public Overrides Sub VisitIfStatement(ByVal node As IfStatement)
			WriteKeyword(VisualBasicKeywords.If)
			WriteSpace()
			Visit(node.Condition)
			WriteSpace()
			WriteKeyword(VisualBasicKeywords.Then)
			WriteLine()
			Indent()
			Visit(node.Then)
			Outdent()
			If node.Else IsNot Nothing Then
				WriteKeyword(VisualBasicKeywords.Else)
				WriteLine()
				Indent()
				Visit(node.Else)
				Outdent()
			End If
			WriteKeyword(VisualBasicKeywords.End)
			WriteSpace()
			WriteKeyword(VisualBasicKeywords.If)
			WriteLine()
		End Sub

		Public Overrides Sub VisitReturnStatement(ByVal node As ReturnStatement)
			WriteKeyword(VisualBasicKeywords.Return)
			If node.Expression IsNot Nothing Then
				WriteSpace()
				Visit(node.Expression)
			End If
			WriteLine()
		End Sub

		Public Overrides Sub VisitVariableDeclarationExpression(ByVal node As VariableDeclarationExpression)
			WriteKeyword(VisualBasicKeywords.Dim)
			WriteSpace()
			WriteIdentifier(node.Variable.Name, node.Variable)
			WriteSpace()
			WriteKeyword(VisualBasicKeywords.As)
			WriteSpace()
			WriteReference(node.Variable.VariableType)
		End Sub

		Public Overrides Sub VisitObjectCreationExpression(ByVal node As ObjectCreationExpression)
			WriteKeyword(VisualBasicKeywords.New)
			WriteSpace()

			If node.Constructor Is Nothing Then
				WriteReference(node.Type)
			Else
				WriteReference(node.Constructor.DeclaringType)
				If node.Constructor.HasParameters Then
					'Todo writelist !
				End If
			End If

		End Sub

		Public Overrides Sub VisitVariableReferenceExpression(ByVal node As VariableReferenceExpression)
			WriteIdentifier(node.Variable.Name, node.Variable)
		End Sub

		Public Overrides Sub VisitArgumentReferenceExpression(ByVal node As ArgumentReferenceExpression)
			WriteIdentifier(node.Parameter.Name, node.Parameter)
		End Sub

		Public Overrides Sub VisitBinaryExpression(ByVal node As BinaryExpression)
			Visit(node.Left)
			WriteSpace()
			Write(node.Operator)
			WriteSpace()
			Visit(node.Right)
		End Sub

		Public Overrides Sub VisitLiteralExpression(ByVal node As LiteralExpression)
			If node.Value Is Nothing Then
				WriteKeyword(VisualBasicKeywords.Nothing)
				Return
			End If

			Select Case Type.GetTypeCode(node.Value.GetType())

				Case TypeCode.Int32
					WriteLiteral(node.Value.ToString())
				Case TypeCode.String
					WriteLiteral(String.Format("""{0}""", node.Value.ToString()))
				Case Else
					Throw New NotImplementedException()
			End Select
		End Sub

		Public Overrides Sub VisitThisReferenceExpression(ByVal node As ThisReferenceExpression)
			WriteKeyword(VisualBasicKeywords.Me)
		End Sub

		Public Overrides Sub VisitBaseReferenceExpression(ByVal node As BaseReferenceExpression)
			WriteKeyword(VisualBasicKeywords.MyBase)	' TODO: enlever VisualBasicKeywords (jb)
		End Sub

		Public Overrides Sub VisitMethodInvocationExpression(ByVal node As MethodInvocationExpression)
			Visit(node.Method)
			WriteToken("(")
			VisitList(node.Arguments)
			WriteToken(")")
		End Sub

		Public Overrides Sub VisitMethodReferenceExpression(ByVal node As MethodReferenceExpression)
			If node.Target IsNot Nothing Then
				Visit(node.Target)
				WriteToken(".")
			End If

			If Not node.Method.HasThis Then
				WriteReference(node.Method.DeclaringType)
				WriteToken(".")
			End If

			Write(node.Method.Name)
		End Sub

		Public Overrides Sub VisitWhileStatement(ByVal node As WhileStatement)
			WriteKeyword(VisualBasicKeywords.While)
			WriteBetweenParenthesis(node.Condition)
			WriteLine()
			Indent()
			Visit(node.Body)
			Outdent()
			WriteKeyword(VisualBasicKeywords.End)
			WriteSpace()
			WriteKeyword(VisualBasicKeywords.While)
			WriteLine()
		End Sub

		Public Overrides Sub VisitDoWhileStatement(ByVal node As DoWhileStatement)
			WriteKeyword(VisualBasicKeywords.Do)
			WriteLine()
			Indent()
			Visit(node.Body)
			Outdent()
			WriteKeyword(VisualBasicKeywords.Loop)
			WriteKeyword(VisualBasicKeywords.While)
			WriteSpace()
			Visit(node.Condition)
			WriteLine()
		End Sub


		Public Sub VisitList(ByVal list As IList(Of Expression))

			For i As Integer = 0 To list.Count - 1
				If i > 0 Then
					WriteToken(",")
					WriteSpace()
				End If
				Visit(list(i))
			Next
		End Sub


		''' <summary>
		''' [ <attributelist> ] [ accessmodifier ] [ proceduremodifiers ] [ Shared ] [ Shadows ] 
		'''Function name [ (Of typeparamlist) ] [ (parameterlist) ] [ As returntype ] [ Implements implementslist | Handles eventlist ]
		'''[ statements ]
		'''[ Exit Function ]
		'''[ statements ]
		'''End Function
		''' </summary>
		''' <param name="method"></param>
		''' <remarks></remarks>
		Public Overrides Sub Write(ByVal method As MethodDefinition)

			Dim isSub As Boolean = False

			Select Case True
				Case method.IsPublic
					WriteKeyword(VisualBasicKeywords.Public)
				Case method.IsPrivate
					WriteKeyword(VisualBasicKeywords.Private)
				Case method.IsFamily
					WriteKeyword(VisualBasicKeywords.Protected)
				Case method.IsFamilyAndAssembly
					'do nothing in VB
				Case method.IsFamilyOrAssembly
					WriteKeyword(VisualBasicKeywords.Protected)
					WriteSpace()
					WriteKeyword(VisualBasicKeywords.Friend)
				Case method.IsAssembly
					WriteKeyword(VisualBasicKeywords.Friend)
				Case Else
					Throw New NotImplementedException()
			End Select

			WriteSpace()

			If method.IsStatic Then
				WriteKeyword(VisualBasicKeywords.Shared)
				WriteSpace()
			End If

			If method.Overrides IsNot Nothing And method.Overrides.Count > 0 Then
				WriteKeyword(VisualBasicKeywords.Overrides)
				WriteSpace()
			End If

			Dim returnType As TypeReference = method.ReturnType.ReturnType

			isSub = returnType.FullName = GetType(Void).FullName

			If isSub Then
				WriteKeyword(VisualBasicKeywords.Sub)
				WriteSpace()
			Else
				WriteKeyword(VisualBasicKeywords.Function)
				WriteSpace()
			End If

			Write(method.Name)


			' TODO : refactoring this shit
			WriteToken("(")
			If method.HasParameters Then

				For i As Integer = 0 To method.Parameters.Count - 1
					If i > 0 Then
						WriteToken(",")
						WriteSpace()
					End If
					' TODO : Add byval or byref ...
					WriteLiteral(method.Parameters(i).Name)
					WriteSpace()
					WriteKeyword(VisualBasicKeywords.As)
					WriteSpace()
					WriteReference(method.Parameters(i).ParameterType)
				Next

			End If
			WriteToken(")")

			If Not isSub Then
				WriteSpace()
				WriteKeyword(VisualBasicKeywords.As)
				WriteSpace()
				WriteReference(returnType)

			End If
			WriteLine()


			Dim body = method.Body.Decompile(language)

			Indent()

			Write(body)

			Outdent()

			WriteKeyword(VisualBasicKeywords.End)
			WriteSpace()

			If isSub Then
				WriteKeyword(VisualBasicKeywords.Sub)
			Else
				WriteKeyword(VisualBasicKeywords.Function)
			End If


		End Sub

		Private Shadows Sub WriteKeyword(ByVal VisualBasicKeywords As VisualBasicKeywords)
			MyBase.WriteKeyword(VisualBasicKeywords.ToString())
		End Sub

		Private Sub WriteReference(ByVal reference As TypeReference)
			formatter.WriteReference(ToString(reference), reference)
		End Sub

		Private Sub WriteBetweenParenthesis(ByVal expression As Expression)
			WriteToken("(")
			Visit(expression)
			WriteToken(")")
		End Sub

		Private Shared Function ToString(ByVal type As TypeReference) As String
			If type.Namespace <> "System" Then
				Return type.Name
			End If

			Select Case type.Name
				Case "Int16"
					Return "Short"
				Case "Int32"
					Return "Integer"
				Case "Int64"
					Return "Long"
				Case "UInt16"
					Return "UShort"
				Case "UInt32"
					Return "UInteger"
				Case "UInt64"
					Return "ULong"
				Case Else
					Return type.Name
			End Select


		End Function

		Public Overloads Sub Write(ByVal op As BinaryOperator)
			Select Case op
				Case BinaryOperator.Add
					WriteToken("+")
				Case BinaryOperator.Subtract
					WriteToken("-")
				Case BinaryOperator.Multiply
					WriteToken("*")
				Case BinaryOperator.Divide
					WriteToken("\")
				Case BinaryOperator.ValueEquality
					WriteToken("=")
				Case BinaryOperator.ValueInequality
					WriteToken("<>")
				Case BinaryOperator.LogicalOr
					WriteToken("OrElse")
				Case BinaryOperator.LogicalAnd
					WriteToken("AndAlso")
				Case BinaryOperator.LessThan
					WriteToken("<")
				Case BinaryOperator.LessThanOrEqual
					WriteToken("<=")
				Case BinaryOperator.GreaterThan
					WriteToken(">")
				Case BinaryOperator.GreaterThanOrEqual
					WriteToken(">=")
				Case BinaryOperator.LeftShift
					WriteToken("<<")
				Case BinaryOperator.RightShift
					WriteToken(">>")
				Case BinaryOperator.BitwiseOr
					WriteToken("Or")
				Case BinaryOperator.BitwiseAnd
					WriteToken("And")
				Case BinaryOperator.BitwiseXor
					WriteToken("Xor")
				Case BinaryOperator.Modulo
					WriteToken("Mod")
				Case Else
					Throw New NotImplementedException

			End Select
		End Sub


		Private Function HandleKeywords(ByVal str As String) As String

			For Each keyword As String In System.Enum.GetNames(GetType(VisualBasicKeywords))

				If str.ToLower() = keyword.ToLower() Then
					str = String.Format("[{0}]", str)
				End If
			Next
			Return str
		End Function

	End Class

End Namespace
