using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.SessionState;
using System.Web.UI;
using System.Windows;
using WebApp.Models;
using WebApp.ViewModel;

using System.Web.UI.WebControls;

namespace WebApp.Controllers
{

  
    public class UsuariosController : Controller
    {

        private ADMINWEBEntities db = new ADMINWEBEntities();

       
        // GET: Usuarios
        public ActionResult Index()
        {

            //var USP_Categoria = db.Database.SqlQuery<CategoriasViewModel>("USP_Categoria").SingleOrDefault();

            return View(db.Usuario.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_registro,nombre,apellido,telefono,correo,contrasena")] Usuario usuario)
        {
            
            var exist = db.Usuario.Where(a => a.correo == usuario.correo).Count();
            
            if (ModelState.IsValid && exist < 1)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();

                TempData["msg"] = "<script>alert('Registrado Correctamente!');</script>";
                return RedirectToAction("Login", "Usuarios");
            }
            else
            {
                TempData["msg"] = "<script>alert('Este usuario ya esta Registrado.');</script>";

            }

            return View(usuario);
        }


        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_registro,nombre,apellido,telefono,correo,contrasena")] Usuario usuario)
        {
           
            if (ModelState.IsValid )
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Usuarios/Create
       
        public ActionResult Login()
        {
            
            return View();
        }

        [HttpPost, ActionName("Login")]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario usuario)
        {

            var auth = db.Usuario.Where(user => (user.correo == usuario.correo) && (user.contrasena == usuario.contrasena)).FirstOrDefault();
            //SACAR EL ID DEL USUARIO Y MONTARL EN LA VARIBLE 

            if(auth != null)
            {


                #region "LIMPIAR SESSION DEL USUARIO "
                //esta funcion al salir del usuario 

                //clear claims
                var identity = System.Web.HttpContext.Current.User.Identity as ClaimsIdentity;
                var claim = (from c in identity.Claims
                             where c.Type == "Id_User"
                             select c).FirstOrDefault();

                //validar si existe el caim
                if (claim != null)
                {
                    identity.RemoveClaim(claim);
                }
                //AQUI AL SALIR DEL LOGIN 



                #endregion

                //loggin
                double IdUser = auth.id_registro;

                //add new claim
                identity.AddClaim(new Claim("Id_User", IdUser.ToString()));

                return RedirectToAction("Index", "Home");

            }
            else
            {
                //faild loggin

                TempData["msg"] = "<script>alert('Usuario o contraseña inválidos');</script>";

            }



            return View(usuario);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
           
            return RedirectToAction("Login", "Usuarios");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
