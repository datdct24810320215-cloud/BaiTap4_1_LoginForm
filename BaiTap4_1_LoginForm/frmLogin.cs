using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BaiTap4_1_LoginForm
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        // 1. Sự kiện CheckBox: Ẩn/Hiện mật khẩu
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu tick chọn -> Hiện mật khẩu (false)
            // Nếu bỏ chọn -> Ẩn mật khẩu (true)
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        // 2. Validation cho txtUsername (Kiểm tra dữ liệu)
        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                e.Cancel = true; // Giữ con trỏ tại ô nhập liệu
                errorProvider1.SetError(txtUsername, "Tên đăng nhập không được để trống!");
            }
            else
            {
                errorProvider1.SetError(txtUsername, ""); // Xóa lỗi nếu hợp lệ
            }
        }

        // 3. Validation cho txtPassword
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                e.Cancel = true; // Giữ con trỏ tại ô nhập liệu
                errorProvider1.SetError(txtPassword, "Mật khẩu không được để trống!");
            }
            else
            {
                errorProvider1.SetError(txtPassword, ""); // Xóa lỗi nếu hợp lệ
            }
        }

        // 4. Sự kiện Click nút Đăng nhập
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Kích hoạt kiểm tra validation cho tất cả các control con
            if (this.ValidateChildren())
            {
                // Nếu tất cả dữ liệu hợp lệ
                MessageBox.Show("Đăng nhập thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Nếu có lỗi, ValidateChildren() sẽ tự động ngăn chặn
                MessageBox.Show("Vui lòng kiểm tra lại thông tin đăng nhập!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 5. Sự kiện Click nút Thoát
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close(); // Đóng Form
            }
        }
    }
}