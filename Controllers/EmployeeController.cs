using DropdownDemo.Data;
using DropdownDemo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace DropdownDemo.Controllers
{
    public class EmployeeController(ApplicationDbContext db) : Controller
    {
        private readonly ApplicationDbContext _db = db;

        public void PopulateDesignation()
        {
            IEnumerable<SelectListItem> GetDesignation =
                _db.Designation.Select(i => new SelectListItem
                {
                    Text = i.DesignationName,
                    Value = i.DesignationId.ToString()
                });
            ViewBag.DesignationList = GetDesignation;
        }

        public IActionResult Index()
        {
            var objEmployeeList = _db.Employee.ToList();
            foreach (var obj in objEmployeeList)
            {
                obj.Designation = _db.Designation.FirstOrDefault(u => u.DesignationId == obj.DesignationId)
                                  ?? new DesignationEntity { DesignationId = obj.DesignationId, DesignationName = "Unknown" };
            }
            return View(objEmployeeList);
        }

        public IActionResult Create()
        {
            PopulateDesignation();
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeEntity objEmp)
        {
            if (ModelState.IsValid)
            {
                _db.Employee.Add(objEmp);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateDesignation();
            return View(objEmp);
        }
        public IActionResult Edit(int id)
        {
            var objEmp = _db.Employee.FirstOrDefault(e => e.Id == id);
            if (objEmp == null)
            {
                return NotFound();
            }

            PopulateDesignation(); // for dropdown
            return View(objEmp);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEntity objEmp)
        {
            if (ModelState.IsValid)
            {
                _db.Employee.Update(objEmp);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateDesignation(); // to reload dropdown in case of error
            return View(objEmp);
        }
        public IActionResult Delete(int id)
        {
            var objEmp = _db.Employee.FirstOrDefault(e => e.Id == id);
            if (objEmp == null)
            {
                return NotFound();
            }

            _db.Employee.Remove(objEmp);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}

        