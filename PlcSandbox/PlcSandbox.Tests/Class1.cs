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
            var result = ParsePlcSymbolFile.CheckAndAddClass(newString, existingStrings?.ToList() ?? new List<string>());
            CollectionAssert.AreEquivalent(expected.ToList(), result);
            Assert.AreEqual(expected.Length, result.Count);
        }

        [Test]
        public void AddToTreeTests()
        {
            var trees = new List<ClassTree>
            {
                new ClassTree("Class1.Class2")
            };
            var result = ParsePlcSymbolFile.UpdateTreesFromPath("Class1.Class3", trees);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(2, result.First().Children.Count());
        }

        [Test]
        public void AddToTreeTests2()
        {
            var trees = new List<ClassTree>();
            var result = ParsePlcSymbolFile.UpdateTreesFromPath("Class1.Class3", trees);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result.First().Children.Count());
        }

        [Test]
        public void MapToTree()
        {
            var treeStructure = new List<ClassTree>
            {
                new ClassTree("Class1.Class2")
            };
            treeStructure = ParsePlcSymbolFile.UpdateTreesFromPath("Class1.Class3", treeStructure);
            ParsePlcSymbolFile.MapToTree(treeStructure, new PlcSymbol("Class1.Class2.Variable12", "string", 1, 3));
            Assert.AreEqual("Class1.Class2.Variable12", treeStructure.First().Children.First().Symbols.First().Name);
        }

        [Test]
        public void FindNode()
        {
            var classTree = new ClassTree("Class1.Class2");
            var node = classTree.FindNode("Class1.Class2.Varnamn");
            Assert.AreEqual("Class2", node.Name);
        }

        [Test]
        public void FindNode2()
        {
            var classTree = new ClassTree("Class1.Class2");
            classTree.AddToTree("Class1.Class2.Class3");
            var node = classTree.FindNode("Class1.Class2.Varnsdsd");
            Assert.AreEqual("Class2", node.Name);
            node = classTree.FindNode("Class1.Class2.Class3.Varnasd");
            Assert.AreEqual("Class3", node.Name);
        }

        [Test]
        public void FindNode3()
        {
            var classTree = new ClassTree("Class1.Class2");
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
            var classTree = new ClassTree("Class1.Class2");
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
            var classTree = new ClassTree("Class1.Class2");
            classTree.AddSymbol(new PlcSymbol("Variable1", "type", 1, 1));
            classTree.AddSymbol(new PlcSymbol("Variable2", "type", 1, 1));
            classTree.AddSymbol(new PlcSymbol("Variable1", "type", 1, 1));
            Assert.AreEqual(2, classTree.Symbols.Count);
        }

        [Test]
        public void TestIt()
        {
            var parsedFile = ParsePlcSymbolFile.ReadFile("C:\\shared\\plc\\PLC_NCi.tmc"); //TestContext.CurrentContext.TestDirectory + "\\PlcTest.tmc");
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

            foreach (var child in parsedFileClassTree.Children)
            {
                if (child != null)
                {
                    this.PrintTree(child, indent + 1);
                }
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
