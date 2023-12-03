using DotnetApp.Models;
using DotnetApp.Repositories.RepositoriesContracts;

namespace DotnetApp.Repositories.Repositories
{ 
    public class MembershiptypeRepository : IMembershiptypeRepository
    {
        private readonly DotnetAppDbContext _db;
        public MembershiptypeRepository(DotnetAppDbContext db)
        {
            _db = db;

        }

        public ICollection<Membershiptype> GetAll()
        {
            return _db.Membershiptypes.ToList();
        }

        public Membershiptype Get(Guid id)
        {
            return _db.Membershiptypes.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Membershiptype membershiptype)
        {
            _db.Membershiptypes.Add(membershiptype);
            _db.SaveChanges();
        }

        public void Delete(Membershiptype membershiptype)
        {
            _db.Membershiptypes.Remove(membershiptype);
            _db.SaveChanges();
        }

        public void Update(Membershiptype membershiptype)
        {
            _db.Membershiptypes.Update(membershiptype);
            _db.SaveChanges();
        }

    }
}
