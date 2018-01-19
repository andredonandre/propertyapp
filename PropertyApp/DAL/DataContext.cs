using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using PropertyApp.Models;

namespace PropertyApp.DAL
{
    public class DataContext: DbContext
    {
        public DataContext() : base("PropertyAppDb") {

        }
        public static DataContext GetContext()
        {
            return new DataContext();
        }

        public DbSet<Property> Properties { get; set; }
    }
}