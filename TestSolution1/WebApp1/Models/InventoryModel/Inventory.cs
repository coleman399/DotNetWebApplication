using System.ComponentModel.DataAnnotations;
using WebApp1.Models.CategoryModel;

namespace WebApp1.Models.InventoryModel
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public int QuantityInStock { get; set; }
        public int QuantityOnOrder { get; set; }
        public int ReorderLevel { get; set; }
        public int ReorderQuantity { get; set; }
        public int Discontinued { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }


        public Inventory()
        {
            QuantityInStock = 0;
            QuantityOnOrder = 0;
            ReorderLevel = 0;
            ReorderQuantity = 0;
            Discontinued = 0;
            CategoryId = 0;
        }

        public Inventory(string name, int quantityInStock, int quantityOnOrder, int reorderLevel, int reorderQuantity, int discontinued, int categoryId)
        {
            Name = name;
            QuantityInStock = quantityInStock;
            QuantityOnOrder = quantityOnOrder;
            ReorderLevel = reorderLevel;
            ReorderQuantity = reorderQuantity;
            Discontinued = discontinued;
            CategoryId = categoryId;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, QuantityInStock: {QuantityInStock}, QuantityOnOrder: {QuantityOnOrder}, ReorderLevel: {ReorderLevel}, ReorderQuantity: {ReorderQuantity}, Discontinued: {Discontinued}, CategoryId: {CategoryId}";
        }
    }
}
