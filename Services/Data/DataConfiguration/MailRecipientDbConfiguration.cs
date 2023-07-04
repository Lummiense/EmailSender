using EmailSender.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmailSender.Services.Data.DataConfiguration
{
    public class MailRecipientDbConfiguration: IEntityTypeConfiguration<MailRecipient>
    {
        public void Configure(EntityTypeBuilder<MailRecipient> builder)
        {
            builder.HasKey(k => new {k.MailId,k.RecipientId});
            builder.HasOne(m => m.Mail).WithMany(mr => mr.MailRecipients).HasForeignKey(fk => fk.MailId);
            builder.HasOne(r => r.Recipient).WithMany(mr => mr.MailRecipients).HasForeignKey(fk => fk.RecipientId);
        }
    }
}
