using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DeveloperRepository : GenericRepository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Developer>> GetPopulerDevelopers(int count)
        {
            return await Task.Run(() => _context.Developers.OrderByDescending(d => d.Followers).Take(count).ToList());
        }
    }
}
