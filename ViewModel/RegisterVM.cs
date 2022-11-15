using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Project.ViewModel
{
    public class RegisterVM
    {
        [Display(Name ="Tên đăng nhập")]
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu đăng nhập")]
        public string Password { get; set; }
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; }
        [Display(Name = "Giới tính")]
        public string Gender { get; set; }
        [Display(Name = "Nhập lại mật khẩu")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Điện thoại")]
        public string Mobile { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime? DateOfBirth { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Thành phố")]
        public string City { get; set; }
    }
}