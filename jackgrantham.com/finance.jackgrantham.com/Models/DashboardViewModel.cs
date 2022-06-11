using finance.jackgrantham.com.Data;
using library.jackgrantham.com.Middleware;

namespace finance.jackgrantham.com.Models
{
    public class DashboardViewModel
    {
        public DashboardViewModel(PlaidCredentials credentials)
        {
            PlaidCredentials = credentials;
        }

        public PlaidCredentials PlaidCredentials { get; set; }
        public List<Account>? Accounts { get; set; }

        public List<Transaction>? Transactions { get; set; }
    }
}
