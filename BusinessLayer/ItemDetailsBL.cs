using DatabaseLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ItemDetailsBL : ItemDetials
    {
        private readonly ApplicationDbContext _ctx;

        public ItemDetailsBL(ApplicationDbContext ctx)
        {
            this._ctx = ctx;
        }
        public ItemDetailsBL()
        {

        }

        public async Task<IEnumerable<ItemDetailsBL>> ReadAll()
        {
            var q = await _ctx.ItemDetials
                .Include(i => i.Item)
                .Include(u => u.Unit)
                .Select(x => new ItemDetailsBL
                {
                    Price = x.Price,
                    Unit = x.Unit,
                    Item = x.Item
                }).ToListAsync();

            return q;
        }

        //public async Task<IEnumerable<ItemDetailsBL>> ReadAllGroupByItems()
        //{
        //    var q = await _ctx.ItemDetials
        //        .Include(i => i.Item)
        //        .Include(u => u.Unit)
        //        .GroupBy(g => g.ItemId)
        //        .Select(x => new ItemDetailsBL
        //        {
        //            Item = x.Key
        //        }).ToListAsync();
        //}

        public async Task<ItemDetailsBL> ReadOne(int unitId, int itemId)
        {
            var q = await _ctx.ItemDetials
                .Include(i => i.Item)
                .Include(u => u.Unit)
                .FirstOrDefaultAsync(a => a.UnitId == unitId && a.ItemId == itemId);

            return new ItemDetailsBL
            {
                Price = q.Price,
                Unit = q.Unit,
                Item = q.Item
            };
        }
    }
}
