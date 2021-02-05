using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarID=1, CarBrandID=1, CarColorID=5, ModelYear=2018, DailyPrice= 180, Description="5 Adult / 2 Suitcase / Automatic Shift / Diesel"  },
                new Car{CarID=2, CarBrandID=3, CarColorID=2, ModelYear=2016, DailyPrice= 220, Description="5 Adult / 3 Suitcase / Manual Shift / Gas"  },
                new Car{CarID=1, CarBrandID=4, CarColorID=4, ModelYear=2013, DailyPrice= 230, Description="4 Adult / 3 Suitcase / Automatic Shift / Diesel"  },
                new Car{CarID=1, CarBrandID=2, CarColorID=3, ModelYear=2014, DailyPrice= 210, Description="5 Adult / 2 Suitcase / Manual Shift / Gas"  },
                new Car{CarID=1, CarBrandID=5, CarColorID=1, ModelYear=2017, DailyPrice= 240, Description="4 Adult / 3 Suitcase / Automatic Shift / Diesel"  }
            };
        }

        public void Add(Car entity)
        {
            _cars.Add(entity);
        }

        public void Delete(Car entity)
        {
            Car carToDelete = _cars.SingleOrDefault(c=> c.CarID == entity.CarID);
            _cars.Remove(carToDelete);

        }

        //public Car Get(int id)
        //{
        //    return _cars.Find(c=> c.CarID == id);
        //}

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        //public List<Car> GetAll()
        //{
        //    return _cars;
        //}

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(b => b.CarID == id);
        }

        public void Update(Car entity)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarID == entity.CarID);
            carToUpdate.CarID = entity.CarID;
            carToUpdate.CarColorID = entity.CarColorID;
            carToUpdate.CarBrandID = entity.CarBrandID;
            carToUpdate.DailyPrice = entity.DailyPrice;
            carToUpdate.Description = entity.Description;
        }
    }
}
