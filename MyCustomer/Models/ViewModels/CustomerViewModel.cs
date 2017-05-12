using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCustomer.Models.SearchModels;
using MyCustomer.Models;

namespace MyCustomer.Models.ViewModels
{
    public class CustomerViewModel
    {
        public IEnumerable<客戶資料> customer { get; set; }
        public CustomerSearchModel customersearch { get; set; }
    }
}