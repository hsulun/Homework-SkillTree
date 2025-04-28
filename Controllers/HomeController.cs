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
            var data = await _ledgerService.GetLedgersData();
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Index(LedgerCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                //儲存檔案
                await _ledgerService.SaveLedgersData(model);
                return RedirectToAction("Index");
            }
            //如果驗證失敗，回到頁面
            var data = await _ledgerService.GetLedgersData();
            ViewData["LedgerCreateViewModel"] = model;
            return View("Index", data);
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
