namespace EmailSender.Domain
{
    public class Recipient:IEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<MailRecipient> MailRecipients { get; set; }
    }
}
