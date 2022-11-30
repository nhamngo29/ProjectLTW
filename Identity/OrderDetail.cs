using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Project.Models;
namespace Project.Identity
{
    public class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdOrder { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "varchar")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(40)]
        public string IdProductt { get; set; }
        public int? Count { get; set; }
        public Nullable<double> Price { get; set; }//Giá sản phẩm
        public Nullable<double> Thanhtien { get; set; }//Giá sản phẩm
        [ForeignKey("IdOrder")]
        public virtual Order Order { get; set; }
        [ForeignKey("IdProductt")]
        public virtual Product Product { get; set; }
    }
}