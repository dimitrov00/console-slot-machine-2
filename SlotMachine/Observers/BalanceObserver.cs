using SlotMachine.Models;

namespace SlotMachine.Observers;

public class BalanceObserver : IObserver<decimal>
{
    public void OnCompleted()
    {
        // Do nothing.
    }

    public void OnError(Exception error)
    {
        Console.WriteLine($"Error: {error.Message}");
    }

    public void OnNext(decimal value)
    {
        Console.WriteLine($"Current balance: {value:C}");
    }
}