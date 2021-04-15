using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTeleInf_.Models;
using PTeleInf_.Models.ViewModels;

namespace PTeleInf_.Controllers
{
    public class laboratorioDBController : Controller
    {
        // GET: laboratorioDB


        // -------------------------------LOGIN - INICIO DE SESION-------------------------------
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string nameUser)
        {
            try
            {
                using (laboratorioDBEntities1 db = new laboratorioDBEntities1())
                {
                    var oUser = (from d in db.USUARIO
                                 where d.NOMBREUSUARIO == nameUser.Trim()
                                 select d).FirstOrDefault();


                    if (oUser == null)
                    {
                        ViewBag.Error = "Usuario o contraseña invalida";
                        return View();
                    }
                    Session["User"] = oUser;
                    Session["ValorNombre"] = nameUser;
                }
                return RedirectToAction("MostrarCita");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }

        // -------------------------------MOSTRAR CITA-------------------------------
        public ActionResult MostrarCita()
        {
            List<ListTablaViewModel> lst;
            using (laboratorioDBEntities1 db = new laboratorioDBEntities1())
            {
                lst = (from d in db.CITA
                       select new ListTablaViewModel
                       {
                           IdCita = d.ID_CITA,
                           //IdUser = (int)d.ID_USUARIO,
                           NamePacient = d.NOMBREPACIENTE,
                           ApellidoPacient = d.APELLIDO,
                           CedulaPacient = d.CEDULA,
                           DireccionPacient = d.DIRECCION,
                           TelefonoPacient = d.TELEFONO,
                           FechaNac = d.FECHANACIMIENTO,
                           FechaPrCita = d.FECHAPROGRAMADA
                       }).ToList();
            }
            return View(lst);
        }


        // -------------------------------CREAR CITA-------------------------------
        public ActionResult CrearCita()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearCita(CrearPacienteViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using(laboratorioDBEntities1 db = new laboratorioDBEntities1())
                    {
                        var oCita = new CITA();
                        oCita.NOMBREPACIENTE = model.NamePacient;
                        oCita.APELLIDO = model.ApellidoPacient;
                        oCita.CEDULA = model.CedulaPacient;
                        oCita.DIRECCION = model.DireccionPacient;
                        oCita.TELEFONO = model.TelefonoPacient;
                        oCita.FECHANACIMIENTO = model.FechaNac;
                        oCita.FECHAPROGRAMADA = model.FechaPrCita;

                        db.CITA.Add(oCita);
                        db.SaveChanges();
                    }
                    return Redirect("/laboratorioDB/MostrarCita");
                }
                return View(model);

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // -------------------------------MOSTRAR DETALLES DE LAS CITAS-------------------------------
        public ActionResult MostrarDetallesCita()
        {
            List<ListTablaViewModel> lst;
            using (laboratorioDBEntities1 db = new laboratorioDBEntities1())
            {
                lst = (from d in db.CITA
                       select new ListTablaViewModel
                       {
                           IdCita = d.ID_CITA,
                           //IdUser = (int)d.ID_USUARIO,
                           NamePacient = d.NOMBREPACIENTE,
                           ApellidoPacient = d.APELLIDO,
                           CedulaPacient = d.CEDULA,
                           FechaNac = d.FECHANACIMIENTO,
                           FechaPrCita = d.FECHAPROGRAMADA
                       }).ToList();
            }
            return View(lst);
        }


        // -------------------------------CREAR RESULTADO PARA LOS PACIENTES-------------------------------
        public ActionResult CrearResultadoPaciente()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CrearResultadoPaciente(CrearResultadoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using(laboratorioDBEntities1 db = new laboratorioDBEntities1())
                    {
                        var oResultado = new RESULTADO_PACIENTE();
                        oResultado.NOMBREPACIENTE = model.NOMBREPACIENTE;
                        oResultado.APELLIDO = model.APELLIDO;
                        oResultado.CEDULA = model.CEDULA;
                        oResultado.DIRECCION = model.DIRECCION;
                        oResultado.TELEFONO = model.TELEFONO;
                    }
                    return Redirect("/laboratorioDB/VerResultadoPaciente");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // -------------------------------VER RESULTADO DE LOS PACIENTES-------------------------------
        public ActionResult VerResultadoPaciente()
        {
            List<ListTablaResult> lst;

            using (laboratorioDBEntities1 db = new laboratorioDBEntities1())
            {
                lst = (from d in db.RESULTADO_PACIENTE
                       select new ListTablaResult
                       {
                           ID_RESULTADOPACIENTE = d.ID_RESULTADOPACIENTE,
                           nombrePaciente = d.NOMBREPACIENTE,
                           ApellidoPaciente = d.APELLIDO,
                           cedulaPaciente = d.CEDULA,
                           direccionPaciente = d.DIRECCION,
                           telefonoPaciente = d.TELEFONO,
                           fechaNacPaciente = d.FECHANACIMIENTO,
                           fechaRstPaciente = d.FECHARESULTADO,
                       }).ToList();
            }
            return View(lst);

        }

        // -------------------------------VER DETALLES DE LOS RESULTADOS-------------------------------
        public ActionResult DetallesResultados()
        {
            return View();
        }
       

    }
   
   
}