using System;
using System.Windows.Forms;

public partial class ChangePasswordForm : Form
{
    public ChangePasswordForm()
    {
        InitializeComponent();
    }

    private void btnChangePassword_Click(object sender, EventArgs e)
    {
        if (txtNewPassword.Text != txtConfirmPassword.Text)
        {
            MessageBox.Show("Mật khẩu mới không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (DatabaseHelper.ChangePassword(CurrentUser.UserId, txtCurrentPassword.Text, txtNewPassword.Text))
        {
            MessageBox.Show("Đổi mật khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        else
        {
            MessageBox.Show("Mật khẩu hiện tại không đúng hoặc có lỗi xảy ra!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }
}