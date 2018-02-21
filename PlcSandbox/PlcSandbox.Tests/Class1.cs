namespace PlcSandbox.Tests
{
    using System;
    using NUnit.Framework;

    public class Class1
    {
        [Test]
        public void TestIt()
        {
            var parsedFile = ParsePlcSymbolFile.ReadFile(TestContext.CurrentContext.TestDirectory + "\\PrinterPlc.tmc");

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
