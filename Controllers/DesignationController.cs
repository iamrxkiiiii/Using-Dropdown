using DropdownDemo.Data;
using DropdownDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace DropdownDemo.Controllers
{
    public class DesignationController(ApplicationDbContext db) : Controller
    {
        private readonly ApplicationDbContext _db = db;

        public IActionResult Index()
        {
            var objDesignationList = _db.Designation.ToList();
            return View(objDesignationList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DesignationEntity designationObj)
        {
            if (ModelState.IsValid)
            {
                _db.Designation.Add(designationObj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(designationObj);
        }

        public IActionResult Edit(int id)
        {
            var designation = _db.Designation.FirstOrDefault(d => d.DesignationId == id);
            if (designation == null)
            {
                return NotFound();
            }

            return View(designation);
        }

        [HttpPost]
        public IActionResult Edit(DesignationEntity designationObj)
        {
            if (ModelState.IsValid)
            {
                _db.Designation.Update(designationObj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(designationObj);
        }

        public IActionResult Delete(int id)
        {
            var designation = _db.Designation.FirstOrDefault(d => d.DesignationId == id);
            if (designation == null)
            {
                return NotFound();
            }

            _db.Designation.Remove(designation);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
