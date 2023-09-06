namespace WebApp1.Service.InventoryService
{
    public interface IInventoryService
    {
        InventoryServiceResponse<SelectList> Create();
        InventoryServiceResponse<GetInventoryDto> Create(AddInventoryDto addInventoryDto);
        InventoryServiceResponse<List<GetInventoryDto>> Index();
        InventoryServiceResponse<GetInventoryDto> Details(DetailInventoryDto detailInventoryDto);
        InventoryServiceResponse<GetInventoryDto> Edit(int? id);
        InventoryServiceResponse<GetInventoryDto> EditPost(UpdateInventoryDto updateInventoryDto);
        InventoryServiceResponse<GetInventoryDto> Delete(int? id);
        InventoryServiceResponse<GetInventoryDto> DeletePost(DeleteInventoryDto deleteInventoryDto);

    }
}
