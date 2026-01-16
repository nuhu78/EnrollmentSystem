using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
   public class Repository<T> : IRepository<T> where T : class
    {
        protected UMSContext db;
        protected DbSet<T> table;

        public Repository(UMSContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }
        public T Add(T entity)
        {
            table.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var entity = Get(id);
            if (entity == null) return false;

            table.Remove(entity);
            db.SaveChanges();
            return true;
        }

        public T Get(int id)
        {
            return table.Find(id);
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }

        public T Update(T entity)
        {
            table.Update(entity);
            db.SaveChanges();
            return entity;
        }
    }
}
