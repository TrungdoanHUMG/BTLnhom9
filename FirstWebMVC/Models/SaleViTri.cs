using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FirstWebMVC.Models
{
    public class SaleViTri
    {
        [Key]
        public string ViTriSaleID { get; set; }
        public string VitriSale { get; set; }
    }
}