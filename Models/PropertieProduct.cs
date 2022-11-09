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
        [Index(IsUnique = true)]
        public Nullable<int> Size { get; set; }
        [Index(IsUnique = true)]
        public Nullable<int> Color { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        //
    }
}