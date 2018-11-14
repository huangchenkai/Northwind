using NorthWindDemo.Models.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NorthWindDemo.Models.DAO
{
    public class Catagory_DAO : ICatagory_DAO, IDisposable
    {
        private DbContext _EF = null;
        public Catagory_DAO(DbContext EF)
        {
            try
            {
                if (this._EF == null)
                {
                    this._EF = EF;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Create(Catagory catagory)
        {
            try
            {
                _EF.Set<Catagory>().Add(catagory);
                _EF.SaveChanges();
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
                Catagory category = _EF.Set<Catagory>().Where(x => x.CategoryID == id).SingleOrDefault();
                _EF.Entry(category).State = EntityState.Deleted;
                _EF.SaveChanges();
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
                _EF.Entry(catagory).State = EntityState.Modified;
                _EF.SaveChanges();
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
                return _EF.Set<Catagory>().ToList();
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
                return _EF.Set<Catagory>().Where(x => x.CategoryID == id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _EF.Dispose();
                }
                disposed = true;
            }
        }
    }
}