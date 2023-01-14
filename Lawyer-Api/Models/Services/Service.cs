using AutoMapper;
using Lawyer_Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Lawyer_Api.Models.Services;

public class Service<TSource, TDestination> : IService<TSource, TDestination>
	where TSource : class, new()
	where TDestination : class, new()
{
	private readonly IMapper _mappper;
	private readonly ApplicationDbContext _context;

	public Service(IMapper mappper, ApplicationDbContext context)
	{
		_mappper = mappper;
		_context = context;
	}

	public async Task<TDestination> GetAsync(int id)
		=> _mappper.Map<TDestination>(await _context.Set<TSource>().FindAsync(id));

	public async Task<IEnumerable<TDestination>> GetAllAsync()
		=> _mappper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(await _context.Set<TSource>().ToListAsync());

	public async Task<TDestination> UpdateAsync(TDestination entity)
	{
		_context.Set<TSource>().Update(_mappper.Map<TSource>(entity));
		await _context.SaveChangesAsync();
		return entity;
	}

	public async Task<TDestination> SaveAsync(TDestination entity)
	{
		await _context.Set<TSource>().AddAsync(_mappper.Map<TSource>(entity));
		await _context.SaveChangesAsync();
		return entity;
	}

	public async Task<TDestination> DeleteAsync(int id)
	{
		var entity = await _context.Set<TSource>().FindAsync(id);

		try
		{
			if (entity == null)
				throw new ArgumentNullException($"Deleting entity cannot be null!");

			_context.Set<TSource>().Remove(entity);
			await _context.SaveChangesAsync();

			return _mappper.Map<TDestination>(entity);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
	}
}