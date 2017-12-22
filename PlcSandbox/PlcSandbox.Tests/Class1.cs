using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlcSandbox.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Internal;

    public class Class1
    {
        [Test]
        public void TestIt()
        {
            var parsedFile = new ReadPlcSymbolFile(TestContext.CurrentContext.TestDirectory);

            Console.WriteLine("____________ClassTrees_________________");
            foreach (var parsedFileClassTree in parsedFile.ClassTrees)
            {
                PrintTree(parsedFileClassTree);
            }
        }

        private void PrintTree(ClassTree parsedFileClassTree, int indent = 0)
        {
            Console.WriteLine("__TreeName");
            WriteLineWithIndent(parsedFileClassTree.Name, indent);
            Console.WriteLine("__Symbols");
            foreach (var plcSymbol in parsedFileClassTree.Symbols)
            {
                WriteLineWithIndent($"{plcSymbol.Name} : {plcSymbol.Type}", indent + 1);
            }
            
            var child = parsedFileClassTree.Children;
            if (child != null)
            {
                PrintTree(child, indent + 1);
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
