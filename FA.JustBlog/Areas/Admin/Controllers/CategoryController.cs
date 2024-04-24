using FA.JustBlog.Repository.Infrastructures;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/{controller}")]
    public class CategoryController : Controller
    {
        private IUnitOfWork uow;

        public CategoryController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [Route("list-category")]
        public IActionResult Categories()
        {
            var result = uow.CategoryRepository.GetAllCategories();
            return View(result.ToList());
        }

        [Route("detail")]
        [HttpGet]
        public IActionResult Detail()
        {
            return View();
        }
        [Route("detail/{id}")]
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var result = uow.CategoryRepository.Find(id);
            return View(result);
        }

        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }
    }
}
