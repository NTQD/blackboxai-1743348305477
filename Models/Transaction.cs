namespace FinanceApp.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public int? IncomeCategoryId { get; set; }
        public int? ExpenseCategoryId { get; set; }
        public int WalletId { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}