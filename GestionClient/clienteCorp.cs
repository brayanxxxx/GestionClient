
using System.Windows.Forms;

namespace GestionClient
{
    public class ClienteCorporativo : Cliente
    {
        public bool AccesoLineaCredito { get; private set; }

        public ClienteCorporativo(string nombre, string identificacion, decimal saldo) : base(nombre, identificacion, saldo)
        {
            if (saldo > 50000000)
            {
                AccesoLineaCredito = true;
                MessageBox.Show($"El cliente corporativo '{nombre}' con ID '{identificacion}' tiene acceso a línea de crédito.", "Acceso a Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                AccesoLineaCredito = false;
                MessageBox.Show($"El cliente corporativo '{nombre}' con ID '{identificacion}' no tiene acceso a línea de crédito debido a que su saldo de {saldo:C} es inferior a $50,000,000.", "Acceso a Crédito", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void MostrarInformacion()
        {
            MessageBox.Show($"Cliente Corporativo: {Nombre}, ID: {Identificacion}, Saldo: {Saldo}, Crédito: {(AccesoLineaCredito ? "Sí" : "No")}");
        }
    }
}
