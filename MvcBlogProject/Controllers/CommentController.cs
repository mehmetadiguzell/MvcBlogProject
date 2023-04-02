using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        [AllowAnonymous]
        public PartialViewResult CommentList(int id)
        {
            var model = commentManager.CommentListByBlog(id);
            return PartialView(model);
        }
        [AllowAnonymous]
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.Id = id;
            return PartialView();
        }
        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult LeaveComment(Comment comment)
        {
            comment.CommentStatus = true;
            commentManager.TAdd(comment);
            return PartialView();
        }

        public ActionResult AdminCommentListStatusTrue()
        {
            var model = commentManager.CommentByStatusTrue();
            return View(model);
        }
        public ActionResult AdminCommentListStatusFalse()
        {
            var model = commentManager.CommentByStatusFalse();
            return View(model);
        }
        public ActionResult CommentStatusChangeFalse(int id)
        {
            commentManager.CommentStatusChangeToFalse(id);
            return RedirectToAction("AdminCommentListStatus");
        }
        public ActionResult CommentStatusChangeToTrue(int id)
        {
            commentManager.CommentStatusChangeTrue(id);
            return RedirectToAction("AdminCommentListStatus");
        }
    }
}