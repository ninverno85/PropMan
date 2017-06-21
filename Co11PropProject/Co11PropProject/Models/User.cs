using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Co11PropProject.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool PropertyOwner { get; set; }
        public string UserName { get; set; }

        public ICollection<Property> Properties { get; set; }
    }
}