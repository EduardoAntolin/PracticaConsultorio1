using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PracticaConsultorio
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime fechaInicioConsulta;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Paciente nuevoPaciente = new Paciente();
            nuevoPaciente.Nombre = txtNombre.Text;
            nuevoPaciente.Direccion = txtDireccion.Text;
            nuevoPaciente.Telefono = txtTelefono.Text;
            nuevoPaciente.Edad = int.Parse(txtEdad.Text);
            nuevoPaciente.Altura = float.Parse(txtAltura.Text);
            nuevoPaciente.Peso = float.Parse(txtPeso.Text);
            nuevoPaciente.EnfermedadesCronicas = txtEnfermedadesCronicas.Text;

            Datos.pacientes.Add(nuevoPaciente);
            actualizarListaPaciente();

            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEdad.Text = "";
            txtPeso.Text = "";
            txtAltura.Text = "";
            txtEnfermedadesCronicas.Text = "";

            gridNuevoPaciente.Visibility = Visibility.Collapsed;
        }

        private void actualizarListaPaciente()
        {
            lstPacientes.Items.Clear();
            foreach(Paciente paciente in Datos.pacientes)
            {
                lstPacientes.Items.Add(
                    new ListBoxItem()
                    {
                        Content = paciente.Nombre
                    }
                );
            }
        }

        private void btnNuevoPaciente_Click(object sender, RoutedEventArgs e)
        {
            gridNuevoPaciente.Visibility = Visibility.Visible;
        }

        private void lstPacientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstPacientes.SelectedIndex != -1)
            {
                btnNuevaConsulta.IsEnabled=true;
            }
            else
            {
                btnNuevaConsulta.IsEnabled = false;
            }
        }

        private void btnNuevaConsulta_Click(object sender, RoutedEventArgs e)
        {
            Paciente paciente = Datos.pacientes[lstPacientes.SelectedIndex];
            gridFormularioNuevaConsulta.Visibility = Visibility.Visible;
            txtNombreConsulta.Text = paciente.Nombre;
            txtPesoConsulta.Text = paciente.Peso.ToString();
            txtEdadConsulta.Text = paciente.Edad.ToString();
            txtAlturaConsulta.Text = paciente.Altura.ToString();
            txtEnfermedadesCronicasConsulta.Text = paciente.EnfermedadesCronicas;

            fechaInicioConsulta = DateTime.Now;

            txtFechaConsulta.Text = fechaInicioConsulta.ToString();

        }

        private void btnGuardarConsulta_Click(object sender, RoutedEventArgs e)
        {
            Consulta nuevaConsulta = new Consulta();
            nuevaConsulta.PacienteActual = Datos.pacientes[lstPacientes.SelectedIndex];
            nuevaConsulta.Sintomas = txtSintomasConsulta.Text;
            nuevaConsulta.Diagnostico = txtDiagnosticoConsulta.Text;
            nuevaConsulta.Receta = txtRecetaConsulta.Text;
            nuevaConsulta.fecha = fechaInicioConsulta;
            Datos.consultas.Add(nuevaConsulta);
            
            txtNombreConsulta.Text = "";
            txtPesoConsulta.Text = "";
            txtEdadConsulta.Text = "";
            txtAlturaConsulta.Text = "";
            txtEnfermedadesCronicasConsulta.Text = "";

            txtDiagnosticoConsulta.Text = "";
            txtFechaConsulta.Text = "";
            txtRecetaConsulta.Text = "";
            txtSintomasConsulta.Text = "";

            var consultas = Datos.consultas;

            gridFormularioNuevaConsulta.Visibility = Visibility.Collapsed;

        }

        private void btnHistorialConsultas_Click(object sender, RoutedEventArgs e)
        {
          var pacientes = Datos.pacientes[lstPacientes.SelectedIndex];


            var ventanaHistorial = new HistorialConsultasWindow(paciente);
            ventanaHistorial.Show();


        }
    }
}
