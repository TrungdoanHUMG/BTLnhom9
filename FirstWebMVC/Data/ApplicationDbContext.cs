using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Models;
namespace FirstWebMVC.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {}
        public DbSet<FirstWebMVC.Models.Sale> Sale { get; set; } = default!;

        public DbSet<FirstWebMVC.Models.Staff> Staff { get; set; } = default!;

        public DbSet<FirstWebMVC.Models.SaleViTri> SaleViTri { get; set; } = default!;

        public DbSet<FirstWebMVC.Models.StaffViTri> StaffViTri { get; set; } = default!;

        public DbSet<FirstWebMVC.Models.Luong> Luong { get; set; } = default!;

        public DbSet<FirstWebMVC.Models.HopDong> HopDong { get; set; } = default!;

        public DbSet<FirstWebMVC.Models.CongNhan> CongNhan { get; set; } = default!;
        public DbSet<FirstWebMVC.Models.Ceo> Ceo { get; set; } = default!;
    
    }
}