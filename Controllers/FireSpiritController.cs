using Microsoft.AspNetCore.Mvc;
using ThisIsIt.Db;
using ThisIsIt.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using ThisIsIt.Models.ViewModels;

namespace ThisIsIt.Controllers
{
    public class FireSpiritController : Controller
    {
        private readonly InformationDbContext informationDbContext;

        public FireSpiritController(InformationDbContext informationDb )
        {
            informationDbContext = informationDb;
        }
        public IActionResult Details()
        {
          var data =   informationDbContext.Hellocategorytable.ToList();    
            return View(data);
        }
        public IActionResult Firstpage()
        {
            return View();
        }
        
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if(claimUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "FireSpirit");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel modelLogin)
        {
            if (modelLogin.Email == "admin@gmail.com" && modelLogin.Password == "admin")
            {

                //this area was causing problem

               // AuthenticationProperties properties = new AuthenticationProperties() {
               //     AllowRefresh = true,
               //// IsPersistent = modelLogin.KeepLoggedIn
               //     };

                return RedirectToAction(nameof(Index));
            }
            ViewData["ValidateMessage"] = "User Don't Exists";
            ViewData["ValidateMessageColor"] = "red";

            return View();  
        }


        [Authorize]
        public async Task<IActionResult> LogOut()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View(nameof(Firstpage));
        }

        public IActionResult Index()
        {
            IEnumerable<MyCategory> categories = informationDbContext.Hellocategorytable;
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
                informationDbContext.Hellocategorytable.Add(obj);
                informationDbContext.SaveChanges();
                return RedirectToAction("Index","FireSpirit");

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
            var categoryfromdb=informationDbContext.Hellocategorytable.Find(id);
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
                informationDbContext.Hellocategorytable.Update(obj);
                informationDbContext.SaveChanges();
                return RedirectToAction("Index");

            }

            return View();
        }
        public IActionResult Delete(int? id)

        {
           
            var categoryfromdb = informationDbContext.Hellocategorytable.Find(id);
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
                informationDbContext.Hellocategorytable.Remove(obj);
                informationDbContext.SaveChanges();
                return RedirectToAction("Index");

            }

            return View();
        }

    }
}
