using System;


namespace GestionClient
{
    public abstract class Cliente
    {
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public decimal Saldo { get; set; }

        public Cliente(string nombre, string identificacion, decimal saldo)
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(identificacion) || saldo <= 0)
                throw new ArgumentException("Datos inválidos para el cliente.");

            Nombre = nombre;
            Identificacion = identificacion;
            Saldo = saldo;
        }

        public abstract void MostrarInformacion();
    }
}
