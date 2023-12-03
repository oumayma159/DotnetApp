using DotnetApp.Models;
using DotnetApp.Repositories.RepositoriesContracts;

namespace DotnetApp.Repositories.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        //Dependency Injection
        private readonly DotnetAppDbContext _db;
        public CustomerRepository(DotnetAppDbContext db)
        {
            _db = db;

        }

        //implementation des methodes
        public void Add(Customer c)
        {
            _db.Customers.Add(c);
            _db.SaveChanges();
        }

        public void Delete(Customer c)
        {
            _db.Customers.Remove(c);
            _db.SaveChanges();
        }

        public ICollection<Customer> GetAll()
        {
            return _db.Customers.ToList();
        }

        public Customer Get(Guid id) 
        {
            return _db.Customers.FirstOrDefault(customer => customer.Id == id);
        }

        public void Update(Customer c)
        {
            _db.Customers.Update(c);
            _db.SaveChanges();
        }
    }
}
