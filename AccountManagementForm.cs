using System;
using System.Windows.Forms;

public partial class AccountManagementForm : Form
{
    public AccountManagementForm()
    {
        InitializeComponent();
        LoadUserInfo();
    }

    private void LoadUserInfo()
    {
        txtUsername.Text = CurrentUser.Username;
        txtEmail.Text = CurrentUser.Email;
        txtFullName.Text = CurrentUser.FullName;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (!ValidateInputs())
            return;

        try
        {
            CurrentUser.Email = txtEmail.Text;
            CurrentUser.FullName = txtFullName.Text;
            
            if (DatabaseHelper.UpdateUserInfo(CurrentUser.UserId, 
                CurrentUser.Email, CurrentUser.FullName))
            {
                MessageBox.Show("Cập nhật thông tin thành công", 
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi cập nhật thông tin: {ex.Message}", 
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnChangePassword_Click(object sender, EventArgs e)
    {
        var changePassForm = new ChangePasswordForm();
        if (changePassForm.ShowDialog() == DialogResult.OK)
        {
            MessageBox.Show("Đổi mật khẩu thành công", 
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private bool ValidateInputs()
    {
        if (string.IsNullOrWhiteSpace(txtEmail.Text))
        {
            MessageBox.Show("Vui lòng nhập email", 
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtFullName.Text))
        {
            MessageBox.Show("Vui lòng nhập họ tên", 
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }
}