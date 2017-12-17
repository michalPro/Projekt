using SimpleProject.Contract;
using SimpleProject.Contract.DataContracts;
using SimpleProject.Contract.Service;
using System.Web.Mvc;

namespace SimpleProject.Controllers
{
    public class CarController : BaseController
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var result = _carService.GetAll();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddEdit(int? id)
        {
            if (id.HasValue)
            {
                var result = _carService.GetById(id.Value);

                ViewBag.Action = "Edycja";

                return JsonNetResult(result.ErrorMessage, result.IsSuccess, result.Item, "AddEdit", JsonRequestBehavior.AllowGet);
            }

            ViewBag.Action = "Dodawanie";

            return JsonNetResult(string.Empty, true, new CarDto(), "AddEdit", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddEdit(CarDto model)
        {
            CommonResult result = null;
            if (model.Id == 0)
                result = _carService.Add(model);
            else
                result = _carService.Edit(model);

            return Json(result);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return JsonNetResult(string.Empty, true, new CarDto { Id = id }, "Delete", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            return Json(_carService.Delete(id));
        }

    }
}