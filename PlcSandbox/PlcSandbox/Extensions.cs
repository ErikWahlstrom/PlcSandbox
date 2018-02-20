namespace PlcSandbox
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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