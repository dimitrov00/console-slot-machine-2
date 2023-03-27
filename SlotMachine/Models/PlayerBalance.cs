namespace SlotMachine.Models;

public class PlayerBalance : IObservable<decimal>
{
    private decimal _balance;
    private readonly List<IObserver<decimal>> _observers = new();

    public decimal CurrentBalance
    {
        get => _balance;
        private set
        {
            _balance = value;
            Notify();
        }
    }

    public void Deposit(decimal amount)
    {
        CurrentBalance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (_balance < amount)
        {
            throw new InvalidOperationException("Insufficient funds");
        }

        CurrentBalance -= amount;
    }

    private void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.OnNext(_balance);
        }
    }

    public IDisposable Subscribe(IObserver<decimal> observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
        return new Unsubscriber(_observers, observer);
    }


    private class Unsubscriber : IDisposable
    {
        private readonly List<IObserver<decimal>> _observers;
        private readonly IObserver<decimal>? _observer;

        public Unsubscriber(List<IObserver<decimal>> observers, IObserver<decimal>? observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observer != null && _observers.Contains(_observer))
            {
                _observers.Remove(_observer);
            }
        }
    }
}