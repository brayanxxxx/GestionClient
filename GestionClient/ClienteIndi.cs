using System;
using System.Windows.Forms;

namespace GestionClient
{
    public class ClienteIndividual : Cliente
    {
        public int CantidadCuentasActivas { get; private set; }

        public ClienteIndividual(string nombre, string identificacion, decimal saldo, int cantidadCuentas) : base(nombre, identificacion, saldo)
        {
            try
            {
                if (cantidadCuentas > 3)
                {
                    throw new ArgumentException($"El cliente individual '{nombre}' con ID '{identificacion}' no puede tener más de 3 cuentas activas. Se intentó crear con {cantidadCuentas} cuentas.");
                }
                CantidadCuentasActivas = cantidadCuentas;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error de Creación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado al crear el cliente individual '{nombre}': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; 
            }
        }

        public override void MostrarInformacion()
        {
            try
            {
                MessageBox.Show($"Cliente Individual: {Nombre}, ID: {Identificacion}, Saldo: {Saldo}, Cuentas Activas: {CantidadCuentasActivas}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar la información del cliente individual '{Nombre}': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}