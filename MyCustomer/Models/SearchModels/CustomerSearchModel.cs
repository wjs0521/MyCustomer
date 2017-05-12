using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCustomer.Models.SearchModels
{
    public class CustomerSearchModel
    {
        public string CustomerName { get; set; }
        public string TaxNumber { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}