using Domain.ValueObjects;

namespace Domain.Entities;

public class Order
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public string Description { get; private set; }
    public decimal Amount { get; private set; }
    public bool IsCanceled { get; private set; }

    protected Order() { }

    public Order(Guid customerId, OrderDetails details)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        Description = details.Description;
        Amount = details.Amount;
        IsCanceled = false;
    }

    public void Cancel()
    {
        IsCanceled = true;
    }
}