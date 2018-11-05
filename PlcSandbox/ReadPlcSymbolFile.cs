// Copy paste from this class to the address template. It should only be used as is for tests (there should not be a call to here from the template).

namespace PlcSandbox
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using static PlcSandbox.PrintTreeClass.PrinterClass;

    public class PrintTreeClass
    {
#pragma warning disable SA1124 // Do not use regions
        #region CopyRegion

        // Copy from here
#pragma warning disable SA1649 // File name must match first type name
#pragma warning disable SA1402 // File may only contain a single class
        public void PrintTree(ClassTree tree, bool child)
        {
            if (child)
            {
                WriteLine(string.Empty);
            }

            WriteLine($"public static class {tree.Name}");
            WriteLine("{");
            PushIndent("    ");
            var written = false;
            foreach (var prop in tree.Symbols)
            {
                if (written)
                {
                    WriteLine(string.Empty);
                }

                written = true;
                if (prop.ArrayInfo != null)
                {
                    var typeString = this.GetCsharpTypeAsClassNameString(prop.Type);
                    if (typeString == string.Empty)
                    {
                        written = false;
                    }
                    else
                    {
                        WriteLine(
                            $"public static {typeString}ArrayAddress{prop.ArrayInfo.Count()}DUnconnected {prop.Name.Split('.').Last()} {{ get; }} = new {typeString}ArrayAddress{prop.ArrayInfo.Count()}DUnconnected({prop.BitSize}, \"{prop.Name}\");");
                    }
                }
                else
                {
                    var stringType = this.GetCsharpTypeAsClassNameString(prop.Type);
                    if (stringType == string.Empty)
                    {
                        written = false;
                    }
                    else
                    {
                        WriteLine(
                            $"public static {stringType}AddressUnconnected {prop.Name.Split('.').Last()} {{ get; }} = new {stringType}AddressUnconnected({prop.BitSize}, \"{prop.Name}\");");
                    }
                }
            }

            foreach (var childTree in tree.Children)
            {
                this.PrintTree(childTree, true);
            }

            PopIndent();
            WriteLine("}");
            if (!child)
            {
                WriteLine(string.Empty);
            }
        }

        private string GetCsharpTypeAsClassNameString(string prop)
        {
            switch (prop)
            {
                case "BOOL":
                    return "Bool";
                case "BYTE":
                    return "Byte";
                case "REAL":
                    return "Float";
                case "UDINT":
                    return "Uint";
                case "UINT":
                    return "Ushort";
                case "INT":
                    return "Short";
                case "DINT":
                    return "Int";
                case "LREAL":
                    return "Double";
                case "DWORD":
                    return "Uint";
                case "WORD":
                    return "Short";
                default:
                    if (prop.StartsWith("STRING"))
                    {
                        return "String";
                    }
                    else
                    {
                        return string.Empty;
                    }
            }
        }

        private string GetCsharpTypeAsString(string prop)
        {
            return this.GetCsharpTypeAsClassNameString(prop).ToLower();
        }

        public class ParsePlcSymbolFile
        {
            public static IEnumerable<ClassTree> ReadFile(string path)
            {
                var xml = XDocument.Load(path);
                var dataTypes = xml.Root.Descendants(XName.Get("DataTypes"));

                var types = new List<PlcType>();

                foreach (var dataType2 in dataTypes)
                {
                    var dataTypes2 = dataType2.Descendants(XName.Get("DataType"));
                    foreach (var dataType in dataTypes2)
                    {

                        var type = new PlcType(dataType.Element("Name").Value);
                        foreach (var symbol in dataType.Descendants(XName.Get("SubItem")))
                        {
                            var arrInfos = symbol.Descendants(XName.Get("ArrayInfo"));
                            List<ArrayInfo> arrInfoList = null;
                            if (arrInfos.Any())
                            {
                                arrInfoList = new List<ArrayInfo>();
                                foreach (var arrInfo in arrInfos)
                                {
                                    arrInfoList.Add(
                                        new ArrayInfo(int.Parse(arrInfo.Element("LBound").Value),
                                            int.Parse(arrInfo.Element("Elements").Value)));
                                }
                            }

                            var parsedSymbol = new PlcSymbol(symbol.Element("Name").Value,
                                symbol.Element("Type").Value,
                                int.Parse(symbol.Element("BitSize").Value), int.Parse(symbol.Element("BitOffs").Value),
                                arrInfoList);

                            type.AddSymbol(parsedSymbol);
                        }

                        types.Add(type);
                    }
                }

                var dataAreas = xml.Root.Descendants(XName.Get("DataArea"));
                var classNames = new List<string>();

                var symbols = new List<PlcSymbol>();

                foreach (var dataArea in dataAreas)
                {
                    foreach (var symbol in dataArea.Descendants(XName.Get("Symbol")))
                    {
                        var arrInfos = symbol.Descendants(XName.Get("ArrayInfo"));
                        List<ArrayInfo> arrInfoList = null;
                        if (arrInfos.Any())
                        {
                            arrInfoList = new List<ArrayInfo>();
                            foreach (var arrInfo in arrInfos)
                            {
                                arrInfoList.Add(
                                    new ArrayInfo(int.Parse(arrInfo.Element("LBound").Value),
                                        int.Parse(arrInfo.Element("Elements").Value)));
                            }
                        }

                        symbols.Add(new PlcSymbol(symbol.Element("Name").Value, symbol.Element("BaseType").Value,
                            int.Parse(symbol.Element("BitSize").Value), int.Parse(symbol.Element("BitOffs").Value),
                            arrInfoList));
                    }
                }

                var replacedSymbols = ReplaceTypeWithSymbol(symbols, types);

                foreach (var plcSymbol in replacedSymbols)
                {
                    classNames = CheckAndAddClass(plcSymbol.Name, classNames);
                }

                var trees = new List<ClassTree>();

                foreach (var classPath in classNames)
                {
                    trees = UpdateTreesFromPath(classPath, trees);
                }

                foreach (var plcSymbol in replacedSymbols)
                {
                    MapToTree(trees, plcSymbol);
                }

                return trees;
            }

            public static List<ClassTree> UpdateTreesFromPath(string classPath, List<ClassTree> trees)
            {
                var firstChild = classPath.Contains(".") ? classPath.Split('.').First() : classPath;
                foreach (var classTree in trees)
                {
                    if (classTree.Name == firstChild)
                    {
                        classTree.AddToTree(classPath);
                        return trees;
                    }
                }

                trees.Add(new ClassTree(classPath));
                return trees;
            }

            public static List<string> CheckAndAddClass(string currentSymbolName, List<string> classNames)
            {
                var currentNames = currentSymbolName.Contains(".")
                    ? currentSymbolName.Split('.')
                    : new[] {currentSymbolName};
                if (currentNames.Length < 2)
                {
                    return classNames;
                }

                currentNames = currentNames.Take(currentNames.Length - 1).ToArray();

                var existingClass = classNames.FirstOrDefault(x =>
                {
                    var firstClassNameSplit = x.Contains(".") ? x.Split('.') : new[] {x};

                    var allEquals = true;
                    for (int i = 0; i < Math.Min(currentNames.Length, firstClassNameSplit.Length); i++)
                    {
                        allEquals = allEquals && (firstClassNameSplit[i] == currentNames[i]);
                    }
                    return allEquals;
                });

                var currentName = currentNames.Length > 1 ? string.Join(".", currentNames) : currentNames[0];
                if (existingClass != null)
                {
                    if (existingClass.Length < currentName.Length)
                    {
                        classNames.Remove(existingClass);
                        classNames.Add(currentName);
                    }

                    return classNames;
                }
                else
                {
                    classNames.Add(currentName);
                    return classNames;
                }
            }

            public static PlcSymbol[] ReplaceTypeWithSymbol(IEnumerable<PlcSymbol> symbols, IEnumerable<PlcType> type)
            {
                if (symbols == null)
                {
                    throw new ArgumentException();
                }

                var newList = new List<PlcSymbol>();
                var plcSymbols = symbols.ToArray();
                var plcTypes = type.ToArray();

                foreach (var plcSymbol in plcSymbols)
                {
                    var compoundType = plcTypes.SingleOrDefault(x => x.TypeName == plcSymbol.Type);
                    if (compoundType == null)
                    {
                        continue;
                    }

                    foreach (var compoundTypeSymbol in compoundType.Symbols)
                    {
                        newList.Add(new PlcSymbol($"{plcSymbol.Name}.{compoundTypeSymbol.Name}", compoundTypeSymbol.Type, compoundTypeSymbol.BitSize, compoundTypeSymbol.BitOffset, compoundTypeSymbol.ArrayInfo));
                    }
                }

                newList.AddRange(plcSymbols);
                return newList.ToArray();
            }

            public static void MapToTree(IEnumerable<ClassTree> trees, PlcSymbol symbol)
            {
                foreach (var classTree in trees)
                {
                    var nodeToAddTo = classTree.FindNode(symbol.Name);
                    if (nodeToAddTo != null)
                    {
                        nodeToAddTo.AddSymbol(symbol);
                        return;
                    }
                }
            }
        }

        public class PlcSymbol
        {
            public PlcSymbol(string name, string type, int bitSize, int bitOffset, IEnumerable<ArrayInfo> arrayInfo)
            {
                this.Name = name;
                this.Type = type;
                this.BitSize = bitSize;
                this.BitOffset = bitOffset;
                this.ArrayInfo = arrayInfo;
            }

            public string Name { get; }

            public string Type { get; }

            public int BitSize { get; }

            public int BitOffset { get; }

            public IEnumerable<ArrayInfo> ArrayInfo { get; }
        }

        public class ArrayInfo
        {
            public ArrayInfo(int lowerBound, int elements)
            {
                this.LowerBound = lowerBound;
                this.Elements = elements;
            }

            public int LowerBound { get; }

            public int Elements { get; }
        }

        public class PlcType
        {
            public PlcType(string typeName)
            {
                this.TypeName = typeName;
            }

            public string TypeName { get; }

            public void AddSymbol(PlcSymbol symbol)
            {
                this.Symbols.Add(symbol);
            }

            public IList<PlcSymbol> Symbols { get; } = new List<PlcSymbol>();
        }

        public class ClassTree
        {
            public ClassTree(string name)
            {
                this.Children = new List<ClassTree>();
                this.Symbols = new List<PlcSymbol>();
                if (name.Contains("."))
                {
                    this.Name = name.Remove(name.IndexOf("."));
                    this.Children.Add(new ClassTree(name.Remove(0, name.IndexOf(".") + 1)));
                }
                else
                {
                    this.Name = name;
                }
            }

            public string Name { get; }

            public List<ClassTree> Children { get; }

            public List<PlcSymbol> Symbols { get; }

            public void AddSymbol(PlcSymbol symbol)
            {
                if (this.Symbols.All(x => x.Name != symbol.Name))
                {
                    this.Symbols.Add(symbol);
                }
            }

            public void AddToTree(string classPath)
            {
                if (classPath.Contains("."))
                {
                    var splitupName = classPath.Split('.');
                    if (splitupName.First() != this.Name)
                    {
                        throw new InvalidOperationException("Wrong mapping");
                    }

                    var childName = splitupName[1];
                    var childToAddTo = this.Children.FirstOrDefault(x =>
                    {
                        if (x != null)
                        {
                            return x.Name == childName;
                        }
                        return false;
                    });
                    var remainderString =
                        splitupName.Length > 1 ? string.Join(".", splitupName.Skip(1)) : splitupName[1];
                    if (childToAddTo == null)
                    {
                        this.Children.Add(new ClassTree(remainderString));
                    }
                    else
                    {
                        childToAddTo.AddToTree(remainderString);
                    }
                }
            }

            public ClassTree FindNode(string name)
            {
                if (!name.Contains("."))
                {
                    throw new InvalidOperationException($"Name must contain '.' but was: {name}");
                }
                else
                {
                    var splitupName = name.Split('.');
                    if (splitupName.First() != this.Name)
                    {
                        return null;
                    }

                    var childName = splitupName[1];
                    var childPath = this.Children.FirstOrDefault(x =>
                    {
                        if (x == null)
                        {
                            return false;
                        }

                        return x.Name == childName;
                    });
                    if (childPath != null && splitupName.Length > 2)
                    {
                        return childPath.FindNode(string.Join(".", splitupName.Skip(1)));
                    }
                    else
                    {
                        return this;
                    }
                }
            }
        }
#pragma warning restore SA1649 // File name must match first type name
#pragma warning restore SA1402 // File may only contain a single class

        //Stop copying here
        #endregion

        public class PrinterClass
        {
            public static List<string> Indent { get; } = new List<string>();

            public static StringWriter Writer { get; } = new StringWriter();

            public static void WriteLine(string line)
            {
                string indentString = Indent.Aggregate(string.Empty, (current, indent) => current + indent);
                Writer.WriteLine(indentString + line);
            }

            public static void PushIndent(string indent)
            {
                Indent.Add(indent);
            }

            public static void PopIndent()
            {
                Indent.Remove(Indent.Last());
            }
        }
    }
}
