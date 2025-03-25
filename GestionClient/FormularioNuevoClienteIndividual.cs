using System;

using System.Windows.Forms;

namespace GestionClient
{
    public partial class FormularioNuevoClienteIndividual : FormularioNuevoClienteBase
    {
        private Label lblCantidadCuentas;
        private TextBox txtCantidadCuentas;
        public int CantidadCuentas { get; private set; }

        public FormularioNuevoClienteIndividual() : base("Nuevo Cliente Individual")
        {
            InitializeIndividualComponents();
            btnAceptar.Click += BtnAceptarIndividual_Click;
        }

        private void InitializeIndividualComponents()
        {
            lblCantidadCuentas = new Label() { Text = "Cant.Cuentas:", Top = 110, Left = 20, Width = 80 };
            txtCantidadCuentas = new TextBox() { Top = 110, Left = 110, Width = 150 };
            ClientSize = new System.Drawing.Size(300, 210);
            Controls.Add(lblCantidadCuentas);
            Controls.Add(txtCantidadCuentas);
        }

        private void BtnAceptarIndividual_Click(object sender, EventArgs e)
        {
            if (ValidarCamposBase() && ValidarCamposIndividual())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool ValidarCamposIndividual()
        {
            if (string.IsNullOrWhiteSpace(txtCantidadCuentas.Text))
            {
                MessageBox.Show("Por favor, ingrese la cantidad de cuentas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(txtCantidadCuentas.Text, out int cantidadCuentasIngresada) || cantidadCuentasIngresada < 0)
            {
                MessageBox.Show("La cantidad de cuentas debe ser un número entero no negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cantidadCuentasIngresada > 3)
            {
                MessageBox.Show("Un cliente individual no puede tener más de 3 cuentas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            CantidadCuentas = cantidadCuentasIngresada;
            return true;
        }
    }
}
