namespace WebBanHang.Models
{
    public class UserService
    {
        public bool Register(User user)
        {
            UserConnector userConnector = new UserConnector();

            // Kiểm tra xem người dùng đã tồn tại chưa
            if (userConnector.FindByEmail(user.Email) != null)
            {
                return false;  // Người dùng đã tồn tại
            }

            // Hash mật khẩu trước khi lưu
            user.Password = HashPassword(user.Password);
            return userConnector.Save(user);
        }

        public bool Login(User user)
        {
            UserConnector userConnector = new UserConnector();
            User temp = userConnector.FindByEmail(user.Email);
            if (temp == null)
            {
                return false;  // Không tìm thấy người dùng với email này
            }

            return VerifyPassword(user.Password, temp.Password);
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            // Kiểm tra xem mật khẩu đã nhập có khớp với mật khẩu đã hash hay không
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
