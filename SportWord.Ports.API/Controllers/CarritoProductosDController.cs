using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SportWord.Ports.API.Controllers
{
    public class CarritoProductosDController : Controller
    {
        // GET: CarritoProductosDController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CarritoProductosDController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarritoProductosDController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarritoProductosDController/Create
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

        // GET: CarritoProductosDController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarritoProductosDController/Edit/5
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

        // GET: CarritoProductosDController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarritoProductosDController/Delete/5
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
