using EmailSender.Domain;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Services.Models
{
    public class MailDTO
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
        public string Result { get; set; }
        public string FailedMessage { get; set; }
        public ICollection<MailRecipient> MailRecipients { get; set; }
    }
}
