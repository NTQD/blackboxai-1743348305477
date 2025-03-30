using System;
using System.Windows.Forms;

public partial class LoginForm : Form
{
    public LoginForm()
    {
        InitializeComponent();
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        int? userId = DatabaseHelper.AuthenticateUser(username, password);
        if (userId.HasValue)
        {
            CurrentUser.UserId = userId.Value;
            CurrentUser.Username = username;
            
            this.Hide();
            var mainForm = new MainForm();
            mainForm.Show();
        }
        else
        {
            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        this.Hide();
        var registerForm = new RegistrationForm();
        registerForm.Show();
    }
}