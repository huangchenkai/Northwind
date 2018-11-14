using NorthWindDemo.Models.DAO;
using NorthWindDemo.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthWindDemo.Models.BLO
{
    public class Catagory_BLO : ICatagory_BLO
    {
        public ICatagory_DAO _DAO { get; set; }
        //public Catagory_BLO()
        //: this(new Catagory_DAO(new NorthwindEntities1()))
        //{
        //}
        public Catagory_BLO(ICatagory_DAO DAO)
        {
            _DAO = DAO;
        }
        public void Create(Catagory catagory)
        {
            try
            {
                _DAO.Create(catagory);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(int? id)
        {
            try
            {
                _DAO.Delete(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Edit(Catagory catagory)
        {
            try
            {
                _DAO.Edit(catagory);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Catagory> GetAll()
        {
            try
            {
                IEnumerable<Catagory> catagory_s;
                catagory_s = _DAO.GetAll();
                return catagory_s;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Catagory> GetDetail(int? id)
        {
            try
            {
                IEnumerable<Catagory> catagory_s;
                catagory_s = _DAO.GetDetail(id);
                return catagory_s;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}