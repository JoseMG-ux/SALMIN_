using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace PTeleInf_.Models.ViewModels
{
    public class CrearPacienteViewModel
    {

        public int IdCita { get; set; }

        [Required]
        [StringLength(50)]
        public string NamePacient { get; set; }

        [Required]
        [StringLength(50)]
        public string ApellidoPacient { get; set; }

        [Required]
        [StringLength(50)]
        public string CedulaPacient { get; set; }

        [Required]
        [StringLength(50)]
        public string DireccionPacient { get; set; }

        [Required]
        [StringLength(50)]
        public string TelefonoPacient { get; set; }

        [Required]
        //[DataType(DataType.Date)]
        public string FechaNac { get; set; }

        [Required]
        public string FechaPrCita { get; set; }

        
    }

}
