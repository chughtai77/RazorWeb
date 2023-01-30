using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWebApp.Data;
using RazorWebApp.Model;

namespace RazorWebApp.Pages.Categories;

[BindProperties]
public class deleteModel : PageModel
{
    private readonly DbContextClass dbcon;
 
    public Category Category { get; set; }

    public deleteModel(DbContextClass db)
    {
        dbcon = db;
    }
    public void OnGet(int id)
    {
        //query which gets data from db and show on html

        Category = dbcon.category.Find(id);
        //Category = dbcon.category.SingleOrDefault(u=>u.Id == id);
        //Category = dbcon.category.FirstOrDefault(u => u.Id = id);
        //Category = dbcon.category.Where(u => u.Id == id).FirstOrDefault();
    }

    public async Task<IActionResult> OnPost() {

      

            var dbcategory = dbcon.category.Find(Category.Id);
            if (dbcategory != null) {
                dbcon.category.Remove(dbcategory);
                await dbcon.SaveChangesAsync();
                TempData["success"] = "Category Deleted Successfully";
                return RedirectToPage("Index");
            }
        

        return Page();
       
    }

}
