using Domain.Entities;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Product> CreateAsync(Product Product)
        {
            _db.Add(Product);
            await _db.SaveChangesAsync();
            return Product;
        }

        public async Task DeleteAsync(Product Product)
        {
            _db.Remove(Product);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Product Product)
        {
            _db.Update(Product);
            await _db.SaveChangesAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Product>> GetProductAsync()
        {
            return await _db.Products.ToListAsync();
        }
    }
}
