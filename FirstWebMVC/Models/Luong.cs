using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FirstWebMVC.Models
{
    public class Luong
    {
        [Key]
        public string LuongID { get; set; }
        public string SoLuong { get; set; }
    }
}