using System;
using System.Data;
using System.Windows.Forms;

public partial class ReportForm : Form
{
    private readonly DateTime _startDate;
    private readonly DateTime _endDate;

    public ReportForm(DateTime startDate, DateTime endDate)
    {
        InitializeComponent();
        _startDate = startDate;
        _endDate = endDate;
        LoadReportData();
    }

    private void LoadReportData()
    {
        // Load income report
        var incomeReport = DatabaseHelper.GetTransactionReport(
            CurrentUser.UserId, _startDate, _endDate, isIncome: true);
        dgvIncome.DataSource = incomeReport;
        FormatDataGrid(dgvIncome);

        // Load expense report
        var expenseReport = DatabaseHelper.GetTransactionReport(
            CurrentUser.UserId, _startDate, _endDate, isIncome: false);
        dgvExpense.DataSource = expenseReport;
        FormatDataGrid(dgvExpense);

        // Calculate totals
        lblIncomeTotal.Text = CalculateTotal(incomeReport).ToString("N0");
        lblExpenseTotal.Text = CalculateTotal(expenseReport).ToString("N0");
        lblNetTotal.Text = (CalculateTotal(incomeReport) - CalculateTotal(expenseReport)).ToString("N0");
    }

    private void FormatDataGrid(DataGridView dgv)
    {
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgv.Columns["Amount"].DefaultCellStyle.Format = "N0";
        dgv.Columns["Date"].DefaultCellStyle.Format = "dd/MM/yyyy";
    }

    private decimal CalculateTotal(DataTable dt)
    {
        decimal total = 0;
        foreach (DataRow row in dt.Rows)
        {
            total += Convert.ToDecimal(row["Amount"]);
        }
        return total;
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
        // Implement printing functionality
        MessageBox.Show("Chức năng in báo cáo sẽ được triển khai sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}