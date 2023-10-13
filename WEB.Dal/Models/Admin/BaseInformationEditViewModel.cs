using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Pet.Database.Models;

namespace WEB.Dal.Models.Admin
{
    public class BaseInformationEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        
        public IFormFile? MainImage { get; set; }
        public string MainImages { get; set; }
        public int ColorId { get; set; }
        public int Weight { get; set; }
        public string Gender { get; set; }
        public int ProductCount { get; set; }
        public ICollection<Color> Colors { get; set; }
        public BaseInformationEditViewModel()
        {
            Colors = new List<Color>();
        }

    }
}
