namespace PatootieCoffee;

public class OrderItem
{
    private int quantity;
    private double subtotal;
    private readonly MenuItem menuItem;          // directed association -> MenuItem

    public MenuItem MenuItem => menuItem;
    public int Quantity => quantity;

    internal OrderItem(MenuItem menuItem, int quantity)   // only Order can create it
    {
        if (quantity <= 0) throw new ArgumentException("Quantity must be positive.");
        this.menuItem = menuItem;
        this.quantity = quantity;
    }

    public double CalculateSubtotal()
    {
        subtotal = menuItem.Price * quantity;
        return subtotal;
    }
}