using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Project.Models;
namespace Project.Identity
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(128)]
        public string IdUser { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(40)]
        public string IdProduct { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("IdUser")]
        public virtual AppUser AppUser { get; set; }
        [ForeignKey("IdProduct")]
        public virtual Product Product { get; set; }
    }
}