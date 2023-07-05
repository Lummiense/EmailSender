using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Domain
{
    /// <summary>
    /// Сущность Письмо.
    /// </summary>
    public class Mail:IEntity
    {
        /// <summary>
        /// Тема письма.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Текст письма
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Дата формирования письма.
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Результат отправки письма.
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Сообщение об ошибке, которое возникает в случае сбоя при отправке письма.
        /// </summary>
        public string FailedMessage { get; set; }

        /// <summary>
        /// Коллекция сущностей для соединительной таблицы Письмо - Получатель.
        /// </summary>
        public ICollection<MailRecipient> MailRecipients { get; set; }
    }
}
