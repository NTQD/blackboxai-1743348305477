using System;
using System.Windows.Forms;

public partial class RegistrationForm : Form
{
    public RegistrationForm()
    {
        InitializeComponent();
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text;
        string confirmPassword = txtConfirmPassword.Text;
        string email = txtEmail.Text.Trim();
        string fullName = txtFullName.Text.Trim();

        if (password != confirmPassword)
        {
            MessageBox.Show("Mật khẩu xác nhận không khớp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (DatabaseHelper.RegisterUser(username, password, email, fullName))
        {
            MessageBox.Show("Đăng ký thành công! Vui lòng đăng nhập.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        else
        {
            MessageBox.Show("Đăng ký không thành công. Tên đăng nhập hoặc email có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        this.Close();
    }
}