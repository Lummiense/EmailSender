using Org.BouncyCastle.Asn1.Mozilla;

namespace EmailSender.WebApi.Helpers
{
    /// <summary>
    /// Класс базовой настройки SMTP-сервера.
    /// </summary>
    public class SMTPSettings
    {
        /// <summary>
        /// Отправитель письма.
        /// </summary>
        public string EmailFrom { get; set; }

        /// <summary>
        /// Адрес почтового сервера.
        /// </summary>
        public string SmtpHost { get;set; }

        /// <summary>
        /// Порт почтового сервера.
        /// </summary>
        public int SmtpPort { get; set; }

        /// <summary>
        /// Логин учетной записи на почтовом сервере.
        /// </summary>
        public string SmtpUser{get; set;}

        /// <summary>
        /// Пароль от учетной записи на почтовом сервере.
        /// </summary>
        public string SmtpPass { get; set; }
    }
}
