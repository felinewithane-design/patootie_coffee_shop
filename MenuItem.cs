namespace PatootieCoffee;

public class MenuItem
{
    private string itemId;
    private string name;
    private double price;
    private string category;
    private bool available = true;
    private readonly List<Ingredient> ingredients = new();   // aggregation

    public string ItemId => itemId;
    public string Name => name;
    public double Price => price;
    public string Category => category;
    public bool Available => available;
    public IReadOnlyList<Ingredient> Ingredients => ingredients;

    public MenuItem(string itemId, string name, double price, string category,
                    IEnumerable<Ingredient> recipe)
    {
        this.itemId = itemId;
        this.name = name;
        this.price = price;
        this.category = category;
        ingredients.AddRange(recipe);     // ingredients are created outside
    }

    public void UpdatePrice(double price)
    {
        if (price <= 0) throw new ArgumentException("Price must be positive.");
        this.price = price;
    }

    public void ToggleAvailability() => available = !available;
}