using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaConsultorio
{
    public class Paciente
    {
        public string Nombre { get; set; }
        public string Direccion {get;set;}
        public string Telefono { get; set; }
        public int Edad { get; set; }
        public float Peso { get; set; }
        public float Altura { get; set; }
        public string EnfermedadesCronicas { get; set; }

        /*public Paciente(string nombre, string direccion, string telefono, int edad, float peso, float altura, string enfermedadesCronicas)
        {
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            Edad = edad;
            Peso = peso;
            Altura = altura;
            EnfermedadesCronicas = enfermedadesCronicas;
        }*/

    }
}
