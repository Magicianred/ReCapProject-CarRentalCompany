using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brands;
        public InMemoryBrandDal()
        {
            _brands = new List<Brand>
            {
                new Brand{BrandID = 1, BrandName= "Citroen", BrandModel = "DS7 Crossback"},
                new Brand{BrandID = 2, BrandName= "Jeep", BrandModel = "Renegade"},
                new Brand{BrandID = 3, BrandName= "Mini Cooper", BrandModel = "Countryman"},
                new Brand{BrandID = 4, BrandName= "Audi", BrandModel = "A3"},
                new Brand{BrandID = 1, BrandName= "Mercedes", BrandModel = "CLA"}
            };
        }
        public void Add(Brand entity)
        {
            _brands.Add(entity);    
        }

        public void Delete(Brand entity)
        {
            Brand colorToDelete = _brands.SingleOrDefault(b => b.BrandID == entity.BrandID);
            _brands.Remove(colorToDelete);
        }

        //public Brand Get(int id)
        //{
        //    return _brands.Find(b=> b.BrandID == id);
        //}

        public Brand Get(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        //public List<Brand> GetAll()
        //{
        //    return _brands;
        //}

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Brand GetById(int id)
        {
            return _brands.SingleOrDefault(b=> b.BrandID == id);
        }

        public void Update(Brand entity)
        {
            Brand brandToUpdate = _brands.SingleOrDefault(b => b.BrandID == entity.BrandID);
            brandToUpdate.BrandID = entity.BrandID;
            brandToUpdate.BrandName = entity.BrandName;
            brandToUpdate.BrandModel = entity.BrandModel;
        }
    }
}
