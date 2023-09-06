namespace WebApp1.Service.CategoryService
{
    public interface ICategoryService
    {
        CategoryServiceResponse<List<GetCategoryDto>> Index();
        CategoryServiceResponse<GetCategoryDto> Details(int? id);
        CategoryServiceResponse<GetCategoryDto> Create(AddCategoryDto addCategoryDto);
        CategoryServiceResponse<GetCategoryDto> Edit(int? id);
        CategoryServiceResponse<GetCategoryDto> Edit(UpdateCategoryDto updateCategoryDto);
        CategoryServiceResponse<GetCategoryDto> Delete(int? id);
        CategoryServiceResponse<GetCategoryDto> Delete(DeleteCategoryDto deleteCategoryDto);
    }
}
