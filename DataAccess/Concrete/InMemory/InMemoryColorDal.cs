using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        List<Color> _colors;
        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color{ColorID = 1, ColorName = "White"},
                new Color{ColorID = 2, ColorName = "Black"},
                new Color{ColorID= 3, ColorName= "Grey"},
                new Color{ColorID= 4, ColorName= "Blue" },
                new Color{ColorID= 5, ColorName= "Red" }
            };
        }
        public List<Color> Add(Color entity)
        {
            _colors.Add(entity);
            return _colors;
        }

        public List<Color> Delete(Color entity)
        {
            Color colorToDelete = _colors.SingleOrDefault(c => c.ColorID == entity.ColorID);
            _colors.Remove(colorToDelete);
            return _colors;
        }

        public Color Get(int id)
        {
            return _colors.SingleOrDefault(c=> c.ColorID == id);
        }

        public List<Color> GetAll()
        {
            return _colors;
        }

        public List<Color> Update(Color entity)
        {
            Color colorToUpdate = _colors.SingleOrDefault(c => c.ColorID == entity.ColorID);
            colorToUpdate.ColorID = entity.ColorID;
            colorToUpdate.ColorName = entity.ColorName;
            return _colors;
        }
    }
}
