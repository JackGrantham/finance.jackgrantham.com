using finance.jackgrantham.com.Data;
using finance.jackgrantham.com.Models;
using Going.Plaid;
using Going.Plaid.Accounts;
using Going.Plaid.Item;
using Going.Plaid.Transactions;
using library.jackgrantham.com.Middleware;
using library.jackgrantham.com.PlaidFunctions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace finance.jackgrantham.com.Controllers
{
    public class HomeController : Controller
    {
        #region Private Members

        private readonly FinanceDbContext _dbContext;
        private readonly LinkFunctions Link;
        private readonly ItemFunctions Item;
        private readonly AccountFunctions Account;
        private readonly TransactionFunctions Transaction;
        private readonly PlaidCredentials _credentials;
        private readonly PlaidClient _client;

        #endregion Private Members

        #region Constructors

        public HomeController(IOptions<PlaidCredentials> credentials, PlaidClient client, FinanceDbContext context)
        {
            _credentials = credentials.Value;
            _client = client;
            _dbContext = context;

            Link = new LinkFunctions(credentials, client);
            Item = new ItemFunctions(credentials, client);
            Account = new AccountFunctions(credentials, client);
            Transaction = new TransactionFunctions(credentials, client);
        }

        #endregion

        #region Index

        [Authorize]
        public IActionResult Index()
        {
            DashboardViewModel model = new DashboardViewModel(_credentials)
            {
                Accounts = _dbContext.Accounts?.ToList(),
                Transactions = _dbContext.Transactions?.ToList(),
            };
            
            return View(model);
        }

        #endregion

        #region Plaid

        [HttpPost]
        public void EstablishItem(string accessToken)
        {
            // /item/get
            ItemGetResponse? itemGetResponse = GetItem(accessToken).Result;

            // Insert Item into Items SQL Table
            Item item = new Item()
            {
                InstitutionID = itemGetResponse.Item.InstitutionId,
                AccessToken = accessToken,
                ItemID = itemGetResponse.Item.ItemId,
                EstablishedDate = DateTime.Now,
                UserID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                Active = true,
                RequestID = itemGetResponse.RequestId,
                Webhook = itemGetResponse.Item.Webhook,
            };
            _dbContext.Add(item);

            // Save Database Changes
            _dbContext.SaveChanges();
        }

        #region Link Functions

        [HttpPost]
        public async Task<IActionResult> GetLinkToken([FromBody] string[] products)
        {
            return Ok(await Link.GetLinkToken(products));
        }

        [HttpPost]
        public async Task<IActionResult> GetAccessToken([FromBody] string publicToken)
        {
            return Ok(await Link.GetAccessToken(publicToken));
        }

        [HttpPost]
        public async Task<IActionResult> GetUpdateToken([FromBody] string accessToken)
        {
            return Ok(await Link.GetUpdateToken(accessToken));
        }

        #endregion

        #region Item Functions

        [HttpPost]
        public async Task<ItemGetResponse> GetItem(string accessToken)
        {
            return await Item.GetItem(accessToken);
        }

        #endregion

        #region Account Functions

        [HttpPost]
        public async Task<AccountsGetResponse> GetAccounts(string accessToken)
        {
            return await Account.GetAccounts(accessToken);
        }

        #endregion

        #region Transaction Functions

        [HttpPost]
        public async Task<TransactionsGetResponse> GetTransactions(string accessToken, DateTime startDate, DateTime endDate)
        {
            return await Transaction.GetTransactionsByDateRange(accessToken, startDate, endDate);
        }

        #endregion

        #endregion

        #region Privacy

        public IActionResult Privacy()
        {
            return View();
        }

        #endregion

    }
}