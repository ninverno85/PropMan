using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Co11PropProject.Models
{
    public class PropertySearch
    {
        public string City { get; set; }
        public int? ZipCode { get; set; }
        public decimal? MinRent { get; set; }
        public decimal? MaxRent { get; set; }
        public int? Bedrooms { get; set; }
        public double? Bathrooms { get; set; }
    }
}