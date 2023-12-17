using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T entity)
        {
            using var context = new Context();
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            using var context = new Context();
            return [.. context.Set<T>()];
        }

        public T? GetById(int id)
        {

            using var context = new Context();
            return context.Set<T>().Find(id);        }

        public void Insert(T entity)
        {
            using var context = new Context();
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            using var context = new Context();
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }
    }
}

/*
using ifadesi, Context nesnesini kullandıktan sonra scope bitiminde otomatik olarak kaynakları temizler ve belleği serbest bırakır.
using ifadesi, IDisposable arayüzünü uygulayan nesneler için kullanılır.

Bu şekilde kullanmak daha optimize bir kullanımdır.
*/