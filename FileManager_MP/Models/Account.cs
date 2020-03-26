using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileManager_MP.Models
{
    public class Account
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public string Role { get; set; }

        public string Message { get; set; }


        public int ChangeRole()
        {
            switch (Role.ToLower())
            {
                case "admin":
                    return 1;
                case "user":
                    return 2;
                default:
                    Message = "Wrong Role"; 
                    return 0;
            }
        }
        
    }
}