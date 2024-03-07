using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ListeManager : IListeService
    {
        private readonly IListeDal _listeDal;

        public ListeManager(IListeDal listeDal)
        {
            _listeDal = listeDal;
        }

        public void Add(Liste liste)
        {
            _listeDal.Create(liste);
        }

        public void Delete(Liste liste)
        {
            _listeDal.Delete(liste);
        }

        public Liste GetById(int id)
        {
            return _listeDal.GetById(id);
        }

        public List<Liste> GetList()
        {
            return _listeDal.GetListAll();
        }

        public void Update(Liste liste)
        {
            _listeDal.Update(liste);
        }
    }
}
