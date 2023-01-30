using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWebApp.Data;
using RazorWebApp.Model;

namespace RazorWebApp.Pages.Categories;

[BindProperties]
public class CreateModel : PageModel
{
    private readonly DbContextClass dbcon;
 
    public Category Category { get; set; }

    public CreateModel(DbContextClass db)
    {
        dbcon = db;
    }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost() {

        if (Category.Name == Category.DispalyOrder.ToString())
        {
            ModelState.AddModelError("Category.Name", "The Display Order cannot exzctly te same with Name ");
        }
        if (ModelState.IsValid) {

            await dbcon.category.AddAsync(Category);
            await dbcon.SaveChangesAsync();
            TempData["success"] = "Category Created Successfully";

            return RedirectToPage("Index");
        }

        return Page();
       
    }

}
