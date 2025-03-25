using System;
using System.Collections.Generic;


namespace GestionClient
{
    public class GestorClientes
    {
        private static GestorClientes _instancia;
        private List<Cliente> clientes = new List<Cliente>();

        private GestorClientes() { }

        public static GestorClientes Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new GestorClientes();
                return _instancia;
            }
        }

        public void AgregarCliente(Cliente cliente)
        {
            if (clientes.Exists(c => c.Identificacion == cliente.Identificacion))
                throw new Exception("El cliente ya está registrado.");
            clientes.Add(cliente);
        }

        public void EliminarCliente(string identificacion)
        {
            clientes.RemoveAll(c => c.Identificacion == identificacion);
        }

        public List<Cliente> ObtenerClientes()
        {
            return clientes;
        }
    }
}
