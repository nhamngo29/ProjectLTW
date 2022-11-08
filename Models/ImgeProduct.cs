using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models
{
    public class ImgeProduct
    {
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key, Column(Order = 1)]
        
        public int ProductId { get; set; }
        public string Path { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}