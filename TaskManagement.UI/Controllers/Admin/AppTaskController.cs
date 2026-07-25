using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskManagement.Application.Requests;

namespace TaskManagement.UI.Controllers.Admin
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AppTaskController : Controller
    {
        private readonly IMediator mediator;

        public AppTaskController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> List(string? s, int activePage = 1)
        {
            ViewBag.s = s;
            ViewBag.Active = "AppTask";
            var result = await this.mediator.Send(new AppTaskListRequest(activePage, s));
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            var result = await this.mediator.Send(new PriorityListRequest());

            ViewBag.Priorities = new List<SelectListItem>(result.Data.Select(x => new SelectListItem(x.Definition, x.Id.ToString())));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppTaskCreateRequest request)
        {
            var result = await this.mediator.Send(request);


            ViewBag.Priorities = new List<SelectListItem>(result.Data.Priorities.Select(x => new SelectListItem(x.Definition, x.Id.ToString())));
            if (result.IsSuccess)
            {
                return RedirectToAction("List");
            }
            else
            {
                if (result.Errors?.Count > 0)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }
                else
                {
                    ModelState.AddModelError("", result.ErrorMessage ?? "Sistemsel bir hata oluştu, üreticinize başvurun");
                }
            }
            return View(request);
        }

        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.Active = "AppTask";
            var result = await this.mediator.Send(new AppTaskDeleteRequest(id));
            return RedirectToAction("List");
        }

        public async Task<IActionResult> Update(int id)
        {
            var updated = await this.mediator.Send(new AppTaskGetByIdRequest(id));
            var priorityResult = await this.mediator.Send(new PriorityListRequest());
            var memberListResult = await this.mediator.Send(new MemberListRequest());


            ViewBag.Priorities = new List<SelectListItem>(priorityResult.Data.Select(x => new SelectListItem(x.Definition, x.Id.ToString(), updated.Data.PriorityId == x.Id)));
            var members = new List<SelectListItem>(memberListResult.Data.Select(x => new SelectListItem(x.Name + " " + x.Surname, x.Id.ToString(), updated.Data.AppUserId == x.Id)));

            if (updated.Data.AppUserId == null)
            {
                members.Add(new SelectListItem("Personel Seçilmemiş", "0", true));
            }

            ViewBag.Members = members;
            return View(new AppTaskUpdateRequest(updated.Data.Id, updated.Data.Title, updated.Data.Description, updated.Data.PriorityId, updated.Data.AppUserId, updated.Data.Latitude, updated.Data.Longitude));
        }

        [HttpPost]
        public async Task<IActionResult> Update(AppTaskUpdateRequest request)
        {
            var result = await this.mediator.Send(request);

            ViewBag.Priorities = new List<SelectListItem>(result.Data.Priorities.Select(x => new SelectListItem(x.Definition, x.Id.ToString(), x.Id == request.PriorityId)));
            ViewBag.Members = new List<SelectListItem>(result.Data.Employees.Select(x => new SelectListItem(x.Name + " " + x.Surname, x.Id.ToString(), x.Id == request.AppUserId)));
            if (result.IsSuccess)
            {
                return RedirectToAction("List");
            }
            else
            {
                if (result.Errors?.Count > 0)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }
                else
                {
                    ModelState.AddModelError("", result.ErrorMessage ?? "Sistemsel bir hata oluştu, üreticinize başvurun");
                }
            }
            return View(request);
        }

        [HttpPost]
        public IActionResult PredictPriority([FromBody] string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                return Json(new { success = false, message = "Lütfen önce açıklama giriniz." });
            }

            string text = description.ToLower();

            int predictedPriorityId = 4;
            string aiMessage = "Metin analiz edildi. Standart bir işlem algılandı, öncelik 'Normal' atandı.";

            string[] cokAcilKeywords = { "tehlike", "çökme", "kaza", "yangın", "kriz", "patlama", "yaralı" };

            string[] acilKeywords = { "acil", "hemen", "patlak", "arıza", "sızıntı", "kopuk" };

            if (cokAcilKeywords.Any(keyword => text.Contains(keyword)))
            {
                predictedPriorityId = 1; 
                aiMessage = "Kritik tehlike kelimeleri algılandı. Öncelik 'Çok Acil' olarak belirlendi.";
            }
            else if (acilKeywords.Any(keyword => text.Contains(keyword)))
            {
                predictedPriorityId = 2; 
                aiMessage = "Aciliyet bildiren kelimeler algılandı. Öncelik 'Acil' olarak belirlendi.";
            }

            return Json(new { success = true, priorityId = predictedPriorityId, message = aiMessage });
        }
    }
}