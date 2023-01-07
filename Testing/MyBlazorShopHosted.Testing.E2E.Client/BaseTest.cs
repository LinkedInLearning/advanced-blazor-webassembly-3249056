using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

namespace MyBlazorShopHosted.Testing.E2E.Client
{
    public abstract class BaseTest
    {


        protected async Task CreateBrowser()
        {
            var playwright = await Playwright.CreateAsync();

            
            await using var browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            var page = await browser.NewPageAsync();
            
        }
    }
}
