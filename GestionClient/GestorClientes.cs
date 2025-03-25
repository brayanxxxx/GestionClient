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
                {
                    try
                    {
                        _instancia = new GestorClientes();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al crear la instancia de GestorClientes: {ex.Message}");
                        throw;
                    }
                }
                return _instancia;
            }
        }

        public void AgregarCliente(Cliente cliente)
        {
            try
            {
                if (clientes.Exists(c => c.Identificacion == cliente.Identificacion))
                {
                    throw new Exception("El cliente ya está registrado.");
                }
                clientes.Add(cliente);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar cliente: {ex.Message}");
                throw; 
            }
        }

        public void EliminarCliente(string identificacion)
        {
            try
            {
                clientes.RemoveAll(c => c.Identificacion == identificacion);
                if (!clientes.Exists(c => c.Identificacion == identificacion))
                {
                    Console.WriteLine($"Cliente con identificación '{identificacion}' eliminado (si existía).");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar cliente con identificación '{identificacion}': {ex.Message}");
                throw; 
            }
        }

        public List<Cliente> ObtenerClientes()
        {
            try
            {
                return clientes;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la lista de clientes: {ex.Message}");
                return new List<Cliente>(); 
            }
        }
    }
}