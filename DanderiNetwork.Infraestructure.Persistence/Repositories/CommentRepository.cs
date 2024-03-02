using DanderiNetwork.Core.Application.Interfaces.Repositories;
using DanderiNetwork.Core.Domain.Entities;
using DanderiNetwork.Infraestructure.Persistence.Contexts;

namespace DanderiNetwork.Infraestructure.Persistence.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly ApplicationContext _dbContext;
        public CommentRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
