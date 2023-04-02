using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcBlogProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult AuthorLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthorLogin(Author author)
        {
            Context context = new Context();
            var model = context.Authors.FirstOrDefault(x => x.AuthorMail == author.AuthorMail && x.AuthorPassword == author.AuthorPassword);
            if (model != null)
            {
                FormsAuthentication.SetAuthCookie(model.AuthorMail, false);
                Session["AuthorMail"] = model.AuthorMail.ToString();
                return RedirectToAction("Index", "User");
            }
            return RedirectToAction("AuthorLogin", "Login");
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            Context context = new Context();
            var model = context.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (model != null)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, false);
                Session["UserName"] = model.UserName.ToString();
                return RedirectToAction("AdminBlogList", "Blog");
            }
            return RedirectToAction("AdminLogin", "Login");
        }

    }
}