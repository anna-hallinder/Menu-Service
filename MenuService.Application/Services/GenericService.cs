using MenuService.Application.InterfacesServices;
using MenuService.Core.Entities;
using MenuService.Infrastructure.Persistence.UnitOfWork;

namespace MenuService.Application.Services;

public class GenericService<TEntity, TId> : IGenericService<TId, TEntity>
    where TEntity : BaseEntity<TId>
{
    private readonly IUnitOfWork _unitOfWork;

    public GenericService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var repository = _unitOfWork.GetRepository<TEntity, TId>();
        return await repository.GetAllAsync();
    }

    public async Task<TEntity?> GetByIdAsync(TId id)
    {
        var repository = _unitOfWork.GetRepository<TEntity, TId>();
        return await repository.GetByIdAsync(id);
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var repository = _unitOfWork.GetRepository<TEntity, TId>();
        await repository.AddAsync(entity);
        await _unitOfWork.CompleteAsync();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var repository = _unitOfWork.GetRepository<TEntity, TId>();
        await repository.UpdateAsync(entity);
        await _unitOfWork.CompleteAsync();
        return entity;
    }

    public async Task<TEntity?> DeleteAsync(TId id)
    {
        var repository = _unitOfWork.GetRepository<TEntity, TId>();
        var entity = await repository.GetByIdAsync(id);
        if (entity != null)
        {
            await repository.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
        return entity;
    }
}
