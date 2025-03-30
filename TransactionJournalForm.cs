using System;
using System.Data;
using System.Windows.Forms;

public partial class TransactionJournalForm : Form
{
    public TransactionJournalForm()
    {
        InitializeComponent();
        LoadTransactions();
    }

    private void LoadTransactions()
    {
        var transactions = DatabaseHelper.GetTransactionsByUser(CurrentUser.UserId);
        dgvTransactions.DataSource = transactions;
        FormatDataGridView();
    }

    private void FormatDataGridView()
    {
        dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvTransactions.Columns["Amount"].DefaultCellStyle.Format = "N0";
        dgvTransactions.Columns["TransactionDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
    }

    private void btnFilter_Click(object sender, EventArgs e)
    {
        DateTime startDate = dtpStartDate.Value;
        DateTime endDate = dtpEndDate.Value;

        var filteredTransactions = DatabaseHelper.GetTransactionsByUser(
            CurrentUser.UserId, startDate, endDate);
        dgvTransactions.DataSource = filteredTransactions;
    }

    private void btnReport_Click(object sender, EventArgs e)
    {
        var reportForm = new ReportForm(dtpStartDate.Value, dtpEndDate.Value);
        reportForm.ShowDialog();
    }
}