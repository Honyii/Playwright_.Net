using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;
public class OrangeHrm : PageTest
{
    [Test]
    public async Task LoginTest()
    {
        await Page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        await Expect(Page).ToHaveTitleAsync(new Regex("OrangeHRM"));
        await Page.Locator("input[name='username']").FillAsync("Admin");
        await Page.Locator("input[name='password']").FillAsync("admin123");
        await Page.Locator("button[type='submit']").ClickAsync();
        await Expect(Page).ToHaveURLAsync(new Regex(".*dashboard"));
    }

}

