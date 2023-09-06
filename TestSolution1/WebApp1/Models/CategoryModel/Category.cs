using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models.CategoryModel
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        public Category()
        {
        }

        public Category(string name)
        {
            Name = name;
        }
    }
}