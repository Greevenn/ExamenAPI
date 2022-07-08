using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SportWord.Ports.API.Controllers
{
    public class ProductosCategoriasDController : Controller
    {
        // GET: ProductosCategoriasDController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductosCategoriasDController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductosCategoriasDController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductosCategoriasDController/Create
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

        // GET: ProductosCategoriasDController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductosCategoriasDController/Edit/5
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

        // GET: ProductosCategoriasDController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductosCategoriasDController/Delete/5
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
