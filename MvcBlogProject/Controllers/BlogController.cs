using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            var blogbycategory = blogManager.GetBlogByCategory(id);
            var CategoryName = blogManager.GetBlogById(id).Select(x => x.Category.CategoryName).FirstOrDefault(); ;
            var CategoryDescription = blogManager.GetBlogById(id).Select(x => x.Category.CategoryDescription).FirstOrDefault(); ;
            ViewBag.categoryName = CategoryName;
            ViewBag.categoryDescription = CategoryDescription;
            return View(blogbycategory);
        }
        [AllowAnonymous]
        public PartialViewResult BlogList(int page = 1)
        {
            var model = blogManager.GetList().ToPagedList(page, 6);
            return PartialView(model);
        }
        [AllowAnonymous]
        public PartialViewResult FeaturedPost()
        {
            //1.Post
            var posttitle1 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage1 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogImage).FirstOrDefault();
            var postdate1 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogDate).FirstOrDefault();
            ViewBag.PostTitle1 = posttitle1;
            ViewBag.BlogImage1 = postimage1;
            ViewBag.Postdate1 = postdate1;
            var blogPostId1 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogId).FirstOrDefault();
            ViewBag.blogPostId1 = blogPostId1;

            //2.Post
            var posttitle2 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage2 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2).Select(y => y.BlogImage).FirstOrDefault();
            var postdate2 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2).Select(y => y.BlogDate).FirstOrDefault();
            ViewBag.PostTitle2 = posttitle2;
            ViewBag.BlogImage2 = postimage2;
            ViewBag.Postdate2 = postdate2;
            var blogPostId2 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 2).Select(y => y.BlogId).FirstOrDefault();
            ViewBag.blogPostId2 = blogPostId2;

            //3.Post
            var posttitle3 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage3 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogImage).FirstOrDefault();
            var postdate3 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogDate).FirstOrDefault();
            ViewBag.PostTitle3 = posttitle3;
            ViewBag.BlogImage3 = postimage3;
            ViewBag.Postdate3 = postdate3;
            var blogPostId3 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogId).FirstOrDefault();
            ViewBag.blogPostId3 = blogPostId3;

            //4.Post
            var posttitle4 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage4 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogImage).FirstOrDefault();
            var postdate4 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogDate).FirstOrDefault();
            ViewBag.PostTitle4 = posttitle4;
            ViewBag.BlogImage4 = postimage4;
            ViewBag.Postdate4 = postdate4;
            var blogPostId4 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogId).FirstOrDefault();
            ViewBag.blogPostId4 = blogPostId3;

            //5.Post
            var posttitle5 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 5).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage5 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 5).Select(y => y.BlogImage).FirstOrDefault();
            var postdate5 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 5).Select(y => y.BlogDate).FirstOrDefault();
            ViewBag.PostTitle5 = posttitle5;
            ViewBag.BlogImage5 = postimage5;
            ViewBag.Postdate5 = postdate5;
            var blogPostId5 = blogManager.GetList().OrderByDescending(z => z.BlogId).Where(x => x.CategoryId == 5).Select(y => y.BlogId).FirstOrDefault();
            ViewBag.blogPostId5 = blogPostId5;

            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult OtherFeaturedPost()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult Footer()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public ActionResult BlogDetails()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogCover(int id = 0)
        {
            var blogdetails = blogManager.GetById(id);
            return PartialView(blogdetails);
        }
        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id = 0)
        {
            var blogdetails = blogManager.GetById(id);
            return PartialView(blogdetails);
        }
        
        public ActionResult AdminBlogList()
        {
            var model = blogManager.GetList();
            return View(model);
        }
        public ActionResult AdminBlogList2()
        {
            var model = blogManager.GetList();
            return View(model);
        }
        [Authorize(Roles ="A")]
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
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult DeleteBlog(int id)
        {
            var model=blogManager.GetById(id);
            blogManager.TDelete(model);
            return RedirectToAction("AdminBlogList");
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
            return RedirectToAction("AdminBlogList");
        }

        public ActionResult GetCommentByBlog(int id)
        {
            CommentManager commentManager = new CommentManager(new EfCommentDal());
            var commentlist = commentManager.CommentListByBlog(id);
            return View(commentlist);
        }
        public ActionResult AuthorBlogList(int id)
        {
            var blogs=blogManager.GetBlogByAuthor(id);
            return View(blogs);
        }
    }
}