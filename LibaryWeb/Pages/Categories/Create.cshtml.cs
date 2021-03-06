using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibaryWeb.Model;
using LibaryWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibaryWeb.Pages.Categories;


public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _db;
    [BindProperty]
    public Category Category { get; set; }

    public CreateModel(ApplicationDbContext db)
    {
        _db = db;
    }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {

        if (ModelState.IsValid)
        {
            await _db.Category.AddAsync(Category);
            await _db.SaveChangesAsync();
            TempData["success"] = "Book added succesfully";
            return RedirectToPage("Index");
        }
        return Page();
    }
}
