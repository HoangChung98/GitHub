using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using N35_WebBanDT.Models.Entities;

namespace N35_WebBanDT.Models.Functions
{
    public class NhaCungCapF
    {
        private MyDBContext context;
        public NhaCungCapF()
        {
            context = new MyDBContext();
        }
        public IQueryable<NhaCungCap> NhaCungCaps
        {
            get { return context.NhaCungCaps; }
        }
        public NhaCungCap ChitietNhaCungCap(string id)
        {
            NhaCungCap ncc = context.NhaCungCaps.Find(id);
            return ncc;
        }
        public bool InSert(NhaCungCap model)
        {
            NhaCungCap dbEntry = context.NhaCungCaps.Find(model.IDNCC);
            if (dbEntry != null)
            {
                return false;
            }
            else
            {
                context.NhaCungCaps.Add(model);
                context.SaveChanges();
                return true;
            }
        }
        public bool Update(NhaCungCap model)
        {
            NhaCungCap dbEntry = context.NhaCungCaps.Find(model.IDNCC);
            if (dbEntry == null)
            {
                return false;
            }
            dbEntry.IDNCC = model.IDNCC;
            dbEntry.TenNCC = model.TenNCC;
            dbEntry.DiaChi_NCC = model.DiaChi_NCC;
            dbEntry.SDT_NCC = model.SDT_NCC;
            context.SaveChanges();
            return true;
        }
        public bool Delete(string MaNCC)
        {
            NhaCungCap dbEntry = context.NhaCungCaps.Find(MaNCC);
            if (dbEntry == null)
            {
                return false;
            }
            context.NhaCungCaps.Remove(dbEntry);
            context.SaveChanges();
            return true;
        }
    
   }
}