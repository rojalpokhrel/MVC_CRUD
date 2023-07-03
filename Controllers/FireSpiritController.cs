using Microsoft.AspNetCore.Mvc;
using ThisIsIt.Db;
using ThisIsIt.Models;

namespace ThisIsIt.Controllers
{
    public class FireSpiritController : Controller
    {
        private readonly InformationDbContext informationDbContext;

        public FireSpiritController(InformationDbContext informationDb )
        {
            informationDbContext = informationDb;
        }
        public IActionResult Index()
        {
            IEnumerable<MyCategory> categories = informationDbContext.Mycategorytable;
            return View(categories);
        }

    public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MyCategory obj)
        {
            
            if (ModelState.IsValid)
            {
                informationDbContext.Mycategorytable.Add(obj);
                informationDbContext.SaveChanges();
                return RedirectToAction("Index");

            }

            return View();
        }
        //get
        public IActionResult Edit(int? id)

        {
            if(id==0||id==null)
            {
                return NotFound();
            }
            var categoryfromdb=informationDbContext.Mycategorytable.Find(id);
            if(categoryfromdb==null)
            {
                return NotFound();
            }
            return View(categoryfromdb);
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MyCategory obj)
        {

            if (ModelState.IsValid)
            {
                informationDbContext.Mycategorytable.Update(obj);
                informationDbContext.SaveChanges();
                return RedirectToAction("Index");

            }

            return View();
        }
        public IActionResult Delete(int? id)

        {
           
            var categoryfromdb = informationDbContext.Mycategorytable.Find(id);
            if (categoryfromdb == null)
            {
                return NotFound();
            }
            return View(categoryfromdb);
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(MyCategory obj)
        {

            if (ModelState.IsValid)
            {
                informationDbContext.Mycategorytable.Remove(obj);
                informationDbContext.SaveChanges();
                return RedirectToAction("Index");

            }

            return View();
        }

    }
}
