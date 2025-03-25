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
            get
            {
                try
                {
                    return (int)nudCantidadCuentas.Value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener la cantidad de cuentas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0; 
                }
            }
            set
            {
                try
                {
                    nudCantidadCuentas.Value = value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al establecer la cantidad de cuentas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InicializarControlesIndividual()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar los controles individuales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public FormularioNuevoClienteIndividual() : base("Nuevo Cliente Individual")
        {
            try
            {
                InicializarControlesIndividual();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
            }
        }

        public FormularioNuevoClienteIndividual(string titulo) : base(titulo)
        {
            try
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
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el formulario con título: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
            }
        }

        private void BtnAceptarIndividual_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCamposBase())
                {
                    CantidadCuentasActivas = (int)nudCantidadCuentas.Value;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al hacer clic en Aceptar (nuevo): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             
            }
        }

        private void BtnAceptarIndividualEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCamposBase())
                {
                    CantidadCuentasActivas = (int)nudCantidadCuentas.Value;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al hacer clic en Aceptar (editar): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
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
                    MessageBox.Show($"Error al obtener el nombre: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show($"Error al establecer el nombre: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
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
                    MessageBox.Show($"Error al obtener la identificación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show($"Error al establecer la identificación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show($"Error al obtener el saldo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show($"Error al establecer el saldo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Error al deshabilitar la edición del ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}