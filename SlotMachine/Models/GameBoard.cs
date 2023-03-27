namespace SlotMachine.Models;

public class GameBoard
{
    private readonly Reel[] _reels;

    public GameBoard(Reel[] reels)
    {
        _reels = reels;
    }

    public void Draw()
    {
        Console.WriteLine("[Game Board]");
        for (var i = _reels.GetLowerBound(1); i <= _reels.GetUpperBound(1); i++)
        {
            for (var j = _reels.GetLowerBound(0); j <= _reels.GetUpperBound(0); j++)
            {
                Console.Write($"[{_reels[j].CurrentSymbols[i].Character}]");
            }
            Console.WriteLine();
        }
    }
}