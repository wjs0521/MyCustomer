using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyCustomer.Models;
using MyCustomer.Models.ViewModels;

namespace MyCustomer.Controllers
{
    public class 客戶資料Controller : Controller
    {
        客戶資料Repository custrepo = RepositoryHelper.Get客戶資料Repository();

        // GET: 客戶資料
        public ActionResult Index()
        {
            var custdata = custrepo.All();
            var custview = new CustomerViewModel();
            custview.customer = custdata.Where(p => p.IsDeleted == false);
            return View(custview);
        }

        [HttpPost]
        public ActionResult Index(CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var query = custrepo.All().AsQueryable();

                if (!string.IsNullOrWhiteSpace(model.customersearch.CustomerName))
                {
                    query = query.Where(p => p.客戶名稱.Contains(model.customersearch.CustomerName));
                }

                var result = new CustomerViewModel();
                result.customersearch = model.customersearch;
                result.customer = query;

                return View(result);
            }

            return View();
        }

        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var 客戶資料 = custrepo.GetSingleDataByCustomerId(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 客戶資料/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                custrepo.Add(客戶資料);
                custrepo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(客戶資料);
        }

        // GET: 客戶資料/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var 客戶資料 = custrepo.GetSingleDataByCustomerId(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                custrepo.Update(客戶資料);
                custrepo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var 客戶資料 = custrepo.GetSingleDataByCustomerId(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var 客戶資料 = custrepo.GetSingleDataByCustomerId(id);
            客戶資料.IsDeleted = true;
            custrepo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult CustomerList()
        {
            var custview = RepositoryHelper.GetCUSTOMERLISTRepository();
            var query = custview.All().AsQueryable();

            return View(query.ToList());
        }
    }
}
