using SlotMachine.Models;

namespace SlotMachine.Utils;

public static class RandomSymbolSelector
{
    private readonly static Random Random = new();

    public static Symbol Select(Symbol[] symbols)
    {
        var totalWeight = symbols.Select(static symbol => symbol.Probability).Sum();
        var randomWeight = (decimal)Random.NextDouble() * totalWeight;

        foreach (var symbol in symbols)
        {
            randomWeight -= symbol.Probability;
            if (randomWeight <= 0)
                return symbol;
        }

        return default;
    }
}