using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models
{
    public class PropertieProduct
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(40)]
        public string ProductId { get; set; }//Mã sản phẩm
        [Index()]
        public Nullable<int> Quantity { get; set; }
        [Column(TypeName ="nvarchar")]
        [StringLength(41)]
        public string Size { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string Color { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        //
    }
}