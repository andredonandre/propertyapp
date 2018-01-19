using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyApp.Models
{
    public class Property
    {
        public Guid id { get; set; }
        public string Title { get; set; }
        public string Landlord { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public virtual string[] ImagePaths { get; set; }

    }
}