using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models
{
    public class Size
    {
        [Key]
        public int ID { get; set; }
        public int size { get; set; }
        [Column(TypeName = "Nvarchar")]
        public string Text { get; set; }
        public int ProductTypeID { get; set; }
        [ForeignKey("ProductTypeID")]
        public virtual ProductType ProductType { get; set; }
    }
}