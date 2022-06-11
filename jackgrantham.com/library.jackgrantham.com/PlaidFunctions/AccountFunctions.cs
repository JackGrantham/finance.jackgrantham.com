using Going.Plaid;
using Going.Plaid.Accounts;
using Going.Plaid.Entity;
using Going.Plaid.Item;
using Going.Plaid.Link;
using library.jackgrantham.com.Middleware;
using Microsoft.Extensions.Options;

namespace library.jackgrantham.com.PlaidFunctions
{
    public class AccountFunctions
    {
        #region Private Members

        private readonly PlaidCredentials _credentials;
        private readonly PlaidClient _client;

        #endregion Private Members

        public AccountFunctions(IOptions<PlaidCredentials> credentials, PlaidClient client)
        {
            _credentials = credentials.Value;
            _client = client;
        }

        public async Task<AccountsGetResponse> GetAccounts(string accessToken)
        {
            var result = await _client.AccountsGetAsync(
                new AccountsGetRequest()
                {
                    AccessToken = accessToken,
                });
            return result;
        }
    }
}
