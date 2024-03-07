using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Kart
    {
        [Key]
        public int KartId { get; set; }
        public string KartIcerik { get; set; }
        public int KartSira { get; set; }
        public int ListeId { get; set; }
        public virtual Liste Liste { get; set; }
    }
}
