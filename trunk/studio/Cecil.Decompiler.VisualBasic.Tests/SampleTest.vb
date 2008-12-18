Imports Mono.Cecil
Imports Cecil.Decompiler.Tests.Cecil.Decompilation
Imports Cecil.Decompiler.Languages
Imports NUnit.Core
Imports Mono.Cecil.Cil
Imports NUnit.Framework

<TestFixture()> _
Public Class SampleTest
	Inherits DecompilationTestFixture

	<DecompilationTest(Filename:="ReturnTest.vb", MethodName:="Test")> _
	Public Sub TestReturn(ByVal body As MethodBody, ByVal expected As String)
		Dim vbLanguage As ILanguage = New Languages.VisualBasic
		AssertMethod(body, expected, vbLanguage)
	End Sub

	<DecompilationTest(Filename:="\Patrice\ReturnTestDef.vb", MethodName:="Test", Mode:=Mode.MethodDefinition)> _
 Public Sub TestReturnDef(ByVal body As MethodDefinition, ByVal expected As String)
		Dim vbLanguage As ILanguage = New Languages.VisualBasic
		AssertMethodDefinition(body, expected, vbLanguage)
	End Sub

	<DecompilationTest(Filename:="LoopTests.vb", MethodName:="MyWhile")> _
	Public Sub TestMyWhile(ByVal body As MethodBody, ByVal expected As String)
		Dim vbLanguage As ILanguage = New Languages.VisualBasic
		AssertMethod(body, expected, vbLanguage)
	End Sub

	<DecompilationTest(Filename:="ReturnVoid.vb", MethodName:="ReturnVoid")> _
	   Public Sub TestReturnVoid(ByVal body As MethodBody, ByVal expected As String)
		Dim vbLanguage As ILanguage = New Languages.VisualBasic
		AssertMethod(body, expected, vbLanguage)
	End Sub

	<DecompilationTest(Filename:="Identity.vb", MethodName:="Identity")> _
	   Public Sub TestIdentity(ByVal body As MethodBody, ByVal expected As String)
		Dim vbLanguage As ILanguage = New Languages.VisualBasic
		AssertMethod(body, expected, vbLanguage)
	End Sub

	<DecompilationTest(Filename:="SimpleIfElse.vb", MethodName:="SimpleIfElse")> _
	   Public Sub TestSimpleIfElse(ByVal body As MethodBody, ByVal expected As String)
		Dim vbLanguage As ILanguage = New Languages.VisualBasic
		AssertMethod(body, expected, vbLanguage)
	End Sub

	<DecompilationTest(Filename:="SimpleIfElse2.vb", MethodName:="SimpleIfElse2")> _
	   Public Sub TestSimpleIfElse2(ByVal body As MethodBody, ByVal expected As String)
		Dim vbLanguage As ILanguage = New Languages.VisualBasic
		AssertMethod(body, expected, vbLanguage)
	End Sub

	<DecompilationTest(Filename:="Addition.vb", MethodName:="Addition")> _
	   Public Sub TestAddition(ByVal body As MethodBody, ByVal expected As String)
		Dim vbLanguage As ILanguage = New Languages.VisualBasic
		AssertMethod(body, expected, vbLanguage)
	End Sub

	<DecompilationTest(Filename:="Addition2.vb", MethodName:="Addition2")> _
	   Public Sub TestAddition2(ByVal body As MethodBody, ByVal expected As String)
		Dim vbLanguage As ILanguage = New Languages.VisualBasic
		AssertMethod(body, expected, vbLanguage)
	End Sub

End Class
