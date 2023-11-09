using System.Data.SqlClient;
using Dapper;
namespace TP11_ProyectoFinal.Models;
public static class BD{
    private static string ConnectionString { get; set; } = @"Server=localhost;DataBase=DB_Conciertos;Trusted_Connection=True;";
    public static List<Concierto> traerConciertos()
    {
        List<Concierto> listaConciertos = new List<Concierto>();
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Concierto";
            listaConciertos = db.Query<Concierto>(sql).ToList();
        }
        return listaConciertos;
    }   
    public static string traerNombre(int IdConcierto)
    {
        string nombre="";
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT Nombre FROM Artista WHERE IdArtista = (SELECT IdArtista FROM Concierto WHERE IdArtista = @id)";
            nombre = db.QueryFirstOrDefault<string>(sql, new { id = IdConcierto});
        }
        return nombre;
    }
    public static List<Concierto> traerInfo(int IdConcierto)
    {
        List<Concierto> listaInfo = new List<Concierto>();
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Concierto WHERE IdConcierto = @id";
            listaInfo = db.Query<Concierto>(sql, new { id = IdConcierto}).ToList();
        }
        return listaInfo;
    }
   
    public static void AgregarAlCarrito (Carrito carr)
    {
            string sql = "INSERT INTO Carrito(IdUsuario, IdConcierto) VALUES (@pIdUsuario, @pIdConcierto)";
            using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new {pIdUsuario = carr.IdUsuario, pIdCarrito = carr.IdConcierto});
        }
        }
    }
       public static List<Carrito> traerCarrito(int IdUsuario)
    {
        List<Carrito> listaCarrito = new List<Carrito>();
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * WHERE IdTendencia = @id";
            listaTendencia = db.Query<Tendencia>(sql, new { id = IdTendencia}).ToList();
        }
        return listaTendencia;
    }