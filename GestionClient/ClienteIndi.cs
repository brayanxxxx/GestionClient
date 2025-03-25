using System;

using System.Windows.Forms;

namespace GestionClient
{
    public class ClienteIndividual : Cliente
    {
        public int CantidadCuentasActivas { get; private set; }

        public ClienteIndividual(string nombre, string identificacion, decimal saldo, int cantidadCuentas) : base(nombre, identificacion, saldo)
        {
            if (cantidadCuentas > 3)
            {
                throw new ArgumentException($"El cliente individual '{nombre}' con ID '{identificacion}' no puede tener más de 3 cuentas activas. Se intentó crear con {cantidadCuentas} cuentas.");
            }
            CantidadCuentasActivas = cantidadCuentas;
        }

        public override void MostrarInformacion()
        {
            MessageBox.Show($"Cliente Individual: {Nombre}, ID: {Identificacion}, Saldo: {Saldo}, Cuentas Activas: {CantidadCuentasActivas}");
        }
    }
}
