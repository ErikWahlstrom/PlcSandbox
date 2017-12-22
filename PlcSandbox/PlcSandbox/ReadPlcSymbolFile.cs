using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlcSandbox
{
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    public class ReadPlcSymbolFile
    {
        public ReadPlcSymbolFile(string currDir)
        {
            var xml = XDocument.Load(currDir + "\\PrinterPlc.tmc");
            var dataAreas = xml.Root.Descendants(XName.Get("DataArea"));
            var classNames = new List<string>();

            var symbols = new List<PlcSymbol>();

            foreach (var dataArea in dataAreas)
            {
                var distinctName = dataArea.Descendants(XName.Get("Symbol")).Elements().Where(x => x.Name == "Name").Select(y=>y.Value.ToString()).Distinct();
                foreach (var dist in distinctName)
                {
                    var splitted = dist.Split('.');
                    var currentClassName = string.Join(".", splitted.Take(splitted.Length - 1));
                    if (classNames.Any(x => x.Contains(currentClassName) && x.StartsWith(currentClassName)))
                    {
                        continue;
                    }

                    var existingClassName = classNames.SingleOrDefault(x => currentClassName.Contains(x) && currentClassName.StartsWith(x));
                    if (existingClassName != null)
                    {
                        classNames.Remove(existingClassName);
                    }

                    classNames.Add(currentClassName);
                }

                foreach (var symbol in dataArea.Descendants(XName.Get("Symbol")))
                {
                    symbols.Add(new PlcSymbol(symbol.Element("Name").Value, symbol.Element("BaseType").Value));
                }
            }

            var trees = new List<ClassTree>();

            foreach (var nameSpace in classNames.Distinct())
            {
                trees.Add(new ClassTree(nameSpace));
            }

            foreach (var plcSymbol in symbols)
            {
                trees.MapToTree(plcSymbol);
            }

            ClassTrees = trees;
        }

        public IEnumerable<ClassTree> ClassTrees { get; }
    }

    public class ClassTree
    {
        public ClassTree(string name)
        {
            Symbols = new List<PlcSymbol>();
            if (name.Contains("."))
            {
                Name = name.Remove(name.IndexOf("."));
                this.Children = new ClassTree(name.Remove(0, name.IndexOf(".") + 1));
            }
            else
            {
                Name = name;
            }
        }

        public string Name { get; }

        public ClassTree Children { get; }

        public void AddSymbol(PlcSymbol symbol)
        {
            this.Symbols.Add(symbol);
        }

        public IList<PlcSymbol> Symbols { get; }
    }

    public class PlcSymbol
    {
        public string Name { get; }
        public string Type { get; }

        public PlcSymbol(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }

    public static class Extensions
    {
        public static void MapToTree(this IEnumerable<ClassTree> trees, PlcSymbol symbol)
        {
            var choppedUpSymbol = symbol.Name.Split('.');
            var possibleTrees = trees;
            for (int i = 0; i < choppedUpSymbol.Length-2; i++)
            {
                possibleTrees = possibleTrees.Where(x => x.Name == choppedUpSymbol[i]).Select(x=>x.Children).ToArray();
            }
            if (!possibleTrees.Any())
            {
                throw new InvalidOperationException("Free flying symbol...");
            }
            possibleTrees.Single(x=>x.Name == choppedUpSymbol[choppedUpSymbol.Length-2]).AddSymbol(symbol);
        }
    }
}
