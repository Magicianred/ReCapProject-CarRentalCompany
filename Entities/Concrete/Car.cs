using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car :IEntity
    {
        public int CarID { get; set; }
        public int CarBrandID { get; set; }
        public int CarColorID { get; set; }
        public short ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }

    }
}
