using Microsoft.AspNetCore.Mvc;

namespace EmailSender.WebApi.Models
{
    public class MailResponseModel
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
        public string Result { get; set; }
        public string FailedMessage { get; set; }
        public ICollection<string> Recipients { get; set; }
    }
}
