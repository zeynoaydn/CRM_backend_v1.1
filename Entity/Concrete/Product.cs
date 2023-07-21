using Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace Entities.Concrete
{
    public class Product:IEntity
    {
        public int Id { get; set; }
        public string Product_Name { get; set; }
        public decimal Unit_Price { get; set; }
        public short Unit_In_Stock { get; set; }
        public short Unit_On_Order { get; set; }

    }
}
