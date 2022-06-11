using Going.Plaid;
using Going.Plaid.Entity;
using Going.Plaid.Item;
using Going.Plaid.Link;
using library.jackgrantham.com.Middleware;
using Microsoft.Extensions.Options;

namespace library.jackgrantham.com.PlaidFunctions
{
    public class ItemFunctions
    {
        #region Private Members

        private readonly PlaidCredentials _credentials;
        private readonly PlaidClient _client;

        #endregion Private Members

        public ItemFunctions(IOptions<PlaidCredentials> credentials, PlaidClient client)
        {
            _credentials = credentials.Value;
            _client = client;
        }

        public async Task<ItemGetResponse> GetItem(string accessToken)
        {
            var result = await _client.ItemGetAsync(
                new ItemGetRequest()
                {
                    AccessToken = accessToken,
                });
            return result;
        }

        // TODO: Implement /item/remove

        // TODO: Implement /item/webhook/update
    }
}
