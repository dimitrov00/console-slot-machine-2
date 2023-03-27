using SlotMachine.Models;

namespace SlotMachine.Strategies;

public interface ICoefficientStrategy
{
    decimal CalculateCoefficient(decimal betAmount, Symbol symbol);
}