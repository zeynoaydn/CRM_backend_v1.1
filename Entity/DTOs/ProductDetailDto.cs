using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProductDetailDto : IDto
    {
        public int Id { get; set; }
        //public string Product_Name { get; set; }
        public short Unit_In_Stock { get; set; }

    }
}
