using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstWebMVC.Models
{
    [Table("DanhSachCongNhan")]
    public class DanhSachCongNhan
    {
        [Key]
        public string MaNV { get; set; }
        public string FullName { get; set; }
        public string Vitri { get; set; }
        public string Luong { get; set; }
        public string Trangthai { get; set; }
    }
}