Option Strict On

Imports Cecil.Decompiler
Imports Cecil.Decompiler.Languages
Imports Cecil.Decompiler.ControlFlow
Imports System.IO
Imports Mono.Cecil

Class Program

	Shared methodsList As IList(Of String) = New List(Of String)






	Public Shared Sub Main()

		'methodsList.Add("ReturnVoid")
		'methodsList.Add("ReturnString")
		'methodsList.Add("Identity")
		'		methodsList.Add("SimpleIfElse")
		'		methodsList.Add("SimpleIfElse2")
		'methodsList.Add("Addition")
		'methodsList.Add("Addition2")
		methodsList.Add("MyWhile")
		'		methodsList.Add("MyWhileX2")
		'		methodsList.Add("MyDoWhile")
		'		methodsList.Add("MyDoUntil")
		'methodsList.Add("PublicSub")

		For i As Integer = 0 To methodsList.Count - 1

			Dim cfg = ControlFlowGraph.Create(GetProgramMethod(methodsList(i)))

			FormatControlFlowGraph(Console.Out, cfg)


			Console.Write(String.Format("===={0}====", methodsList(i)))
			Console.WriteLine()

			Dim method = GetProgramMethod(methodsList(i))
			Dim language = New VisualBasic()
			Dim body = method.Body.Decompile(language)
            Dim writer = language.GetWriter(New PlainTextFormatter(Console.Out))
			writer.Write(method)

			Console.WriteLine()
			'Console.Write("================================================================================")
			'Console.WriteLine()
		Next


	End Sub

	Public Shared Sub FormatControlFlowGraph(ByVal writer As TextWriter, ByVal cfg As ControlFlowGraph)

		For Each block As InstructionBlock In cfg.Blocks
			writer.WriteLine("block {0}:", block.Index)
			writer.WriteLine("\tbody:")
			For Each instruction As Mono.Cecil.Cil.Instruction In block
				writer.Write("\t\t")
				Dim data = cfg.GetData(instruction)
				writer.Write("[{0}:{1}] ", data.StackBefore, data.StackAfter)
				Cecil.Decompiler.Cil.Formatter.WriteInstruction(writer, instruction)
				writer.WriteLine()
			Next
			Dim successors As InstructionBlock() = block.Successors
			If successors.Length > 0 Then
				writer.WriteLine("\tsuccessors:")
				For Each successor As InstructionBlock In successors
					writer.WriteLine("\t\tblock {0}", successor.Index)
				Next
			End If
			Next
	End Sub


	Shared Function GetProgramMethod(ByVal name As String) As MethodDefinition
		Return GetProgramAssembly().MainModule.Types("vbdbg.TestMethods").Methods.GetMethod(name)(0)
	End Function


	Shared Function GetProgramAssembly() As AssemblyDefinition
		Dim assembly As AssemblyDefinition = AssemblyFactory.GetAssembly(GetType(Program).Module.FullyQualifiedName)
		Return assembly
	End Function

End Class
