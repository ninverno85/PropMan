using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Co11PropProject.Models
{
    public class Property
    {
        [Key]
        public int PropertyId { get; set; }

        public int UserId { get; set; }
        public string PropertyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public decimal RentMonth { get; set; }
        public int SquareFoot { get; set; }
        public int Bedrooms { get; set; }
        public double Bathrooms { get; set; }
        public bool Pets { get; set; }
        public int LeaseTerms { get; set; }
        public string ImagePath { get; set; }

        public User User { get; set; }
    }
}