

using AutoMapper;
using DanderiNetwork.Core.Application.Interfaces.Repositories;
using DanderiNetwork.Core.Application.Interfaces.Services;
using DanderiNetwork.Core.Application.ViewModels.Post;
using DanderiNetwork.Core.Domain.Entities;

namespace DanderiNetwork.Core.Application.Services
{
    public class PostService : GenericService<SavePostViewModel, PostViewModel, Post>, IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper) : base(postRepository, mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
    }
}
