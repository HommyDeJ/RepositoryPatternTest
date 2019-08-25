using Microsoft.EntityFrameworkCore;
using RepositoryPatternTest.Interfaces;
using RepositoryPatternTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPatternTest.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public async Task<Category> GetCoolestCategory()
        {
            return await GetAll().OrderByDescending(c => c.Name).FirstOrDefaultAsync();
        }
    }
}
