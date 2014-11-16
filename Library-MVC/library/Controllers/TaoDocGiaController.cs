using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using library.Models;

namespace library.Controllers
{
    public class TaoDocGiaController : Controller
    {
        //
        // GET: /TaoDocGia/
        public ActionResult themdocgia()
        {
            return View();
        }

        public ActionResult save(FormCollection f)
        {
            libraryEntities data = new libraryEntities();
            DOC_GIA d = new DOC_GIA();

            int id_temp = (from t in data.DOC_GIA select t.MaDocGia).Max();
            d.MaDocGia = id_temp + 1;
            d.HoTen = f["HoTen"];
            d.NgaySinh = DateTime.Parse(f["NgaySinh"]);
            d.GioiTinh=int.Parse(f["GioiTinh"]);
            d.Email = f["Email"];
            d.CMND = f["CMND"];
            d.DiaChi = f["DiaChi"];
            data.DOC_GIA.AddObject(d);
            data.SaveChanges();
            return RedirectToAction("themthanhcong");
        }

        public ActionResult themthanhcong()
        {
            return View();
        }
        

    }
}
