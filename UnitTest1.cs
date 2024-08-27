using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;
public class OrangeHrm : PageTest
{
    [Test]
    public async Task HasTitle()
    {
        await Page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

      
        await Expect(Page).ToHaveTitleAsync(new Regex("OrangeHRM"));
    }

   
}

