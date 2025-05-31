using FinanceApp.Models;
namespace FinanceApp.Data.Services
{
    public interface IExpensesService
    {
        Task<IEnumerable<Expense>> GetAll();
        Task Add(Expense expense);

        IQueryable GetChartData();
    }
}
