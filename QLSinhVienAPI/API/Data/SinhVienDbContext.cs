using Microsoft.EntityFrameworkCore;
using API.Models;
namespace API.Data
{


    public class SinhVienDbContext : DbContext
    {
        public SinhVienDbContext(DbContextOptions<SinhVienDbContext> options) : base(options)
        {
        }

        public DbSet<SinhVien> dsSinhVien { get; set; }
        public DbSet<Khoa> dsKhoa { get; set; }

    }
}