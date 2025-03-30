using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public static class DatabaseHelper
{
    private static string connectionString = ConfigurationManager.ConnectionStrings["FinanceAppDB"].ConnectionString;

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }

    public static bool RegisterUser(string username, string password, string email, string fullName)
    {
        using (var conn = GetConnection())
        {
            conn.Open();
            string query = "INSERT INTO [User] (UserName, PasswordHash, Email, FullName) VALUES (@username, @password, @email, @fullName)";
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", HashPassword(password));
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@fullName", fullName);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public static int? AuthenticateUser(string username, string password)
    {
        using (var conn = GetConnection())
        {
            conn.Open();
            string query = "SELECT UserId FROM [User] WHERE UserName = @username AND PasswordHash = @password";
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", HashPassword(password));
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : (int?)null;
            }
        }
    }

    public static DataTable GetTransactionsByUser(int userId, DateTime? startDate = null, DateTime? endDate = null)
    {
        using (var conn = GetConnection())
        {
            conn.Open();
            string query = @"SELECT t.TransactionId, t.TransactionDate, 
                           CASE 
                               WHEN t.IncomeCategoryId IS NOT NULL THEN 'Thu' 
                               ELSE 'Chi' 
                           END AS Type,
                           COALESCE(ic.CategoryName, ec.CategoryName) AS Category,
                           t.Amount, t.Description, w.WalletName
                           FROM [Transaction] t
                           LEFT JOIN IncomeCategory ic ON t.IncomeCategoryId = ic.IncomeCategoryId
                           LEFT JOIN ExpenseCategory ec ON t.ExpenseCategoryId = ec.ExpenseCategoryId
                           LEFT JOIN Wallet w ON t.WalletId = w.WalletId
                           WHERE t.UserId = @userId";

            if (startDate != null && endDate != null)
            {
                query += " AND t.TransactionDate BETWEEN @startDate AND @endDate";
            }

            query += " ORDER BY t.TransactionDate DESC";

            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@userId", userId);
                if (startDate != null && endDate != null)
                {
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);
                }

                var adapter = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }

    private static string HashPassword(string password)
    {
        using (var sha256 = System.Security.Cryptography.SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
}