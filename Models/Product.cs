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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [Display(Name="Bao gồm thuế")]
        public bool IncludeVAT { get; set; }//Thuế
        [Display(Name="Số lượng")]
        public Nullable<int> Quantity { get; set; }//Số lượng
        public Nullable<bool> Featured { get; set; }//sản phẩm nổi bật
        public Nullable<System.DateTime> DateCreate { get; set; }//Tình trạng
        public Nullable<int> Evaluate { get; set; }//Đánh giá
        public string ImgeMain { get; set; }//hình ảnh chính
        public int ProductTypeID { get;set ; }
        public Nullable<int> TotalSold { get; set; }//số sp đã bán
        [DefaultValue(0)]
        public Nullable<int> FormId { get; set; }
        [ForeignKey("FormId")]
        public virtual Form Form { get; set; }    
        public Nullable<int> BrandID { get; set; }
        [ForeignKey("BrandID")]
        public virtual Brand Brand { get; set; }
        [ForeignKey("ProductTypeID")]
        public virtual ProductType ProductType { get; set; }//Khóa ngoại của bảng ProductType
        [DefaultValue(false)]
        public bool IsHot { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        [StringLength(250)]
        public string SeoTitle { get; set; }
        [StringLength(500)]
        public string SeoDescription { get; set; }
        [StringLength(250)]
        public string SeoKeywords { get; set; }
        [AllowHtml]
        public string Detail { get; set; }
        public string Description { get; set; }
    }
}