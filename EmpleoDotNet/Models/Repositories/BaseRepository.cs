﻿using System.Data.Entity;
using System.Linq;

namespace EmpleoDotNet.Models.Repositories
{
    public class BaseRepository<T> where T : class
    {
        protected DbContext Context = new Models.Database();
        protected DbSet<T> DbSet;

        public BaseRepository()
        {
            DbSet = Context.Set<T>();
        }
        protected T GetById(int? id)
        {
            return DbSet.Find(id);
        }
        protected IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public void SaveChanges()
        {
            //TODO: Implement Unit of Work Pattern
            //Esto permitirá que se pueda grabar de forma transaccional en la BD
            Context.SaveChanges();
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }
    }
}