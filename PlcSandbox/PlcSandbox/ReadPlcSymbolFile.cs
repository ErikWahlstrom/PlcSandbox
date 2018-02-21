// Copy paste from this class to the address template. It should only be used as is for tests (there should not be a call to here from the template).

namespace PlcSandbox
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    // Copy from here
#pragma warning disable SA1649 // File name must match first type name
#pragma warning disable SA1402 // File may only contain a single class
    public class ParsePlcSymbolFile
    {
        public static IEnumerable<ClassTree> ReadFile(string path)
        {
            var xml = XDocument.Load(path);
            var dataAreas = xml.Root.Descendants(XName.Get("DataArea"));
            var classNames = new List<string>();

            var symbols = new List<PlcSymbol>();

            foreach (var dataArea in dataAreas)
            {
                var distinctName = dataArea.Descendants(XName.Get("Symbol")).Elements().Where(x => x.Name == "Name").Select(y => y.Value.ToString()).Distinct();
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
                    symbols.Add(new PlcSymbol(symbol.Element("Name").Value, symbol.Element("BaseType").Value, int.Parse(symbol.Element("BitSize").Value), int.Parse(symbol.Element("BitOffs").Value)));
                }
            }

            var trees = new List<ClassTree>();

            foreach (var nameSpace in classNames.Distinct())
            {
                trees.Add(new ClassTree(nameSpace));
            }

            foreach (var plcSymbol in symbols)
            {
                MapToTree(trees, plcSymbol);
            }

            return trees;
        }

        public static void MapToTree(IEnumerable<ClassTree> trees, PlcSymbol symbol)
        {
            var choppedUpSymbol = symbol.Name.Split('.');
            var possibleTrees = trees;
            for (int i = 0; i < choppedUpSymbol.Length - 2; i++)
            {
                possibleTrees = possibleTrees.Where(x => x.Name == choppedUpSymbol[i]).Select(x => x.Children).ToArray();
            }

            if (!possibleTrees.Any())
            {
                throw new InvalidOperationException("Free flying symbol...");
            }

            possibleTrees.Single(x => x.Name == choppedUpSymbol[choppedUpSymbol.Length - 2]).AddSymbol(symbol);
        }
    }

    public class PlcSymbol
    {
        public PlcSymbol(string name, string type, int bitSize, int bitOffset)
        {
            this.Name = name;
            this.Type = type;
            this.BitSize = bitSize;
            this.BitOffset = bitOffset;
        }

        public string Name { get; }

        public string Type { get; }

        public int BitSize { get; }

        public int BitOffset { get; }
    }

    public class ClassTree
    {
        public ClassTree(string name)
        {
            this.Symbols = new List<PlcSymbol>();
            if (name.Contains("."))
            {
                this.Name = name.Remove(name.IndexOf("."));
                this.Children = new ClassTree(name.Remove(0, name.IndexOf(".") + 1));
            }
            else
            {
                this.Name = name;
            }
        }

        public string Name { get; }

        public ClassTree Children { get; }

        public IList<PlcSymbol> Symbols { get; }

        public void AddSymbol(PlcSymbol symbol)
        {
            this.Symbols.Add(symbol);
        }
    }
#pragma warning restore SA1649 // File name must match first type name
#pragma warning restore SA1402 // File may only contain a single class

    // To here
}
