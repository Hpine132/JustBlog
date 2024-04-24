using FA.JustBlog.Repository.Infrastructures;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly IUnitOfWork uow;
        public PostController(IUnitOfWork unitOfWork)
        {
            this.uow = unitOfWork;
        }
        public IActionResult Index()
        {
            var posts = uow.PostRepository.GetAllPosts().ToList();
            return View(posts);
        }

        [Route("Post/{year}/{month}/{title}")]
        public IActionResult Detail(string title, int year, int month)
        {
            var result = uow.PostRepository.FindPost(year, month, title);
            return View(result);
        }

        [Route("Post/Category/{name}")]
        public IActionResult GetPostsByCategory(string name)
        {
            ViewBag.CategoryName = name;
            var result = uow.PostRepository.GetPostsByCategory(name);
            return View(result);
        }
        public IActionResult GetLatestPost()
        {
            var result = uow.PostRepository.GetLatestPost();
            return View(result);
        }
    }
}
