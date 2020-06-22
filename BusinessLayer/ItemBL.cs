using DatabaseLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ItemBL : Item
    {
        private readonly ApplicationDbContext _ctx;

        public ItemBL(ApplicationDbContext ctx)
        {
            this._ctx = ctx;
        }
        public ItemBL()
        {

        }

        public async Task<IEnumerable<ItemBL>> ReadAll()
        {
            var q = await _ctx.Items
                .Select(x => new ItemBL
                {
                    Id = x.Id,
                    ItemName= x.ItemName
                }).ToListAsync();

            return q;
        }

        public async Task<ItemBL> ReadOne(int id)
        {
            var q = await _ctx.Items
                .FirstOrDefaultAsync(a => a.Id == id);

            return new ItemBL
            {
                Id = q.Id,
                ItemName = q.ItemName
            };
        }


    }
}
