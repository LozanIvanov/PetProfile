using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pet.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB.Dal.Services
{
    public class BaseInformationService : BaseService
    {
        public BaseInformationService(IConfiguration configuration) : base(configuration)
        {
        }
        public List<BaseInformation> GetInformation()
        {
            return this.dbContext.BaseInformations.ToList();
        }
        public void Create(BaseInformation information)
        {
            this.dbContext.BaseInformations.Add(information);
            dbContext.SaveChanges();
        }
        public BaseInformation GetInformationById(int id)
        {
            return dbContext.BaseInformations.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Update(int id, BaseInformation information)
        {
            var newinformation = dbContext.BaseInformations.Where(x => x.Id == id).FirstOrDefault();
            
            if (newinformation != null) {
                newinformation.Name = information.Name;
                newinformation.Age = information.Age;
                newinformation.ColorId = information.ColorId;
                newinformation.Weight = information.Weight;
                newinformation.Gender= information.Gender;
            }
            if (!string.IsNullOrEmpty(information.MainImage)) {
                newinformation.MainImage = information.MainImage;
            }
            dbContext.Entry(newinformation).State = EntityState.Modified;
            dbContext.SaveChanges();
            

            }
        public void Delete(int id)
        {
            var deleted = GetInformationById(id);
            dbContext.Entry(deleted).State = EntityState.Deleted;
            dbContext.SaveChanges();
        }
    }
}
