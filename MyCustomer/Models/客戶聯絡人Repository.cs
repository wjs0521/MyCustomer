using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;

namespace MyCustomer.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        public 客戶聯絡人 GetSingleDataByContactId(int id)
        {
            return (this.All().FirstOrDefault(p => p.Id == id));
        }

        public IQueryable<客戶聯絡人> GetContactAllData()
        {
            IQueryable<客戶聯絡人> all = this.All();

            return all.Include(p => p.客戶資料);
        }

        public void Update(客戶聯絡人 contactdata)
        {
            this.UnitOfWork.Context.Entry(contactdata).State = EntityState.Modified;
        }
    }

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}