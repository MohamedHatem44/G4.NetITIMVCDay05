using G4.NetITIMVCDay05.Context;
using G4.NetITIMVCDay05.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace G4.NetITIMVCDay05.Controllers
{
    public class EmployeeController : Controller
    {
        /*---------------------------------------------------------*/
        // Context
        CompanyContext db = new CompanyContext();
        /*---------------------------------------------------------*/
        [HttpGet]
        public IActionResult Index()
        {
            var employees = db.Employees.Include(emp => emp.Department);
            return View(employees);
        }
        /*---------------------------------------------------------*/
        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var employee = db.Employees.Include(emp => emp.Department).FirstOrDefault(e => e.Id == id);
            return View(employee);
        }
        /*---------------------------------------------------------*/
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(db.Departments, "Id", "Name");
            return View();
        }
        /*---------------------------------------------------------*/
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            ModelState.Remove("Department");
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Is Reqired");
                ViewBag.Departments = new SelectList(db.Departments, "Id", "Name");
                return View();
            }
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*---------------------------------------------------------*/
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = db.Employees.Include(emp => emp.Department).FirstOrDefault(e => e.Id == id);
            if(employee == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Departments = new SelectList(db.Departments, "Id", "Name");
            return View(employee);
        }
        /*---------------------------------------------------------*/
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            ModelState.Remove("Department");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Is Reqired");
                ViewBag.Departments = new SelectList(db.Departments, "Id", "Name");
                return View();
            }
            db.Employees.Update(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*---------------------------------------------------------*/
    }
}
