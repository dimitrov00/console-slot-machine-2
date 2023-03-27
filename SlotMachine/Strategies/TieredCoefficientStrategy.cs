using SlotMachine.Models;

namespace SlotMachine.Strategies;

public class TieredCoefficientStrategy : ICoefficientStrategy
{
    private readonly Dictionary<decimal, decimal> _tiers;

    public TieredCoefficientStrategy(Dictionary<decimal, decimal> tiers)
    {
        _tiers = tiers;
    }

    public decimal CalculateCoefficient(decimal betAmount, Symbol symbol)
    {
        decimal coefficient = 0;

        foreach (var tier in _tiers)
        {
            if (betAmount > tier.Key) continue;

            coefficient = tier.Value;
            break;
        }

        return coefficient;
    }
}