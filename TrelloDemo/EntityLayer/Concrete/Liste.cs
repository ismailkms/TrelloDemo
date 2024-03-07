using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Liste
    {
        [Key]
        public int ListeId { get; set; }
        public string ListeAdi { get; set; }
        public int ListeSira { get; set; }
        public virtual List<Kart> Karts { get; set; }
    }
}
