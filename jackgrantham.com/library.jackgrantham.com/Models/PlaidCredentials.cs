using Going.Plaid;

namespace library.jackgrantham.com.Middleware
{
    public class PlaidCredentials : PlaidOptions
    {
        public string? LinkToken { get; set; }
        public string? AccessToken { get; set; }
    }
}
