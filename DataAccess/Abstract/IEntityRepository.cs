using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter =null);
        T Get(Expression<Func<T, bool>> filter);
        T GetById(int id); // ColorId ve BrandId lerin, Name karşılıklarını almak için tasarlanmış bir metot
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

    }
}
