using System;
using System.Data;
using Microsoft.Data.SqlClient;
using FinanceApp.Models;

namespace FinanceApp.Helpers
{
    public static class DatabaseHelperExtensions
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FinanceApp"].ConnectionString);
        }

        public static User GetUser(int userId)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT * FROM Users WHERE Id = @userId", 
                    conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            Id = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            Email = reader.GetString(3),
                            FullName = reader.GetString(4)
                        };
                    }
                }
            }
            return new User {
                Id = 0,
                Username = string.Empty,
                Password = string.Empty,
                Email = string.Empty,
                FullName = string.Empty
            };
        }

        public static bool UpdateUserProfile(int userId, string email, string fullName)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "UPDATE Users SET Email = @email, FullName = @fullName WHERE Id = @userId", 
                    conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@fullName", fullName);
                cmd.Parameters.AddWithValue("@userId", userId);
                
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public static bool ValidateUser(string username, string password)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password", 
                    conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                
                return (int)cmd.ExecuteScalar() > 0;
            }
        }
        public static bool ChangePassword(int userId, string currentPassword, string newPassword)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "UPDATE Users SET Password = @newPassword WHERE Id = @userId AND Password = @currentPassword", 
                    conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@currentPassword", currentPassword);
                cmd.Parameters.AddWithValue("@newPassword", newPassword);
                
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public static List<IncomeCategory> GetIncomeCategories()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM IncomeCategories", conn);
                var categories = new List<IncomeCategory>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categories.Add(new IncomeCategory {
                            IncomeCategoryId = reader.GetInt32(0),
                            CategoryName = reader.GetString(1)
                        });
                    }
                }
                return categories;
            }
        }

        public static List<ExpenseCategory> GetExpenseCategories()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM ExpenseCategories", conn);
                var categories = new List<ExpenseCategory>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categories.Add(new ExpenseCategory {
                            ExpenseCategoryId = reader.GetInt32(0),
                            CategoryName = reader.GetString(1)
                        });
                    }
                }
                return categories;
            }
        }

        public static List<Wallet> GetUserWallets(int userId)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Wallets WHERE UserId = @userId", conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                var wallets = new List<Wallet>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        wallets.Add(new Wallet {
                            WalletId = reader.GetInt32(0),
                            WalletName = reader.GetString(1),
                            Balance = reader.GetDecimal(2)
                        });
                    }
                }
                return wallets;
            }
        }

        public static bool SaveTransaction(Transaction transaction)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "INSERT INTO Transactions (UserId, Amount, Description, TransactionDate, WalletId, IncomeCategoryId, ExpenseCategoryId) " +
                    "VALUES (@userId, @amount, @description, @date, @walletId, @incomeCatId, @expenseCatId)", 
                    conn);
                
                cmd.Parameters.AddWithValue("@userId", transaction.UserId);
                cmd.Parameters.AddWithValue("@amount", transaction.Amount);
                cmd.Parameters.AddWithValue("@description", transaction.Description);
                cmd.Parameters.AddWithValue("@date", transaction.TransactionDate);
                cmd.Parameters.AddWithValue("@walletId", transaction.WalletId);
                cmd.Parameters.AddWithValue("@incomeCatId", transaction.IncomeCategoryId ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@expenseCatId", transaction.ExpenseCategoryId ?? (object)DBNull.Value);
                
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public static bool RegisterUser(string username, string password, string email, string fullName)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "INSERT INTO Users (Username, Password, Email, FullName) " +
                    "VALUES (@username, @password, @email, @fullName)", 
                    conn);
                
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@fullName", fullName);
                
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
