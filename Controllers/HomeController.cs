using System.Diagnostics;
using Homework_SkillTree.Models;
using Homework_SkillTree.Service;
using Microsoft.AspNetCore.Mvc;

namespace Homework_SkillTree.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LedgerService _ledgerService;

        public HomeController(ILogger<HomeController> logger, LedgerService ledgerService)
        {
            _logger = logger;
            _ledgerService = ledgerService;
        }

        public async Task<IActionResult> Index()
        {
            //�]�C�����bINDEX�A�ҥH���N��Ʀs��ViewData�A�A�NViewData�z�LPartialView�Ǩ�C��
            //PartialView�����n�����|Ĳ�oController��Action�A�ҥH�L�k�����bPartialView���I�sController��Action
            var data = await _ledgerService.GetLedgersData();
            ViewData["LedgerData"] = data;
            return View(new LedgerCreateModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //�����������y�n�D
        public async Task<IActionResult> Index(LedgerCreateModel model)
        {
            if (ModelState.IsValid)
            {
                //�x�s�ɮ�
                await _ledgerService.SaveLedgersData(model);             
            }
            return RedirectToAction("Index");
        }

        public IActionResult DataList()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
