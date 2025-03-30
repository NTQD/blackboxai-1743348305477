using System;
using System.Windows.Forms;
using FinanceApp.Models;

namespace FinanceApp
{
    public partial class AddTransactionForm : Form
    {
        public AddTransactionForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            // Load categories and wallets
            cmbIncomeCategory.DataSource = Helpers.DatabaseHelperExtensions.GetIncomeCategories();
            cmbIncomeCategory.DisplayMember = "CategoryName";
            cmbIncomeCategory.ValueMember = "IncomeCategoryId";

            cmbExpenseCategory.DataSource = Helpers.DatabaseHelperExtensions.GetExpenseCategories();
            cmbExpenseCategory.DisplayMember = "CategoryName";
            cmbExpenseCategory.ValueMember = "ExpenseCategoryId";

            cmbWallet.DataSource = Helpers.DatabaseHelperExtensions.GetUserWallets(CurrentUser.UserId);
            cmbWallet.DisplayMember = "WalletName";
            cmbWallet.ValueMember = "WalletId";

            dtpDate.Value = DateTime.Now;
        }

        private void rbIncome_CheckedChanged(object sender, EventArgs e)
        {
            pnlIncome.Visible = rbIncome.Checked;
            pnlExpense.Visible = !rbIncome.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var transaction = new Transaction
                {
                    UserId = CurrentUser.UserId,
                    Amount = decimal.Parse(txtAmount.Text),
                    Description = txtNote.Text,
                    TransactionDate = dtpDate.Value,
                    WalletId = cmbWallet.SelectedValue != null ? (int)cmbWallet.SelectedValue : 0
                };

                if (rbIncome.Checked)
                {
                    transaction.IncomeCategoryId = cmbIncomeCategory.SelectedValue != null ? (int)cmbIncomeCategory.SelectedValue : 0;
                }
                else
                {
                    transaction.ExpenseCategoryId = cmbExpenseCategory.SelectedValue != null ? (int)cmbExpenseCategory.SelectedValue : 0;
                }

                if (Helpers.DatabaseHelperExtensions.SaveTransaction(transaction))
                {
                    MessageBox.Show("Giao dịch đã được lưu thành công!", "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu giao dịch: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}