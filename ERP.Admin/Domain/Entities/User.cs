using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User :BaseEntity
    {

       
        public string RegNo { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string ?LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ?Phone { get; set; } = string.Empty;
        public string ?Address1 { get; set; } = string.Empty;
        public string ?Address2 { get; set; } = string.Empty;
        public string ?City { get; set; } = string.Empty;
        public string ?District { get; set; } = string.Empty;
        public DateOnly ?DoB { get; set; }
        public string ?NationalID { get; set; } = string.Empty;
        public string ?PhoneNumber { get; set; } = string.Empty;

        public String  ?ImageUrl { get; set; }

        
    }
}
