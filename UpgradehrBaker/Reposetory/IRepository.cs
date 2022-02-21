using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpgradehrBaker.Models;

namespace UpgradehrBaker.Reposetory
{
    public interface IRepository
    {
        void AddPartener(Partner user);
        bool IsPartenerExist(string email);
        Partner GetPartenerByEmail(string email);
        Partner GetPartener(int id);
        List<TblOffer> GetOffer(int partnerId);
        void AddOffer(TblOffer tblOffer);
        void UpdateOffer(TblOffer tblOffer);
        void DeleteOffer(int id);
        List<TblOrder> GetOrderList(int partnerId);
    }
}
