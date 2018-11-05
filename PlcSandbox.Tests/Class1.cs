namespace PlcSandbox.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using NUnit.Framework.Internal;

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
            var result = PrintTreeClass.ParsePlcSymbolFile.CheckAndAddClass(newString, existingStrings?.ToList() ?? new List<string>());
            CollectionAssert.AreEquivalent(expected.ToList(), result);
            Assert.AreEqual(expected.Length, result.Count);
        }

        [Test]
        public void AddToTreeTests()
        {
            var trees = new List<PrintTreeClass.ClassTree>
            {
                new PrintTreeClass.ClassTree("Class1.Class2")
            };
            var result = PrintTreeClass.ParsePlcSymbolFile.UpdateTreesFromPath("Class1.Class3", trees);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(2, result.First().Children.Count());
        }

        [Test]
        public void AddToTreeTests2()
        {
            var trees = new List<PrintTreeClass.ClassTree>();
            var result = PrintTreeClass.ParsePlcSymbolFile.UpdateTreesFromPath("Class1.Class3", trees);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result.First().Children.Count());
        }

        [Test]
        public void MapToTree()
        {
            var treeStructure = new List<PrintTreeClass.ClassTree>
            {
                new PrintTreeClass.ClassTree("Class1.Class2")
            };
            treeStructure = PrintTreeClass.ParsePlcSymbolFile.UpdateTreesFromPath("Class1.Class3", treeStructure);
            PrintTreeClass.ParsePlcSymbolFile.MapToTree(treeStructure, new PrintTreeClass.PlcSymbol("Class1.Class2.Variable12", "string", 1, 3, null));
            Assert.AreEqual("Class1.Class2.Variable12", treeStructure.First().Children.First().Symbols.First().Name);
        }

        [Test]
        public void FindNode()
        {
            var classTree = new PrintTreeClass.ClassTree("Class1.Class2");
            var node = classTree.FindNode("Class1.Class2.Varnamn");
            Assert.AreEqual("Class2", node.Name);
        }

        [Test]
        public void FindNode2()
        {
            var classTree = new PrintTreeClass.ClassTree("Class1.Class2");
            classTree.AddToTree("Class1.Class2.Class3");
            var node = classTree.FindNode("Class1.Class2.Varnsdsd");
            Assert.AreEqual("Class2", node.Name);
            node = classTree.FindNode("Class1.Class2.Class3.Varnasd");
            Assert.AreEqual("Class3", node.Name);
        }

        [Test]
        public void FindNode3()
        {
            var classTree = new PrintTreeClass.ClassTree("Class1.Class2");
            classTree.AddToTree("Class1.Class2.Class3");
            var node = classTree.FindNode("Class1.Class2.Varnsdsd");
            Assert.AreEqual("Class2", node.Name);
            node = classTree.FindNode("Class1.Class2.Class3.Varnasd");
            Assert.AreEqual("Class3", node.Name);
            node = classTree.FindNode("Class1.Varname");
            Assert.AreEqual("Class1", node.Name);
        }

        [Test]
        public void FindNode4()
        {
            var classTree = new PrintTreeClass.ClassTree("Class1.Class2");
            classTree.AddToTree("Class1.Class2.Class3");
            classTree.AddToTree("Class1.Class22.Class3");
            classTree.AddToTree("Class1.Class22.Class33");
            classTree.AddToTree("Class1.Class21.Class3");

            var node = classTree.FindNode("Class1.Class2.Varnsdsd");
            Assert.AreEqual("Class2", node.Name);
            node = classTree.FindNode("Class1.Class2.Class3.Varnasd");
            Assert.AreEqual("Class3", node.Name);
            node = classTree.FindNode("Class1.Varname");
            Assert.AreEqual("Class1", node.Name);
            node = classTree.FindNode("Class1.Class22"); //Strange case but seems to exist
            Assert.AreEqual("Class1", node.Name);
        }

        [Test]
        public void AddSymbols()
        {
            var classTree = new PrintTreeClass.ClassTree("Class1.Class2");
            classTree.AddSymbol(new PrintTreeClass.PlcSymbol("Variable1", "type", 1, 1, null));
            classTree.AddSymbol(new PrintTreeClass.PlcSymbol("Variable2", "type", 1, 1, null));
            classTree.AddSymbol(new PrintTreeClass.PlcSymbol("Variable1", "type", 1, 1, null));
            Assert.AreEqual(2, classTree.Symbols.Count);
        }

        [Test]
        public void AddArray()
        {
            var classTree = new PrintTreeClass.ClassTree("Class1.Class2");
            classTree.AddSymbol(new PrintTreeClass.PlcSymbol("ArrayVariable1", "LREAL", 1, 1, new[] { new PrintTreeClass.ArrayInfo(1, 506) }));
            Assert.AreEqual(1, classTree.Symbols.Count);
            var classRef = new PrintTreeClass();
            classRef.PrintTree(classTree, false);
            Console.WriteLine(PrintTreeClass.PrinterClass.Writer.ToString());
        }

        [Test]
        public void TestIt()
        {
            var classRef = new PrintTreeClass();
            var parsedFile = PrintTreeClass.ParsePlcSymbolFile.ReadFile(TestContext.CurrentContext.TestDirectory + "\\PlcTest.tmc");
            Console.WriteLine("____________ClassTrees_________________");
            foreach (var parsedFileClassTree in parsedFile)
            {
                classRef.PrintTree(parsedFileClassTree, false);
            }

            Console.WriteLine(PrintTreeClass.PrinterClass.Writer.ToString());
        }

        [Test]
        public void VariableFromFunctionBlock()
        {
            var parsedFile = PrintTreeClass.ParsePlcSymbolFile.ReadFile(TestContext.CurrentContext.TestDirectory + "\\PlcRun.tmc").ToArray();
            Assert.AreEqual(
                "BOOL",
                parsedFile.First(x => x.Name == "MAIN").Children.First(x => x.Name == "mainFbTest").Symbols.First(x => x.Name == "MAIN.mainFbTest.InputBool").Type);
            Console.WriteLine("____________ClassTrees_________________");
            var classRef = new PrintTreeClass();
            foreach (var parsedFileClassTree in parsedFile)
            {
                classRef.PrintTree(parsedFileClassTree, false);
            }
            Console.WriteLine(PrintTreeClass.PrinterClass.Writer.ToString());
        }
    }
}
