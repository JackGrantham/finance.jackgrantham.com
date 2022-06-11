using Microsoft.EntityFrameworkCore;

namespace finance.jackgrantham.com.Data
{
    public class FinanceDbContext : DbContext
    {
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Account>? Accounts { get; set; }
        public DbSet<Item>? Items { get; set; }
        public DbSet<Transaction>? Transactions { get; set; }
    }

    public class Item
    {
        public string? ItemID { get; set; }
        public string? UserID { get; set; }
        public string? InstitutionID { get; set; }
        public string? Webhook { get; set; }
        public string? RequestID { get; set; }
        public string? AccessToken { get; set; }
        public DateTime? EstablishedDate { get; set; }
        public bool Active { get; set; }

        public List<Account>? Accounts { get; set; }
    }

    public class Account
    {
        public string? AccountID { get; set; }
        public string? Name { get; set; }
        public string? OfficialName { get; set; }
        public decimal? AvailableBalance { get; set; }
        public decimal? CurrentBalance { get; set; }
        public decimal? Limit { get; set; }
        public string? ISOCurrencyCode { get; set; }
        public DateTimeOffset? LastUpdatedDatetime { get; set; }
        public string? Mask { get; set; }
        public string? Type { get; set; }
        public string? Subtype { get; set; }
        public string? VerificationStatus { get; set; }
        public string? ItemID { get; set; }
        public string? RequestID { get; set; }
        public bool Active { get; set; }

        public List<Transaction>? Transactions { get; set; }
    }

    public class Transaction
    {
        public string? AccountID { get; set; }
        public string? TransactionID { get; set; }
        public decimal? Amount { get; set; }
        public string? ISOCurrencyCode { get; set; }
        public string? CategoryID { get; set; }
        public string? PrimaryCategory { get; set; }
        public string? SecondaryCategory { get; set; }
        public string? Location { get; set; }
        public string? StoreNumber { get; set; }
        public string? Payee { get; set; }
        public string? Payer { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? ByOrderOf { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentProcessor { get; set; }
        public string? Reason { get; set; }
        public string? AccountOwner { get; set; }
        public string? Name { get; set; }
        public string? OriginalDescription { get; set; }
        public DateTime? Date { get; set; }
        public bool? Pending { get; set; }
        public string? MerchantName { get; set; }
        public string? CheckNumber { get; set; }
        public string? PaymentChannel { get; set; }
        public string? TransactionCode { get; set; }
        public string? TransactionType { get; set; }
    }

    public class Budget
    {
        public int BudgetID { get; set; }
        public string? Month { get; set; }

        public List<Income>? Incomes { get; set; }
        public List<Expense>? Expenses { get; set; }
    }

    public class Income
    {
        public int IncomeID { get; set; }
        public int BudgetID { get; set; }
        public DateOnly? Date { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal ProjectedAmount { get; set; }
        public decimal ActualAmount { get; set; }
    }

    public class Expense
    {
        public int ExpenseID { get; set; }
        public int BudgetID { get; set; }
        public bool Fixed { get; set; }
        public DateOnly? Date { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal ProjectedAmount { get; set; }
        public decimal ActualAmount { get; set; }
    }

    public class ExpenseCategoryMap
    {
        public int ExpenseID { get; set; }
        public int CategoryID { get; set; }
    }

    public class Category
    {
        public int CategoryID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal ProjectedAmount { get; set; }
        public decimal ActualAmount { get; set; }
    }
}
