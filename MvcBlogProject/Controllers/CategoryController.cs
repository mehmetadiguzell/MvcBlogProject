using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategoryList()
        {
            var model = categoryManager.GetList();
            return PartialView(model);
        }
        public ActionResult AdminCategoryList()
        {
            var model = categoryManager.GetList();
            return View(model);
        }
        public ActionResult AdminCategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminCategoryAdd(Category category)
        {
                categoryManager.TAdd(category);
                return RedirectToAction("AdminCategoryList");
        }
        public ActionResult CategoryEdit(int id = 1)
        {
            var model = categoryManager.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult CategoryEdit(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(category);
            if (result.IsValid)
            {
                categoryManager.TUpdate(category);
                return RedirectToAction("AdminCategoryList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteCategory(int id = 1)
        {
            var model = categoryManager.GetById(id);
            categoryManager.TDelete(model);
            return RedirectToAction("AdminCategoryList");
        }
        public ActionResult StatusTrue(int id = 1)
        {
            categoryManager.StatusChangeTrue(id);
            return RedirectToAction("AdminCategoryList");
        }
    }
}