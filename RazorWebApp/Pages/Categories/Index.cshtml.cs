using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWebApp.Data;
using RazorWebApp.Model;

namespace RazorWebApp.Pages.Categories
{
    public class IndexModel : PageModel
    {

        private readonly DbContextClass _dbclass;

        public IEnumerable<Category> categories { get; set; }
        public IndexModel(DbContextClass db)
        {
            _dbclass = db;
        }

        public void OnGet()
        {
            //reterive all list from database to the code
            categories = _dbclass.category;
             
        }
    }
}
