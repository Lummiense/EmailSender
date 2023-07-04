﻿using EmailSender.Domain;

namespace EmailSender.Services.Contracts
{
    public class RecipientDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<MailRecipient> MailRecipients { get; set; }
    }
}
