using System.ComponentModel;

namespace ReportingExample.Web.Models
{
    public class CustomerViewModel
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }
    }
}