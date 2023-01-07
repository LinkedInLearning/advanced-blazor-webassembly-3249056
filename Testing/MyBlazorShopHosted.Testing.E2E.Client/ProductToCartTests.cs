namespace MyBlazorShopHosted.Testing.E2E.Client
{
    public class ProductToCartTests : BaseTest
    {
        public ProductToCartTests()
        {

        }

        [Fact]
        public async void Page_AddsProductToCart_ShowsCartPage()
        {
           var page = await CreateBrowserAsync();
        }
    }
}