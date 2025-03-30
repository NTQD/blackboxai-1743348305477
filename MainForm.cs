using System;
using System.Windows.Forms;

namespace FinanceApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            lblWelcome.Text = $"Chào mừng {CurrentUser.Username}";
        }

        private void ShowForm(Form form)
        {
            form.ShowDialog();
        }

        private void btnOverview_Click(object sender, EventArgs e)
        {
            ShowForm(new OverviewForm());
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            ShowForm(new TransactionJournalForm());
        }

        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            ShowForm(new AddTransactionForm());
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            ShowForm(new AccountManagementForm());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ShowForm(new ReportForm());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}