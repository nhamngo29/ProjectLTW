using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Web.Mvc;

namespace Project.Models
{
    public class Product
    {
        [Key]
        [Display(Name = "Mã sản phẩm")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName ="varchar")]
        [StringLength(40)]
        public string ProductId { get; set; }//Mã sản phẩm
        [Column(TypeName="nvarchar")]
        [Display(Name="Tên sản phẩm")]
        public string Name { get; set; }//Tên sản phẩm
        [Display(Name="Giá sản phẩm")]
        [DisplayFormat(DataFormatString ="{0:0,0 đ}")]
        public Nullable<double> Price { get; set; }//Giá sản phẩm
        [Display(Name="Phần tram giảm")]
        public Nullable<float> Promotion { get; set; }//Phần trăm giảm của sản phẩm
        [Display(Name="Số lượng")]
        public Nullable<int> Quantity { get; set; }//Số lượng
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        [Display(Name = "Ngày bán sản phẩm")]
        public Nullable<System.DateTime> DateCreate { get; set; }//Tình trạng
        [Display(Name = "Sao đánh giá")]
        public Nullable<int> Evaluate { get; set; }//Đánh giá
        [Display(Name = "Ảnh đại diện")]
        public string ImgeMain { get; set; }//hình ảnh chính
        [Display(Name = "Loại sản phẩm")]
        public int ProductTypeID { get;set ; }
        public bool Featured { get; set; }
        [Display(Name = "đã bán")]
        public Nullable<int> TotalSold { get; set; }//số sp đã bán
        public Nullable<int> BrandID { get; set; }
        [ForeignKey("BrandID")]
        public virtual Brand Brand { get; set; }
        [ForeignKey("ProductTypeID")]
        public virtual ProductType ProductType { get; set; }//Khóa ngoại của bảng ProductType
        [DefaultValue(false)]
        public bool IsHot { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        [AllowHtml]
        public string Detail { get; set; }
        public string Description { get; set; }
    }
}