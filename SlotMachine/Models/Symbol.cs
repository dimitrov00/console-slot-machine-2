namespace SlotMachine.Models;

public struct Symbol
{
    public char Character { get; set; }
    public decimal Coefficient { get; set; }
    public decimal Probability { get; set; }
    public int MinimalMatchingSymbols { get; set; }
    public bool IsWildcard { get; set; }
}