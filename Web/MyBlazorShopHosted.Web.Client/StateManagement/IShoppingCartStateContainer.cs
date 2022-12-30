using System.Net.Http.Json;

namespace MyBlazorShopHosted.Web.Client.StateManagement
{
    /// <summary>
    /// Stores information about the shopping cart in-memory
    /// </summary>
    public interface IShoppingCartStateContainer
    {
        /// <summary>
        /// Gets the count of the total items.
        /// </summary>
        int TotalItemsCount { get; }

        /// <summary>
        /// Runs an event when the total item has changed
        /// </summary>
        event Action? OnTotalItemsCountChange;

        /// <summary>
        /// Updates the total items count and invokes the onchange event
        /// </summary>
        /// <returns>An instance of <see cref="Task"/></returns>
        Task UpdateTotalItemsCountAsync();
    }
}
