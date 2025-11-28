using Managment_SYS.Data;
using Managment_SYS.Models;
using Managment_SYS.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Managment_SYS.Controllers
{
    public class TeamMemberController : Controller
    {
        private readonly TaskManagementSystemDB _db;
        public TeamMemberController(TaskManagementSystemDB DB) => _db = DB;
        [HttpGet]
        public IActionResult Index()
        {
            var TeamMems = _db.TeamMembers.Select(x => new TeamMemberReadVM
            {
                Id = x.Id,
                Email = x.Email,
                Name = x.Name,
                Role = x.Role

            }).ToList();
            return View(TeamMems);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TeamMemberCreateVM Created)
        {
            if (!ModelState.IsValid)
            {
                TempData["NotValid"] = "The Task Is Not Valid";
                return View(Created);
            }
            var newCrea = new TeamMember()
            {
                Email = Created.Email,
                Name = Created.Name,
                Role = Created.Role,
            };
            _db.TeamMembers.Add(newCrea);
            _db.SaveChanges();
            TempData["Created"] = "Memeber Added Successfully !!";
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var MemFDB = _db.TeamMembers.FirstOrDefault(x => x.Id == id);
            if (MemFDB is null)
            {
                TempData["NotFound"] = "This Member is not found ";
                return View(MemFDB);
            }
            var edit = new TeamMemberEditVM()
            {
                Email = MemFDB.Email,
                Role = MemFDB.Role,
                Name = MemFDB.Name, 
                Id = MemFDB.Id
            };
            return View(edit);
        }
        [HttpPost]
        public IActionResult Edit(int id, TeamMemberEditVM vm)
        {
            if (!ModelState.IsValid)
            {
                TempData["NotValid"] = "The Task Is Not Valid";
                return View(vm);
            }
            var edit = _db.TeamMembers.FirstOrDefault(y => y.Id == id);
            if (edit is null)
            {
                TempData["NotFound"] = "This Member is not found ";
                return View(edit);
            }
            _db.TeamMembers.Update(edit);
            _db.SaveChanges();
            TempData["Edited"] = "The member data updated successfully";
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete (int id) 
        {
            var DelFDB = _db.TeamMembers.FirstOrDefault(x => x.Id == id);
            if (DelFDB is null)
            {
                TempData["NotFound"] = "This Member is not found ";
                return View(DelFDB);
            }
            var newDel = new TeamMemberDeleteVM()
            {
                Email = DelFDB.Email,
                Name = DelFDB.Name,
                Id = DelFDB.Id,
                Role  = DelFDB.Role,
            };
            return View(newDel);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var delfoDb = _db.TeamMembers.FirstOrDefault( x => x.Id == id);
            if (delfoDb is null)
            {
                TempData["NotFound"] = "This Member is not found ";
                return View(delfoDb);
            }
            _db.Remove(delfoDb);
            _db.SaveChanges();
            TempData["Deleted"] = "The member deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
