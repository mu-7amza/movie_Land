using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieWorld.Data.Services;
using MovieWorld.Models;
using MovieWorld.ViewModels;

namespace MovieWorld.Controllers
{
    
    public class UserController : Controller
    {
        IUsersService service;
      
        public UserController(IUsersService service)
        {
            this.service = service;
        }
        
        public async Task<IActionResult> Index()
        {
            var data = await service.GetAllAsync();
            return View(data);
        }
        
        public async Task<IActionResult> details(int id)
        {
            var userDetails =await service.GetByIdAsync(id);
            if (userDetails == null) return View("NotFound");
            return View(userDetails);
        }

   
      

        // delete
        public async Task<IActionResult> delete(int id)
        {
            var userDetails = await service.GetByIdAsync(id);
            if (userDetails == null) return View("NotFound");
            return View(userDetails);
        }

        [HttpPost , ActionName("delete")]
        public async Task<IActionResult> deleteConfirm(int id)
        {
            var userDetails = await service.GetByIdAsync(id);
            if (userDetails == null) return View("NotFound");

            await service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
      

    }
}
