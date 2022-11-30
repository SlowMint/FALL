using FALL.Client;
using FALL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FALL.Controllers
{
    public class GlobalController : Controller
    {
        //MySQL Database
        private readonly IGlobalRepository repo;

        //Dependency Injection
        public GlobalController(IGlobalRepository repo)
        {
            this.repo = repo;
        }

        //Initial Player List
        public IActionResult Index()
        {
            var globals = repo.GetAllGlobals();
            return View(globals);
        }

        //Select ID to View Player
        public IActionResult ViewGlobal(long id)
        {
            var global = repo.GetGlobal(id);
            return View(global);
        }

        //Input & Request
        [HttpGet]
        public IActionResult InsertGlobal()
        {
            return View();
        }

        //Data Drawn from Request Inserted to Table
        [HttpPost]
        public IActionResult InsertGlobal(AddUserModel model)
        {
            var newUser = ApexStats.DisplayStats(model);

            //Null Exception for request errors
            if (newUser is null)
            {
                return RedirectToAction("InsertGlobal");
            }

            repo.InsertGlobal(newUser);

            return RedirectToAction("Index");
        }

        //Request Data from API again
        [HttpPost]
        public IActionResult UpdateGlobal(AddUserModel model)
        {
            var newUser = ApexStats.DisplayStats(model);

            repo.UpdateGlobal(newUser);
            
            //Null Exception for Active Player Changes
            if (newUser == null)
            {
                return View("Index");
            }

            return RedirectToAction("ViewGlobal", new { id = newUser.UID });
        }

        //Delete 
        public IActionResult DeleteGlobal(Global global)
        {
            repo.DeleteGlobal(global);
            return RedirectToAction("Index");
        }
    }
}
