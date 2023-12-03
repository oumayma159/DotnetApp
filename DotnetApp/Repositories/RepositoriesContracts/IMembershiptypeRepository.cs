using DotnetApp.Models;

namespace DotnetApp.Repositories.RepositoriesContracts
{
    public interface IMembershiptypeRepository
    {
        public ICollection<Membershiptype> GetAll();
        public Membershiptype Get(Guid id);
        public void Update(Membershiptype membershiptype);
        public void Delete(Membershiptype membershiptype);
        public void Add(Membershiptype membershiptype);

    }
}
