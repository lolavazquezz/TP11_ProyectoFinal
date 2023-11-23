
using System;
using System.Collections.Generic;
using Dapper;
using System.Data.SqlClient;



namespace TPFinal.Models
{
    public class BD
    {
        private static string _connectionString = @"Server=localhost;DataBase=CuboGames;Trusted_Connection=True;";
        private static List<concierto> listaconciertos = new List<concierto>();
        private static List<Categoria> listaCategorias = new List<Categoria>();

        public static List<concierto> Traerconciertos()
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * from conciertos";
                listaconciertos = db.Query<concierto>(sql).ToList();
            }
            return listaconciertos;
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
        public static concierto verInfoconcierto(int idJ)
        {
            concierto conciertoActual = null;
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM conciertos WHERE Idconcierto = @pidconcierto";
                conciertoActual = db.QueryFirstOrDefault<concierto>(sql, new { pidconcierto = idJ });
            }
            return conciertoActual;
        }
        public static void AgregarconciertoSP(concierto Jug)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute("sp_Agregarconcierto", new
                {
                    Nombre = Jug.Nombre,
                    CantLikes = Jug.CantLikes,
                    Descripcion = Jug.Descripcion,
                    FechaCreacion = Jug.FechaCreacion,
                    Imagen = Jug.Imagen,
                    Precio = Jug.Precio,
                    fkCategoria = Jug.fkCategoria
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
        public static int ActualizarLikesconciertoSP(int idconcierto, int cantLikes)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string idconciertoStr = idconcierto.ToString();
                return db.Execute("sp_ActualizarLikesconcierto", new
                {
                    Idconcierto = idconciertoStr,
                    CantLikes = cantLikes
                }, commandType: CommandType.StoredProcedure);
            }
        }
        public static int VerCantLikes(int idJ)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT CantLikes FROM conciertos WHERE Idconcierto = @pIdconcierto";
                return db.QueryFirstOrDefault<int>(sql, new { pIdconcierto = idJ });
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
