using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWebApp.Data;
using RazorWebApp.Model;

namespace RazorWebApp.Pages.Categories;

[BindProperties]
public class editModel : PageModel
{
    private readonly DbContextClass dbcon;
 
    public Category Category { get; set; }

    public editModel(DbContextClass db)
    {
        dbcon = db;
    }
    public void OnGet(int id)
    {

        Category = dbcon.category.Find(id);
        //Category = dbcon.category.SingleOrDefault(u=>u.Id == id);
        //Category = dbcon.category.FirstOrDefault(u => u.Id = id);
        //Category = dbcon.category.Where(u => u.Id == id).FirstOrDefault();
    }

    public async Task<IActionResult> OnPost() {

        if (Category.Name == Category.DispalyOrder.ToString())
        {
            ModelState.AddModelError("Category.Name", "The Display Order cannot exzctly te same with Name ");
        }
        if (ModelState.IsValid) {
            
            //update automatically bsae on primary key 
            dbcon.category.Update(Category);
            await dbcon.SaveChangesAsync();
            TempData["success"] = "Category Edited Successfully";
            return RedirectToPage("Index");
        }

        return Page();
       
    }

}
