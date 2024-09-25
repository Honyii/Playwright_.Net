using System.Text.RegularExpressions;
using NUnit.Framework;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using My.Testing;
using DashboardPages.Pages;
using System.IO;
using Newtonsoft.Json;

namespace PlaywrightTests
{

    [TestFixture]
    public class OrangeHrm : PageTest
    {
        private class LoginData
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
        [SetUp]
        public async Task LoginSetup()
        {
            var loginData = JsonConvert.DeserializeObject<LoginData>(File.ReadAllText("data.json"));
            var loginPage = new LoginPage(Page);
            await loginPage.NavigateToLoginPage();
            await loginPage.VerifyPageTitle();
            await loginPage.PerformLogin(loginData.Username, loginData.Password);
            await loginPage.VerifyDashboardUrl();

        }

        [Test]
        public async Task DashboardPunchInTest()
        {
            var dashboard = new Dashboard(Page);
            await Expect(dashboard.ConfirmAttendanceCard).ToBeVisibleAsync(); 
            await Expect(dashboard.ConfirmPunchInText).ToHaveTextAsync(new Regex("Punched Out"));          
            await Expect(dashboard.ConfirmAttendanceChart).ToBeVisibleAsync();
            await dashboard.PunchInBtn();
            await Expect(Page).ToHaveURLAsync(new Regex(".*attendance"));
            await Page.PauseAsync();
        }
        [Test]
        public async Task DashboardMyActionsTest() {

        }
    }
}
  