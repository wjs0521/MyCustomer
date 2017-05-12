using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCustomer.Models.SearchModels
{
    public class ContactSearchModel
    {
        public int CustomerId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string Tel { get; set; }
    }
}