using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models
{
    //Chi tiết sản phảm
    public class Detail
    {
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key,Column(Order =1)]
        public int ProductID { get; set; }
        [Column(TypeName ="Nvarchar")] 
        public string Text { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}