using Microsoft.EntityFrameworkCore;
using Task5_Messages.EF.Entities;

namespace Task5_Messages.EF
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Message> Messages { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Message>()
                .HasOne(x => x.Author)
                .WithMany(x => x.SentMessages)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Message>()
                .HasOne(x => x.Recipient)
                .WithMany(x => x.ReceivedMessages)
                .HasForeignKey(x => x.RecipientId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
