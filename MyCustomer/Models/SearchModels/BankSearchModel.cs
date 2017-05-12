using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCustomer.Models.SearchModels
{
    public class BankSearchModel
    {
        public int CustomerId { get; set; }
        public string BankName { get; set; }
        public int BankNumber { get; set; }
        public Nullable<int> BranchNumber { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
    }
}