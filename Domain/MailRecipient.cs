using System.Diagnostics.Contracts;

namespace EmailSender.Domain
{
    public class MailRecipient
    {
        public Guid MailId { get; set; }
        public virtual Mail Mail { get; set; }

        public Guid RecipientId { get; set; }
        public virtual Recipient Recipient { get; set; }
    }
}
