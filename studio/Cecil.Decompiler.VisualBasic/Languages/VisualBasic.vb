Imports Cecil.Decompiler.Ast
Imports Cecil.Decompiler.Steps
Imports Cecil.Decompiler.Languages

Namespace Languages

	Public Class VisualBasic
		Implements ILanguage

		Public Overridable ReadOnly Property Name() As String Implements ILanguage.Name
			Get
				Return "Visual Basic"
			End Get
		End Property

		Public Function GetWriter(ByVal formatter As IFormatter) As ILanguageWriter Implements ILanguage.GetWriter
            Return New VisualBasicWriter(Me, formatter)
		End Function

		Public Overridable Function CreatePipeline() As DecompilationPipeline Implements ILanguage.CreatePipeline
			Return New DecompilationPipeline(New StatementDecompiler(BlockOptimization.Detailed), _
					 RemoveLastReturn.Instance, _
			   DeclareTopLevelVariables.Instance)
		End Function

		Public Shared Function GetLanguage(ByVal version As VisualBasicVersion) As ILanguage

			Select Case version
				Case VisualBasicVersion.None
					Return New VisualBasic
				Case VisualBasicVersion.VB7
					Return New VisualBasic7
				Case VisualBasicVersion.VB8
					Return New VisualBasic8
				Case VisualBasicVersion.VB9
					Return New VisualBasic9
				Case Else
					Throw New ArgumentException()
			End Select

		End Function

	End Class

	Public Class VisualBasic7
		Inherits VisualBasic

		Public Overrides ReadOnly Property Name() As String
			Get
				Return "Visual Basic 7"
			End Get
		End Property

		'Public Overrides Function CreatePipeline() As DecompilationPipeline Implements ILanguage.CreatePipeline
		'    Return New DecompilationPipeline(New StatementDecompiler(BlockOptimization.Basic), DeclareTopLevelVariables.Instance)
		'End Function

	End Class

	Public Class VisualBasic8
		Inherits VisualBasic

		Public Overrides ReadOnly Property Name() As String
			Get
				Return "Visual Basic 8"
			End Get
		End Property

		'Public Overrides Function CreatePipeline() As DecompilationPipeline Implements ILanguage.CreatePipeline
		'    Return New DecompilationPipeline(New StatementDecompiler(BlockOptimization.Basic), DeclareTopLevelVariables.Instance)
		'End Function

	End Class

	Public Class VisualBasic9
		Inherits VisualBasic

		Public Overrides ReadOnly Property Name() As String
			Get
				Return "Visual Basic 9"
			End Get
		End Property

		'Public Overrides Function CreatePipeline() As DecompilationPipeline Implements ILanguage.CreatePipeline
		'    Return New DecompilationPipeline(New StatementDecompiler(BlockOptimization.Basic), DeclareTopLevelVariables.Instance)
		'End Function

	End Class

	Public Enum VisualBasicVersion
		None
		VB7
		VB8
		VB9
	End Enum

End Namespace
