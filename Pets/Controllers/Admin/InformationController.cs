using Microsoft.AspNetCore.Mvc;
using Pet.Database.Models;
using WEB.Dal.Models.Admin;
using WEB.Dal.Services;

namespace Pets.Controllers.Admin
{
    [Route("/Admin/Information")]
    public class InformationController : Controller
    {
        private BaseInformationService baseservice;
        private ColorService colorService;
        public InformationController(BaseInformationService baseservice, ColorService colorService)
        {
            this.baseservice = baseservice;
            this.colorService = colorService;
        }
        [Route("/Admin/Information")]
        public IActionResult Index()
        {
            List<BaseInformation> information = baseservice.GetInformation();
            return View("~/Views/Admin/Information/Index.cshtml", information);
        }

        [HttpGet]
        [Route("/Admin/Information/Create")]
        public IActionResult Create()
        {
            BaseInformationEditViewModel information = new BaseInformationEditViewModel() ;
            information.Colors = colorService.GetColors();
            return View("~/Views/Admin/Information/Create.cshtml", information);
        }
        [HttpPost]
        [Route("/Admin/information/Create")]
        public async Task<IActionResult> Create(BaseInformationEditViewModel info)
        {
            string filePath = "no-image.png";
            if (info.MainImage != null)
            {
                filePath = await UploadFile(info.MainImage);
            }

            BaseInformation newPet = new BaseInformation
            {
                Name = info.Name,
                Age=info.Age,

                MainImage = filePath,
                ColorId = info.ColorId,
                Weight=info.Weight,
                Gender=info.Gender

            };
            baseservice.Create(newPet);
            return Redirect("/Admin/Information");
        }
        [HttpGet]
        [Route("/Admin/Information/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            BaseInformationEditViewModel model = new BaseInformationEditViewModel();
           // model.Categories = service.GetCategories();
           // model.SelectedCategory = service.GetCategoryById(id);
            return View("~/Views/Admin/Information/Edit.cshtml", model);
        }
        [HttpPost]
        [Route("/Admin/Information/Edit/{id}")]
        public async Task<IActionResult> Edit(int id, BaseInformationEditViewModel info)
        {
            string filePath = "no-image.png";
            if (info.MainImage != null)
            {
                filePath = await UploadFile(info.MainImage);
            }

              BaseInformation newinfo = new BaseInformation
            {
               Name = info.Name,
               Age=info.Age,

               MainImage = filePath,
               ColorId = info.ColorId,
               Weight=info.Weight,
               Gender=info.Gender

             };
            baseservice.Update(id,newinfo);
            return Redirect("/Admin/Information");
        }
        [HttpGet]
        [Route("/Admin/Information/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            baseservice.Delete(id);
            return Redirect("/Admin/Information");
        }

        private async Task<string> UploadFile(IFormFile file)
        {
            var uniqueFileName = Guid.NewGuid() + "-" + file.FileName;
            var filePath = Path.Combine("wwwroot", "images", uniqueFileName);

            using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }

            return uniqueFileName;
        }

    }
}
