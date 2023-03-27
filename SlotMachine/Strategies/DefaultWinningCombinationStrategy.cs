using SlotMachine.Models;

namespace SlotMachine.Strategies;

public class DefaultWinningCombinationStrategy : IWinningCombinationStrategy
{
    private readonly PayTable _payTable;

    public DefaultWinningCombinationStrategy(PayTable payTable)
    {
        _payTable = payTable;
    }

    public List<WinningCombination> GetWinningCombinations(Symbol[][] reels)
    {
        throw new NotImplementedException();
    }
}