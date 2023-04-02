using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers
{
    [AllowAnonymous]
    public class MailSubscribeController : Controller
    {
        // GET: MailSubscribe
        SubscribeMailManager mailManager = new SubscribeMailManager(new EfSubscribeMailDal());
        public PartialViewResult AddMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult AddMail(SubscribeMail subscribeMail)
        {
            mailManager.TAdd(subscribeMail);
            return PartialView();
        }

    }
}