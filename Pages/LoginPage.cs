using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Extensions.Configurations;
using System.IO;

namespace My.Testing
{
    public class LoginPage
    {
        private readonly IPage _page;
        public LoginPage(IPage page)
        {
            _page = page;
        }

        public async Task NavigateToLoginPage()
        {
            await _page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        }

        public async Task PerformLogin(string username, string password)
        {
            await _page.Locator("input[name='username']").FillAsync(username);
            await _page.Locator("input[name='password']").FillAsync(password);
            await _page.Locator("button[type='submit']").ClickAsync();
        }

        public async Task VerifyPageTitle()
        {
            await Assertions.Expect(_page).ToHaveTitleAsync(new Regex("OrangeHRM"));
        }

        public async Task VerifyDashboardUrl()
        {
            await Assertions.Expect(_page).ToHaveURLAsync(new Regex(".*dashboard"));
        }
    }
}