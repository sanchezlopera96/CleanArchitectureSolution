using Domain.Entities;

namespace Domain.Interfaces;

public interface ICustomerRepository
{
    IEnumerable<Customer> GetAll();
    Customer? GetById(Guid id);
    void Add(Customer customer);
    void SaveChanges();
}