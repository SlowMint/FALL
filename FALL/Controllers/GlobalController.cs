using FALL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FALL.Controllers
{
    public class GlobalController : Controller
    {
        private readonly IGlobalRepository repo;

        public GlobalController(IGlobalRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var globals = repo.GetAllGlobals();
            return View(globals);
        }

        public IActionResult ViewGlobal(long id)
        {
            var global = repo.GetGlobal(id);
            return View(global);
        }

        [HttpGet]
        public IActionResult InsertGlobal()
        {
            return View();
        }


        [HttpPost]
        public IActionResult InsertGlobal(AddUserModel model)
        {
            var newUser = ApexStats.DisplayStats(model);

            repo.InsertGlobal(newUser);

            return RedirectToAction("Index");
        }

        public IActionResult UpdateGlobal(AddUserModel model)
        {
            var newUser = ApexStats.DisplayStats(model);

            repo.UpdateGlobal(newUser);

            if (newUser == null)
            {
                return View("Index");
            }

            return RedirectToAction("ViewGlobal", new { id = newUser.UID });
        }

        public IActionResult DeleteGlobal(Global global)
        {
            repo.DeleteGlobal(global);
            return RedirectToAction("Index");
        }
    }
}
