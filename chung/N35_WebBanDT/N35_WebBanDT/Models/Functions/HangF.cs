using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using N35_WebBanDT.Models.Entities;
namespace N35_WebBanDT.Models.Functions
{
    public class HangF
    {
        private MyDBContext context;
        public HangF()
        {
            context = new MyDBContext();
        }
        public IQueryable<Hang> Hangs
        {
            get { return context.Hangs; }
        }
        public Hang ChitietHang(string id)
        {
            Hang h = context.Hangs.Find(id);
            return h;
        }
        public bool InSert(Hang model)
        {
            Hang dbEntry = context.Hangs.Find(model.IDHang);
            if (dbEntry != null)
            {
                return false;
            }
            else
            {
                context.Hangs.Add(model);
                context.SaveChanges();
                return true;
            }
        }
        public bool Update(Hang model)
        {
            Hang dbEntry = context.Hangs.Find(model.IDHang);
            if (dbEntry == null)
            {
                return false;
            }
            dbEntry.IDHang = model.IDHang;
            dbEntry.TenHang = model.TenHang;
            context.SaveChanges();
            return true;
        }
        public bool Delete(string MaH)
        {
            Hang dbEntry = context.Hangs.Find(MaH);
            if (dbEntry == null)
            {
                return false;
            }
            context.Hangs.Remove(dbEntry);
            context.SaveChanges();
            return true;
        }

    }
}