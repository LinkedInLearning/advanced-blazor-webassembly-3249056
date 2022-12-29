using System.Net.Http.Json;

namespace MyBlazorShopHosted.Web.Client.StateManagement
{
    /// <summary>
    /// Stores information about the shopping cart in-memory
    /// </summary>
    public class ShoppingCartStateContainer : IShoppingCartStateContainer
    {
        /// <summary>
        /// Gets the count of the total items.
        /// </summary>
        public int TotalItemsCount { get; private set; }

        /// <summary>
        /// Runs an event when the total item has changed
        /// </summary>
        public event Action? OnTotalItemsCountChange;

        /// <summary>
        /// Updates the total items count and invokes the onchange event
        /// </summary>
        /// <param name="httpClient">An instance of <see cref="HttpClient"/></param>
        /// <returns>An instance of <see cref="Task"/></returns>
        public async Task UpdateTotalItemsCountAsync(HttpClient httpClient)
        {
            TotalItemsCount = await httpClient.GetFromJsonAsync<int>(
                "/api/shopping-cart/count"
            );

            OnTotalItemsCountChange?.Invoke();
        }
    }
}
