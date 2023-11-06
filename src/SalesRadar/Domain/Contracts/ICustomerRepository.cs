using SalesRadar.Domain;

namespace SalesRadar.Domain.Contracts;
public interface ICustomerRepository
{
    void Create(Customer customer);
    void Delete(int id);
    Customer Get(int id);
    List<Customer> GetAll();
    void Update(Customer customer);
}