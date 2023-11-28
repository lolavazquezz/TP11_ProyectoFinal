using System;

namespace TP11_ProyectoFinal.Models
{
    public class Concierto
    {
        private int _idConcierto;
        private string _nombre;
        private int _cantLikes;
        private string _descripcionConcierto;
        private DateTime _FechaConcierto;
        private string _imagen;

        private int _precio;

        private int _fkCategoria;

        public Concierto(int IdConcierto, string Nombre, int CantLikes, string DescripcionConcierto, DateTime FechaConcierto, string Imagen, int Precio, int fkCategoria)
        {
            _idConcierto = IdConcierto;
            _nombre = Nombre;
            _cantLikes = CantLikes;
            _descripcionConcierto = DescripcionConcierto;
            _FechaConcierto = FechaConcierto;
            _imagen = Imagen;
            _precio = Precio;
            _fkCategoria = fkCategoria;

        }
        public Concierto() { }
        public int IdConcierto
        {
            get { return _idConcierto; }
            set { _idConcierto = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public int CantLikes
        {
            get { return _cantLikes; }
            set { _cantLikes = value; }
        }
        public string Descripcion
        {
            get { return _descripcionConcierto; }
            set { _descripcionConcierto = value; }
        }
        public DateTime FechaConcierto
        {
            get { return _FechaConcierto; }
            set { _FechaConcierto = value; }
        }
        public string Imagen
        {
            get { return _imagen; }
            set { _imagen = value; }
        }
        public int Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

         public int fkCategoria
        {
            get { return _fkCategoria; }
            set { _fkCategoria = value; }
        }

    }
}