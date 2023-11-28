using System;

namespace TP11_ProyectoFinal.Models
{
    public class Tarjeta
    {
        public int Numero { get; set; }
        public string Titular { get; set; }
        public int CodigoSeg { get; set; }

        public Tarjeta(int numero, string titular, int codigoSeg)
        {
            Numero = numero;
            Titular = titular;
            CodigoSeg = codigoSeg;
        }

        public Tarjeta() { }
    }
}