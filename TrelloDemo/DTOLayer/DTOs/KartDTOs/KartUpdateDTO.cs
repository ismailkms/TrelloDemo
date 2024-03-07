using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.KartDTOs
{
    public class KartUpdateDTO
    {
        public int KartId { get; set; }
        public string KartIcerik { get; set; }
        public int KartSira { get; set; }
        public int ListeId { get; set; }
    }
}
