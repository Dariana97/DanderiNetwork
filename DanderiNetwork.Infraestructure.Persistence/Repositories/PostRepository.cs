

using DanderiNetwork.Core.Application.Interfaces.Repositories;
using DanderiNetwork.Core.Domain.Entities;
using DanderiNetwork.Infraestructure.Persistence.Contexts;

namespace DanderiNetwork.Infraestructure.Persistence.Repositories
{
    public class PostRepository : GenericRepository<Post>,IPostRepository
    {
        private readonly ApplicationContext _dbContext;
        public PostRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
