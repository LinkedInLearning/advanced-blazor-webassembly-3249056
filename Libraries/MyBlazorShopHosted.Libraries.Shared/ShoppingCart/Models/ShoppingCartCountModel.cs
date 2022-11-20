using System.Net.Http.Json;

namespace MyBlazorShopHosted.Libraries.Shared.ShoppingCart.Models
{
    public class ShoppingCartCountModel
    {
        public int Count { get; private set; }

        public event Action? UpdateCart;

        public async Task OnUpdateCartAsync(HttpClient httpClient)
        {
            Count = await httpClient.GetFromJsonAsync<int>(
                "/api/shopping-cart/count"
            );
            UpdateCart?.Invoke();
        }
    }
}
