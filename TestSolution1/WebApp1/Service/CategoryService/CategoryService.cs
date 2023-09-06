namespace WebApp1.Service.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly InventoryDbContext _context;

        public CategoryService(InventoryDbContext context)
        {
            _context = context;
        }

        public CategoryServiceResponse<List<GetCategoryDto>> Index()
        {
            var serviceResponse = new CategoryServiceResponse<List<GetCategoryDto>>() { Data = null };
            try
            {
                List<GetCategoryDto> categoryList = new();
                var categories = _context.Category.ToList();
                foreach (var category in categories)
                {
                    categoryList.Add(new GetCategoryDto
                    {
                        Category = category
                    });
                }
                serviceResponse.Success = true;
                serviceResponse.Data = categoryList;
                serviceResponse.Message = "Category list retrieved successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public CategoryServiceResponse<GetCategoryDto> Details(int? id)
        {
            var serviceResponse = new CategoryServiceResponse<GetCategoryDto>();
            try
            {
                var category = _context.Category.FirstOrDefault(c => c.Id == id);
                var data = new GetCategoryDto
                {
                    Category = category!
                };
                serviceResponse.Data = data;
                serviceResponse.Success = true;
                serviceResponse.Message = "Category data found successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public CategoryServiceResponse<GetCategoryDto> Create(AddCategoryDto addCategoryDto)
        {
            var serviceResponse = new CategoryServiceResponse<GetCategoryDto>() { Data = null };
            try
            {
                var category = new Category
                {
                    Id = addCategoryDto.Id,
                    Name = addCategoryDto.Name
                };
                _context.Category.Add(category);
                _context.SaveChanges();
                var data = new GetCategoryDto
                {
                    Category = category
                };
                serviceResponse.Data = data;
                serviceResponse.Success = true;
                serviceResponse.Message = "Category created successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public CategoryServiceResponse<GetCategoryDto> Edit(int? id)
        {
            var serviceResponse = new CategoryServiceResponse<GetCategoryDto>() { Data = null };
            try
            {
                var category = _context.Category.FirstOrDefault(c => c.Id == id);
                var data = new GetCategoryDto
                {
                    Category = category!
                };
                serviceResponse.Data = data;
                serviceResponse.Success = true;
                serviceResponse.Message = "Category data found successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public CategoryServiceResponse<GetCategoryDto> Edit(UpdateCategoryDto updateCategoryDto)
        {
            var serviceResponse = new CategoryServiceResponse<GetCategoryDto>() { Data = null };
            try
            {
                var category = _context.Category.FirstOrDefault(c => c.Id == updateCategoryDto.Id);
                category!.Name = updateCategoryDto.Name;
                _context.Category.Update(category);
                _context.SaveChanges();
                var data = new GetCategoryDto
                {
                    Category = category
                };
                serviceResponse.Data = data;
                serviceResponse.Success = true;
                serviceResponse.Message = "Category updated successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public CategoryServiceResponse<GetCategoryDto> Delete(int? id)
        {
            var serviceResponse = new CategoryServiceResponse<GetCategoryDto>() { Data = null };
            try
            {
                var category = _context.Category.FirstOrDefault(c => c.Id == id);
                var data = new GetCategoryDto
                {
                    Category = category!
                };
                serviceResponse.Data = data;
                serviceResponse.Success = true;
                serviceResponse.Message = "Category data found successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public CategoryServiceResponse<GetCategoryDto> Delete(DeleteCategoryDto deleteCategoryDto)
        {
            var serviceResponse = new CategoryServiceResponse<GetCategoryDto>() { Data = null };
            try
            {
                _context.Category.Remove(_context.Category.FirstOrDefault(x => x.Id == deleteCategoryDto.Id)!);
                _context.SaveChanges();
                serviceResponse.Success = true;
                serviceResponse.Message = "Category deleted successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
