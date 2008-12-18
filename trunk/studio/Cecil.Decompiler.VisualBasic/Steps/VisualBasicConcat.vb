Imports Cecil.Decompiler.Ast

Namespace Steps

	Public Class VisualBasicConcat
        Implements IDecompilationStep

        Public Function Process(ByVal context As DecompilationContext, ByVal body As BlockStatement) As BlockStatement Implements IDecompilationStep.Process
            Return body
        End Function
    End Class

End Namespace
