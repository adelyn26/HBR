using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebApp.Models;
using WebApp.ViewModel;

namespace WebApp.Controllers
{
    public class ProductoesController : Controller
    {
        private ADMINWEBEntities db = new ADMINWEBEntities();

       
        // GET: Productoes
        public ActionResult Index()
        {
            var result = new List<Producto>();  
           var cat = new List<CategoriasViewModel>();

            try
            {
                    result = db.Producto.ToList();

                var categorias = db.Categoria.ToList();

                foreach (var data in categorias)
                {
                    var obj = new CategoriasViewModel();
                    obj.nombre = data.nombre;
                    obj.id_Categoria = data.id_Categoria;

                    cat.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ViewData["categorias"] = cat;
            return View(result);
        }

        [HttpPost]
        public ActionResult Index(int id)
        {
            var result = new List<Producto>();
            var cat = new List<CategoriasViewModel>();

            try
            {

                if (id == null)
                {
                    result = db.Producto.ToList();
                }
                else
                {
                    result = db.USP_Categoria_Procedure(id).ToList();
                }

                var categorias = db.Categoria.ToList();

                foreach (var data in categorias)
                {
                    var obj = new CategoriasViewModel();
                    obj.nombre = data.nombre;
                    obj.id_Categoria = data.id_Categoria;

                    cat.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ViewData["categorias"] = cat;
            return View(result);
        }

        public JsonResult ProductFilter(int? id)
        {
            var result = new List<Producto>();
            try
            {
                result = db.USP_Categoria_Procedure(id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productoes/Create
        public ActionResult Create()
        {
            ViewBag.idcategoria = new SelectList(db.Categoria, "id_Categoria", "nombre");
            return View();
        }

        // POST: Productoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Producto,nombre,categoria,idcategoria")] Producto producto)
        {
            if (ModelState.IsValid)
            {
            

                db.Producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcategoria = new SelectList(db.Categoria, "id_Categoria", "nombre", producto.idcategoria);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcategoria = new SelectList(db.Categoria, "id_Categoria", "nombre", producto.idcategoria);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Producto,nombre,categoria,idcategoria")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcategoria = new SelectList(db.Categoria, "id_Categoria", "nombre", producto.idcategoria);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Producto.Find(id);
            db.Producto.Remove(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public JsonResult GetCategoria()
        {
            object datos;
            try
            {
                datos = db.Categoria.ToList().Select(a => new SelectListItem
                {
                    Text = a.nombre,
                    Value = a.id_Categoria.ToString()
                });

            }

            catch (Exception)
            {

                throw;
            }


            return this.Json(datos, JsonRequestBehavior.AllowGet);
        }
        //[HttpGet]
        //public JsonResult Getfiltro()
        //{
        //    var filtro = db.Database.SqlQuery<CategoriasViewModel>("USP_Categoria").SingleOrDefault();
        //    return Json(filtro, JsonRequestBehavior.AllowGet);
        //}

      
    }

}
