using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FashionStoreIS.Data;

namespace FashionStoreIS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnalyticsController : Controller
    {
        private readonly AnalyticsDbContext _analyticsDb;

        public AnalyticsController(AnalyticsDbContext analyticsDb)
        {
            _analyticsDb = analyticsDb;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ExportFactSales()
        {
            var data = await _analyticsDb.Fact_Sales
                .Include(f => f.DimProduct)
                .Include(f => f.DimDate)
                .Include(f => f.DimCustomer)
                .ToListAsync();

            var csv = new StringBuilder();
            csv.AppendLine("FactSalesId,Date,Product,Customer,OrderCode,Quantity,SalesAmount,DiscountAmount,COGS,GrossProfit");

            foreach (var item in data)
            {
                csv.AppendLine($"{item.FactSalesId},{item.DimDate?.Date:yyyy-MM-dd},{item.DimProduct?.ProductName.Replace(",", " ")},{item.DimCustomer?.FullName.Replace(",", " ")},{item.OrderCode},{item.Quantity},{item.SalesAmount},{item.DiscountAmount},{item.COGS},{item.GrossProfit}");
            }

            return File(Encoding.UTF8.GetBytes(csv.ToString()), "text/csv", "Fact_Sales_Export.csv");
        }

        [HttpGet]
        public async Task<IActionResult> ExportDimProducts()
        {
            var data = await _analyticsDb.Dim_Product.ToListAsync();
            var csv = new StringBuilder();
            csv.AppendLine("ProductSurrogateKey,ProductId,ProductName,CategoryName,Color,Size");

            foreach (var item in data)
            {
                csv.AppendLine($"{item.ProductSurrogateKey},{item.ProductId},{item.ProductName.Replace(",", " ")},{item.CategoryName.Replace(",", " ")},{item.Color},{item.Size}");
            }

            return File(Encoding.UTF8.GetBytes(csv.ToString()), "text/csv", "Dim_Products_Export.csv");
        }
    }
}
