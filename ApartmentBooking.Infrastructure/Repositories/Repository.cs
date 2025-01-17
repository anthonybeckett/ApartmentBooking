﻿using ApartmentBooking.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ApartmentBooking.Infrastructure.Repositories;

internal abstract class Repository<T>
    where T : Entity
{
    protected readonly ApplicationDbContext _context;

    protected Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
    }

    public void Add(T entity)
    {
        _context.Add(entity);
    }
}
