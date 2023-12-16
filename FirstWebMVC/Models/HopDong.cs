using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstWebMVC.Models
{
    [Table("HopDong")]
    public class HopDong
    {
        [Key]
        public string HopDongID { get; set; }
        public string TimeHopDong { get; set; }
    }
}