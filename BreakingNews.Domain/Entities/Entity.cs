using BreakingNews.Domain.Interfaces.Entities;

namespace BreakingNews.Domain.Entities
{
    public abstract class Entity<T> : IEntity<T>
    {
        public virtual T Id { get; protected set; }
    }
}
