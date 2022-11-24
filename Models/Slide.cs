using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace Project.Models
{
    public class Slide
    {
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName ="nvarchar")]
        public string Image { get; set; }
        [DefaultValue(false)]
        public Boolean Active { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(40)]
        public string ProductId { get; set; }//Mã sản phẩm
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}