using System;
using System.Windows.Forms;
using FinanceApp.Models;

namespace FinanceApp
{
    public partial class AccountManagementForm : Form
    {
        public AccountManagementForm()
        {
            InitializeComponent();
            LoadUserData();
        }

        private void LoadUserData()
        {
            var user = Helpers.DatabaseHelperExtensions.GetUser(CurrentUser.UserId);
            if (user != null)
            {
                txtUsername.Text = user.Username;
                txtEmail.Text = user.Email;
                txtFullName.Text = user.FullName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Helpers.DatabaseHelperExtensions.UpdateUserProfile(
                    CurrentUser.UserId,
                    txtEmail.Text,
                    txtFullName.Text))
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}