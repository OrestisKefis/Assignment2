using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationDatabase;
using RepositoryServices.Core;

namespace RepositoryServices.Persistence
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public ApplicationDbContext db;
        public DbSet<T> table;

        public GenericRepository(ApplicationDbContext context)
        {
            db = context;
            table = db.Set<T>();
        }
        

        public void Delete(int? id)
        {
            var entity = table.Find(id);
            db.Entry(entity).State = EntityState.Deleted;
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T entity)
        {
            db.Entry(entity).State = EntityState.Added;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(T enity)
        {
            db.Entry(enity).State = EntityState.Modified;
        }
    }
}
