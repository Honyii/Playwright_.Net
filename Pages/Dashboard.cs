using System.Threading.Tasks;
using Microsoft.Playwright;
using System.IO;

namespace DashboardPages.Pages {
    public class Dashboard {
        private readonly IPage _page;
        private readonly ILocator _attendance;
        private readonly ILocator _attendanceChart;
        private readonly ILocator _punchInText;
        private readonly ILocator _punchInBtn;
        private readonly ILocator _myActionsBtn;
        private readonly ILocator _toDoList;

         public Dashboard(IPage page) {
            _page = page;
            _attendance = _page.Locator(".orangehrm-attendance-card");
            _attendanceChart = _page.Locator(".emp-attendance-chart");
            _punchInText = _page.Locator(".orangehrm-attendance-card-state");
            _punchInBtn = _page.Locator(".orangehrm-attendance-card-action > .bi-stopwatch");
            _myActionsBtn = _page.Locator(".bi-list-check");
            _toDoList = _page.Locator(".orangehrm-todo-list");
         }
         public ILocator ConfirmAttendanceCard => _attendance;
         public ILocator ConfirmAttendanceChart => _attendanceChart;
         public ILocator ConfirmPunchInText => _punchInText;
         public ILocator ConfirmMyActionsBtn => _myActionsBtn;
         public ILocator ToDoList => _toDoList;

         public async Task PunchInBtn() {
            await _punchInBtn.ClickAsync();

         }
    }
   
}