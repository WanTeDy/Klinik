using System.Data.Entity;
using Klinik.Utils.DataBase.Emails;
using Klinik.Utils.DataBase.Products;
using Klinik.Utils.DataBase.Security;

namespace Klinik.Utils.DataBase
{
    public class DbKlinik : DbContext
    {
        public DbKlinik()
        //:base("Local")
        :base("smarter")
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        //public DbSet<PageDescription> PageDescriptions { get; set; }
        //public DbSet<Category> Categories { get; set; }
        public DbSet<UserEmailMessage> Emails { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}