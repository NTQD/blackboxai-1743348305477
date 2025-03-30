using System;
using System.Windows.Forms;
using System.Data;
using FinanceApp.Helpers;

namespace FinanceApp
{
    public partial class TransactionJournalForm : Form
    {
        public TransactionJournalForm()
        {
            InitializeComponent();
            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            dtpEndDate.Value = DateTime.Now;
            LoadTransactions();
        }

        private void LoadTransactions()
        {
            try
            {
                // Load transactions between selected dates
                DataTable transactions = ReportHelper.GetTransactionsByDateRange(
                    CurrentUser.UserId,
                    dtpStartDate.Value,
                    dtpEndDate.Value);
                    
                dgvTransactions.DataSource = transactions;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading transactions: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTransactions();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}