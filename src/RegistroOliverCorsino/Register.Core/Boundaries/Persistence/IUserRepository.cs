using Core.Models;

namespace Core.Boundaries.Persistence
{
    /// <summary>
    /// Represents the repository interface for working with the User's persistence
    /// </summary>
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
