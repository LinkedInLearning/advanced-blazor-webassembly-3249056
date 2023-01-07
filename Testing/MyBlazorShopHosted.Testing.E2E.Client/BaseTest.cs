using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

namespace MyBlazorShopHosted.Testing.E2E.Client
{
    public abstract class BaseTest
    {
        protected async Task<IPage> CreateBrowserAsync()
        {
            var playwright = await Playwright.CreateAsync();
          
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Args = new string[] { "--start-maximized" },
                Headless = false, 
            });

            var context = await browser.NewContextAsync(new BrowserNewContextOptions()
            {
                ViewportSize = ViewportSize.NoViewport
            });
          
            return await context.NewPageAsync();     
        }
    }
}
