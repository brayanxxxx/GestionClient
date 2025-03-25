using System;

namespace GestionClient
{
    public static class ClienteFactory
    {
        public static Cliente CrearCliente(string tipo, string nombre, string identificacion, decimal saldo, int cuentas = 0)
        {
            try
            {
                if (tipo == "Corporativo")
                {
                    return new ClienteCorporativo(nombre, identificacion, saldo);
                }
                if (tipo == "Individual")
                {
                    return new ClienteIndividual(nombre, identificacion, saldo, cuentas);
                }
                throw new ArgumentException($"Tipo de cliente '{tipo}' no válido");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error al crear cliente: {ex.Message}");
                throw; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado al crear cliente de tipo '{tipo}': {ex.Message}");
                throw; 
            }
        }
    }
}