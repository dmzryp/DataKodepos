using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataKodepos.Data;
using DataKodepos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DataKodepos.Controllers
{
    public class DataKodeposController : Controller
    {
        private readonly ApplicationDBContext _db;

        public DataKodeposController(ApplicationDBContext db)
        {
            _db = db;
        }


        public IActionResult Index(int pg = 1)
        {

            //DataKabProp();
            ViewBag.ListofPropinsi = new SelectList(_db.Propinsi, "Nama", "Nama");
            ViewBag.ListofKabupaten = new SelectList(_db.Kabupaten, "Nama", "Nama");


            var item = _db.Kodepos.AsNoTracking().OrderBy(p => p.Propinsi);
            List<Kodepos> model = item.ToList();

            const int pageSize = 5;
            if (pg < 1)
            {
                pg = 1;
            }
            int recsCount = model.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = model.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;
            ViewData["cek"] = "get";
            return View(data);
        }

        [HttpPost]
        public IActionResult Index(string ListofPropinsi, string ListofKabupaten, int pg = 1) 
        {
            //DataKabProp();
            ViewBag.ListofPropinsi = new SelectList(_db.Propinsi, "Nama", "Nama");
            ViewBag.ListofKabupaten = new SelectList(_db.Kabupaten, "Nama", "Nama");

            var Kodeposquery = from x in _db.Kodepos select x;
            Kodeposquery = Kodeposquery.Where(x => x.Propinsi.Contains(ListofPropinsi) && x.Kabupaten.Contains(ListofKabupaten));
            var item2 = Kodeposquery.AsNoTracking().OrderBy(p => p.Propinsi);
            List<Kodepos> model2 = item2.ToList();

            const int pageSize = 5;
            if (pg < 1)
            {
                pg = 1;
            }
            int recsCount = model2.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = model2.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;
            ViewData["cek"] = "post";
            //return RedirectToAction("Index", data);
             return View(data);
        }

        public void DataKabProp()
        {
            var PropinsiLIst = (from Propinsi in _db.Propinsi
                                select new SelectListItem()
                                {
                                    Text = Propinsi.Nama,
                                    Value = Propinsi.Nama
                                }).ToList();
            ViewBag.ListofPropinsi = PropinsiLIst;

            var KabupatenLIst = (from Kabupaten in _db.Kabupaten
                                 select new SelectListItem()
                                 {
                                     Text = Kabupaten.Nama,
                                     Value = Kabupaten.Nama
                                 }).ToList();
            ViewBag.ListofKabupaten = KabupatenLIst;
        }

        public IActionResult Create()
        {
            DataKabProp();
            return View();
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Kodepos obj)
        {
            if (ModelState.IsValid)
            {
                _db.Kodepos.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET Delete
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Kodepos.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        // POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Kodepos.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Kodepos.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET Update
        public IActionResult Update(int? id)
        {
            DataKabProp();
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Kodepos.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        // POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Kodepos obj)
        {
            if (ModelState.IsValid)
            {
                _db.Kodepos.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }
    }
}
