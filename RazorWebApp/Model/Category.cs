using System.ComponentModel.DataAnnotations;

namespace RazorWebApp.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Display(Name="Display Order")]
        [Range(1,100,ErrorMessage="Display Order Must be in Range 1 to 100!!!")]
        public String DispalyOrder { get; set; }
    }
}
