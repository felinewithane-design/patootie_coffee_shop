namespace PatootieCoffee;

public class Order
{
    private readonly List<OrderItem> items = new();   // composition
    private string orderID = Guid.NewGuid().ToString("N")[..8];
    private OrderStatus status = OrderStatus.New;
    private double total;
    private double discount;
    private IDiscount? discountPolicy;

    public string OrderID => orderID;
    public OrderStatus Status => status;
    public IReadOnlyList<OrderItem> Items => items;

    public void AddItem(MenuItem item, int qty)
    {
        if (status != OrderStatus.New && status != OrderStatus.InProgress)
            throw new InvalidOperationException("The order is closed.");
        if (!item.Available || item.Ingredients.Any(i => i.StockLevel < qty))
            throw new InvalidOperationException($"{item.Name} is not available.");

        items.Add(new OrderItem(item, qty));       // the Order creates its parts
        status = OrderStatus.InProgress;
    }

    public void RemoveItem(MenuItem item)
    {
        items.RemoveAll(i => i.MenuItem == item);
        if (items.Count == 0) status = OrderStatus.New;
    }

    // Overload 1: fixed amount (from the original diagram)
    public void ApplyDiscount(double amt)
    {
        discount = amt;
        discountPolicy = null;
    }

    // Overload 2: any IDiscount implementation
    public void ApplyDiscount(IDiscount policy)
    {
        discountPolicy = policy;
        discount = 0;
    }

    public double CalculateTotal()
    {
        double subtotal = items.Sum(i => i.CalculateSubtotal());
        total = discountPolicy != null
            ? discountPolicy.Apply(subtotal)
            : Math.Max(0, subtotal - discount);
        return total;
    }

    public void CloseOrder()
    {
        if (status != OrderStatus.InProgress)
            throw new InvalidOperationException("Only an in-progress order can be closed.");

        foreach (var item in items)
            foreach (var ingredient in item.MenuItem.Ingredients)
                ingredient.ReduceStock(item.Quantity);

        status = OrderStatus.PendingPayment;
    }
}