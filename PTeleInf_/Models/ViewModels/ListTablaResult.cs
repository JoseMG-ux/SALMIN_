using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTeleInf_.Models.ViewModels
{
    public class ListTablaResult
    {

        public int ID_RESULTADOPACIENTE { get; set; }
        public string nombrePaciente { get; set; }
        public string ApellidoPaciente { get; set; }
        public string cedulaPaciente { get; set; }
        public string direccionPaciente { get; set; }
        public string telefonoPaciente { get; set; }
        public string fechaNacPaciente { get; set; }
        public string fechaPrPaciente { get; set; }
        public string fechaRstPaciente { get; set; }
        public int ID_CITA { get; set; }
        public int ID_USUARIO { get; set; }

    }
}