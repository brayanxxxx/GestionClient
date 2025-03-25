using System;

using System.Windows.Forms;

namespace GestionClient
{
    public abstract partial class FormularioNuevoClienteBase : Form
    {
        protected Label lblNombre, lblIdentificacion, lblSaldo;
        protected TextBox txtNombre, txtIdentificacion, txtSaldo;
        protected Button btnAceptar, btnCancelar;

        public string Nombre { get; protected set; }
        public string Identificacion { get; protected set; }
        public decimal Saldo { get; protected set; }

        public FormularioNuevoClienteBase(string titulo)
        {
            try
            {
                InitializeComponent();
                Text = titulo;
                StartPosition = FormStartPosition.CenterParent;
                FormBorderStyle = FormBorderStyle.FixedDialog;
                MaximizeBox = false;
                MinimizeBox = false;
                ClientSize = new System.Drawing.Size(300, 180);

                lblNombre = new Label() { Text = "Nombre:", Top = 20, Left = 20, Width = 80 };
                txtNombre = new TextBox() { Top = 20, Left = 110, Width = 150 };

                lblIdentificacion = new Label() { Text = "Identificación:", Top = 50, Left = 20, Width = 80 };
                txtIdentificacion = new TextBox() { Top = 50, Left = 110, Width = 150 };

                lblSaldo = new Label() { Text = "Saldo:", Top = 80, Left = 20, Width = 80 };
                txtSaldo = new TextBox() { Top = 80, Left = 110, Width = 150 };

                btnAceptar = new Button() { Text = "Aceptar", Top = 120, Left = 60, Width = 80 };
                btnCancelar = new Button() { Text = "Cancelar", Top = 120, Left = 160, Width = 80 };

                btnCancelar.Click += BtnCancelar_Click;

                Controls.Add(lblNombre);
                Controls.Add(txtNombre);
                Controls.Add(lblIdentificacion);
                Controls.Add(txtIdentificacion);
                Controls.Add(lblSaldo);
                Controls.Add(txtSaldo);
                Controls.Add(btnAceptar);
                Controls.Add(btnCancelar);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar el formulario base: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual bool ValidarCamposBase()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtIdentificacion.Text) || string.IsNullOrWhiteSpace(txtSaldo.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!decimal.TryParse(txtSaldo.Text, out decimal saldoIngresado) || saldoIngresado <= 0)
                {
                    MessageBox.Show("El saldo debe ser un número válido mayor que cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                Nombre = txtNombre.Text;
                Identificacion = txtIdentificacion.Text;
                Saldo = saldoIngresado;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar los campos base: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; 
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al hacer clic en Cancelar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void DeshabilitarEdicionId()
        {
            try
            {
                txtIdentificacion.ReadOnly = true;
                txtIdentificacion.BackColor = System.Drawing.SystemColors.ControlLight;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al deshabilitar la edición del ID en la base: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Designer generated code
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            try
            {
                this.SuspendLayout();
                this.ClientSize = new System.Drawing.Size(300, 180);
                this.Name = "FormularioNuevoClienteBase";
                this.Text = "Nuevo Cliente";
                this.ResumeLayout(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar componentes del diseñador: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}