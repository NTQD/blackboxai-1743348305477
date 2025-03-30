using System;
using System.Windows.Forms;

public partial class AddTransactionForm : Form
{
    public AddTransactionForm()
    {
        InitializeComponent();
        LoadCategories();
        LoadWallets();
    }

    private void LoadCategories()
    {
        // Load income categories
        cmbIncomeCategory.DataSource = DatabaseHelper.GetIncomeCategories();
        cmbIncomeCategory.DisplayMember = "CategoryName";
        
        // Load expense categories
        cmbExpenseCategory.DataSource = DatabaseHelper.GetExpenseCategories();
        cmbExpenseCategory.DisplayMember = "CategoryName";
    }

    private void LoadWallets()
    {
        cmbWallet.DataSource = DatabaseHelper.GetUserWallets(CurrentUser.UserId);
        cmbWallet.DisplayMember = "WalletName";
    }

    private void rbIncome_CheckedChanged(object sender, EventArgs e)
    {
        pnlIncome.Enabled = rbIncome.Checked;
        pnlExpense.Enabled = !rbIncome.Checked;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (!ValidateInputs())
            return;

        try
        {
            var transaction = new Transaction
            {
                UserId = CurrentUser.UserId,
                WalletId = (int)cmbWallet.SelectedValue,
                Amount = decimal.Parse(txtAmount.Text),
                Description = txtNote.Text,
                TransactionDate = dtpDate.Value
            };

            if (rbIncome.Checked)
            {
                transaction.IncomeCategoryId = (int)cmbIncomeCategory.SelectedValue;
            }
            else
            {
                transaction.ExpenseCategoryId = (int)cmbExpenseCategory.SelectedValue;
            }

            if (DatabaseHelper.SaveTransaction(transaction))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi lưu giao dịch: {ex.Message}", 
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private bool ValidateInputs()
    {
        if (string.IsNullOrWhiteSpace(txtAmount.Text) || 
            !decimal.TryParse(txtAmount.Text, out decimal amount) || 
            amount <= 0)
        {
            MessageBox.Show("Vui lòng nhập số tiền hợp lệ", 
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (dtpDate.Value > DateTime.Now)
        {
            MessageBox.Show("Ngày giao dịch không thể trong tương lai", 
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }
}