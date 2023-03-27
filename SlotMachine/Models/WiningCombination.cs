namespace SlotMachine.Models;

public class WinningCombination
{
    public string Name { get; set; }
    public decimal Coefficient { get; set; }
    public List<int[]> Positions { get; set; }
}