namespace SlotMachine.Models;

public class Row
{
    public Reel[] Reels { get; }

    public Row(Reel[] reels)
    {
        Reels = reels;
    }
}