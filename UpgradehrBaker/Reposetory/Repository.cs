using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpgradehrBaker.Models;

namespace UpgradehrBaker.Reposetory
{
    public class Repository : IRepository
    {
        AnnaBakeContext db = new AnnaBakeContext();
        public void AddPartener(Partner partener)
        {
            db.Partners.Add(partener);
            db.SaveChanges();
           
        }
        public bool IsPartenerExist(string email)
        {
           return db.Partners.Any(x=>x.Email==email);

        }
        public Partner GetPartenerByEmail(string email)
        {
            return db.Partners.Where(x => x.Email == email).FirstOrDefault();

        }
        public Partner GetPartener(int id)
        {
            return db.Partners.Where(x => x.Id == id).FirstOrDefault();

        }
        public List<TblOffer> GetOffer(int partnerId)
        {
            return db.TblOffers.Where(x => x.PartnerId == partnerId).ToList();

        }
        public void AddOffer(TblOffer tblOffer)
        {
            db.TblOffers.Add(tblOffer);
            db.SaveChanges();

        }
        public void UpdateOffer(TblOffer tblOffer)
        {
            db.TblOffers.Update(tblOffer);
            db.SaveChanges();

        }
        public void DeleteOffer(int id)
        {
            var entity = db.TblOffers.Find(id);
            db.Remove(entity);

        }
        public List<TblOrder> GetOrderList(int partnerId)
        {
            return db.TblOrders.Where(x => x.PartnerId == partnerId).ToList();

        }

    }
}
