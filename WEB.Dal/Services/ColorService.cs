using Microsoft.Extensions.Configuration;
using Pet.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB.Dal.Services
{
    public class ColorService : BaseService
    {
        public ColorService(IConfiguration configuration) : base(configuration)
        {
        }
        public List<Color> GetColors()
        {
            return this.dbContext.Colors.ToList();
        }
    }
}
