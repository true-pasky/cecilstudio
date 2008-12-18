Imports Cecil.Decompiler.Steps
Imports Mono.Cecil.Cil

Public Class OnErrorResumeNext
	Implements IDecompilationStep

	Public Shared ReadOnly Instance As OnErrorResumeNext = New OnErrorResumeNext()

	Public Sub Process(ByVal context As DecompilationContext, ByVal body As Ast.BlockStatement) Implements Steps.IDecompilationStep.Process

	End Sub

	Public Function HasClearProject(ByVal body As MethodBody) As Boolean
		Dim a As String = body.Instructions(0).OpCode.ToString
		Dim b As String = body.Instructions(0).Operand.ToString
		Dim ad As String = "l"

	End Function
End Class
