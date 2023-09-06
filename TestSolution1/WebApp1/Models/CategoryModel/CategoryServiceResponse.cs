namespace WebApp1.Models.CategoryModel
{
    public class CategoryServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; } = string.Empty;
    }
}
