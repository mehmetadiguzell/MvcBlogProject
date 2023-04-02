using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contactManager = new ContactManager(new EfContactDal());
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult SendMessage()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult SendMessage(Contact contact)
        {
            contact.MessageDate = System.DateTime.Now;
            contactManager.TAdd(contact);
            return View();
        }
        public ActionResult SendBox()
        {
            var model = contactManager.GetList();
            return View(model);
        }
        public ActionResult MessageDetails(int id = 1)
        {
            var model = contactManager.GetByIdMessageDetails(id);
            return View(model);
        }
    }
}