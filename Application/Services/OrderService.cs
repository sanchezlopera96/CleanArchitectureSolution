using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Services;

public class OrderService
{
    public Order CreateOrder(Customer customer, OrderDetails details)
    {
        if (customer == null)
            throw new ArgumentNullException(nameof(customer));

        if (details == null)
            throw new ArgumentNullException(nameof(details));

        return new Order(customer.Id, details);
    }

    public void CancelOrder(Order order)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order));

        order.Cancel();
    }
}