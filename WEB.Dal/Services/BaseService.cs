using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pet.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB.Dal.Services
{
    public class BaseService
    {
        protected readonly ApplicationDbContext dbContext;
        public BaseService(IConfiguration configuration)
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            dbContext = new ApplicationDbContext(builder.Options);
        }
    }
}
