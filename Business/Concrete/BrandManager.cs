using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetBrandNameByBrandId(int brandId)
        {
            return _brandDal.GetById(brandId);
        }

        public void Add(Brand brand)
        {
            if (brand.BrandName.Length > 2)
            {
                _brandDal.Add(brand);
            }
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

    }
}
