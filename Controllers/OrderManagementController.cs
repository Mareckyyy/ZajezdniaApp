using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wyjazdy.Data;
using System.Threading.Tasks;
using System;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Wyjazdy.Attributes;


[CustomAuthorize("Administrator")]
public class OrderManagementController : Controller
{
    private readonly ApplicationDbContext _context;

    public OrderManagementController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var wyjazdy = await _context.Wyjazdy
            .Where(z => z.listaPrzedmiotow != null) 
            .ToListAsync();

        return View(wyjazdy);
    }

    [HttpPost]
    public async Task<IActionResult> RealizujZamowienie(int id)
    {
        var zamowienie = await _context.Wyjazdy.FindAsync(id);
        if (zamowienie == null)
        {
            return NotFound();
        }

        zamowienie.czyZrealizowano = "TAK";
        zamowienie.dataRealizacji = DateTime.Now;
        _context.Update(zamowienie);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> CofnijRealizacje(int id)
    {
        var zamowienie = await _context.Wyjazdy.FindAsync(id);
        if (zamowienie == null)
        {
            return NotFound();
        }

        zamowienie.czyZrealizowano = "NIE";
        zamowienie.dataRealizacji = DateTime.Now;
        _context.Update(zamowienie);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

 
    public  IActionResult PobierzPlikTekstowy(int id)
    {
        var zamowienie = _context.Wyjazdy.FirstOrDefault(o => o.id == id);
        if (zamowienie == null)
        {
            return NotFound();
        }

        var trescPliku = "- "+zamowienie.listaPrzedmiotow.Replace(",","\n-");

        var plikBytes = Encoding.UTF8.GetBytes(trescPliku);
        var nazwaPliku = $"Wyjazdy_{id}.txt";

        return File(plikBytes, "text/plain", nazwaPliku);
    }


}

