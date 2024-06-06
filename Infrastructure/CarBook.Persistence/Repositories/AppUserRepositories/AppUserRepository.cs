using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CarBook.Application.Interfaces.AppUserInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly CarBookContext _context;

        public AppUserRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<AppUser>> GetCheckAppUserAsync(Expression<Func<AppUser, bool>> filter)
        {
            var values = await _context.AppUsers.Where(filter).ToListAsync();
            return values;
        }
    }
}