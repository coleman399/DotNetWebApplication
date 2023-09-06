using Microsoft.AspNetCore.Mvc;

namespace WebApp1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: CategoryController
        public ActionResult Index()
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
            return View(categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = _categoryService.Details(id);
            if (result.Success == false)
            {
                return NotFound();
            }
            Category category = result.Data!.Category!;
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var categoryDto = new AddCategoryDto()
                    {
                        Id = category.Id,
                        Name = category.Name
                    };
                    var result = _categoryService.Create(categoryDto);
                    if (result.Success == false)
                    {
                        return NotFound();
                    };
                };
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            };
            var result = _categoryService.Edit(id);
            if (result.Success == false)
            {
                return NotFound();
            };
            Category category = result.Data!.Category!;
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var updateCategoryDto = new UpdateCategoryDto()
                    {
                        Id = category.Id,
                        Name = category.Name
                    };
                    var result = _categoryService.Edit(updateCategoryDto);
                    if (result.Success == false)
                    {
                        return NotFound();
                    };
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var result = _categoryService.Delete(id);
            if (result.Success == false)
            {
                return NotFound();
            }
            Category category = result.Data!.Category!;
            return View(category);
        }

        // POST: CategoryController/Delete/5
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
                var result = _categoryService.Delete(new DeleteCategoryDto() { Id = id });
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
