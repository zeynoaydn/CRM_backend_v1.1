
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Order:IEntity
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public DateTime Order_Date { get; set; }
        public int Product_Id { get; set; }
    }
}
