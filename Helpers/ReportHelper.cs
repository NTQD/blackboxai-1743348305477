using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace FinanceApp.Helpers
{
    public static class ReportHelper
    {
        public static DataTable GetIncomeReport(int userId)
        {
            using (var conn = Helpers.DatabaseHelperExtensions.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT * FROM Transactions WHERE UserId = @userId AND Type = 'Income'", 
                    conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
        }

        public static DataTable GetExpenseReport(int userId)
        {
            using (var conn = Helpers.DatabaseHelperExtensions.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT * FROM Transactions WHERE UserId = @userId AND Type = 'Expense'", 
                    conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
        }
        public static DataTable GetTransactionsByDateRange(int userId, DateTime startDate, DateTime endDate)
        {
            using (var conn = Helpers.DatabaseHelperExtensions.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT * FROM Transactions WHERE UserId = @userId AND Date BETWEEN @startDate AND @endDate ORDER BY Date DESC", 
                    conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
        }
    }
}
