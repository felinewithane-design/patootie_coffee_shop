namespace PatootieCoffee;

public interface IDiscount
{
    string Description { get; }
    double Apply(double amount);
}

public class PercentageDiscount : IDiscount
{
    private readonly double percent;
    public string Description => $"{percent}% off";
    public PercentageDiscount(double percent) => this.percent = percent;
    public double Apply(double amount) => amount * (1 - percent / 100);
}

public class FixedAmountDiscount : IDiscount
{
    private readonly double value;
    public string Description => $"{value:F2} off";
    public FixedAmountDiscount(double value) => this.value = value;
    public double Apply(double amount) => Math.Max(0, amount - value);
}