using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using smvn.Models;

namespace smvn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentController : Controller
    {
        private readonly DataContext _context;
        public DepartmentController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var dpList = _context.Khoas.OrderBy(d => d.DepartmentID).ToList();
            return View(dpList);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var dp = _context.Khoas.Find(id);
            if (dp == null)
                return NotFound();
            return View(dp);
        }
        [HttpPost]

        public IActionResult Delete(int id)
        {
            var delDepartment = _context.Khoas.Find(id);
            if (delDepartment == null)
                return NotFound();
            _context.Khoas.Remove(delDepartment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // public IActionResult Create()
        // {
        //     var dpList = (from d in _context.Khoas
        //                   select new { d.DepartmentID});
        //     dpList.Insert(0, DepartmentID 
        //     {
        //         Text = "--- select ---", 
        //         Value = "0" 
        //     });
        //     ViewBag.dpList = dpList;
        //     return View();
        // }
        // [HttpPost]
        // public IActionResult Create(tblKhoa dp)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Khoas.Add(dp);
        //         _context.SaveChanges();
        //         return RedirectToAction("Index");
        //     }
        //     return View(dp);
        // }

        // public IActionResult Edit(int? id)
        // {
        //     if (id == null || id == 0)
        //         return NotFound();
        //     var mn = _context.Menus.Find(id);
        //     if (mn == null)
        //         return NotFound();
        //     var mnList = (from m in _context.Menus
        //                   select new SelectListItem()
        //                   {
        //                     Text = (m.Levels == 1) ? m.MenuName : "-- " + m.MenuName,
        //                     Value = m.MenuID.ToString()
        //                   }).ToList();
        //     mnList.Insert(0, new SelectListItem()
        //     {
        //         Text = "--- select---",
        //         Value = "0"
        //     });
        //     ViewBag.mnList = mnList;
        //     return View(mn);
        // }
        // [HttpPost]
        // public IActionResult Edit(tblMenu mn)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Update(mn);
        //         _context.SaveChanges();
        //         return RedirectToAction("Index");
        //     }
        //     return View(mn);
        // }
    }
}