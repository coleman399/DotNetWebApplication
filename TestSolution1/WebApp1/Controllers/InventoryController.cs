using Microsoft.AspNetCore.Mvc;

namespace WebApp1.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;
        private readonly ICategoryService _categoryService;

        public InventoryController(IInventoryService inventoryService, ICategoryService categoryService)
        {
            _inventoryService = inventoryService;
            _categoryService = categoryService;
        }

        // GET: InventoryController/Create
        public ActionResult Create()
        {
            var result = _categoryService.Index();
            if (result.Success == false)
            {
                return NotFound();
            }
            List<Category> categories = new();
            foreach (var item in result.Data!)
            {
                categories.Add(item.Category!);
            }
            ViewBag.CategoryId = new SelectList(categories.Select(c => c.Id).ToList());
            return View();
        }

        // POST: InventoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddInventoryDto inventory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _inventoryService.Create(inventory);
                    if (result.Success == false)
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InventoryController
        public ActionResult Index()
        {
            var result = _inventoryService.Index();
            if (result.Success == false)
            {
                return NotFound();
            }
            List<Inventory> inventories = new();
            foreach (var item in result.Data!)
            {
                inventories.Add(item.Inventory!);
            }
            return View(inventories);
        }

        // GET: InventoryController/Details/5
        public ActionResult Details(int id)
        {
            var result = _inventoryService.Details(new DetailInventoryDto() { Id = id });
            if (result.Success == false)
            {
                return NotFound();
            }
            Inventory inventory = result.Data!.Inventory!;
            return View(inventory);
        }

        // GET: InventoryController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var indexResult = _categoryService.Index();
            if (indexResult.Success == false)
            {
                return NotFound();
            }
            List<Category> categories = new();
            foreach (var item in indexResult.Data!)
            {
                categories.Add(item.Category!);
            }
            ViewBag.CategoryId = new SelectList(categories.Select(c => c.Id).ToList());
            var editResult = _inventoryService.Edit(id);
            if (editResult.Success == false)
            {
                return NotFound();
            }
            Inventory inventory = editResult.Data!.Inventory!;
            return View(inventory);
        }

        // POST: InventoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(Inventory inventory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var updateInventoryDto = new UpdateInventoryDto
                    {
                        Id = inventory.Id,
                        Name = inventory.Name,
                        QuantityInStock = inventory.QuantityInStock,
                        QuantityOnOrder = inventory.QuantityOnOrder,
                        ReorderLevel = inventory.ReorderLevel,
                        ReorderQuantity = inventory.ReorderQuantity,
                        Discontinued = inventory.Discontinued,
                        CategoryId = inventory.CategoryId
                    };
                    var result = _inventoryService.EditPost(updateInventoryDto);
                    if (result.Success == false)
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InventoryController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = _inventoryService.Delete(id);
            if (result.Success == false)
            {
                return NotFound();
            }
            Inventory inventory = result.Data!.Inventory!;
            return View(inventory);
        }

        // POST: InventoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var result = _inventoryService.DeletePost(new DeleteInventoryDto() { Id = id });
                if (result.Success == false)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
