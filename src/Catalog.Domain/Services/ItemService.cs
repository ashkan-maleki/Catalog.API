using AutoMapper;
using Catalog.Domain.Entities;
using Catalog.Domain.Mappers;
using Catalog.Domain.Repositories;
using Catalog.Domain.Requests.Item;
using Catalog.Domain.Responses;

namespace Catalog.Domain.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _repository;
        private readonly IMapper _mapper;

        public ItemService(IMapper mapper, IItemRepository repository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<ItemResponse>> GetItemsAsync() =>
            (await _repository.GetAsync())
            .Select(x => _mapper.Map<ItemResponse>(x));

        public async Task<ItemResponse?> GetItemAsync(GetItemRequest request)
        {
            if (request?.Id == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Item? entity = await _repository.GetAsync(request.Id);
            if (entity == null)
            {
                return null;
            }

            return _mapper.Map<ItemResponse>(entity);
        }

        public async Task<ItemResponse> AddItemAsync(AddItemRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Item entity = _repository.Add(
                _mapper.Map<Item>(request)
            );
            await _repository.UnitOfWork.SaveChangesAsync();
            
            return _mapper.Map<ItemResponse>(entity);
        }

        public async Task<ItemResponse> EditItemAsync(EditItemRequest request)
        {
            if (request?.Id == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (!(await _repository.AnyAsync(request.Id)))
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            Item entity = _repository.Update(
                _mapper.Map<Item>(request)
            );
            await _repository.UnitOfWork.SaveChangesAsync();

            return _mapper.Map<ItemResponse>(entity);
        }
    }
}
