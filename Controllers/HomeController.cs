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
            //因列表頁不在INDEX，所以先將資料存到ViewData，再將ViewData透過PartialView傳到列表頁
            //PartialView本身好像不會觸發Controller的Action，所以無法直接在PartialView中呼叫Controller的Action
            var data = await _ledgerService.GetLedgersData();
            ViewData["LedgerData"] = data;
            return View(new LedgerCreateModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //防止跨網站偽造要求
        public async Task<IActionResult> Index(LedgerCreateModel model)
        {
            if (ModelState.IsValid)
            {
                //儲存檔案
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
