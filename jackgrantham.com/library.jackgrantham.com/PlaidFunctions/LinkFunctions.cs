using Going.Plaid;
using Going.Plaid.Entity;
using Going.Plaid.Item;
using Going.Plaid.Link;
using library.jackgrantham.com.Middleware;
using Microsoft.Extensions.Options;

namespace library.jackgrantham.com.PlaidFunctions
{
    public class LinkFunctions
    {
        #region Private Members

        private readonly PlaidCredentials _credentials;
        private readonly PlaidClient _client;

        #endregion Private Members

        public LinkFunctions(IOptions<PlaidCredentials> credentials, PlaidClient client)
        {
            _credentials = credentials.Value;
            _client = client;
        }

        public async Task<LinkTokenCreateResponse> GetLinkToken(string[] products)
        {
            var result = await _client.LinkTokenCreateAsync(
                new LinkTokenCreateRequest()
                {
                    User = new LinkTokenCreateRequestUser { ClientUserId = Guid.NewGuid().ToString(), },
                    ClientName = "Going.Plaid.Net Walkthrough Demo ",
                    Products = products.Select(p => Enum.Parse<Products>(p, true)).ToArray(),
                    Language = Language.English,
                    CountryCodes = new[] { CountryCode.Us },
                });
            return result;
        }

        public async Task<ItemPublicTokenExchangeResponse> GetAccessToken(string publicToken)
        {
            var result = await _client.ItemPublicTokenExchangeAsync(
                new ItemPublicTokenExchangeRequest()
                {
                    PublicToken = publicToken,
                });
            _credentials.AccessToken = result.ItemId;
            System.Diagnostics.Debug.WriteLine($"access_token: '{result.AccessToken}'");

            return result;
        }

        public async Task<LinkTokenCreateResponse> GetUpdateToken(string accessToken)
        {
            var result = await _client.LinkTokenCreateAsync(
                new LinkTokenCreateRequest()
                {
                    AccessToken = accessToken,
                    User = new LinkTokenCreateRequestUser { ClientUserId = Guid.NewGuid().ToString(), },
                    ClientName = "Going.Plaid.Net Walkthrough Demo ",
                    Language = Language.English,
                    CountryCodes = new[] { CountryCode.Us },
                });
            System.Diagnostics.Debug.WriteLine($"public_token: '{result.LinkToken}'");

            return result;
        }

    }
}
