using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCustomer.Models.SearchModels;

namespace MyCustomer.Models.ViewModels
{
    public class BankViewModel
    {
        public IEnumerable<客戶銀行資訊> bank { get; set; }
        public BankSearchModel banksearch { get; set; }
        
    }
}