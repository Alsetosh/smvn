using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using smvn.Areas.Admin.Models;

namespace smvn.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<tblMenu> Menus { get; set; }

        public DbSet<tblKhoa> Khoas { get; set; }
        public DbSet<AdminMenu> AdminMenus { get; set; }
    }
}