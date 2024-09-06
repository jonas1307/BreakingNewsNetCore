namespace BreakingNews.Domain.Interfaces.Entities
{
    public interface IEntity<T>
    {
        T Id { get; }
    }
}