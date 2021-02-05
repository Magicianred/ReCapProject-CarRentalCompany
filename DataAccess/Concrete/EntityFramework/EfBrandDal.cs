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
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                var addedEntity = context.Entry(entity); // veri tabanı bağlantısındaki entity ye abone ol, addedEntity değişkenine at.
                addedEntity.State = EntityState.Added; // addedEntity değişkeni üzerinden, durumu ekleme komutuna çek ve ekleme işlemini gerçekleştir.
                context.SaveChanges(); // veritabanı bağlantısı üzerinden değişiklikleri kaydet.
            }
        }

        public void Delete(Brand entity)
        {
            using (CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter = null)
        {
            using (CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                return filter == null ? context.Set<Brand>().ToList() : context.Set<Brand>().Where(filter).ToList();
            }
        }

        public Brand GetById(int id)
        {
            using (CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                return context.Set<Brand>().SingleOrDefault(b=> b.BrandID == id);
            }
        }

        public void Update(Brand entity)
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
