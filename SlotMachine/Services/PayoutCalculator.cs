using SlotMachine.Models;
using SlotMachine.Strategies;

namespace SlotMachine.Services;

public class PayoutCalculator
{
    private readonly ICoefficientStrategy _coefficientStrategy;

    public PayoutCalculator(ICoefficientStrategy coefficientStrategy)
    {
        _coefficientStrategy = coefficientStrategy;
    }

    public decimal CalculatePayout(decimal betAmount, Reel[] reels)
    {
        decimal payout = 0;

        // TODO: implement logic using pay table
        for (int rowIndex = 0; rowIndex < reels.GetLength(0); rowIndex++)
        {
            int winningSlotCount = 1;
            Symbol winningSymbol = reels[rowIndex].CurrentSymbols[0];
            bool isWinningSequence = true;

            for (int columnIndex = 1; columnIndex < reels.GetLength(1); columnIndex++)
            {
                Symbol symbol = reels[rowIndex].CurrentSymbols[columnIndex];

                if (symbol.IsWildcard || isWinningSequence && (winningSymbol.IsWildcard || winningSymbol.Equals(symbol)))
                {
                    winningSlotCount++;
                    if (!winningSymbol.IsWildcard) winningSymbol = symbol;
                }
                else
                {
                    isWinningSequence = false;
                }
            }

            if (winningSlotCount >= winningSymbol.MinimalMatchingSymbols)
            {
                var coefficient = _coefficientStrategy.CalculateCoefficient(betAmount, winningSymbol);
                payout += coefficient * winningSlotCount;
            }
        }

        return payout;
    }
}