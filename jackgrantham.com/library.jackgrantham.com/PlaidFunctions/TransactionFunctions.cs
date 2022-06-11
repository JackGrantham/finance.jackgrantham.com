using Going.Plaid;
using Going.Plaid.Accounts;
using Going.Plaid.Transactions;
using Going.Plaid.Entity;
using Going.Plaid.Item;
using Going.Plaid.Link;
using library.jackgrantham.com.Middleware;
using Microsoft.Extensions.Options;

namespace library.jackgrantham.com.PlaidFunctions
{
    public class TransactionFunctions
    {
        #region Private Members

        private readonly PlaidCredentials _credentials;
        private readonly PlaidClient _client;

        #endregion Private Members

        public TransactionFunctions(IOptions<PlaidCredentials> credentials, PlaidClient client)
        {
            _credentials = credentials.Value;
            _client = client;
        }

        public async Task<TransactionsGetResponse> GetTransactionsByDateRange(string accessToken, DateTime startDate, DateTime endDate)
        {
            var result = await _client.TransactionsGetAsync(
                new TransactionsGetRequest()
                {
                    AccessToken = accessToken,
                    StartDate = DateOnly.FromDateTime(startDate),
                    EndDate = DateOnly.FromDateTime(endDate),
                });
            return result;
        }
    }
}
