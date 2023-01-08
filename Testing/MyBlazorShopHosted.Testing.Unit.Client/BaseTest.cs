using Bunit;
using Bunit.TestDoubles;
using Microsoft.Extensions.DependencyInjection;
using MyBlazorShopHosted.Libraries.Shared.Product.Models;
using MyBlazorShopHosted.Web.Client.StateManagement;
using RichardSzalay.MockHttp;

namespace MyBlazorShopHosted.Testing.Unit.Client
{
    public abstract class BaseTest : IDisposable
    {
        protected readonly TestContext _testContext;
        public BaseTest()
        {
            _testContext = new TestContext();
            _testContext.AddFakePersistentComponentState();           
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
