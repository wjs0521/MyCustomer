﻿using System;
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
    public class 客戶銀行資訊Controller : Controller
    {
        客戶銀行資訊Repository bankrepo = RepositoryHelper.Get客戶銀行資訊Repository();
        客戶資料Repository custrepo = RepositoryHelper.Get客戶資料Repository();

        // GET: 客戶銀行資訊
        public ActionResult Index()
        {
            var 客戶銀行資訊 = bankrepo.GetBankAllData();
            var bankview = new BankViewModel();
            bankview.bank = 客戶銀行資訊.Where(p => p.IsDeleted == false);
            return View(bankview);
        }

        [HttpPost]
        public ActionResult Index(BankViewModel model)
        {
            if (ModelState.IsValid)
            {
                var query = bankrepo.All().AsQueryable();

                if (!string.IsNullOrWhiteSpace(model.banksearch.AccountName))
                {
                    query = query.Where(p => p.帳戶名稱.Contains(model.banksearch.AccountName));
                }

                var result = new BankViewModel();
                result.banksearch = model.banksearch;
                result.bank = query;

                return View(result);
            }

            return View();
        }

        // GET: 客戶銀行資訊/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var 客戶銀行資訊 = bankrepo.GetSingleDataByBankId(id.Value);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(custrepo.All(), "Id", "客戶名稱");
            return View();
        }

        // POST: 客戶銀行資訊/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,銀行名稱,銀行代碼,分行代碼,帳戶名稱,帳戶號碼")] 客戶銀行資訊 客戶銀行資訊)
        {
            if (ModelState.IsValid)
            {
                bankrepo.Add(客戶銀行資訊);
                bankrepo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(custrepo.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var 客戶銀行資訊 = bankrepo.GetSingleDataByBankId(id.Value);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(custrepo.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // POST: 客戶銀行資訊/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,銀行名稱,銀行代碼,分行代碼,帳戶名稱,帳戶號碼")] 客戶銀行資訊 客戶銀行資訊)
        {
            if (ModelState.IsValid)
            {
                bankrepo.Update(客戶銀行資訊);
                bankrepo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(custrepo.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var 客戶銀行資訊 = bankrepo.GetSingleDataByBankId(id.Value);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // POST: 客戶銀行資訊/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var 客戶銀行資訊 = bankrepo.GetSingleDataByBankId(id);
            客戶銀行資訊.IsDeleted = true;
            bankrepo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }
    }
}
