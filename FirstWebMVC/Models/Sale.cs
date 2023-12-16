using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FirstWebMVC.Models
{
    public class Sale
    {
        [Key]
        [Required(ErrorMessage ="ID không được bỏ trống")]
        public string SaleID{ get; set; }
        [Required(ErrorMessage ="Họ Và Tên không được bỏ trống")]
        [Display(Name = "Họ và tên")]
        public string SaleName { get; set; }
        [Required(ErrorMessage =" SĐT Không được bỏ trống")]
        [Display(Name = "SĐT")]
        public string SalePhoneNumber{ get; set; }
        [Required(ErrorMessage =" Địa chỉ Không được bỏ trống")]
        [Display(Name = "Địa chỉ")]
        public string SaleAddress{ get; set; }
        [Display(Name = "Ngày Sinh")]
        public string SaleBirth{ get; set; }
        [Display(Name = "Giới tính")]
        public string SaleSex{ get; set; }
        [Required(ErrorMessage =" Tài khoản Ngân hàng Không được bỏ trống")]
        [Display(Name = "TK Ngân hàng BIDV")]
        public string SaleBank{ get; set; }
        [Required(ErrorMessage =" Số Căn Cước Không được bỏ trống")]
        [Display(Name ="Số Căn Cước")]
        public string SaleCCCD { get; set; }
        public string ViTriSaleID { get; set; }
        [ForeignKey("ViTriSaleID")]
        [Display(Name = "Vị Trí")]
        public SaleViTri? SaleViTri { get; set; }
        public string LuongID { get; set; }
        [ForeignKey("LuongID")]
        [Display(Name = "Lương")]
        public Luong? Luong { get; set; }
        public string HopDongID { get; set; }
        [ForeignKey("HopDongID")]
        [Display(Name = "Hợp đồng")]
        public HopDong? HopDong { get; set; }
        [Display(Name = "Ngày làm")]
        public string SaleStart{ get; set; }
        [Display(Name = "Ngày hết hợp đồng")]
        public string SaleEnd{ get; set; }
    }
}