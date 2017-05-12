using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCustomer.Models.SearchModels;

namespace MyCustomer.Models.ViewModels
{
    public class ContactViewModel
    {
        public IEnumerable<客戶聯絡人> contact { get; set; }
        public ContactSearchModel contactsearch { get; set; }
    }
}