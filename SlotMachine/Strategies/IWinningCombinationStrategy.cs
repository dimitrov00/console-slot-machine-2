using SlotMachine.Models;

namespace SlotMachine.Strategies;

public interface IWinningCombinationStrategy
{
    List<WinningCombination> GetWinningCombinations(Symbol[][] reels);
}