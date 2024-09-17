using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Dashboaed.Pages {
    public class Dashboard {
        private readonly IPage _page;
        private readonly ILocator _attendance;
        private readonly ILocator _attendanceChart;
        private readonly ILocator _punchOutText;
        private readonly ILocator _punchOutBtn;


         public Dashboard(IPage page) {
            _page = page;
            _attendance = _page.Locator(".orangehrm-attendance-card");
            _attendanceChart = _page.Locator(".emp-attendance-chart");
            _punchOutText = _page.Locator(".orangehrm-attendance-card-state");
            _punchOutBtn = _page.Locator(".orangehrm-attendance-card-bar .bi-stopwatch");
         }
    }
   
}