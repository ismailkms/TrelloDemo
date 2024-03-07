using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class KartManager : IKartService
    {
        private readonly IKartDal _kartDal;

        public KartManager(IKartDal kartDal)
        {
            _kartDal = kartDal;
        }

        public void Add(Kart kart)
        {
            _kartDal.Create(kart);
        }

        public void Delete(Kart kart)
        {
            _kartDal.Delete(kart);
        }

        public Kart GetById(int id)
        {
            return _kartDal.GetById(id);
        }

        public List<Kart> GetList()
        {
            return _kartDal.GetListAll();
        }

        public void Update(Kart kart)
        {
            _kartDal.Update(kart);
        }
    }
}
