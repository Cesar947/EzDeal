using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using Business.Implementaciones;
using Business.InterfacesServicio;
using System.Dynamic;

namespace webAppServicios.Controllers
{
    public class ResenaController : Controller
    {
        private IServicioResena servicioResena = new ServicioResena();
        private IServicioPublicacion servicioPublicacion = new ServicioPublicacion();
        private IServicioUsuario servicioCliente = new ServicioUsuario();
        // GET: Resena
        public ActionResult Index()
        {
            return View(servicioResena.Listar());
        }

        public ActionResult CreateResena()
        {
            ViewBag.publicacion = servicioPublicacion.Listar();
            ViewBag.cliente = servicioCliente.ListarCliente();
            return View();
        }

        [HttpPost]

        public ActionResult CreateResena(Resena resena)
        {
            ViewBag.publicacion = servicioPublicacion.Listar();
            ViewBag.cliente = servicioCliente.ListarCliente();
            bool rptainsert = servicioResena.Insertar(resena);
            if (rptainsert)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult EditResena(int id)
        {
            //ViewBag.resenas = servicioResena.Listar();
            var resena = servicioResena.ListarPorId(id);
            return View(resena);
    
        }
        [HttpPost]
        public ActionResult EditResena(Resena resena)
        {
            //ViewBag.resenas = servicioResena.Listar();
            bool rptaEdit = servicioResena.Actualizar(resena);
            if (rptaEdit)
                return RedirectToAction("Index");

            return View(resena);
        }

        public ActionResult DeleteResena(int id)
        {
            servicioResena.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}