using SlotMachine.Models;

namespace SlotMachine.Strategies;

public class ProgressiveCoefficientStrategy : ICoefficientStrategy
{
    private readonly decimal _progressionRate;

    public ProgressiveCoefficientStrategy(decimal progressionRate)
    {
        _progressionRate = progressionRate;
    }

    public decimal CalculateCoefficient(decimal betAmount, Symbol symbol)
    {
        return symbol.Coefficient + (_progressionRate * betAmount);
    }
}