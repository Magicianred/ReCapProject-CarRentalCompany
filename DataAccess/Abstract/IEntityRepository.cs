using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        List<T> GetAll();
        T Get(int id);
        List<T> Add(T entity);
        List<T> Delete(T entity);
        List<T> Update(T entity);

    }
}
