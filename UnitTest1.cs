using NUnit.Framework;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightTests.Pages;

namespace PlaywrightTests
{

    [TestFixture]
    public class OrangeHrm : PageTest
    {
        [Test]
        public async Task LoginTest()
        {
            var loginPage = new LoginPage(Page);
            await loginPage.NavigateToLoginPage();
            await loginPage.VerifyPageTitle();
            await loginPage.PerformLogin("Admin", "admin123");
            await loginPage.VerifyDashboardUrl();
            await Page.PauseAsync();
        }
    }
}

