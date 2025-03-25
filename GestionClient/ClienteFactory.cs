using System;


namespace GestionClient
{
    public static class ClienteFactory
    {
        public static Cliente CrearCliente(string tipo, string nombre, string identificacion, decimal saldo, int cuentas = 0)
        {
            if (tipo == "Corporativo") return new ClienteCorporativo(nombre, identificacion, saldo);
            if (tipo == "Individual") return new ClienteIndividual(nombre, identificacion, saldo, cuentas);
            throw new ArgumentException("Tipo de cliente no válido");
        }
    }
}
