

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProjectDataAccess
{
    public class User
    {
        public short UserId { get; set; } 

        public string LoginId { get; set; } 

        public string Password { get; set; }

        public string FullName { get; set; }

        public string Address1 { get; set; } 

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }
        public bool IsActive { get; set; } 
        public bool NewUser { get; set; }
        public string CreatedBy { get; set; } 
        public System.DateTime CreatedDate { get; set; } 
        public string ModifiedBy { get; set; } 
        public System.DateTime ModifiedDate { get; set; }
        [NotMapped]
        public string SelectedItem { get; set; }
        [NotMapped]
        public List<SelectListItem> SDL { get; set; }

    }
   
    
}
