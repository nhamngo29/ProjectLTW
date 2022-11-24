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
        [Key, Column(Order = 0)]
        [Required]
        public int ID { get; set; }
        [Key, Column(Order = 1, TypeName = "varchar")]
        [Required]
        [StringLength(40)]
        public string IdProduct { get; set; }
        public double TotalMoney { get; set; }
        [ForeignKey("ID")]
        public virtual Order Order { get; set; }
        [ForeignKey("IdProduct")]
        public virtual Product Product { get; set; }
    }
}