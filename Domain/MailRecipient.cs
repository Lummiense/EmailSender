﻿using Org.BouncyCastle.Cms;

namespace EmailSender.Domain
{
    /// <summary>
    /// Сущность соединительной таблицы Письмо - Получаетель.
    /// </summary>
    public class MailRecipient
    {

        /// <summary>
        /// Уникальный идентификатор письма из сущности Письмо.
        /// </summary>
        public Guid MailId { get; set; }

        /// <summary>
        /// Сущность письма.
        /// </summary>
        public virtual Mail Mail { get; set; }

        /// <summary>
        /// Уникальный идентификатор получателя из сущности Получатель.
        /// </summary>
        public Guid RecipientId { get; set; }

        /// <summary>
        /// Сущность получателя.
        /// </summary>
        public virtual Recipient Recipient { get; set; }
    }
}
