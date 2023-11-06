using SalesRadar.Domain;
using SalesRadar.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesRadar.Infrastruture.Repository;
public class CustomerRepository : ICustomerRepository
{
    private readonly SalesRadarLiteDbContext _db;

    public CustomerRepository(SalesRadarLiteDbContext db)
    {
        _db = db;
    }

    public void Create(Customer customer)
    {
        var customerCollection = _db.Context.GetCollection<Customer>();
        customerCollection.Insert(customer);
    }

    public Customer Get(int id)
    {
        var customerCollection = _db.Context.GetCollection<Customer>();
        return customerCollection.FindById(id);
    }

    public List<Customer> GetAll()
    {
        var customerCollection = _db.Context.GetCollection<Customer>();
        return customerCollection.FindAll().ToList();
    }

    public void Update(Customer customer)
    {
        var customerCollection = _db.Context.GetCollection<Customer>();
        customerCollection.Update(customer);
    }

    public void Delete(int id)
    {
        var customerCollection = _db.Context.GetCollection<Customer>();
        customerCollection.Delete(id);
    }
}
