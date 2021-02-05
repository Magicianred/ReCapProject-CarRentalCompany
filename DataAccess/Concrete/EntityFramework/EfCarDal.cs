using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                var addedEntity = context.Entry(entity); // veri tabanı bağlantısındaki entity ye abone ol, addedEntity değişkenine at.
                addedEntity.State = EntityState.Added; // addedEntity değişkeni üzerinden, durumu ekleme komutuna çek ve ekleme işlemini gerçekleştir.
                context.SaveChanges(); // veritabanı bağlantısı üzerinden değişiklikleri kaydet.
            }
        }

        public void Delete(Car entity)
        {
            using (CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentalCompanyContext context= new CarRentalCompanyContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public Car GetById(int id)
        {
            using (CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                return context.Set<Car>().SingleOrDefault(b => b.CarID == id);
            }
        }

        public void Update(Car entity)
        {
            using (CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

    }
}
