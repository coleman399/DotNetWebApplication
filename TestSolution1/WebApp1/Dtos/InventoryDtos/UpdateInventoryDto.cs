namespace WebApp1.Dtos.InventoryDtos
{
    public class UpdateInventoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int QuantityInStock { get; set; }
        public int QuantityOnOrder { get; set; }
        public int ReorderLevel { get; set; }
        public int ReorderQuantity { get; set; }
        public int Discontinued { get; set; }
        public int CategoryId { get; set; }
    }
}
