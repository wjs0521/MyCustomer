using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;

namespace MyCustomer.Models
{   
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{
        public 客戶銀行資訊 GetSingleDataByBankId(int id)
        {
            return (this.All().FirstOrDefault(p => p.Id == id));
        }

        public IQueryable<客戶銀行資訊> GetBankAllData()
        {
            IQueryable<客戶銀行資訊> all = this.All();

            return all.Include(p => p.客戶資料);
        }

        public void Update(客戶銀行資訊 bankdata)
        {
            this.UnitOfWork.Context.Entry(bankdata).State = EntityState.Modified;
        }
    }

	public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}