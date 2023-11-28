using System.Runtime.InteropServices.ComTypes;
using System.IO.Compression;
using System.Security.Cryptography;
using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data.SqlClient;



namespace TP11_ProyectoFinal.Models

{
    public class BD
    {
        private static string _connectionString = @"Server=localhost;DataBase=WorldConcerts;Trusted_Connection=True;";
        private static List<Concierto> listaConciertos = new List<Concierto>();
        private static List<Categoria> listaCategorias = new List<Categoria>();

        public static List<Concierto> TraerConciertos()
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * from Conciertos";
                listaConciertos = db.Query<Concierto>(sql).ToList();
            }
            return listaConciertos;
        }
        public static List<Categoria> TraerCategorias()
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * from Categorias";
                listaCategorias = db.Query<Categoria>(sql).ToList();
            }
            return listaCategorias;
        }
        public static Concierto verInfoConcierto(int idc)
        {
            Concierto ConciertoActual = null;
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Conciertos WHERE IdConcierto = @pidConcierto";
                ConciertoActual = db.QueryFirstOrDefault<Concierto>(sql, new { pidConcierto = idc });
            }
            return ConciertoActual;
        }
        public static void AgregarConciertoSP(Concierto Con)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute("sp_AgregarConcierto", new
                {
                    Nombre = Con.Nombre,
                    CantLikes = Con.CantLikes,
                    Descripcion = Con.Descripcion,
                    FechaConcierto = Con.FechaConcierto,
                    Imagen = Con.Imagen,
                    Precio = Con.Precio,
                    fkCategoria = Con.fkCategoria
                }, commandType: CommandType.StoredProcedure);
            }
        }
        public static Tarjeta VerificarSiExisteTarjeta(int numero)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Tarjeta WHERE Numero = @pNumero";
                return db.QueryFirstOrDefault<Tarjeta>(sql, new { pNumero = numero});
            }
        }   
        public static int ActualizarLikesConciertoSP(int idConcierto, int cantLikes)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string idConciertoStr = idConcierto.ToString();
                return db.Execute("sp_ActualizarLikesConcierto", new
                {
                    IdConcierto = idConciertoStr,
                    CantLikes = cantLikes
                }, commandType: CommandType.StoredProcedure);
            }
        }
        public static int VerCantLikes(int idc)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT CantLikes FROM Conciertos WHERE IdConcierto = @pIdConcierto";
                return db.QueryFirstOrDefault<int>(sql, new { pIdConcierto = idc });
            }
        }

        public static int AgregarUsuarioSP(Usuario usuario)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                return db.Execute("sp_AgregarUsuario", new
                {
                    Contraseña = usuario.Contraseña,
                    Nombre = usuario.Nombre
                }, commandType: CommandType.StoredProcedure);
            }
        }
        public static Usuario BuscarUsuario(Usuario U)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Usuarios WHERE IdUsuario = @U.IdUsuario";
                return db.QueryFirstOrDefault<Usuario>(sql);
            }
        }
        public static Usuario BuscarUsuarioXNombre(string nombre)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Usuarios WHERE Nombre = @Nombre";
                return db.QueryFirstOrDefault<Usuario>(sql, new{ Nombre = nombre });
            }
        }
        public static Usuario BuscarContraXUsuario(string nombre)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT Contraseña FROM Usuarios WHERE Nombre = @Nombre";
                return db.QueryFirstOrDefault<Usuario>(sql, new{ Nombre = nombre });
            }
        }


    }
}