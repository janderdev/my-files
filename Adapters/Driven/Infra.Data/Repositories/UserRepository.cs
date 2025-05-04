using Domain.Adapters;
using Domain.Entities;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly SqlContext _context;

    public UserRepository(SqlContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }
    public async Task<IEnumerable<User>> GetAll()
    {
        return await _context.User.ToListAsync();
    }

    public async Task<User> Insert(User user)
    {
        if (user is null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        _context.User.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
    public async Task<User> Update(User user)
    {
        _context.User.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> Delete(Guid id)
    {
        var user = await _context.User.FirstOrDefaultAsync(u => u.Id == id);

        if (user is null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        _context.User.Remove(user);
        await _context.SaveChangesAsync();
        return user;
    }
}
