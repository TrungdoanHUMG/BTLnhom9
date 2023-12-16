using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FirstWebMVC.Models
{
    public class Staff
    {
        [Key]
        [Required(ErrorMessage ="ID không được bỏ trống")]
        public string StaffID{ get; set; }
        [Required(ErrorMessage ="Họ Và Tên không được bỏ trống")]
        [Display(Name = "Họ và tên")]
        public string StaffName { get; set; }
        [Required(ErrorMessage =" SĐT Không được bỏ trống")]
        [Display(Name = "SĐT")]
        public string StaffPhoneNumber{ get; set; }
        [Required(ErrorMessage =" Địa chỉ Không được bỏ trống")]
        [Display(Name = "Địa chỉ")]
        public string StaffAddress{ get; set; }
        [Display(Name = "Ngày Sinh")]
        public string StaffBirth{ get; set; }
        [Display(Name = "Giới tính")]
        public string StaffSex{ get; set; }
        [Required(ErrorMessage =" Tài khoản Ngân hàng Không được bỏ trống")]
        [Display(Name = "TK Ngân hàng BIDV")]
        public string StaffBank{ get; set; }
        [Required(ErrorMessage =" Số Căn Cước Không được bỏ trống")]
        [Display(Name ="Số Căn Cước")]
        public string StaffCCCD { get; set; }
        public string ViTriStaffID { get; set; }
        [ForeignKey("ViTriStaffID")]
        [Display(Name = "Vị Trí")]
        public StaffViTri? StaffViTri { get; set; }
        public string LuongID { get; set; }
        [ForeignKey("LuongID")]
        [Display(Name = "Lương")]
        public Luong? Luong { get; set; }
        public string HopDongID { get; set; }
        [ForeignKey("HopDongID")]
        [Display(Name = "Hợp đồng")]
        public HopDong? HopDong { get; set; }
        [Display(Name = "Ngày làm")]
        public string StaffStart{ get; set; }
        [Display(Name = "Ngày hết hợp đồng")]
        public string StaffEnd{ get; set; }
    }
}