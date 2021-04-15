using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTeleInf_.Models.ViewModels
{
    public class ListTablaViewModel
    {
        public int IdCita { get; set; }
        public int IdUser { get; set; }

        public string NamePacient { get; set; }

        public string ApellidoPacient { get; set; }

        public string CedulaPacient { get; set; }

        public string DireccionPacient { get; set; }

        public string TelefonoPacient { get; set; }

        public string FechaNac { get; set; }

        public string FechaPrCita { get; set; }
    }
}