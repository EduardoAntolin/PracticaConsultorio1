﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaConsultorio
{
    class Consulta
    {
        public Paciente PacienteActual { get; set; }
        public string Sintomas { get; set; }
        public string Diagnostico { get; set; }
        public string Receta { get; set; }
        public DateTime fecha { get; set; }
    }
}
