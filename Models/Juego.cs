using System;

namespace TP9.Models
{
    public class concierto
    {
        private int _idconcierto;
        private string _nombre;
        private int _cantLikes;
        private string _descripcionconcierto;
        private DateTime _fechaCreacion;
        private string _imagen;

        private int _precio;

        private int _fkCategoria;

        public concierto(int Idconcierto, string Nombre, int CantLikes, string Descripcionconcierto, DateTime FechaCreacion, string Imagen, int Precio, int fkCategoria)
        {
            _idconcierto = Idconcierto;
            _nombre = Nombre;
            _cantLikes = CantLikes;
            _descripcionconcierto = Descripcionconcierto;
            _fechaCreacion = FechaCreacion;
            _imagen = Imagen;
            _precio = Precio;
            _fkCategoria = fkCategoria;

        }
        public concierto() { }
        public int Idconcierto
        {
            get { return _idconcierto; }
            set { _idconcierto = value; }
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
            get { return _descripcionconcierto; }
            set { _descripcionconcierto = value; }
        }
        public DateTime FechaCreacion
        {
            get { return _fechaCreacion; }
            set { _fechaCreacion = value; }
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