using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthWindDemo.Models.Repository
{
    public interface ICatagory_BLO :IAutoInject
    {
        IEnumerable<Catagory> GetAll();
        IEnumerable<Catagory> GetDetail(int? id);
        void Create(Catagory catagory);
        void Edit(Catagory catagory);
        void Delete(int? id);

    }
}