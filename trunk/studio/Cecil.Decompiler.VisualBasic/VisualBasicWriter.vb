Imports Mono.Cecil
Imports Mono.Cecil.Cil
Imports Cecil.Decompiler.Ast

Public Enum BlockType
	[Sub]
	[Function]
End Enum

Public Class VisualBasicWriter
	Inherits BaseLanguageWriter

	Public Sub New(ByVal formatter As IFormatter)
		MyBase.New(formatter)
    End Sub



	Public Overloads Overrides Sub Write(ByVal expression As Ast.Expression)
		Visit(expression)
	End Sub

	Public Overloads Overrides Sub Write(ByVal statement As Ast.Statement)
		Visit(statement)
		WriteLine()
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
		WriteKeyword("If")
		WriteSpace()
		Visit(node.Condition)
		WriteSpace()
		WriteKeyword("Then")
		WriteLine()
		Indent()
		Visit(node.Then)
		Outdent()
		If node.Else IsNot Nothing Then
			WriteKeyword("Else")
			WriteLine()
			Indent()
			Visit(node.Else)
			Outdent()
		End If
		WriteKeyword("End")
		WriteSpace()
		WriteKeyword("If")
		WriteLine()
	End Sub

	Public Overrides Sub VisitReturnStatement(ByVal node As ReturnStatement)
		WriteKeyword("Return")
		If node.Expression IsNot Nothing Then
			WriteSpace()
			Visit(node.Expression)
		End If
		WriteLine()
	End Sub

	Public Overrides Sub VisitVariableDeclarationExpression(ByVal node As VariableDeclarationExpression)
		WriteKeyword("Dim")
		WriteSpace()
		WriteIdentifier(node.Variable.Name, node.Variable)
		WriteSpace()
		WriteKeyword("As")
		WriteSpace()
		WriteReference(node.Variable.VariableType)
	End Sub

	Public Overrides Sub VisitObjectCreationExpression(ByVal node As ObjectCreationExpression)
		WriteKeyword("new")
		WriteSpace()

		If node.Constructor Is Nothing Then
			WriteReference(node.Type)
		Else
			WriteReference(node.Constructor.DeclaringType)
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
			WriteKeyword("Nothing")
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
		WriteKeyword("While")
		WriteBetweenParenthesis(node.Condition)
		WriteLine()
		Indent()
		Visit(node.Body)
		Outdent()
		WriteKeyword("End")
		WriteSpace()
		WriteKeyword("While")
		WriteLine()
	End Sub

	Public Overrides Sub VisitDoWhileStatement(ByVal node As DoWhileStatement)
		WriteKeyword("Do")
		WriteLine()
		Indent()
		Visit(node.Body)
		Outdent()
		WriteKeyword("Loop")
		WriteSpace()
		WriteKeyword("While")
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

End Class
