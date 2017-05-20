using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MyCustomer.Models
{   
	public  class CUSTOMERLISTRepository : EFRepository<CUSTOMERLIST>, ICUSTOMERLISTRepository
	{

	}

	public  interface ICUSTOMERLISTRepository : IRepository<CUSTOMERLIST>
	{

	}
}