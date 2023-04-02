using DataAccessLayer.Concrete;
using MvcBlogProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeResult()
        {
            return Json(categoryList(), JsonRequestBehavior.AllowGet);
        }
        public List<Class1> categoryList()
        {
            List<Class1> classes = new List<Class1>();
            classes.Add(new Class1()
            {
                CategoryName = "Teknoloji",
                BlogCount = 14
            });
            classes.Add(new Class1()
            {
                CategoryName = "Spor",
                BlogCount = 10
            });
            classes.Add(new Class1()
            {
                CategoryName = "Kitap",
                BlogCount = 16
            });
            return classes;
        }
        public List<Class2> BlogList()
        {
            List<Class2> classes = new List<Class2>();
            using (Context context = new Context())
            {
                var model = context.Blogs.Select(x => new Class2()
                {
                    BlogName = x.BlogTitle,
                    BlogRating = x.BlogRating
                }).ToList();
                return model;
            }
        }
        public ActionResult VisualizeResult2()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Chart1()
        {
            return View();
        }
        public ActionResult Chart2()
        {
            return View();
        }
        public ActionResult Chart3()
        {
            return View();
        }
    }
}