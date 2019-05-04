using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using Business.InterfacesServicio;
using Business.Implementaciones;


namespace webAppServicios.Controllers
{
    public class PublicacionController : Controller
    {
        private IServicioPublicacion servicioPublicacion = new ServicioPublicacion();
        private IServicioServicio servicioServicio = new ServicioServicio();
        // GET: Publicacion
        public ActionResult Index()
        {
            return View(servicioPublicacion.Listar());
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Publicacion publicacion = servicioPublicacion.ListarPorId(id);
            return View(publicacion);
        }

        public ActionResult CreatePublicacion()
        {
            ViewBag.servicio = servicioServicio.Listar();
            return View();
        }

        
        public ActionResult EditPublicacion(int id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}

            //bool rptaEdit = servicioPublicacion.Actualizar(publicacion);
            //if (rptaEdit)
            //{
            //    return RedirectToAction("Index");
            //}

            var publicacion = servicioPublicacion.ListarPorId(id);
            ViewBag.servicio = servicioServicio.Listar();
            return View(publicacion);
        }

        [HttpPost]
        public ActionResult EditPublicacion(Publicacion publicacion)
        {
            bool rptaEdit = servicioPublicacion.Actualizar(publicacion);

            if (rptaEdit)
                return RedirectToAction("Index");

            return View(publicacion);
        }

        [HttpPost]
        public ActionResult CreatePublicacion(Publicacion publicacion)
        {
            bool rptaInsert = servicioPublicacion.Insertar(publicacion);

            if (rptaInsert)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult DeletePublicacion(int id)
        {
            servicioPublicacion.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}