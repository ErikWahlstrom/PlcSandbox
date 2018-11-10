// Copy paste from this class to the address template. It should only be used as is for tests (there should not be a call to here from the template).

using System.Diagnostics;
using System.Runtime.CompilerServices;
using GeneratedAddress;

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
        public void PrintTree(ClassTree tree, bool child, IEnumerable<PlcType> knownTypes)
        {
            if (knownTypes == null)
            {
                throw new ArgumentException("knownTypes must not be null", nameof(knownTypes));
            }

            knownTypes = knownTypes.ToArray();
            if (child)
            {
                WriteLine(string.Empty);
            }

            WriteLine($"public static class {tree.Name}");
            WriteLine("{");
            PushIndent("    ");
            var written = false;
            var writtenProps = new List<string>();

            foreach (var prop in tree.Symbols)
            {
                if (written)
                {
                    WriteLine(string.Empty);
                }

                written = true;
                if (prop.ArrayInfo != null)
                {
                    var typeString = this.GetCsharpTypeAsClassNameString(prop.Type.TypeName);
                    if (typeString == string.Empty)
                    {
                        typeString = prop.Type.TypeName;
                        if (knownTypes.Select(x => x.TypeName).Contains(typeString))
                        {
                            var propName = prop.Name.Split('.').Last();
                            WriteLine($"public static {typeString}ArrayAddress{prop.ArrayInfo.Count()}DUnconnected {propName} {{ get; }} = new {typeString}ArrayAddress{prop.ArrayInfo.Count()}DUnconnected({prop.BitSize}, \"{prop.Name}\");");
                            writtenProps.Add(propName);
                        }
                        else
                        {
                            written = false;
                        }
                    }
                    else
                    {
                        var propName = prop.Name.Split('.').Last();
                        WriteLine($"public static {typeString}ArrayAddress{prop.ArrayInfo.Count()}DUnconnected {propName} {{ get; }} = new {typeString}ArrayAddress{prop.ArrayInfo.Count()}DUnconnected({prop.BitSize}, \"{prop.Name}\");");
                        writtenProps.Add(propName);
                    }
                }
                else
                {
                    var stringType = this.GetCsharpTypeAsClassNameString(prop.Type.TypeName);
                    if (stringType == string.Empty)
                    {
                        stringType = prop.Type.TypeName;
                        if (knownTypes.Select(x => x.TypeName).Contains(stringType))
                        {
                            var propName = prop.Name.Split('.').Last();
                            WriteLine($"public static {stringType} {propName} {{ get; }} = new {stringType} (\"{prop.Name}\");");
                            writtenProps.Add(propName);
                        }
                        else
                        {
                            written = false;
                        }
                    }
                    else
                    {
                        var propName = prop.Name.Split('.').Last();
                        WriteLine($"public static {stringType}AddressUnconnected {propName} {{ get; }} = new {stringType}AddressUnconnected({prop.BitSize}, \"{prop.Name}\");");
                        writtenProps.Add(propName);
                    }
                }
            }

            ;
            foreach (var childTree in tree.Children)
            {
                if (!writtenProps.Contains(childTree.Name))
                {
                    this.PrintTree(childTree, true, knownTypes);
                }
            }

            PopIndent();
            WriteLine("}");
            if (!child)
            {
                WriteLine(string.Empty);
            }
        }

        public void PrintType(PlcType type)
        {
            var constructorInitializer = new List<string>();
            PushIndent("    ");
            WriteLine($"public class {type.TypeName}");
            WriteLine("{");
            PushIndent("    ");
            WriteLine("private string namedAddress;");
            WriteLine(string.Empty);
            foreach (var prop in type.Symbols)
            {
                if (prop.ArrayInfo != null)
                {
                    var typeString = this.GetCsharpTypeAsClassNameString(prop.Type.TypeName);
                    if (typeString == string.Empty)
                    {
                        typeString = prop.Type.TypeName;
                        if (typeString == "GUID" || typeString == "TIME" || typeString == "OTCID" || typeString == "PVOID" || typeString == "DT" || typeString == "ITComObjectServer")
                        {
                        }
                        else
                        {
                            WriteLine($"public {prop.Type.TypeName} {prop.Name.Split('.').Last()} {{ get; }}");
                            constructorInitializer.Add(
                                $"{prop.Name.Split('.').Last()} = new {prop.Type.TypeName}(this.namedAddress);");
                        }
                    }
                    else
                    {
                        WriteLine(
                            $"public {typeString}ArrayAddress{prop.ArrayInfo.Count()}DUnconnected {prop.Name.Split('.').Last()} {{ get; }}");
                        constructorInitializer.Add(
                            $"{prop.Name.Split('.').Last()} = new {typeString}ArrayAddress{prop.ArrayInfo.Count()}DUnconnected({prop.BitSize}, this.namedAddress + \".{prop.Name}\");");
                    }
                }
                else
                {
                    var stringType = this.GetCsharpTypeAsClassNameString(prop.Type.TypeName);
                    if (stringType == string.Empty)
                    {
                        stringType = prop.Type.TypeName;
                        if (stringType == "GUID" || stringType == "TIME" || stringType == "OTCID" || stringType == "PVOID" || stringType == "DT" || stringType == "ITComObjectServer")
                        {
                        }
                        else
                        {
                            WriteLine($"public {prop.Type.TypeName} {prop.Name.Split('.').Last()} {{ get; }}");
                            constructorInitializer.Add(
                                $"{prop.Name.Split('.').Last()} =  new {prop.Type.TypeName}(this.namedAddress);");
                        }
                    }
                    else
                    {
                        WriteLine($"public {stringType}AddressUnconnected {prop.Name.Split('.').Last()} {{ get; }}");
                        constructorInitializer.Add($" {prop.Name.Split('.').Last()} = new {stringType}AddressUnconnected({prop.BitSize}, this.namedAddress + \".{prop.Name}\");");
                    }
                }
            }

            WriteLine($"public {type.TypeName}(string namedAddress)");
            WriteLine("{");
            PushIndent("    ");
            WriteLine("this.namedAddress = namedAddress;");
            foreach (var addressAssignment in constructorInitializer)
            {
                WriteLine(addressAssignment);
            }

            PopIndent();
            WriteLine("}");
            WriteLine(string.Empty);

            PopIndent();
            WriteLine("}");
            PopIndent();
        }

        private string GetCsharpTypeAsClassNameString(string prop)
        {
            switch (prop)
            {
                case "BOOL":
                case "BIT":
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
                case "LINT":
                    return "Long";
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

        //private string GetCsharpTypeAsString(string prop)
        //{
        //    return this.GetCsharpTypeAsClassNameString(prop).ToLower();
        //}

        public class ParsePlcSymbolFile
        {
            public static IEnumerable<ClassTree> ReadDataArea(string path)
            {
                var xml = XDocument.Load(path);

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

                        symbols.Add(new PlcSymbol(symbol.Element("Name").Value, new PlcType(symbol.Element("BaseType").Value),
                            int.Parse(symbol.Element("BitSize").Value), int.Parse(symbol.Element("BitOffs").Value),
                            arrInfoList));
                    }
                }

                var replacedSymbols = symbols.ToArray();

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

            public static IEnumerable<PlcType> ReadTypes(string path)
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
                                new PlcType(symbol.Element("Type").Value),
                                int.Parse(symbol.Element("BitSize").Value), int.Parse(symbol.Element("BitOffs").Value),
                                arrInfoList);

                            type.AddSymbol(parsedSymbol);
                        }

                        types.Add(type);
                    }
                }

                var nestedTypes = new List<PlcType>();

                foreach (var plcType in types)
                {
                    nestedTypes.Add(GetFlattenedType(plcType));
                }

                return nestedTypes;
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
                    : new[] { currentSymbolName };
                if (currentNames.Length < 2)
                {
                    return classNames;
                }

                currentNames = currentNames.Take(currentNames.Length - 1).ToArray();

                var existingClass = classNames.FirstOrDefault(x =>
                {
                    var firstClassNameSplit = x.Contains(".") ? x.Split('.') : new[] { x };

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

            public static PlcType GetFlattenedType(PlcType type)
            {
                if (type.Symbols.Any())
                {
                    foreach (var symbol in type.Symbols)
                    {
                        type.AddType(GetFlattenedType(symbol.Type));
                    }
                }

                return type;
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
            public PlcSymbol(string name, PlcType type, int bitSize, int bitOffset, IEnumerable<ArrayInfo> arrayInfo)
            {
                this.Name = name;
                this.Type = type;
                this.BitSize = bitSize;
                this.BitOffset = bitOffset;
                this.ArrayInfo = arrayInfo;
            }

            public string Name { get; }

            public PlcType Type { get; }

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
                this.Symbols = new List<PlcSymbol>();
                this.Types = new List<PlcType>();
            }

            public string TypeName { get; }

            public IList<PlcSymbol> Symbols { get; }

            public IList<PlcType> Types { get; }

            public void AddSymbol(PlcSymbol symbol)
            {
                this.Symbols.Add(symbol);
            }

            public void AddType(PlcType type)
            {
                this.Types.Add(type);
            }
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
