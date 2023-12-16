using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FirstWebMVC.Models
{
    public class Ceo
    {
        [Key]
        [Required(ErrorMessage ="ID không được bỏ trống")]
        public string CeoID{ get; set; }
        [Required(ErrorMessage ="Họ Và Tên không được bỏ trống")]
        [Display(Name = "Họ và tên")]
        public string CeoName { get; set; }
        [Required(ErrorMessage =" SĐT Không được bỏ trống")]
        [Display(Name = "SĐT")]
        public string CeoPhoneNumber{ get; set; }
        [Required(ErrorMessage =" Địa chỉ Không được bỏ trống")]
        [Display(Name = "Địa chỉ")]
        public string CeoAddress{ get; set; }
        [Display(Name = "Ngày Sinh")]
        public string CeoBirth{ get; set; }
        [Display(Name = "Giới tính")]
        public string CeoSex{ get; set; }
        [Required(ErrorMessage =" Tài khoản Ngân hàng Không được bỏ trống")]
        [Display(Name = "TK Ngân hàng BIDV")]
        public string CeoBank{ get; set; }
        [Required(ErrorMessage =" Số Căn Cước Không được bỏ trống")]
        [Display(Name ="Số Căn Cước")]
        public string CeoCCCD { get; set; }
        public string ViTriCeoID { get; set; }
        [ForeignKey("ViTriCeoID")]
        [Display(Name = "Vị Trí")]
        public string LuongID { get; set; }
        [ForeignKey("LuongID")]
        [Display(Name = "Lương")]
        public Luong? Luong { get; set; }
        public string HopDongID { get; set; }
        [ForeignKey("HopDongID")]
        [Display(Name = "Hợp đồng")]
        public HopDong? HopDong { get; set; }
        [Display(Name = "Ngày làm")]
        public string CeoStart{ get; set; }
        [Display(Name = "Ngày hết hợp đồng")]
        public string CeoEnd{ get; set; }
    }
}