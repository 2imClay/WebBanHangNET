using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using WebBanHang.Model;

namespace WebBanHang.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên người dùng là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên người dùng không được quá 100 ký tự")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [Required(ErrorMessage = "Email là bắt buộc")]
        public String Email { get; set; }

        [PasswordPropertyText]
        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        public String Password { get; set; }

        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Số điện thoại chỉ được chứa ký tự số")]
        public String Phone { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        public int RoleId { get; set; }
    }
}
