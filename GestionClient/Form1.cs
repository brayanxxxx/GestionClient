using System;
using System.Windows.Forms;
using GestionClient;
using System.Linq;

namespace GestionDeClientes
{
    public partial class Form1 : Form
    {
        private ListBox listClientes;
        private Button btnAgregarCorporativo, btnAgregarIndividual, btnEliminar, btnListar, btnEditar;
        private TextBox txtIdentificacion;

        public Form1()
        {
            InitializeComponent();

            listClientes = new ListBox() { Top = 10, Left = 10, Width = 400, Height = 150 };
            txtIdentificacion = new TextBox() { Top = 170, Left = 10, Width = 200 };
            btnAgregarCorporativo = new Button() { Top = 200, Left = 10, Text = "Corporativo" };
            btnAgregarIndividual = new Button() { Top = 200, Left = 150, Text = "Individual" };
            btnEliminar = new Button() { Top = 200, Left = 300, Text = "Eliminar Cliente" };
            btnListar = new Button() { Top = 240, Left = 10, Text = "Listar Clientes" };
            btnEditar = new Button() { Top = 240, Left = 150, Text = "Editar Cliente" };

            btnAgregarCorporativo.Click += BtnAgregarCorporativo_Click;
            btnAgregarIndividual.Click += BtnAgregarIndividual_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnListar.Click += BtnListar_Click;
            btnEditar.Click += BtnEditar_Click;

            Controls.Add(listClientes);
            Controls.Add(txtIdentificacion);
            Controls.Add(btnAgregarCorporativo);
            Controls.Add(btnAgregarIndividual);
            Controls.Add(btnEliminar);
            Controls.Add(btnListar);
            Controls.Add(btnEditar);

            this.Text = "Gestión de Clientes";
            this.ClientSize = new System.Drawing.Size(420, 280);

            txtIdentificacion.Text = "ID para eliminar/editar";
            txtIdentificacion.ForeColor = System.Drawing.SystemColors.GrayText;
            txtIdentificacion.Enter += TxtIdentificacion_Enter;
            txtIdentificacion.Leave += TxtIdentificacion_Leave;
        }

        private void TxtIdentificacion_Enter(object sender, EventArgs e)
        {
            if (txtIdentificacion.Text == "ID para eliminar/editar")
            {
                txtIdentificacion.Text = "";
                txtIdentificacion.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void TxtIdentificacion_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdentificacion.Text))
            {
                txtIdentificacion.Text = "ID para eliminar/editar";
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

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            string idEditar = txtIdentificacion.Text;
            var clienteAEditar = GestorClientes.Instancia.ObtenerClientes().FirstOrDefault(c => c.Identificacion == idEditar);

            if (clienteAEditar != null)
            {
                if (clienteAEditar is ClienteCorporativo clienteCorporativo)
                {
                    using (var formularioEditar = new FormularioNuevoClienteCorporativo("Editar Cliente Corporativo"))
                    {
                        formularioEditar.Nombre = clienteCorporativo.Nombre;
                        formularioEditar.Identificacion = clienteCorporativo.Identificacion;
                        formularioEditar.Saldo = clienteCorporativo.Saldo;
                        formularioEditar.Credito = clienteCorporativo.AccesoLineaCredito;
                        formularioEditar.DeshabilitarEdicionId();

                        if (formularioEditar.ShowDialog() == DialogResult.OK)
                        {
                            clienteCorporativo.Nombre = formularioEditar.Nombre;
                            clienteCorporativo.Saldo = formularioEditar.Saldo;
                            MessageBox.Show($"Cliente con ID '{idEditar}' editado.");
                            ActualizarListaClientes();
                        }
                    }
                }
                else if (clienteAEditar is ClienteIndividual clienteIndividual)
                {
                    using (var formularioEditar = new FormularioNuevoClienteIndividual("Editar Cliente Individual"))
                    {
                        formularioEditar.Nombre = clienteIndividual.Nombre;
                        formularioEditar.Identificacion = clienteIndividual.Identificacion;
                        formularioEditar.Saldo = clienteIndividual.Saldo;
                        formularioEditar.CantidadCuentasActivas = clienteIndividual.CantidadCuentasActivas;
                        formularioEditar.DeshabilitarEdicionId();

                        if (formularioEditar.ShowDialog() == DialogResult.OK)
                        {
                            clienteIndividual.Nombre = formularioEditar.Nombre;
                            clienteIndividual.Saldo = formularioEditar.Saldo;
                            MessageBox.Show($"Cliente con ID '{idEditar}' editado.");
                            ActualizarListaClientes();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show($"No se encontró ningún cliente con el ID '{idEditar}'.");
            }
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