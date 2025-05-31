using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinanceApp.Data;
using FinanceApp.Models;
using FinanceApp.Data.Services;

namespace FinanceApp.Controllers
{
    public class ExpensesController : Controller
    {
        public readonly IExpensesService _expenseService;
        public ExpensesController(IExpensesService context)
        {
            _expenseService = context;
        }
        public async Task<IActionResult> Index()
        {
            var expenses = await _expenseService.GetAll();
            return View(expenses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (ModelState.IsValid)
            {

                await _expenseService.Add(expense);
                return RedirectToAction("Index");
            }
            return View();
        }

        
        public IActionResult GetChartData()
        {
            var data = _expenseService.GetChartData();
            return Json(data);
        }
    }
}
