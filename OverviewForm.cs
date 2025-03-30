using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

public partial class OverviewForm : Form
{
    public OverviewForm()
    {
        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        // Load wallet balances
        LoadWallets();

        // Load recent transactions
        LoadRecentTransactions();

        // Load charts
        LoadCharts();
    }

    private void LoadWallets()
    {
        // Implement wallet loading
    }

    private void LoadRecentTransactions()
    {
        // Implement transaction loading
    }

    private void LoadCharts()
    {
        // Create summary DataGridView
        var summaryGrid = new DataGridView
        {
            Dock = DockStyle.Top,
            Height = 200,
            ReadOnly = true,
            AllowUserToAddRows = false
        };

        // Add columns
        summaryGrid.Columns.Add("Category", "Danh mục");
        summaryGrid.Columns.Add("Amount", "Số tiền");
        summaryGrid.Columns.Add("Percentage", "Tỷ lệ");

        // Add sample data
        summaryGrid.Rows.Add("Thu nhập", "10,000,000", "40%");
        summaryGrid.Rows.Add("Ăn uống", "3,000,000", "12%");
        summaryGrid.Rows.Add("Di chuyển", "2,000,000", "8%");
        summaryGrid.Rows.Add("Nhà ở", "5,000,000", "20%");
        summaryGrid.Rows.Add("Tiết kiệm", "5,000,000", "20%");

        // Formatting
        summaryGrid.Columns["Amount"].DefaultCellStyle.Alignment = 
            DataGridViewContentAlignment.MiddleRight;
        summaryGrid.Columns["Percentage"].DefaultCellStyle.Alignment = 
            DataGridViewContentAlignment.MiddleRight;

        this.Controls.Add(summaryGrid);
    }
}