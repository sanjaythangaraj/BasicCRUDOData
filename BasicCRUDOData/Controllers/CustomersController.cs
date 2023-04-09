using BasicCRUDOData.Data;
using BasicCRUDOData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace BasicCRUDOData.Controllers
{
    public class CustomersController: ODataController
    {
        private readonly BasicCrudDbContext db;

        public CustomersController(BasicCrudDbContext db)
        {
            this.db = db;   
        }

        [EnableQuery]
        public ActionResult<IQueryable<Customer>> Get()
        {
            return Ok(db.Customers);
        }

        [EnableQuery]
        public ActionResult<Customer> Get([FromRoute] int key)
        {
            var customer = db.Customers.SingleOrDefault(d => d.Id == key);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        public ActionResult Post([FromBody] Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();

            return Created(customer);
        }

        public ActionResult Put([FromRoute] int key, [FromBody] Customer updatedCustomer)
        {
            var customer = db.Customers.SingleOrDefault(d => d.Id == key);

            if (customer == null)
            {
                return NotFound();
            }

            customer.Name = updatedCustomer.Name;
            customer.CustomerType = updatedCustomer.CustomerType;
            customer.CreditLimit = updatedCustomer.CreditLimit;
            customer.CustomerSince = updatedCustomer.CustomerSince;
            customer.VIPCustomer = updatedCustomer.VIPCustomer;

            db.SaveChanges();

            return Updated(customer);
        }

        public ActionResult Patch([FromRoute] int key, [FromBody] Delta<Customer> delta)
        {
            var customer = db.Customers.SingleOrDefault(d => d.Id == key);

            if (customer == null)
            {
                return NotFound();
            }

            delta.Patch(customer);

            db.SaveChanges();

            return Updated(customer);
        }

        public ActionResult Delete([FromRoute] int key)
        {
            var customer = db.Customers.SingleOrDefault(d => d.Id == key);

            if (customer != null)
            {
                db.Customers.Remove(customer);
            }

            db.SaveChanges();

            return NoContent();
        }
    }
}
