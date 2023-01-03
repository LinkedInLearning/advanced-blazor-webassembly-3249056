using Bunit;
using Bunit.TestDoubles;
using Microsoft.Extensions.DependencyInjection;
using MyBlazorShopHosted.Libraries.Shared.Product.Models;
using MyBlazorShopHosted.Web.Client.StateManagement;
using RichardSzalay.MockHttp;

namespace MyBlazorShopHosted.Testing.Client
{
    public abstract class BaseTest : IDisposable
    {
        protected readonly TestContext _testContext;
        public BaseTest()
        {
            _testContext = new TestContext();
            _testContext.AddFakePersistentComponentState();

            var mockHttpClient = _testContext.Services.AddMockHttpClient();

            mockHttpClient.When("/api/product?size=8&page=1").RespondJson<IList<ProductModel>?>(new List<ProductModel>()
            {
                { new ProductModel("BLADE-MUG", "Blade Mug", "Our strong ceramic mug, with its comfortable D-shaped handle, is microwave and dishwasher safe, and available in one size: 11 oz (3.2\" diameter x 3.8\" h).", 16, "lil-monsters-mug-blade-blue.svg") },
                { new ProductModel("BLADE-NOTEBOOK", "Blade Notebook", "Available with lined, graph, or blank pages, our lay-flat notebooks are made with curl-resistant ever-so-slightly textured smudge-proof paper that�s ideal for your ideas and creations.", 18, "lil-monsters-notebook-blade.svg") },
                { new ProductModel("BLADE-PILLOW", "Blade Pillow", "Use as a reusable shopping bag at the farmers market, as a heavy-duty tote for business and play, and as a unique and useful fashion item.", 30, "lil-monsters-pillow-blade.svg") },
                { new ProductModel("BLADE-TRADING-CARD", "Blade Trading Card", "Constructed of our own organic cotton weave, the pillows are stuffed with organic Kapok fibers harvested in April and May in Hawaii when the fruits mature and fall from the trees. 10 percent of each sale is donated to Hawaii's botanical gardens.", 19.99m, "lil-monsters-cards-blade-front.svg") },
                { new ProductModel("CHARMAINE-FRAMED-ART", "Charmaine Framed Art", "Our framed artwork is hand-printed on our proprietary triple-layer organic, acid-free cotton stock, and shipped ready to hang in one of our in-house hand-made frames.", 45, "stargazers-artwork-charmaine-black.svg") },
                { new ProductModel("CHARMAINE-TOTE-BAG", "Charmaine Framed Art", "Use as a reusable shopping bag at the farmers market, as a heavy-duty tote for business and play, and as a unique and useful fashion item.", 18.5m, "stargazers-tote-charmaine.svg") },
                { new ProductModel("CHARMAINE-T-SHIRT", "Charmaine T-Shirt", "Our t-shirts are made from ring-spun, long-staple organic cotton that's ethically sourced from member farms of local organic cotton cooperatives. Original artwork is screen-printed using PVC- and phthalate-free inks. Features crew-neck styling, shoulder-to-shoulder taping, and a buttery soft feel. Machine-wash warm, tumble-dry low.", 19.99m, "stargazers-tshirt-charmaine-black.svg") },
                { new ProductModel("CHARMAINE-TRADING-CARD", "Charmaine Trading Card", "Our deluxe, limited-edition trading cards are printed on our proprietary, textured, triple-layer organic stock. After printing, all cards are silk laminated to better preserve the cards and to best showcase its character and copy. In addition, each of our cards is encased in an acid-free rigid card sleeve to further protect it from UV rays, moisture, and handling.", 19.99m, "stargazers-cards-charmaine-front.svg") }
            });
            mockHttpClient.When("/api/product/total-page-count?size=8").RespondJson(2);

            _testContext.Services.AddSingleton<IShoppingCartStateContainer, ShoppingCartStateContainer>();
        }

        public void Dispose()
        {
            if (_testContext != null)
            {
                _testContext.Dispose();
            }
        }
    }
}
