namespace PlcSandbox
{
    using System.Collections.Generic;

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
}