using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        // GET: About
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        AuthorManager authorManager = new AuthorManager(new EfAuthorDal());
        public ActionResult Index()
        {
            var model = aboutManager.GetList();
            return View(model);
        }
        public PartialViewResult Footer()
        {
            var model = aboutManager.GetList();
            return PartialView(model);
        }
        public PartialViewResult MeetTheTeam()
        {
            var model = authorManager.GetList();
            return PartialView(model);
        }
        public ActionResult UpdateAboutList()
        {
            var model = aboutManager.GetList();
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            aboutManager.TUpdate(about);
            return RedirectToAction("UpdateAboutList");
        }
    }
}