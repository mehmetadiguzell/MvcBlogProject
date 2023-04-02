using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcBlogProject.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: AuthorLogin
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        UserProfilManager userProfilManager = new UserProfilManager();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Partial1(string userMAil)
        {
            userMAil = (string)Session["AuthorMail"];
            var model = userProfilManager.GetAuthorByMail(userMAil);
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult UpdateUserProfile(Author author)
        {
            userProfilManager.EditAuthor(author);
            return RedirectToAction("Index");
        }
        public ActionResult BlogList(string user)
        {
            Context context = new Context();
            user = (string)Session["AuthorMail"];
            int id = context.Authors.Where(x => x.AuthorMail == user).Select(y => y.AuthorId).FirstOrDefault();
            var blogs = userProfilManager.GetAuthorByAuthor(id);
            return View(blogs);
        }
        public ActionResult UpdateBlog(int id)
        {
            Context context = new Context();
            List<SelectListItem> categoryList = (from x in context.Categories.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.CategoryList = categoryList;

            List<SelectListItem> authorList = (from x in context.Authors.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.AuthorName,
                                                   Value = x.AuthorId.ToString()
                                               }).ToList();
            ViewBag.AuthorList = authorList;
            var model = blogManager.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog blog)
        {
            blogManager.TUpdate(blog);
            return RedirectToAction("BlogList");
        }
        public ActionResult AddNewBlog()
        {
            Context context = new Context();
            List<SelectListItem> categoryList = (from x in context.Categories.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.CategoryList = categoryList;

            List<SelectListItem> authorList = (from x in context.Authors.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.AuthorName,
                                                   Value = x.AuthorId.ToString()
                                               }).ToList();
            ViewBag.AuthorList = authorList;

            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog blog)
        {
            blogManager.TAdd(blog);
            return RedirectToAction("BlogList");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("AuthorLogin", "Login");
        }
    }
}