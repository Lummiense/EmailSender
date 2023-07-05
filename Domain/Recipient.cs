namespace EmailSender.Domain
{
    /// <summary>
    /// Сущность Получатель.
    /// </summary>
    public class Recipient:IEntity
    {
        /// <summary>
        /// Имя получателя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Адрес электронной почты получателя.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Коллекция сущностей для соединительной таблицы Письмо - Получатель.
        /// </summary>
        public ICollection<MailRecipient> MailRecipients { get; set; }
    }
}
