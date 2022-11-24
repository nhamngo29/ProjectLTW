using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace Project.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Tên thể loại")]
        [Required(ErrorMessage ="Tên danh mục chưa được nhập")]
        public string Name { get; set; }
    }
}