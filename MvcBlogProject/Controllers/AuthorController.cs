using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Linq;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        AuthorManager authorManager = new AuthorManager(new EfAuthorDal());
        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authordetails = blogManager.GetBlogById(id);
            return PartialView(authordetails);
        }
        [AllowAnonymous]
        public PartialViewResult AuthorPopularPosts(int id)
        {
            var authorıd = blogManager.GetList().Where(x => x.BlogId == id).Select(y => y.AuthorId).FirstOrDefault();
            var model = blogManager.GetBlogByAuthor(authorıd);
            return PartialView(model);
        }
        public ActionResult AuthorList()
        {
            var model = authorManager.GetList();
            return View(model);
        }
        public ActionResult AuthorAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthorAdd(Author author)
        {
            authorManager.TAdd(author);
            return RedirectToAction("AuthorList");
        }
        public ActionResult AuthorEdit(int id = 1)
        {
            var model = authorManager.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult AuthorEdit(Author author)
        {
            authorManager.TUpdate(author);
            return RedirectToAction("AuthorList");
        }
    }
}