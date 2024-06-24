using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wyjazdy.Data;
using Wyjazdy.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Wyjazdy.Attributes;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;

namespace Wyjazdy.Controllers
{
    [CustomAuthorize("Administrator")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var viewModel = new ProductIndexViewModel
            {
                Pojazdy = await _context.Pojazdy.ToListAsync(),
                NowyPrzedmiot = new Przedmiot()
            };
            return View(viewModel);
        }



        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NazwaTramwaju")] Przedmiot nowyPrzedmiot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nowyPrzedmiot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var viewModel = new ProductIndexViewModel
            {
                Pojazdy = await _context.Pojazdy.ToListAsync(),
                NowyPrzedmiot = nowyPrzedmiot
            };
            return View("Index", viewModel);
        }


    


        public async Task<IActionResult> Delete(int id)
        {
            var przedmiot = await _context.Pojazdy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (przedmiot == null)
            {
                return NotFound();
            }

            return View(przedmiot);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var przedmiot = await _context.Pojazdy.FindAsync(id);
            _context.Pojazdy.Remove(przedmiot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrzedmiotExists(int id)
        {
            return _context.Pojazdy.Any(e => e.Id == id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Import(IFormFile fileUpload)
        {
            if (fileUpload == null || fileUpload.Length == 0)
            {
                TempData["Error"] = "Please upload a valid text file.";
                return RedirectToAction(nameof(Index));
            }

            int count = 0;
            using (var stream = new StreamReader(fileUpload.OpenReadStream()))
            {
                string line;
                while ((line = await stream.ReadLineAsync()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        var newProduct = new Przedmiot { NazwaTramwaju = line.Trim() };
                        _context.Add(newProduct);
                        count++;
                    }
                }
            }
            await _context.SaveChangesAsync();
            TempData["Success"] = $"{count} products have been successfully imported.";
            return RedirectToAction(nameof(Index));
        }
    }
}

