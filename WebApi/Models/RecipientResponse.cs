using EmailSender.Domain;

namespace EmailSender.WebApi.Models
{
    /// <summary>
    /// Модель Получателя для работы в view-слое.
    /// </summary>
    public class RecipientResponse
    {
        /// <summary>
        /// Уникальный идентификатор получателя.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя получателя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Адрес электронной почты получателя.
        /// </summary>
        public string Email { get; set; }
    }
}
