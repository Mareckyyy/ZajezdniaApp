using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wyjazdy.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Wyjazdy.Attributes;


[CustomAuthorize("Administrator")]
public class UserController : Controller
{
    
    private readonly UserManager<ApplicationUser> _userManager;

    public UserController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _userManager.Users.ToListAsync();
        return View(users);
    }

    public async Task<IActionResult> ChangeRole(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user != null)
        {
            if (user.TypUzytkownika == "Administrator") //tutaj jest haslo aby utworzyc uzytkownika z uprawnieniami administratora
            {
                user.TypUzytkownika = "Użytkownik";
            }
            else
            {
                user.TypUzytkownika = "Administrator";
            }

            var result = await _userManager.UpdateAsync(user);
            
        }

        return RedirectToAction("Index");
    }
}
