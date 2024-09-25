using System.Threading.Tasks;
using Microsoft.Playwright;
using System.IO;

namespace TimeSpacePage

public class TimePage {
    private readonly IPage _page;
    private readonly ILocator _textReportText;
    private readonly ILocator _timesheets;
    private readonly  ILocator _attendance;
    private readonly ILocator _reports;
    private readonly ILocator _projectInfo;
    private readonly ILocator _date;
    private readonly ILocator _time;
    private readonly ILocator _note;
    private readonly ILocator _submitBtn;
    public TimePage(IPage page) {
        _page = page;
        _textReportText = _page.Locator(".oxd-topbar-header-breadcrumb");
        _attendance = _page.Locator(".oxd-topbar-body-nav-tab-item").Nth(1);
        _timesheets = _page.Locator(".oxd-topbar-body-nav-tab-item").First();
        _reports = _page.Locator(".oxd-topbar-body-nav-tab-item").Nth(2);
        _projectInfo = _page.Locator(".oxd-topbar-body-nav-tab-item").Nth(3);
        _date = _page.Locator("input[placeholder='yyyy-dd-mm']");
        _time = _page.Locator("input[placeholder='hh:mm']");
        _note = _page.Locator("textarea[placeholder='Type here']");
        _submitBtn = _page.Locator("button[type='submit']");
    }
    public ILocator ConfirmAttendanceText => _textReportText;
        public async Task Attendance() {
        
    }
}