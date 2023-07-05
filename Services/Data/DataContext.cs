using EmailSender.Domain;
using EmailSender.Services.Data.DataConfiguration;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Cms;
using System.ComponentModel;

namespace EmailSender.Services.Data
{
    /// <summary>
    /// Класс конфигурации таблиц базы данных.
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Recipient> Recipients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MailRecipientDbConfiguration());
        }
    }
}
