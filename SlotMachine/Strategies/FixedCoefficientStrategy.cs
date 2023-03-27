using SlotMachine.Models;

namespace SlotMachine.Strategies;

public class FixedCoefficientStrategy : ICoefficientStrategy
{
    public decimal CalculateCoefficient(decimal betAmount, Symbol symbol)
    {
        return symbol.Coefficient;
    }
}