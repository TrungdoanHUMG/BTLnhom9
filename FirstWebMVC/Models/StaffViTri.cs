using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstWebMVC.Models
{
    public class StaffViTri
    {
        [Key]
        public string ViTriStaffID { get; set; }
        public string VitriStaff { get; set; }
    }
}