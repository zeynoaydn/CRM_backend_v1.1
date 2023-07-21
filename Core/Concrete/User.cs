using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Concrete
{
    public class User:IEntity
    {
        public string Email { get; set; }
        public int Id { get; set; }
        public string User_First_Name { get; set; }
        public string User_Last_Name { get; set; }
        public string User_Name { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}
