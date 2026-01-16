namespace Domain.ValueObjects;

public class OrderDetails
{
    public string Description { get; }
    public decimal Amount { get; }

    public OrderDetails(string description, decimal amount)
    {
        Description = description;
        Amount = amount;
    }
}