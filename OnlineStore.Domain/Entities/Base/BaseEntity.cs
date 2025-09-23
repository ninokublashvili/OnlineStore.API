namespace OnlineStore.Domain.Entities.Base
{
    public abstract class BaseEntity<T>
    {
        public virtual T Id { get; protected set; }

        public virtual bool IsActive { get; protected set; } = true;

        public void Delete()
        {
            IsActive = false;
        }
    }
}