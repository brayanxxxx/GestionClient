using System;

using System.Windows.Forms;
using GestionClient;

namespace GestionDeClientes
{
    public partial class Form1 : Form
    {
        private ListBox listClientes;
        private Button btnAgregarCorporativo, btnAgregarIndividual, btnEliminar, btnListar;
        private TextBox txtIdentificacion;

        public Form1()
        {
            InitializeComponent();

            listClientes = new ListBox() { Top = 10, Left = 10, Width = 400, Height = 150 };
            txtIdentificacion = new TextBox() { Top = 170, Left = 10, Width = 200 };
            btnAgregarCorporativo = new Button() { Top = 200, Left = 10, Text = "Agregar Corporativo" };
            btnAgregarIndividual = new Button() { Top = 200, Left = 150, Text = "Agregar Individual" };
            btnEliminar = new Button() { Top = 200, Left = 300, Text = "Eliminar Cliente" };
            btnListar = new Button() { Top = 240, Left = 10, Text = "Listar Clientes" };

            btnAgregarCorporativo.Click += BtnAgregarCorporativo_Click;
            btnAgregarIndividual.Click += BtnAgregarIndividual_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnListar.Click += BtnListar_Click;

            Controls.Add(listClientes);
            Controls.Add(txtIdentificacion);
            Controls.Add(btnAgregarCorporativo);
            Controls.Add(btnAgregarIndividual);
            Controls.Add(btnEliminar);
            Controls.Add(btnListar);

            this.Text = "Gestión de Clientes";
            this.ClientSize = new System.Drawing.Size(420, 280);

            txtIdentificacion.Text = "ID para eliminar";
            txtIdentificacion.ForeColor = System.Drawing.SystemColors.GrayText;
            txtIdentificacion.Enter += TxtIdentificacion_Enter;
            txtIdentificacion.Leave += TxtIdentificacion_Leave;
        }

        private void TxtIdentificacion_Enter(object sender, EventArgs e)
        {
            if (txtIdentificacion.Text == "ID para eliminar")
            {
                txtIdentificacion.Text = "";
                txtIdentificacion.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void TxtIdentificacion_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdentificacion.Text))
            {
                txtIdentificacion.Text = "ID para eliminar";
                txtIdentificacion.ForeColor = System.Drawing.SystemColors.GrayText;
            }
        }

        private void BtnAgregarCorporativo_Click(object sender, EventArgs e)
        {
            using (var formularioNuevoCliente = new FormularioNuevoClienteCorporativo())
            {
                if (formularioNuevoCliente.ShowDialog() == DialogResult.OK)
                {
                    string nombre = formularioNuevoCliente.Nombre;
                    string identificacion = formularioNuevoCliente.Identificacion;
                    decimal saldo = formularioNuevoCliente.Saldo;

                    try
                    {
                        Cliente nuevoCliente = ClienteFactory.CrearCliente("Corporativo", nombre, identificacion, saldo);
                        GestorClientes.Instancia.AgregarCliente(nuevoCliente);
                        MessageBox.Show("Cliente Corporativo agregado");
                        ActualizarListaClientes();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show($"Error al crear el cliente: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error inesperado: {ex.Message}");
                    }
                }
            }
        }

        private void BtnAgregarIndividual_Click(object sender, EventArgs e)
        {
            using (var formularioNuevoClienteIndividual = new FormularioNuevoClienteIndividual())
            {
                if (formularioNuevoClienteIndividual.ShowDialog() == DialogResult.OK)
                {
                    string nombre = formularioNuevoClienteIndividual.Nombre;
                    string identificacion = formularioNuevoClienteIndividual.Identificacion;
                    decimal saldo = formularioNuevoClienteIndividual.Saldo;
                    int cuentas = formularioNuevoClienteIndividual.CantidadCuentas;

                    try
                    {
                        Cliente nuevoCliente = ClienteFactory.CrearCliente("Individual", nombre, identificacion, saldo, cuentas);
                        GestorClientes.Instancia.AgregarCliente(nuevoCliente);
                        MessageBox.Show("Cliente Individual agregado");
                        ActualizarListaClientes();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show($"Error al crear el cliente: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error inesperado: {ex.Message}");
                    }
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            GestorClientes.Instancia.EliminarCliente(txtIdentificacion.Text);
            MessageBox.Show("Cliente eliminado si existía");
            ActualizarListaClientes();
        }

        private void BtnListar_Click(object sender, EventArgs e)
        {
            ActualizarListaClientes();
        }

        private void ActualizarListaClientes()
        {
            listClientes.Items.Clear();
            foreach (var cliente in GestorClientes.Instancia.ObtenerClientes())
            {
                if (cliente is ClienteCorporativo clienteCorporativo)
                {
                    listClientes.Items.Add($"{clienteCorporativo.Nombre} - ID: {clienteCorporativo.Identificacion} - Saldo: {clienteCorporativo.Saldo:C} - Crédito: {(clienteCorporativo.AccesoLineaCredito ? "Sí" : "No")}");
                }
                else if (cliente is ClienteIndividual clienteIndividual)
                {
                    listClientes.Items.Add($"{clienteIndividual.Nombre} - ID: {clienteIndividual.Identificacion} - Saldo: {clienteIndividual.Saldo:C} - Cuentas: {clienteIndividual.CantidadCuentasActivas}");
                }
            }
        }
    }
}