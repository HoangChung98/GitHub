using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using N35_WebBanDT.Models.Entities;
namespace N35_WebBanDT.Models.Functions
{
    public class SanPhamF
    {
        private MyDBContext context;
        public SanPhamF()
        {
            context = new MyDBContext();
        }
        public IQueryable<SanPham> SanPhams
        {
            get { return context.SanPhams; }
        }
        public SanPham ChitietSanPham(string id)
        {
            SanPham sp = context.SanPhams.Find(id);
            return sp;
        }
        public bool InSert(SanPham model)
        {
            SanPham dbEntry = context.SanPhams.Find(model.IDSanPham);
            if (dbEntry != null)
            {
                return false;
            }
            else
            {
                context.SanPhams.Add(model);
                context.SaveChanges();
                return true;
            }
        }
        public bool Update(SanPham model)
        {
            SanPham dbEntry = context.SanPhams.Find(model.IDSanPham);
            if (dbEntry == null)
            {
                return false;
            }
            dbEntry.IDSanPham = model.IDSanPham;
            dbEntry.TenSanPham = model.TenSanPham;
            dbEntry.UrlAnh = model.UrlAnh;
            dbEntry.DonGiaB = model.DonGiaB;
            dbEntry.DonGiaN = model.DonGiaN;
            dbEntry.ManHinh = model.ManHinh;
            dbEntry.Ram = model.Ram;
            dbEntry.BoNhoTrong = model.BoNhoTrong;
            dbEntry.CameraSau = model.CameraSau;
            dbEntry.CameraTruoc = model.CameraTruoc;
            dbEntry.DungLuongPin = model.DungLuongPin;
            dbEntry.TheSim = model.TheSim;
            context.SaveChanges();
            return true;
        }
        public bool Delete(string MaSP)
        {
                SanPham dbEntry = context.SanPhams.Find(MaSP);
                if (dbEntry == null)
                {
                    return false;
                }
                context.SanPhams.Remove(dbEntry);
                context.SaveChanges();
                return true;
            }
        }
    }

