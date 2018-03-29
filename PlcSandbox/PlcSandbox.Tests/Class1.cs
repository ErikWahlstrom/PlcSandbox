namespace PlcSandbox.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    public class Class1
    {
        [TestCase("Class.newString", null, new[] { "Class" })]
        [TestCase("Class1.newVariable", new[] { "Class1.Class2", "Class1.Class3" }, new[] { "Class1.Class2", "Class1.Class3" })]
        [TestCase("Class.newString", new[] { "existingClass" }, new[] { "existingClass", "Class" })]
        [TestCase("newString.Variable", new[] { "existingString", "newString" }, new[] { "existingString", "newString" })]
        [TestCase("SAMPLE_10.Variable", new[] { "SAMPLE_100" }, new[] { "SAMPLE_10", "SAMPLE_100" })]
        [TestCase("SAMPLE_100.Variable", new[] { "SAMPLE_10" }, new[] { "SAMPLE_100", "SAMPLE_10" })]
        [TestCase("SAMPLE1.SAMPLE2.SAMPLE3.Variable", new[] { "SAMPLE1" }, new[] { "SAMPLE1.SAMPLE2.SAMPLE3" })]
        [TestCase("SAMPLE1.SAMPLE2.Variable1", new[] { "SAMPLE1.SAMPLE2" }, new[] { "SAMPLE1.SAMPLE2" })]
        [TestCase("Class1.Variable1", new[] { "Class1.Class2" }, new[] { "Class1.Class2" })]
        public void CheckAndAddClassTest(string newString, string[] existingStrings, params string[] expected)
        {
            var result = ParsePlcSymbolFile.CheckAndAddClass(newString, existingStrings?.ToList() ?? new List<string>());
            CollectionAssert.AreEquivalent(expected.ToList(), result);
            Assert.AreEqual(expected.Length, result.Count);
        }

        [Test]
        public void TestIt()
        {
            var parsedFile = ParsePlcSymbolFile.ReadFile(TestContext.CurrentContext.TestDirectory + "\\PlcTest.tmc");
            Console.WriteLine("____________ClassTrees_________________");
            foreach (var parsedFileClassTree in parsedFile)
            {
                this.PrintTree(parsedFileClassTree);
            }
        }

        private void PrintTree(ClassTree parsedFileClassTree, int indent = 0)
        {
            Console.WriteLine("__TreeName");
            this.WriteLineWithIndent(parsedFileClassTree.Name, indent);
            Console.WriteLine("__Symbols");
            foreach (var plcSymbol in parsedFileClassTree.Symbols)
            {
                this.WriteLineWithIndent($"{plcSymbol.Name} : {plcSymbol.Type} __ : {plcSymbol.BitOffset} :  {plcSymbol.BitSize} ", indent + 1);
            }

            var child = parsedFileClassTree.Children;
            if (child != null)
            {
                this.PrintTree(child, indent + 1);
            }
        }

        private void WriteLineWithIndent(string message, int indent)
        {
            for (int i = 0; i < indent; i++)
            {
                Console.Write("\t");
            }

            Console.WriteLine(message);
        }
    }
}
