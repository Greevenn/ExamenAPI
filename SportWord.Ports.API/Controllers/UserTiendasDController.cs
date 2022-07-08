using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SportWord.Ports.API.Controllers
{
    public class UserTiendasDController : Controller
    {
        // GET: UserTiendasDController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserTiendasDController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserTiendasDController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserTiendasDController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserTiendasDController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserTiendasDController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserTiendasDController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserTiendasDController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
