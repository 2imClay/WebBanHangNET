using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên sản phẩm không được vượt quá 100 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Giá sản phẩm là bắt buộc")]
        [Range(0.01, 9999999.99, ErrorMessage = "Giá sản phẩm phải từ 0.01 đến 9999999.99")]
        public decimal Price { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự")]
        public string Description { get; set; }

        [StringLength(50, ErrorMessage = "Màu sắc không được vượt quá 50 ký tự")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Số lượng là bắt buộc")]
        [Range(1, 9999, ErrorMessage = "Số lượng phải từ 1 đến 9999")]
        public int Quantity { get; set; }

        [StringLength(10, ErrorMessage = "Kích thước không được vượt quá 10 ký tự")]
        public string Size { get; set; }

        [Required(ErrorMessage = "Loại sản phẩm là bắt buộc")]
        public string Category { get; set; }

        public string Sex { get; set; }

        public string imageURL { get; set; }
    }


}