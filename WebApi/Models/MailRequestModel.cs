namespace EmailSender.WebApi.Models
{
    public class MailRequestModel
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public ICollection<string> Recipients { get; set; }
    }
}
