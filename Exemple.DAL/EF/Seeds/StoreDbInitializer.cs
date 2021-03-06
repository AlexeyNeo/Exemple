﻿using System.Data.Entity;
using Exemple.DAL.Entities;

namespace Exemple.DAL.EF.Seeds
{
    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<MobileContext>
    {
        protected override void Seed(MobileContext db)
        {
            db.Phones.Add(new Phone { Name = "Nokia Lumia 630", Company = "Nokia", Price = 220 });
            db.Phones.Add(new Phone { Name = "iPhone 6", Company = "Apple", Price = 320 });
            db.Phones.Add(new Phone { Name = "LG G4", Company = "lG", Price = 260 });
            db.Phones.Add(new Phone { Name = "Samsung Galaxy S 6", Company = "Samsung", Price = 300 });
            db.SaveChanges();
        }
    }
}