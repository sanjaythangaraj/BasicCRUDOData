﻿namespace BasicCRUDOData.Models
{
    using System;
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CustomerType CustomerType { get; set; }

        public decimal CreditLimit { get; set; }
        public DateTime CustomerSince { get; set; }

        public string VIPCustomer { get; set; }
    }
}
