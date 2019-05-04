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
    public class UsuarioController : Controller
    {
        public IServicioUsuario servicioUsuario = new ServicioUsuario();
        public IServicioDistrito servicioDistrito = new ServicioDistrito();

        public ActionResult IndexCliente()
        {
            return View(servicioUsuario.ListarCliente());
        }
        public ActionResult IndexAnunciante()
        {
            return View(servicioUsuario.ListarAnunciante());
        }

        public ActionResult Publicar()
        {
            return View("~/Views/Publicacion/CreatePublicacion.cshtml");
        }

        public ActionResult CreateCliente()
        {
            ViewBag.distrito = servicioDistrito.Listar();
            return View();
        }
        [HttpPost]
        public ActionResult CreateCliente(Usuario c)
        {
            ViewBag.distrito = servicioDistrito.Listar();
            bool rptaInsert = servicioUsuario.InsertarCliente(c);
            if (rptaInsert)
            {
                return RedirectToAction("IndexCliente");
            }
            return View();
        }

        public ActionResult CreateAnunciante()
        {
            ViewBag.distrito = servicioDistrito.Listar();
            return View();
        }
        [HttpPost]
        public ActionResult CreateAnunciante(Usuario c)
        {
            ViewBag.distrito = servicioDistrito.Listar();
            bool rptaInsert = servicioUsuario.InsertarAnunciante(c);
            if (rptaInsert)
            {
                return RedirectToAction("IndexAnunciante");
            }
            return View();
        }

        public ActionResult EditCliente(int id)
        {
            //var cliente = servicioUsuario.ListarCliente().
            //    Where(c => c.codigoUsuario == id).FirstOrDefault();
            //return View(cliente);

            var usuario = servicioUsuario.ListarPorId(id);
            ViewBag.distrito = servicioDistrito.Listar();
            return View(usuario);
        }
        [HttpPost]
        public ActionResult EditCliente(Usuario cliente)
        {
            //var c = cliente.codigoUsuario > 0 ? servicioUsuario.ActualizarCliente(cliente) :
            //    servicioUsuario.InsertarCliente(cliente);
            //if (!c)
            //{
            //    ViewBag.Message = "Ocurrio un error inesperado";
            //    return View("~/Views/Shared/Error.cshtml");
            //}
            //return RedirectToAction("IndexCliente");

            bool rptaEdit = servicioUsuario.ActualizarCliente(cliente);

            if (rptaEdit)
                return RedirectToAction("IndexCliente");

            return View(cliente);

        }

        public ActionResult EditAnunciante(int id)
        {
            var anunciante = servicioUsuario.ListarAnunciante().
                Where(a => a.codigoUsuario == id).FirstOrDefault();
            ViewBag.distrito = servicioDistrito.Listar();
            return View(anunciante);
        }

        [HttpPost]
        public ActionResult EditAnunciante(Usuario anunciante)
        {
            var a = anunciante.codigoUsuario > 0 ? servicioUsuario.ActualizarCliente(anunciante) :
                servicioUsuario.InsertarCliente(anunciante);
            if (!a)
            {
                ViewBag.Message = "Ocurrio un error inesperado";
                return View("~/Views/Shared/Error.cshtml");
            }
            return RedirectToAction("IndexAnunciante");
        }

        public ActionResult DeleteCliente(int id)
        {
            bool respuesta = servicioUsuario.Eliminar(id);
            return RedirectToAction("IndexCliente");
        }
        public ActionResult DeleteAnunciante(int id)
        {
            bool respuesta = servicioUsuario.Eliminar(id);

            return RedirectToAction("IndexAnunciante");
        }
    }
}