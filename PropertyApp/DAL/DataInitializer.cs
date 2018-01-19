using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PropertyApp.Models;

namespace PropertyApp.DAL
{
    public class DataInitializer: System.Data.Entity.CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var properties = new List<Property>
            {
                //new Property {
                //    id = Guid.NewGuid(),
                //    Title = "Title one",
                //    Landlord = "Mr Rick Lander",
                //    Address = "34 kivumbi Road",
                //    Country = "Uganda",
                //    Description = "Spain",
                //    ImagePaths = new string[]{ }
                //},
            };
            var prop = properties;
            properties.ForEach(p => context.Properties.Add(p));
            context.SaveChanges();
        }
    }
}