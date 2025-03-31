using System;
using System.Windows.Forms;
using FinanceApp;

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        
        // Initialize database connection
        try 
        {
            // Show login form
            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Login successful, show main form
                    Application.Run(new MainForm());
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Khởi động ứng dụng thất bại: {ex.Message}", 
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}