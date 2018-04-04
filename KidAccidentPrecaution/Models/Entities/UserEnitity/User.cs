using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidAccidentPrecaution.Models.Entities.UserEnitity
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }
        public string EmailID { get; set; }
        public string mobilenno { get; set; }
        public string description { get; set; }
        public char Rowstatus { get; set; }
    }
}