using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Identity
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        public DateTime? PurchaseDate { get; set; }//Ngày mua
        [Required]
        [DefaultValue(0)]
        [Display(Name = "Tổng tiền")]
        public double Total { get; set; }//Tổng tiền
        [Display(Name = "Trạng thái")]
        [DefaultValue(0)]
        public int Status { get; set; } //--0 chưa xác định
        [Column(TypeName = "nvarchar")]
        [StringLength(128)]
        public string IdUser { get; set; }
        [ForeignKey("IdUser")]
        public AppUser AppUser { get; set; }
    }
}