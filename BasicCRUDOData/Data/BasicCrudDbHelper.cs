﻿using BasicCRUDOData.Models;

namespace BasicCRUDOData.Data
{
    internal static class BasicCrudDbHelper
    {
        public static void SeedDb(BasicCrudDbContext db)
        {
            if (!db.Customers.Any())
            {
                db.Add(new Customer
                {
                    Id = 1,
                    Name = "Sue",
                    CustomerType = CustomerType.Retail,
                    CreditLimit = 3700,
                    CustomerSince = new DateTime(2022, 7, 4),
                    VIPCustomer = "Yes"
                });

                db.Add(new Customer
                {
                    Id = 2,
                    Name = "Joe",
                    CustomerType = CustomerType.Wholesale,
                    CreditLimit = 5100,
                    CustomerSince = new DateTime(2022, 12, 12),
                    VIPCustomer = "No"
                });

                db.SaveChanges();
            }
        }
    }
}
