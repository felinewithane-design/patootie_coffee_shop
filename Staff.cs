namespace PatootieCoffee;

public abstract class Staff
{
    protected string staffID;
    protected string name;

    protected Staff(string staffID, string name)
    {
        this.staffID = staffID;
        this.name = name;
    }

    public bool Login(string id, string password) =>
        id == staffID && !string.IsNullOrWhiteSpace(password);
}