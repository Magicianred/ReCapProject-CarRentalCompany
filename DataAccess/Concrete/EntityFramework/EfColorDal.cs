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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                var addedEntity = context.Entry(entity); // veri tabanı bağlantısındaki entity ye abone ol, addedEntity değişkenine at.
                addedEntity.State = EntityState.Added; // addedEntity değişkeni üzerinden, durumu ekleme komutuna çek ve ekleme işlemini gerçekleştir.
                context.SaveChanges(); // veritabanı bağlantısı üzerinden değişiklikleri kaydet.
            }
        }

        public void Delete(Color entity)
        {
            using (CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter = null)
        {
            using (CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using(CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                return filter == null ? context.Set<Color>().ToList() : context.Set<Color>().Where(filter).ToList();
            }
        }

        public Color GetById(int id)
        {
            using (CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                return context.Set<Color>().SingleOrDefault(b => b.ColorID == id);
            }
        }

        public void Update(Color entity)
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
