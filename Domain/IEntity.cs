namespace EmailSender.Domain
{
    /// <summary>
    /// Базовая сущность.
    /// </summary>
    public class IEntity
    {
    /// <summary>
    /// Уникальный идентификатор сущности.
    /// </summary>
        public Guid Id { get; set; }
    }
}
