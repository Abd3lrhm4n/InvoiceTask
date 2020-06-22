using DatabaseLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class StoreBL : Store
    {
        private readonly ApplicationDbContext _ctx;

        public StoreBL(ApplicationDbContext ctx)
        {
            this._ctx = ctx;
        }
        public StoreBL()
        {

        }

        public async Task<IEnumerable<StoreBL>> ReadAll()
        {
            var q = await _ctx.Stores
                .Select(x => new StoreBL
                {
                    Id = x.Id,
                    StoreName = x.StoreName
                }).ToListAsync();

            return q;
        }

        public async Task<StoreBL> ReadOne(int id)
        {
            var q = await _ctx.Stores
                .FirstOrDefaultAsync(a => a.Id == id);

            return new StoreBL
            {
                Id = q.Id,
                StoreName = q.StoreName
            };
        }
    }
}
