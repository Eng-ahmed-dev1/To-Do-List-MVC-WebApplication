using Managment_SYS.Data;
using Managment_SYS.Models;
using Managment_SYS.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;

namespace Managment_SYS.Controllers
{
    public class TaskController : Controller
    {
        private readonly TaskManagementSystemDB _db;
        public TaskController(TaskManagementSystemDB DB) => _db = DB;

        [HttpGet]
        public IActionResult Index()
        {
            var Tasks = _db.Tasks.Select(x => new TaskReadVM
            {
                Id = x.Id,
                Description = x.Description,
                Deadline = x.Deadline,
                Title = x.Title,
                Status = x.Status,
                Priority = x.Priority,
                ProjectId = x.ProjectId,
                TeamMemberId = x.TeamMemberId,
            }).ToList();
            return View(Tasks);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Projects = new SelectList(_db.Projects,"Id","Name");
            ViewBag.TeamMembers = new SelectList(_db.TeamMembers,"Id","Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create (TaskCreateVM CrVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Projects = new SelectList(_db.Projects, "Id", "Name",CrVM.ProjectId);
                ViewBag.TeamMembers = new SelectList(_db.TeamMembers, "Id", "Name",CrVM.TeamMemberId);

                return View(CrVM);
            }
            var NewTask = new Models.Task() 
            {
                Description = CrVM.Description, 
                Deadline = CrVM.Deadline,
                Title = CrVM.Title,
                Priority = CrVM.Priority,
                ProjectId = CrVM.ProjectId, 
                Status = CrVM.Status,
                TeamMemberId= CrVM.TeamMemberId,
            };
            _db.Tasks.Add(NewTask);
            _db.SaveChanges();
            TempData["Created"] = "The Task Created Successfully !!";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var newTask = _db.Tasks.FirstOrDefault(x=>x.Id == id);
            if (newTask is null)
            {
                TempData["NotFOUND"] = "The Task is not found to edit ";
                return View(newTask);
               
            }
            var newVm = new TaskEditVM()
            {
                Id = newTask.Id,
                Deadline = newTask.Deadline,
                Description = newTask.Description,
                Priority = newTask.Priority,
                ProjectId = newTask.ProjectId,
                Status = newTask.Status,
                TeamMemberId = newTask.TeamMemberId,
                Title = newTask.Title
            };
            ViewBag.Projects = new SelectList(_db.Projects, "Id", "Name");
            ViewBag.Members = new SelectList(_db.TeamMembers, "Id", "Name");
            return View(newVm); 
        }
        [HttpPost]
        public IActionResult Edit(int id , TaskEditVM taskEdit)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Projects = new SelectList(_db.Projects, "Id", "Name",taskEdit.ProjectId);
                ViewBag.Members = new SelectList(_db.TeamMembers, "Id", "Name",taskEdit.TeamMemberId);
                return View(taskEdit);
            }
            var TfromDb = _db.Tasks.FirstOrDefault(x => x.Id == id);
            if (TfromDb == null)
            {
                TempData["Not Found"] = "The Task Is Not Exist";
                return View(TfromDb);
            }
            TfromDb.Title = taskEdit.Title;
            TfromDb.Status = taskEdit.Status;
            TfromDb.Deadline = taskEdit.Deadline;
            TfromDb.Description = taskEdit.Description;
            TfromDb.Priority = taskEdit.Priority;
            TfromDb.ProjectId = taskEdit.ProjectId;
            TfromDb.TeamMemberId = taskEdit.TeamMemberId;
            TempData["Sucess"] = "The Task Updated Successfully !!";
            _db.Tasks.Update(TfromDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Del = _db.Tasks.FirstOrDefault(x => x.Id == id);
            if (Del == null)
            {
                TempData["Not Found"] = "The Task Is Not Exist";
                return View(Del);
            }
            var Vm = new TaskDeleteVM()
            {
                Deadline = Del.Deadline,
                Description = Del.Description,
                Id = Del.Id,Priority = Del.Priority,
                ProjectId = Del.ProjectId,
                Status = Del.Status,
                TeamMemberId = Del.TeamMemberId,
                Title = Del.Title
            };
            return View(Vm); 
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var TtoDel = _db.Tasks.FirstOrDefault(x=>x.Id == id);
            if ( TtoDel == null)
            {
                TempData["Not Found"] = "The Task Is Not Exist";
                return View(TtoDel);
            }
            _db.Tasks.Remove(TtoDel);
            _db.SaveChanges();
            TempData["Deleted"] = "The Task Updated Successfully !!";
            return RedirectToAction(nameof(Index));
        }
    }
}

