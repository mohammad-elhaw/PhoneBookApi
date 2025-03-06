namespace Contracts
{
    public interface IRepositoryManager
    {
        IContactRepository Contact {  get; }
        Task SaveAsync();
    }
}
