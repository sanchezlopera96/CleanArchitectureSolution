using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;
using Moq;
using Xunit;

public class OrderServiceTests
{
    private readonly Mock<ICustomerRepository> _customerRepoMock;
    private readonly OrderService _orderService;

    public OrderServiceTests()
    {
        _customerRepoMock = new Mock<ICustomerRepository>();
        _orderService = new OrderService();
    }

    [Fact]
    public void CreateOrder_ShouldCreateOrderSuccessfully()
    {
        var customer = new Customer("Santiago", "santiago@test.com");
        var details = new OrderDetails("Compra de laptop", 3000);

        var order = _orderService.CreateOrder(customer, details);

        Assert.NotNull(order);
        Assert.Equal(customer.Id, order.CustomerId);
        Assert.Equal("Compra de laptop", order.Description);
        Assert.Equal(3000, order.Amount);
        Assert.False(order.IsCanceled);
    }

    [Fact]
    public void CancelOrder_ShouldCancelOrder()
    {
        var customerId = Guid.NewGuid();
        var details = new OrderDetails("Compra de monitor", 800);
        var order = new Order(customerId, details);

        _orderService.CancelOrder(order);

        Assert.True(order.IsCanceled);
    }
}