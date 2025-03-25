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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar los controles corporativos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public FormularioNuevoClienteCorporativo() : base("Nuevo Cliente Corporativo")
        {
            try
            {
                InicializarControlesCorporativo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el formulario corporativo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public FormularioNuevoClienteCorporativo(string titulo) : base(titulo)
        {
            try
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
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el formulario corporativo con título: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAceptarCorporativo_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCamposBase())
                {
                    AccesoLineaCredito = chkCredito.Checked;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al hacer clic en Aceptar (corporativo - nuevo): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAceptarCorporativoEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCamposBase())
                {
                    AccesoLineaCredito = chkCredito.Checked;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al hacer clic en Aceptar (corporativo - editar): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public new string Nombre
        {
            get
            {
                try
                {
                    return base.Nombre;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener el nombre (corporativo): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty; 
                }
            }
            set
            {
                try
                {
                    txtNombre.Text = base.Nombre = value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al establecer el nombre (corporativo): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public new string Identificacion
        {
            get
            {
                try
                {
                    return base.Identificacion;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener la identificación (corporativo): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty; 
                }
            }
            set
            {
                try
                {
                    txtIdentificacion.Text = base.Identificacion = value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al establecer la identificación (corporativo): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public new decimal Saldo
        {
            get
            {
                try
                {
                    return base.Saldo;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener el saldo (corporativo): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0; 
                }
            }
            set
            {
                try
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
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al establecer el saldo (corporativo): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public bool Credito
        {
            get
            {
                try
                {
                    return chkCredito.Checked;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener el estado del crédito: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false; 
                }
            }
            set
            {
                try
                {
                    chkCredito.Checked = value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al establecer el estado del crédito: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public new void DeshabilitarEdicionId()
        {
            try
            {
                base.DeshabilitarEdicionId();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al deshabilitar la edición del ID (corporativo): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}