using RepositoryPatternTest.Model;
using RepositoryPatternTest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPatternTest.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetCoolestCategory();
    }
}