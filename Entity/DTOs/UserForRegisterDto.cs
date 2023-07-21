using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserForRegisterDto : IDto
    {
        public string Email { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public string User_First_Name { get; set; }
        public string User_Last_Name { get; set; }
    }
    
}
