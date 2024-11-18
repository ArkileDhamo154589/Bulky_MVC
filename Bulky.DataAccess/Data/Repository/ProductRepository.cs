using Bulky.DataAccess.Data.Repository.IRepository;
using System;
using Bulky.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAcess.Data;

namespace Bulky.DataAccess.Data.Repository
{
    public class ProductRepository : Repository<Product> , IProductRepository
    {

        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}
