using Microsoft.AspNetCore.Mvc;

namespace EmailSender.WebApi.Models
{
    /// <summary>
    /// Модель данных письма, которые выводятся пользователю.
    /// </summary>
    public class MailResponseModel
    {
        /// <summary>
        /// Тема письма.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Текст письма.
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
        /// Список получателей письма.
        /// </summary>
        public ICollection<RecipientResponse> Recipients { get; set; }
    }
}
