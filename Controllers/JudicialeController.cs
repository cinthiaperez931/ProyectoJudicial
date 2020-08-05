using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trabajo2.Models;

namespace Trabajo2.Controllers
{
    public class JudicialeController : Controller
    {
        // GET: Judiciale
        public ActionResult Index()
        {
            try
            {
                using (var db = new JudicialContext1())
                {
                    ///// List<Judicial> lista = db.Judicial.Where(j => j.AñoCausa > 2010).ToList();
                    return View(db.Judicial.ToList());

                }
            }
            catch (Exception)
            {

                throw;
            }



        }


        ////[HttpGet]
        public ActionResult Agregar()
        {


            return View();

        }

          [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Judicial j)
        {
                if(!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new JudicialContext1())
                {

                    db.Judicial.Add(j);
                   
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error al registrar los datos - " +  ex.Message);
                return View();
            }




        }
        public ActionResult Editar(int id)
        {
            try
            {
                using (var db = new JudicialContext1())
                {

                    Judicial judi = db.Judicial.Find(id);
                    return View(judi);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Judicial j)
        {
            try
            {   using (var db = new JudicialContext1())
                {
                    Judicial judi = db.Judicial.Find(j.Id);
                    judi.Rol = j.Rol;
                    judi.Nombres = j.Nombres;
                    judi.Apellidos = j.Apellidos;
                    judi.AñoCausa = j.AñoCausa;
                    judi.CorreoElectronico = j.CorreoElectronico;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                

            }
            catch (Exception ex)
            {

                throw;
            }
            

      
        
        }
        public ActionResult Detalles(int id)
        {
            try
            {
                using (var db = new JudicialContext1())
                {

                    Judicial judi = db.Judicial.Find(id);
                    return View(judi);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Eliminar( int id)
        {
            try
            {
                using (var db = new JudicialContext1())
                {
                    Judicial judi = db.Judicial.Find(id);
                    db.Judicial.Remove(judi);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

                   
            }
            catch (Exception)
            {

                throw;
            }

        }

    }   

}



