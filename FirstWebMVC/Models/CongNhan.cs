using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FirstWebMVC.Models
{
    public class CongNhan
    {
        [Key]
        [Required(ErrorMessage ="Mã Nhân Viên không được bỏ trống")]
        [Display(Name ="Mã Nhân Viên")]
        public string? MaCongNhan {get; set;}
        [Required(ErrorMessage ="Phòng Ban không được bỏ trống")]
        [Display(Name ="Tên")]
        public string? PhongBan {get; set;}
          
        [Display(Name ="Vị Trí")]
        public string? ViTri {get; set;}
        
        [Required(ErrorMessage ="Lương không được bỏ trống")]
        [Display(Name ="Lương")]
        public string? Luong {get; set;}

        [Required(ErrorMessage ="Trạng Thái không được bỏ trống")]
        [Display(Name ="Trạng Thái")]
        
        public string? TrangThai {get; set;}
    }
}