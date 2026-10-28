using PatootieCoffee;

var milk = new Ingredient("Milk", 120);
var coffee = new Ingredient("Coffee", 45);
var latte = new MenuItem("M01", "Latte", 4.25, "Coffee", new[] { milk, coffee });
var menu = new List<MenuItem> { latte };

Staff staff = new Barista("B102", "Shevchenko Oleksandra", menu);   // Barista used as Staff
Console.WriteLine($"Login ok: {staff.Login("B102", "pass")}");

var barista = (Barista)staff;
var found = barista.SearchMenu("lat");
Console.WriteLine($"Found: {found[0].Name}");

Order order = barista.CreateOrder();
order.AddItem(found[0], 2);
Console.WriteLine($"Total: {order.CalculateTotal():F2}");                // 8.50

order.ApplyDiscount(1.00);                                              // overload 1
Console.WriteLine($"Total with fixed discount: {order.CalculateTotal():F2}");   // 7.50

IDiscount discount = new PercentageDiscount(10);                        // overload 2
order.ApplyDiscount(discount);
Console.WriteLine($"Total with {discount.Description}: {order.CalculateTotal():F2}");  // 7.65

barista.CloseOrder(order);
Console.WriteLine($"Status: {order.Status}");                            // PendingPayment
Console.WriteLine($"Milk: {milk.StockLevel}, Coffee: {coffee.StockLevel}");   // 118, 43