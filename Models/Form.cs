using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace Project.Models
{
    public class Form
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="Nvarchar")]
        [StringLength(50)]
        public string Name { get; set; }
    }
}