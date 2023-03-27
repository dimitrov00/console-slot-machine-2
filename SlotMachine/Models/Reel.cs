using SlotMachine.Utils;

namespace SlotMachine.Models;

public class Reel
{
    private readonly Symbol[] _possibleSymbols;
    private readonly int _size;
    public Symbol[] CurrentSymbols { get; private set; }

    public Reel(Symbol[] possibleSymbols, int size)
    {
        _possibleSymbols = possibleSymbols;
        _size = size;
        CurrentSymbols = Spin();
    }

    public Reel Spin()
    {
        var result = new Symbol[_size];

        for (var i = 0; i < _size; i++)
        {
            result[i] = RandomSymbolSelector.Select(_possibleSymbols);
        }

        CurrentSymbols = result;
        return this;
    }

    public static implicit operator Symbol[](Reel reel)
    {
        return reel.CurrentSymbols;
    }
}