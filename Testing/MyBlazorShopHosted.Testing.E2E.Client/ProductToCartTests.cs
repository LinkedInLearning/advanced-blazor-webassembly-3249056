namespace MyBlazorShopHosted.Testing.E2E.Client
{
    public class ProductToCartTests : BaseTest
    { 
        [Fact]
        public async void Page_AddsProductToCart_ShowsCartPage()
        {
           var page = await CreateBrowserAsync();
            await page.GotoAsync("https://localhost:9002");

            await Task.Delay(TimeSpan.FromSeconds(5));

            await page.Locator("a[data-test='BLADE-MUG']").ClickAsync();
            await page.WaitForURLAsync("https://localhost:9002/product/blade-mug");

            await Task.Delay(TimeSpan.FromSeconds(5));

            await page.Locator("button[data-test='add-to-cart']").ClickAsync();
            await page.WaitForURLAsync("https://localhost:9002/cart");

            await Task.Delay(TimeSpan.FromSeconds(5));

            Assert.True(page.Url == "https://localhost:9002/cart");
        }
    }
}