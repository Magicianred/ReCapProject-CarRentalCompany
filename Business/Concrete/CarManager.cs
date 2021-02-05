using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
       
        public List<Car> GetCarsByBrandId(int categoryId)
        {
           return  _carDal.GetAll(p=>p.CarBrandID == categoryId);
        }
        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(p => p.CarBrandID == colorId);
        }
        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
        }
        public void Update(Car car)
        {
            _carDal.Update(car);
        }
        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

    }
}
