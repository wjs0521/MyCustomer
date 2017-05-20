using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;

namespace MyCustomer.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public 客戶資料 GetSingleDataByCustomerId(int id)
        {
            return (this.All().FirstOrDefault(p => p.Id == id));
        }

        public void Update(客戶資料 custdata)
        {
            this.UnitOfWork.Context.Entry(custdata).State = EntityState.Modified;
        }
	}

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}