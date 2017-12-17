using System.IO;
using System.Web.Mvc;

namespace SimpleProject.Controllers
{
    public class BaseController : Controller
    {
        protected virtual JsonResult JsonNetResult(string ErrorMessage, bool IsSuccess, object item, string view, JsonRequestBehavior behavior)
        {
            return Json(new { IsSuccess = IsSuccess, ErrorMessage = ErrorMessage, body = RenderRazorViewToString(view, item)}, behavior);
        }

        protected virtual string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext,viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View,ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}