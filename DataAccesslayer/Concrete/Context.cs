using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesslayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // bu metodun içerisinde biz connectionstringimizi tanımlıcaz
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-61LIS6H;database=BlogProjectDb;integrated security = true");
        }
        //notlarla maç örneği var ona bak HomeMatches>WriteSender,AwayMatches>WriteReceiver | HomeTeam>SenderUser,GuestTeam>xReceiveruser
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message2>()  //Gönderici
                .HasOne(x => x.SenderUser)
                .WithMany(y => y.WriteSender)
                .HasForeignKey(z => z.SenderID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message2>()  //Alıcı
                .HasOne(x => x.ReceiverUser)
                .WithMany(y => y.WriteReceiver)
                .HasForeignKey(z => z.ReceiverID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder); //identity migration u hata vermesin diye yazdık tekrar
        }

        public DbSet<About> Abouts { get; set; }  
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter> Newsletters { get; set; }
        public DbSet<BlogRayting> BlogRaytings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Message2> Messages2s { get; set; }
        public DbSet<Admin> Admins { get; set; }


    }
}
