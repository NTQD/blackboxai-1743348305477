using System;
using System.Windows.Forms;
using System.Data;
using FinanceApp.Helpers;

namespace FinanceApp
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
            LoadReportData();
        }

        private void LoadReportData()
        {
            try
            {
                // Load income data
                DataTable incomeData = ReportHelper.GetIncomeReport(CurrentUser.UserId);
                dgvIncome.DataSource = incomeData;
                
                // Load expense data
                DataTable expenseData = ReportHelper.GetExpenseReport(CurrentUser.UserId);
                dgvExpense.DataSource = expenseData;
                
                // Calculate totals
                decimal incomeTotal = CalculateTotal(incomeData);
                decimal expenseTotal = CalculateTotal(expenseData);
                decimal netTotal = incomeTotal - expenseTotal;
                
                // Update labels
                lblIncomeTotal.Text = $"Tổng thu: {incomeTotal:N0}";
                lblExpenseTotal.Text = $"Tổng chi: {expenseTotal:N0}";
                lblNetTotal.Text = $"Tổng cộng: {netTotal:N0}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải báo cáo: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal CalculateTotal(DataTable data)
        {
            decimal total = 0;
            foreach (DataRow row in data.Rows)
            {
                total += Convert.ToDecimal(row["Amount"]);
            }
            return total;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng in báo cáo sẽ được triển khai sau", 
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}