using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Models;
namespace FirstWebMVC.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {}
       public DbSet<DanhSachCongNhan> DanhSachCongNhan { get; set;}
    }
}