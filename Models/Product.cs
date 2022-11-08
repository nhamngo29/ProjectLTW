using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models
{
    public class Product
    {
        [Key]
        [Display(Name = "Mã sản phẩm")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }//Mã sản phẩm
        [Column(TypeName="nvarchar")]
        [Display(Name="Tên sản phẩm")]
        public string Name { get; set; }//Tên sản phẩm
        [Display(Name="Giá sản phẩm")]
        [Column(TypeName ="float")]
        public double Price { get; set; }//Giá sản phẩm
        [Display(Name="Phần tram giảm")]
        public float Promotion { get; set; }//Phần trăm giảm của sản phẩm
        [Display(Name="Bao gồm thuế")]
        public bool IncludeVAT { get; set; }//Thuế
        [Display(Name="Số lượng")]
        public int Quantity { get; set; }//Số lượng
        [Column(TypeName ="nvarchar")]
        [Display(Name="Tình trạng")]
        public string Status { get; set; }//Tình trạng
        public bool Favorite { get; set; }//Yêu thích

        public int CategoryID { get; set; }
        public int BrandID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        [ForeignKey("BrandID")]
        public virtual Brand Brand { get; set; }
    }
}