using System;
using System.Windows.Forms;
using System.Linq;

namespace GestionClient
{
    public partial class FormularioNuevoClienteCorporativo : FormularioNuevoClienteBase
    {
        private Label lblCredito;
        private CheckBox chkCredito;

        public bool AccesoLineaCredito { get; set; }

        private void InicializarControlesCorporativo()
        {
            lblCredito = new Label() { Text = "Línea de Crédito:", Top = 110, Left = 20, Width = 100 };
            chkCredito = new CheckBox() { Top = 110, Left = 130, Width = 20 };

            btnAceptar.Top = 150;
            btnCancelar.Top = 150;

            ClientSize = new System.Drawing.Size(300, 220);

            Controls.Add(lblCredito);
            Controls.Add(chkCredito);

            btnAceptar.Click += BtnAceptarCorporativo_Click;
        }

        public FormularioNuevoClienteCorporativo() : base("Nuevo Cliente Corporativo")
        {
            InicializarControlesCorporativo();
        }

        public FormularioNuevoClienteCorporativo(string titulo) : base(titulo)
        {
            InicializarControlesCorporativo();
            lblCredito = Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Text == "Línea de Crédito:");
            chkCredito = Controls.OfType<CheckBox>().FirstOrDefault(chk => chk.Top == 110 && chk.Left == 130);

            if (lblCredito == null || chkCredito == null)
            {
                throw new InvalidOperationException("Los controles específicos del cliente corporativo no se inicializaron correctamente.");
            }

            chkCredito.Enabled = false;
            btnAceptar.Click += BtnAceptarCorporativoEditar_Click;
        }

        private void BtnAceptarCorporativo_Click(object sender, EventArgs e)
        {
            if (ValidarCamposBase())
            {
                AccesoLineaCredito = chkCredito.Checked;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void BtnAceptarCorporativoEditar_Click(object sender, EventArgs e)
        {
            if (ValidarCamposBase())
            {
                AccesoLineaCredito = chkCredito.Checked;
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

        public bool Credito
        {
            get => chkCredito.Checked;
            set => chkCredito.Checked = value;
        }

        public new void DeshabilitarEdicionId()
        {
            base.DeshabilitarEdicionId();
        }
    }
}