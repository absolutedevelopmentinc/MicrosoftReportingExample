using System.Collections.Generic;
using System.Linq;
using ReportingExample.Web.Models;

namespace ReportingExample.Web.Services
{
    public class CustomerService
    {
        public IEnumerable<CustomerViewModel> GetActiveCustomers()
        {
            // NOTE: this would be a call to Repo or Unit of Work in the real world
            var customers = FakeCustomers();

            return customers;
        }

        private IEnumerable<CustomerViewModel> FakeCustomers()
        {
            return new List<CustomerViewModel>
            {
                new CustomerViewModel { FirstName = "John", LastName = "Doe", EmailAddress = "john@example.com" },
                new CustomerViewModel { FirstName = "Mary", LastName = "Moe", EmailAddress = "mary@example.com" },
                new CustomerViewModel { FirstName = "July", LastName = "Dooley", EmailAddress = "july@example.com" }
            }.AsEnumerable();
        }
    }
}