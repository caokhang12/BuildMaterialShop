using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BMShop.Models
{
    public class RegisterModel
    {
        [Key] public long iD { get; set; }   
        
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage ="Yêu cầu nhập tên đăng nhập")]
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage ="Yêu cầu nhập mật khẩu")]
        [StringLength(20,MinimumLength = 6,ErrorMessage ="Cần nhập ít nhất 6 ký tự")]
        public string Password { get; set; }
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password",ErrorMessage ="Xác nhận mật khẩu không đúng")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage ="Yêu cầu nhập họ tên")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage ="Yêu cầu nhập email")]
        public string Email { get; set; }
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
    }
}