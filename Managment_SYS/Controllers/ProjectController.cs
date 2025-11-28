using Managment_SYS.Data;
using Managment_SYS.Models;
using Managment_SYS.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata.Ecma335;

namespace Managment_SYS.Controllers
{
    public class ProjectController : Controller
    {
        private readonly TaskManagementSystemDB _db;
        public ProjectController(TaskManagementSystemDB Db) => _db = Db;


        [HttpGet]
        public IActionResult Index()
        {
            var Projects = _db.Projects.Select(x => new ProjectReadVM
            {
                Id = x.Id,
                Description = x.Description,
                EndDate = x.EndDate,
                Name = x.Name,
                StartDate = x.StartDate
            }).ToList();
            return View(Projects);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProjectCreateVM ProVM)
        {
            if (!ModelState.IsValid)
            {
                return View(ProVM);
            }
            var project = new Project()
            {
                Description = ProVM.Description,
                EndDate = ProVM.EndDate,
                Name = ProVM.Name,
                StartDate = ProVM.StartDate
            };

            _db.Projects.Add(project);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var pro = _db.Projects.FirstOrDefault(x => x.Id == id);
            if (pro == null)
            {
                TempData["NotFound"] = "This Task Is NOT FOUND !!";
                return RedirectToAction("Index");
            }

            var vm = new ProjectEditVM()
            {
                Name = pro.Name,
                Description = pro.Description,
                StartDate = pro.StartDate,
                EndDate = pro.EndDate
            };

            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(int id, ProjectEditVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var pro = _db.Projects.FirstOrDefault(x => x.Id == id);
            if (pro == null)
            {
                TempData["NotFound"] = "This Project Is NOT FOUND!!";
                return RedirectToAction("Index");
            }

            pro.Name = vm.Name;
            pro.Description = vm.Description;
            pro.StartDate = vm.StartDate;
            pro.EndDate = vm.EndDate;

            _db.Projects.Update(pro);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Pro = _db.Projects.FirstOrDefault(y => y.Id == id);
            if (Pro == null)
            {
                TempData["NotFound"] = "The Project is not found!";
                return View(Pro);
            }
            var Vm = new ProjectDeleteVM()
            {
                Description = Pro.Description,
                Name = Pro.Name,
                StartDate = Pro.StartDate,
                EndDate = Pro.EndDate,
            };
            return View(Vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var delPro = _db.Projects.FirstOrDefault(y => y.Id == id);
            if (delPro == null)
            {
                TempData["NotFound"] = "The Project is not found!";
                return RedirectToAction("Index");
            }

            _db.Projects.Remove(delPro);
            _db.SaveChanges();

            TempData["Success"] = "The Project was removed successfully!";
            return RedirectToAction("Index");
        }

    }
}