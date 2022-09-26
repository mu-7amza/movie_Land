using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieWorld.Data.Services;
using MovieWorld.Models;
using MovieWorld.ViewModels;
using System.Xml.Linq;

namespace MovieWorld.Controllers
{
    
    public class MovieController : Controller
    {
        IMovieService service;
        UsersService Users;

        public MovieController(IMovieService service)
        {
            this.service = service;
        }
        



        public async Task<IActionResult> Index()
        {

            var allMovies = await service.GetAllAsync();
            return View(allMovies);
        }
        public IActionResult create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> create([Bind("Name,Category,Description,ImageUrl")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                return View(movie);
            }
            await service.AddAsync(movie);
            return RedirectToAction("index");

        }
        public async Task<IActionResult> details(int id)
        {

            var movieDetails = await service.GetByIdAsync(id);
            if (movieDetails == null) return View("NotFound");
            return View(movieDetails);
        }
        //Get
        public async Task<IActionResult> edit(int id)
        {
            var movieDetails = await service.GetByIdAsync(id);
            if (movieDetails == null) return View("NotFound");
            return View(movieDetails);
        }
        [HttpPost]
        public async Task<IActionResult> edit(int id, [Bind("Id,Name, Category, Description, ImageUrl")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                return View(movie);
            }
            await service.UpdateAsync(id, movie);
            return RedirectToAction(nameof(Index));

        }

        // delete
        public async Task<IActionResult> delete(int id)
        {
            var movieDetails = await service.GetByIdAsync(id);
            if (movieDetails == null) return View("NotFound");
            return View(movieDetails);
        }
        [HttpPost, ActionName("delete")]
        public async Task<IActionResult> deleteConfirm(int id)
        {
            var movieDetails = await service.GetByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            await service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public IActionResult login()
        {
            LoginVM vM = new LoginVM();
            return View(vM);
        }
        public async Task <IActionResult> profile()
        {

            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("login");
            }
            User currentUser = await service.GetByIdAsync1(userId);
            return View(currentUser);
            HttpContext.Session.Clear();

        }
        [HttpPost]
        public async Task<IActionResult> login(LoginVM login)
        {
            User user = await service.loginAsync(login);
            if (user != null)
            {
                // admin page
               if(user.Email == "Hamza@gmail.com"){
                    return RedirectToAction("index");
                    HttpContext.Session.SetInt32("UserId", user.Id);
                }
                else
                {
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    return RedirectToAction("profile");
                    
                }
            } 
             LoginVM vM = new LoginVM();
            vM.Message = "Wrong Email Or Password";
            return View("login", vM);

        

        }
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login");
        }
        public IActionResult register()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> register([Bind("Fname,Lname,Email,Password,ConfirmPassword,Phone,Address,profileUrl")] User user)
        {
            if (ModelState.IsValid)
            {
                return View(user);
            }
            await service.AddAsync1(user);
            return RedirectToAction(nameof(profile));

        }
        public async Task <IActionResult> home()
        {
            var allMovies = await service.GetAllAsync();
            return View(allMovies);
        }

    }
}
