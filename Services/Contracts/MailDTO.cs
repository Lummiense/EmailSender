using EmailSender.Domain;
using EmailSender.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Services.Models
{
    /// <summary>
    /// Модель данных сущности Письмо для работы в слое бизнес-логики.
    /// </summary>
    public class MailDTO
    {
        /// <summary>
        /// Уникальный идентификатор модели данных Письмо.
        /// </summary>
        public Guid Id { get; set; }

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
        /// Коллекция моделей для соединительной таблицы Письмо - Получатель.
        /// </summary>
        public ICollection<MailRecipientDTO> MailRecipients { get; set; }       
       
    }
}
