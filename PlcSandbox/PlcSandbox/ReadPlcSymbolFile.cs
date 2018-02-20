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
                trees.MapToTree(plcSymbol);
            }

            ClassTrees = trees;
        }

        public IEnumerable<ClassTree> ClassTrees { get; }
    }
}
