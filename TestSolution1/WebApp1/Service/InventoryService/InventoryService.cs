namespace WebApp1.Service.InventoryService
{
    public class InventoryService : IInventoryService
    {
        private readonly InventoryDbContext _context;

        public InventoryService(InventoryDbContext context)
        {
            _context = context;
        }

        public InventoryServiceResponse<SelectList> Create()
        {
            var serviceResponse = new InventoryServiceResponse<SelectList>() { Data = null };
            try
            {
                var data = new SelectList(_context.Category.Select(c => c.Id).ToList());
                serviceResponse.Data = data;
                serviceResponse.Success = true;
                serviceResponse.Message = "Inventory data found successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public InventoryServiceResponse<GetInventoryDto> Create(AddInventoryDto addInventoryDto)
        {
            var serviceResponse = new InventoryServiceResponse<GetInventoryDto>() { Data = null };
            try
            {
                var inventory = new Inventory()
                {
                    Name = addInventoryDto.Name,
                    QuantityInStock = addInventoryDto.QuantityInStock,
                    QuantityOnOrder = addInventoryDto.QuantityOnOrder,
                    ReorderLevel = addInventoryDto.ReorderLevel,
                    ReorderQuantity = addInventoryDto.ReorderQuantity,
                    Discontinued = addInventoryDto.Discontinued,
                    CategoryId = addInventoryDto.CategoryId
                };
                _context.Inventory.Add(inventory);
                _context.SaveChanges();
                var data = new GetInventoryDto
                {
                    Inventory = inventory
                };
                serviceResponse.Data = data;
                serviceResponse.Success = true;
                serviceResponse.Message = "Inventory created successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public InventoryServiceResponse<List<GetInventoryDto>> Index()
        {
            var serviceResponse = new InventoryServiceResponse<List<GetInventoryDto>>() { Data = null };
            try
            {
                List<Inventory> inventoryList = _context.Inventory.ToList();
                List<GetInventoryDto> inventoryDtoList = new();
                foreach (var inventory in inventoryList)
                {
                    var data = new GetInventoryDto
                    {
                        Inventory = inventory
                    };
                    inventoryDtoList.Add(data);
                }
                serviceResponse.Data = inventoryDtoList;
                serviceResponse.Success = true;
                serviceResponse.Message = "Inventory data found successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public InventoryServiceResponse<GetInventoryDto> Details(DetailInventoryDto detailInventoryDto)
        {
            var serviceResponse = new InventoryServiceResponse<GetInventoryDto>() { Data = null };
            try
            {
                var inventory = _context.Inventory.FirstOrDefault(i => i.Id == detailInventoryDto.Id);
                var data = new GetInventoryDto
                {
                    Inventory = inventory
                };
                serviceResponse.Data = data;
                serviceResponse.Success = true;
                serviceResponse.Message = "Inventory data found successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public InventoryServiceResponse<GetInventoryDto> Edit(int? id)
        {
            var serviceResponse = new InventoryServiceResponse<GetInventoryDto>() { Data = null };
            try
            {
                var inventory = _context.Inventory.FirstOrDefault(i => i.Id == id);
                var data = new GetInventoryDto
                {
                    Inventory = inventory
                };
                serviceResponse.Data = data;
                serviceResponse.Success = true;
                serviceResponse.Message = "Inventory data found successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public InventoryServiceResponse<GetInventoryDto> EditPost(UpdateInventoryDto updateInventoryDto)
        {
            var serviceResponse = new InventoryServiceResponse<GetInventoryDto>() { Data = null };
            try
            {
                var inventory = _context.Inventory.FirstOrDefault(i => i.Id == updateInventoryDto.Id);
                inventory!.Name = updateInventoryDto.Name;
                inventory.QuantityInStock = updateInventoryDto.QuantityInStock;
                inventory.QuantityOnOrder = updateInventoryDto.QuantityOnOrder;
                inventory.ReorderLevel = updateInventoryDto.ReorderLevel;
                inventory.ReorderQuantity = updateInventoryDto.ReorderQuantity;
                inventory.Discontinued = updateInventoryDto.Discontinued;
                inventory.CategoryId = updateInventoryDto.CategoryId;
                _context.Inventory.Update(inventory);
                _context.SaveChanges();
                var data = new GetInventoryDto
                {
                    Inventory = inventory
                };
                serviceResponse.Data = data;
                serviceResponse.Success = true;
                serviceResponse.Message = "Inventory updated successfully";

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public InventoryServiceResponse<GetInventoryDto> Delete(int? id)
        {
            var serviceResponse = new InventoryServiceResponse<GetInventoryDto>() { Data = null };
            try
            {
                var inventory = _context.Inventory.FirstOrDefault(x => x.Id == id);
                var data = new GetInventoryDto
                {
                    Inventory = inventory
                };
                serviceResponse.Data = data;
                serviceResponse.Success = true;
                serviceResponse.Message = "Inventory data found successfully";

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public InventoryServiceResponse<GetInventoryDto> DeletePost(DeleteInventoryDto deleteInventoryDto)
        {
            var serviceResponse = new InventoryServiceResponse<GetInventoryDto>() { Data = null };
            try
            {
                _context.Inventory.Remove(_context.Inventory.FirstOrDefault(x => x.Id == deleteInventoryDto.Id)!);
                _context.SaveChanges();
                serviceResponse.Success = true;
                serviceResponse.Message = "Inventory deleted successfully";
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
