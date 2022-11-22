using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Identity
{
    public class UserCart
    {
        public int ID { get => ID; set { 
                Random r = new Random();
                ID= r.Next(-9999,9999);
            } }
        //[DefaultValue(DateTime.Now.ToString())]
        public DateTime? PurchaseDate { get; set; }//Ngày mua
        [Required]
        [DefaultValue(0)]
        [Display(Name = "Tổng tiền")]
        public double Total { get; set; }//Tổng tiền
        [Display(Name = "Trạng thái")]
        [DefaultValue(0)]
        public int Status { get; set; } //--0 chưa xác định
                                        //--1 Đang xác nhận
                                        //--2 Đã giao
                                        //--3 Đã hủy
    }
}