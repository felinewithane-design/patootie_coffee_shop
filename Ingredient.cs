namespace PatootieCoffee;

public class Ingredient
{
    private int stockLevel;
    private readonly int lowThreshold;

    public string Name { get; }
    public int StockLevel => stockLevel;

    public Ingredient(string name, int stockLevel, int lowThreshold = 10)
    {
        Name = name;
        this.stockLevel = stockLevel;
        this.lowThreshold = lowThreshold;
    }

    public bool IsLow() => stockLevel <= lowThreshold;

    public void ReduceStock(int amount)
    {
        if (amount <= 0) throw new ArgumentException("Amount must be positive.");
        if (amount > stockLevel) throw new InvalidOperationException($"Not enough {Name}.");
        stockLevel -= amount;
    }

    public void Restock(int amount)
    {
        if (amount <= 0) throw new ArgumentException("Amount must be positive.");
        stockLevel += amount;
    }
}