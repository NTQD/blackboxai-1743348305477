using System;
using System.Windows.Forms;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void LoadDashboard()
    {
        // Dashboard loading implementation will be added later
        lblWelcome.Text = $"Xin chào, {CurrentUser.Username}";
    }

    private void btnOverview_Click(object sender, EventArgs e)
    {
        var overviewForm = new OverviewForm();
        overviewForm.ShowDialog();
    }

    private void btnTransactions_Click(object sender, EventArgs e)
    {
        var transactionForm = new TransactionJournalForm();
        transactionForm.ShowDialog();
    }

    private void btnAddTransaction_Click(object sender, EventArgs e)
    {
        var addForm = new AddTransactionForm();
        if (addForm.ShowDialog() == DialogResult.OK)
        {
            LoadDashboard();
        }
    }

    private void btnAccount_Click(object sender, EventArgs e)
    {
        var accountForm = new AccountManagementForm();
        accountForm.ShowDialog();
    }
}