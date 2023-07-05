namespace EmailSender.WebApi.Models
{
    /// <summary>
    /// Модель данных письма, которая формируется на основании данных введеных пользователем.
    /// </summary>
    public class MailRequestModel
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
        /// Список получателей
        /// </summary>
        public ICollection<string> Recipients { get; set; }
    }
}
