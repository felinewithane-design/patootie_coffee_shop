namespace PatootieCoffee;

public class Barista : Staff
{
    private readonly List<MenuItem> menu;

    public Barista(string staffID, string name, List<MenuItem> menu)
        : base(staffID, name)
    {
        this.menu = menu;
    }

    public List<MenuItem> SearchMenu(string keyword) =>
        menu.Where(m => m.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

    public List<MenuItem> FilterMenu(string category) =>
        menu.Where(m => m.Available &&
                        m.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();

    public Order CreateOrder() => new Order();

    public void CloseOrder(Order order) => order.CloseOrder();
}