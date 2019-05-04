using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using Business.Implementaciones;
using Business.InterfacesServicio;

namespace webAppServicios.Controllers
{
    public class SolicitudController : Controller
    {
        public IServicioSolicitud servicioSolicitud = new ServicioSolicitud();
        public IServicioPublicacion servicioPublicacion = new ServicioPublicacion();
        // GET: Solicitud
        public ActionResult IndexSolicitud()
        {
            return View(servicioSolicitud.Listar());
        }

        //public ActionResult CreateSolicitud(int id)
        //{
        //    var publicacion = servicioPublicacion.Listar().
        //        Where(p => p.codigoPublicacion == id).FirstOrDefault();
        //    return View(publicacion);
        //}
        //[HttpPost]
        //public ActionResult CreateSolicitud(Solicitud s, Publicacion pub)
        //{
        //    s.codigoPublicacion = pub;
        //    bool rptaInsert = servicioSolicitud.Insertar(s);
        //    if (rptaInsert)
        //    {
        //        return RedirectToAction("IndexSolicitud");
        //    }
        //    return View();
        //}

        public ActionResult CreateSolicitud()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSolicitud(Solicitud s)
        {
            
            bool rptaInsert = servicioSolicitud.Insertar(s);
            if (rptaInsert)
            {
                return RedirectToAction("IndexSolicitud");
            }
            return View();
        }

    }
}