using Microsoft.AspNetCore.Mvc;
using Wyjazdy.Data;
using Wyjazdy.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wyjazdy.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Wyjazdy.Attributes;

public class OrderController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;

    public OrderController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public IActionResult Create()
    {
        if (_context.Pojazdy == null)
        {
            return View("Error", "Błąd: Brak dostępu do Przedmiotów w bazie danych.");
        }

        var model = new OrderFormModel
        {
            Tramwaje = _context.Pojazdy.Select(p => new PrzedmiotViewModel
            {
                Id = p.Id,
                NazwaTramwaju = p.NazwaTramwaju,
                IsSelected = false
            }).ToList()
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(OrderFormModel orderForm)
    {
        var user = await _userManager.GetUserAsync(User);
        if (!ModelState.IsValid)
        {
            return View(orderForm);
        }

        if (orderForm.SelectedProductId == null)
        {
            ModelState.AddModelError("", "Nie wybrano żadnego pojazdu");
            return View(orderForm);
        }

        var selectedProduct = _context.Pojazdy.FirstOrDefault(p => p.Id == orderForm.SelectedProductId);
        if (selectedProduct == null)
        {
            ModelState.AddModelError("", "Wybrany pojazd nie istnieje.");
            return View(orderForm);
        }

        var zamowienie = new Order
        {
            dataZlozenia = DateTime.Now,
            listaPrzedmiotow = selectedProduct.NazwaTramwaju,
            czyZrealizowano = "NIE",
            dataRealizacji = DateTime.Now,
            uwagi = orderForm.uwagi,
            UserName = user.UserName
        };

        _context.Wyjazdy.Add(zamowienie);
        await _context.SaveChangesAsync();

        return RedirectToAction("OrderSuccess");
    }


    [HttpGet]
    public IActionResult OrderSuccess()
    {
        return View();
    }
}
