using FashionStoreIS.Areas.Admin.ViewModels.Executive;
using FashionStoreIS.Models;
using FashionStoreIS.Models.Executive;
using FashionStoreIS.Services;
using FashionStoreIS.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace FashionStoreIS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Executive,CEO,CFO,CMO,COO,BoardMember")]
    public class ExecutiveController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IStrategicAnalyticsService _strategicAnalytics;
        private readonly IExternalDataIntegrationService _externalData;

        public ExecutiveController(
            ApplicationDbContext db,
            UserManager<ApplicationUser> userManager,
            IStrategicAnalyticsService strategicAnalytics,
            IExternalDataIntegrationService externalData)
        {
            _db = db;
            _userManager = userManager;
            _strategicAnalytics = strategicAnalytics;
            _externalData = externalData;
        }

        // ─── Executive Strategic Dashboard ─────────────────────────────────────

        public async Task<IActionResult> Index()
        {
            var model = new ExecutiveDashboardViewModel
            {
                FinancialKpis = await _strategicAnalytics.GetFinancialKpis(),
                MarketMetrics = await _strategicAnalytics.GetMarketMetrics(),
                OperationalMetrics = await _strategicAnalytics.GetOperationalMetrics(),
                PredictiveInsights = await _strategicAnalytics.GetPredictiveInsights(),
                CompetitiveIntelligence = await _externalData.GetCompetitiveIntelligence(),
                ExecutiveAlerts = await _strategicAnalytics.GetExecutiveAlerts()
            };

            return View(model);
        }

        // ─── Financial Analysis ─────────────────────────────────────────────

        public async Task<IActionResult> FinancialAnalysis()
        {
            var model = new FinancialAnalysisViewModel
            {
                RevenueAnalysis = await _strategicAnalytics.GetRevenueAnalysis(),
                ProfitabilityAnalysis = await _strategicAnalytics.GetProfitabilityAnalysis(),
                CashFlowAnalysis = await _strategicAnalytics.GetCashFlowAnalysis(),
                BudgetVariance = await _strategicAnalytics.GetBudgetVariance(),
                FinancialForecasts = await _strategicAnalytics.GetFinancialForecasts()
            };

            return View(model);
        }

        // ─── Market Intelligence ─────────────────────────────────────────────

        public async Task<IActionResult> MarketIntelligence()
        {
            var model = new MarketIntelligenceViewModel
            {
                MarketShareAnalysis = await _strategicAnalytics.GetMarketShareAnalysis(),
                CompetitorAnalysis = await _externalData.GetCompetitorAnalysis(),
                TrendAnalysis = await _externalData.GetTrendAnalysis(),
                CustomerInsights = await _strategicAnalytics.GetCustomerInsights(),
                GeographicAnalysis = await _strategicAnalytics.GetGeographicAnalysis()
            };

            return View(model);
        }

        // ─── Strategic Planning ─────────────────────────────────────────────

        public async Task<IActionResult> StrategicPlanning()
        {
            var model = new StrategicPlanningViewModel
            {
                ScenarioAnalysis = await _strategicAnalytics.GetScenarioAnalysis(),
                GrowthOpportunities = await _strategicAnalytics.GetGrowthOpportunities(),
                RiskAssessment = await _strategicAnalytics.GetRiskAssessment(),
                InvestmentAnalysis = await _strategicAnalytics.GetInvestmentAnalysis(),
                StrategicRecommendations = await _strategicAnalytics.GetStrategicRecommendations()
            };

            return View(model);
        }

        // ─── Performance Monitoring ─────────────────────────────────────────

        public async Task<IActionResult> PerformanceMonitoring()
        {
            var model = new PerformanceMonitoringViewModel
            {
                KpiDashboard = await _strategicAnalytics.GetKpiDashboard(),
                BalancedScorecard = await _strategicAnalytics.GetBalancedScorecard(),
                DepartmentPerformance = await _strategicAnalytics.GetDepartmentPerformance(),
                InitiativeTracking = await _strategicAnalytics.GetInitiativeTracking(),
                PerformanceTrends = await _strategicAnalytics.GetPerformanceTrends()
            };

            return View(model);
        }

        // ─── API Endpoints for Real-time Data ─────────────────────────────────

        [HttpGet]
        public async Task<IActionResult> GetRealTimeKpis()
        {
            var kpis = await _strategicAnalytics.GetRealTimeKpis();
            return Json(kpis);
        }

        [HttpGet]
        public async Task<IActionResult> GetMarketData()
        {
            var marketData = await _externalData.GetRealTimeMarketData();
            return Json(marketData);
        }

        [HttpPost]
        public async Task<IActionResult> GenerateScenarioAnalysis([FromBody] ScenarioRequest request)
        {
            var analysis = await _strategicAnalytics.GenerateScenarioAnalysis(request);
            return Json(analysis);
        }

        // ─── Executive Reports ───────────────────────────────────────────────

        [HttpGet]
        public async Task<IActionResult> GenerateReport(string reportType, string period)
        {
            var report = await _strategicAnalytics.GenerateExecutiveReport(reportType, period);
            return File(report.Data, report.ContentType, report.FileName);
        }

        // ─── Settings & Configuration ────────────────────────────────────────

        [HttpGet]
        public async Task<IActionResult> Settings()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = new ExecutiveSettingsViewModel
            {
                UserPreferences = await _strategicAnalytics.GetUserPreferences(user.Id),
                AlertConfigurations = await _strategicAnalytics.GetAlertConfigurations(user.Id),
                DashboardLayout = await _strategicAnalytics.GetDashboardLayout(user.Id),
                ReportSubscriptions = await _strategicAnalytics.GetReportSubscriptions(user.Id)
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveSettings(ExecutiveSettingsViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            await _strategicAnalytics.SaveUserPreferences(user.Id, model.UserPreferences);
            await _strategicAnalytics.SaveAlertConfigurations(user.Id, model.AlertConfigurations);
            await _strategicAnalytics.SaveDashboardLayout(user.Id, model.DashboardLayout);
            
            TempData["Success"] = "Cài đặt đã được lưu thành công";
            return RedirectToAction("Settings");
        }
    }
}
