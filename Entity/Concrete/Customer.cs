using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Adress { get; set; }
        public bool Status { get; set; }

    }
}
