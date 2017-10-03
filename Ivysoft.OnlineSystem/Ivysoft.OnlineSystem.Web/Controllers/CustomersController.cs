using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ivysoft.OnlineSystem.Data;
using Ivysoft.OnlineSystem.Data.Models;
using Ivysoft.OnlineSystem.Web.Infrastructure;

namespace Ivysoft.OnlineSystem.Web.Controllers
{
    public class CustomersController : Controller
    {
        private OnlineSystemDbContext db = new OnlineSystemDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            //var customers = db.Customers.Include(c => c.User);
            return View(/*customers.ToList()*/);
        }

        public ActionResult GetAll(JQDTParams param)
        {
            var customers = db.Customers.Include(c => c.User);
            //var customers.ToList()

            //using (var db = new MBOSSEntities())
            //{
            //    var q = from x in db.VW_ARACMARKATIPI select x;
            //    var nonfilteredcount = q.Count();
            //    //filter
            //    //-------------------------------------------------------------------
            //    foreach (var item in param.columns)
            //    {
            //        var filterText = item.search.value;
            //        if (!String.IsNullOrEmpty(filterText))
            //        {
            //            filterText = filterText.ToLower();
            //            switch (item.name)
            //            {
            //                case "MARKAADI":
            //                    q = q.Where(
            //           x =>
            //               x.MARKAADI.ToLower().Contains(filterText)

            //       );
            //                    break;
            //                case "TIPADI":
            //                    q = q.Where(
            //           x =>
            //               x.TIPADI.ToLower().Contains(filterText)

            //       );
            //                    break;
            //            }
            //        }
            //    }
            //    //order
            //    //-------------------------------------------------------------------
            //    foreach (var item in param.order)
            //    {
            //        string orderingFunction = "MARKAADI";
            //        switch (item.column)
            //        {
            //            case 1:
            //                orderingFunction = "MARKAADI";
            //                break;

            //            case 2:
            //                orderingFunction = "TIPADI";
            //                break;

            //        }

            //        q = OrderClass.OrderBy<VW_ARACMARKATIPI>(q, orderingFunction, item.dir.GetStringValue());
            //    }

            //    //result
            //    //-------------------------------------------------------------------
            //    var filteredCount = q.Count();
            //    q = q.Skip(param.start).Take(param.length);
            //    var data = q.ToList()
            //        .Select(r => new[] {
            //           r.ARACMARKAPK.ToString(),
            //           r.MARKAADI,
            //           r.TIPADI,
            //        }

            //        );
            //    return Json(new
            //    {
            //        draw = param.draw,
            //        recordsTotal = nonfilteredcount,
            //        recordsFiltered = filteredCount,
            //        data = data
            //    }, JsonRequestBehavior.AllowGet);

            //}


            //var model = new ModelZa();
            //var fileContents = System.IO.File.ReadAllText(Server.MapPath(@"~/NewFolder1/Bookings.json"));




            //var movie1 = JsonConvert.DeserializeObject<ModelZa>(fileContents);
            var nonfilteredcount = customers.Count();

            ////filter
            ////-------------------------------------------------------------------
            //foreach (var item in param.columns)
            //{
            //    var filterText = item.search.value;
            //    if (!String.IsNullOrEmpty(filterText))
            //    {
            //        filterText = filterText.ToLower();
            //        switch (item.name)
            //        {
            //            case "MARKAADI":
            //                movie1.Bookings = movie1.Bookings.Where(
            //       x =>
            //           x.MARKAADI.ToLower().Contains(filterText)

            //   );
            //                break;
            //            case "TIPADI":
            //                movie1.Bookings = q.Where(
            //       x =>
            //           x.TIPADI.ToLower().Contains(filterText)

            //   );
            //                break;
            //        }
            //    }
            //}


            customers = customers.OrderBy(n => n.ContactName).Skip(param.start).Take(param.length);

            var data = customers.ToList().Select(r => new[]
            {

                   r.CustomerId.ToString(),
                   r.ContactName.ToString(),
                   r.Address.ToString(),
                   r.City.ToString(),
                   r.Phone.ToString()

            }).ToArray();


            //            < td > @item.Id </ td >
            //< td > @item.Upd_Dat </ td >
            //< td > @item.Srv_Prc </ td >
            //< td > @item.Sta </ td >



            return this.Json(new
            {
                draw = param.draw,
                recordsTotal = nonfilteredcount,
                recordsFiltered = nonfilteredcount,
                data = data
            }, JsonRequestBehavior.AllowGet);
        }

        // GET: Customers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,Address,City,CompanyName,ContactName,ContactTitle,Country,Fax,Phone,PostalCode,Region,UserId,IsDeleted,DeletedOn,CreatedOn,ModifiedOn")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", customer.UserId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", customer.UserId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,Address,City,CompanyName,ContactName,ContactTitle,Country,Fax,Phone,PostalCode,Region,UserId,IsDeleted,DeletedOn,CreatedOn,ModifiedOn")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", customer.UserId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
