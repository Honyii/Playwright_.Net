using NUnit.Framework;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using My.Testing;
using System.IO;
using Newtonsoft.Json;

namespace PlaywrightTests
{

    [TestFixture]
    public class OrangeHrm : PageTest
    {
        private class LoginData {
            public string Username {get; set;}
            public string Password {get; set;}
        }
        [Test]
        public async Task LoginTest()
        {
            var loginData = JsonConvert.DeserializeObject<LoginData>(File.ReadAllText("data.json"));
            var loginPage = new LoginPage(Page);
            await loginPage.NavigateToLoginPage();
            await loginPage.VerifyPageTitle();
            await loginPage.PerformLogin(loginData.Username, loginData.Password);
            await loginPage.VerifyDashboardUrl();
            await Page.PauseAsync();
        }
    }
}

