using SlotMachine.Models;
using SlotMachine.Observers;
using SlotMachine.Strategies;

namespace SlotMachine.Services;

public class GameEngine
{
    private readonly Reel[] _reels;
    private readonly GameBoard _gameBoard;
    private readonly PayoutCalculator _payoutCalculator;
    private readonly PlayerBalance _balance;
    private readonly Random _random;

    public GameEngine(Reel[] reels, ICoefficientStrategy coefficientStrategy)
    {
        _reels = reels;
        _gameBoard = new GameBoard(reels);
        _payoutCalculator = new PayoutCalculator(coefficientStrategy);
        _balance = new PlayerBalance();
        _random = new Random();

        var balanceObserver = new BalanceObserver();
        _balance.Subscribe(balanceObserver);
    }

    public void Play()
    {
        Console.WriteLine("Welcome to Slot Machine Game!");

        while (true)
        {
            _balance.Deposit(1000);

            Console.Write("Enter your bet amount: ");
            var betAmount = Convert.ToDecimal(Console.ReadLine());

            // Deduct bet amount from balance
            _balance.Withdraw(betAmount);

            // Draw the game board
            _gameBoard.Draw();

            // Spin the reels
            for (var i = _reels.GetLowerBound(1); i < _reels.GetUpperBound(1); i++)
            {
                _reels[i].Spin();
            }

            // Draw the game board
            _gameBoard.Draw();

            // Calculate the payout
            decimal payoutAmount = _payoutCalculator.CalculatePayout(betAmount, _reels);


            if (payoutAmount > 0)
            {
                Console.WriteLine("Congratulations! You won: " + payoutAmount);
            }
            else
            {
                Console.WriteLine("Sorry, you didn't win anything.");
            }

            // Add the payout amount to the balance
            _balance.Deposit(payoutAmount);
        }
    }
}


public class SpinResult
{
    public Symbol[][] ReelResults { get; }
    public Dictionary<int, decimal> Payouts { get; }

    public SpinResult(Symbol[][] reelResults, Dictionary<int, decimal> payouts)
    {
        ReelResults = reelResults;
        Payouts = payouts;
    }
}