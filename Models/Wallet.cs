namespace FinanceApp.Models
{
    public class Wallet
    {
        public int WalletId { get; set; }
        public string WalletName { get; set; } = string.Empty;
        public decimal Balance { get; set; }
    }
}