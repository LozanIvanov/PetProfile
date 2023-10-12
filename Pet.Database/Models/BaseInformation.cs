using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Database.Models
{
    public class BaseInformation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string? MainImage{ get; set;}
        public int ColorId { get; set; }
        public Color color { get; set; }
        public int Weight { get; set; }
        public string Gender { get; set; }
        
        public ICollection <Parent> Parents { get; set; }
        
        public ICollection <Brother> Brothers { get; set; }
        
        public ICollection <Sister> Sisters { get; set; }

        public BaseInformation()
        {
            this.Brothers = new List<Brother>();
            this.Sisters = new List<Sister>();
            this.Parents = new List<Parent>();
        }

    }
}
