using DotnetApp.Models;

namespace DotnetApp.Repositories.RepositoriesContracts
{
    public interface ICustomerRepository
    {
        public ICollection<Customer> GetAll();
        public Customer Get(Guid id);
        public void Add(Customer c);
        public void Update(Customer c);
        public void Delete(Customer c);
    }
}
