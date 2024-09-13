using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace My.Testing
{
    public class LoginPage
    {
        private IPage _page;
        public LoginPage(IPage page) => _page = page;
        private IConfiguration _config => new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();


        public async Task NavigateToLoginPage()
        {
            var baseUrl = _config["AppSettings:BaseUrl"];
            await _page.GotoAsync(baseUrl);
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