using System;
using System.Windows.Forms;
using System.Linq;

namespace GestionClient
{
    public partial class FormularioNuevoClienteIndividual : FormularioNuevoClienteBase
    {
        private Label lblCantidadCuentas;
        private NumericUpDown nudCantidadCuentas;

        public int CantidadCuentasActivas { get; set; }

        public int CantidadCuentas
        {
            get => (int)nudCantidadCuentas.Value;
            set => nudCantidadCuentas.Value = value;
        }

        private void InicializarControlesIndividual()
        {
            lblCantidadCuentas = new Label() { Text = "Cantidad Cuentas:", Top = 110, Left = 20, Width = 100 };
            nudCantidadCuentas = new NumericUpDown() { Top = 110, Left = 130, Width = 50, Minimum = 0, Maximum = 10 };

            btnAceptar.Top = 150;
            btnCancelar.Top = 150;

            ClientSize = new System.Drawing.Size(300, 220);

            Controls.Add(lblCantidadCuentas);
            Controls.Add(nudCantidadCuentas);

            btnAceptar.Click += BtnAceptarIndividual_Click;
        }

        public FormularioNuevoClienteIndividual() : base("Nuevo Cliente Individual")
        {
            InicializarControlesIndividual();
        }

        public FormularioNuevoClienteIndividual(string titulo) : base(titulo)
        {
            InicializarControlesIndividual();
            lblCantidadCuentas = Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Text == "Cantidad Cuentas:");
            nudCantidadCuentas = Controls.OfType<NumericUpDown>().FirstOrDefault(nud => nud.Top == 110 && nud.Left == 130);
            if (lblCantidadCuentas == null || nudCantidadCuentas == null)
            {
                throw new InvalidOperationException("Los controles específicos del cliente individual no se inicializaron correctamente.");
            }
            nudCantidadCuentas.Enabled = false;
            btnAceptar.Click += BtnAceptarIndividualEditar_Click;
        }

        private void BtnAceptarIndividual_Click(object sender, EventArgs e)
        {
            if (ValidarCamposBase())
            {
                CantidadCuentasActivas = (int)nudCantidadCuentas.Value; 
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void BtnAceptarIndividualEditar_Click(object sender, EventArgs e)
        {
            if (ValidarCamposBase())
            {
                CantidadCuentasActivas = (int)nudCantidadCuentas.Value; 
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        public new string Nombre
        {
            get => base.Nombre;
            set => txtNombre.Text = base.Nombre = value;
        }

        public new string Identificacion
        {
            get => base.Identificacion;
            set => txtIdentificacion.Text = base.Identificacion = value;
        }

        public new decimal Saldo
        {
            get => base.Saldo;
            set
            {
                if (decimal.TryParse(value.ToString(), out decimal saldoValue))
                {
                    txtSaldo.Text = saldoValue.ToString();
                    base.Saldo = saldoValue;
                }
                else
                {
                    MessageBox.Show("El valor proporcionado para el saldo no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public new void DeshabilitarEdicionId()
        {
            base.DeshabilitarEdicionId();
        }
    }
}