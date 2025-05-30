using UpToDo.Domain;

namespace UpToDo.Application.Shared.Repositories;

public interface ITagRepository
{
    Task AddAsync(Tag tag);
    Task<Tag?> GetByIdAsync(Guid id);
    Task<List<Tag>> GetAllAsync();
    Task UpdateAsync(Tag tag);
    Task DeleteAsync(Guid id);
}