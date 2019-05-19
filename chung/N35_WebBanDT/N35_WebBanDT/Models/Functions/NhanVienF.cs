using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using N35_WebBanDT.Models.Entities;
namespace N35_WebBanDT.Models.Functions
{
    public class NhanVienF
    {
        private MyDBContext context;
        public NhanVienF()
        {
            context = new MyDBContext();
        }
        public IQueryable<NhanVien> NhanViens
        {
            get { return context.NhanViens; }
        }
        public NhanVien ChitietNhanVien(string id)
        {
            NhanVien nv = context.NhanViens.Find(id);
            return nv;
        }
        public bool InSert(NhanVien model)
        {
            NhanVien dbEntry = context.NhanViens.Find(model.IDNhanVien);
            if (dbEntry != null)
            {
                return false;
            }
            else
            {
                context.NhanViens.Add(model);
                context.SaveChanges();
                return true;
            }
        }
        public bool Update(NhanVien model)
        {
            NhanVien dbEntry = context.NhanViens.Find(model.IDNhanVien);
            if (dbEntry == null)
            {
                return false;
            }
            dbEntry.IDNhanVien = model.IDNhanVien;
            dbEntry.TenNhanVien = model.TenNhanVien;
            dbEntry.GioiTinh_NV = model.GioiTinh_NV;
            dbEntry.ChucVu = model.ChucVu;
            dbEntry.SDT_NV = model.SDT_NV;
            dbEntry.TaiKhoan = model.TaiKhoan;
            context.SaveChanges();
            return true;
        }
        public bool Delete(string MaNV)
        {
            NhanVien dbEntry = context.NhanViens.Find(MaNV);
            if (dbEntry == null)
            {
                return false;
            }
            context.NhanViens.Remove(dbEntry);
            context.SaveChanges();
            return true;
        }
    }
}
