namespace WebApp1.Models.InventoryModel
{
    public class InventoryServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; } = string.Empty;
    }
}
