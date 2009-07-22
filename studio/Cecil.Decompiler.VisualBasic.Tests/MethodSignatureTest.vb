Imports Mono.Cecil
Imports Cecil.Decompiler
Imports Cecil.Decompiler.Languages
Imports NUnit.Core
Imports Mono.Cecil.Cil
Imports NUnit.Framework

<TestFixture()> _
Public Class MethodSignatureTest
    Inherits DecompilerTestFixture

    <DecompilerTestFixture(Filename:="\MethodSignatures\PublicSub.vb", MethodName:="PublicSub", Mode:=Mode.MethodDefinition)> _
 Public Sub TestPublicSub(ByVal body As MethodDefinition, ByVal expected As String)
        Dim vbLanguage As ILanguage = New Languages.VisualBasic
        AssertMethodDefinition(body, expected, vbLanguage)
    End Sub

    <DecompilerTest(Filename:="\MethodSignatures\PrivateSub.vb", MethodName:="PrivateSub", Mode:=Mode.MethodDefinition)> _
 Public Sub TestPrivateSub(ByVal body As MethodDefinition, ByVal expected As String)
        Dim vbLanguage As ILanguage = New Languages.VisualBasic
        AssertMethodDefinition(body, expected, vbLanguage)
    End Sub

	<DecompilationTest(Filename:="\MethodSignatures\ProtectedSub.vb", MethodName:="ProtectedSub", Mode:=Mode.MethodDefinition)> _
 Public Sub TestProtectedSub(ByVal body As MethodDefinition, ByVal expected As String)
		Dim vbLanguage As ILanguage = New Languages.VisualBasic
		AssertMethodDefinition(body, expected, vbLanguage)
	End Sub

	<DecompilationTest(Filename:="\MethodSignatures\PublicSharedSub.vb", MethodName:="PublicSharedSub", Mode:=Mode.MethodDefinition)> _
	Public Sub TestPublicSharedSub(ByVal body As MethodDefinition, ByVal expected As String)
		Dim vbLanguage As ILanguage = New Languages.VisualBasic
		AssertMethodDefinition(body, expected, vbLanguage)
	End Sub

	<DecompilationTest(Filename:="\MethodSignatures\PublicOverridesFunction.vb", MethodName:="ToString", Mode:=Mode.MethodDefinition)> _
 Public Sub TestPublicOverridesFunction(ByVal body As MethodDefinition, ByVal expected As String)
		Dim vbLanguage As ILanguage = New Languages.VisualBasic
		AssertMethodDefinition(body, expected, vbLanguage)
	End Sub

End Class
