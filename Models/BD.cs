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
     public static Concierto traerConcierto(int idconcierto)
    {
        Concierto MiConcierto = new Concierto();
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Concierto WHERE IdConcierto=@pIdConcierto";
            MiConcierto = db.QueryFirstOrDefault<Concierto>(sql, new { pIdConcierto = idconcierto});        }
        return MiConcierto;
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
   
    public static void InsertarCompra(string email, int idConcierto, int cantidad){
        string SQL = "INSERT INTO Compra(Email, IdConcierto, Cantidad) VALUES (@pEmail, @pIdConcierto, @pCantidad)";
        using(SqlConnection db = new SqlConnection(ConnectionString)){
            db.Execute(SQL, new {pEmail = email, pIdConcierto = idConcierto, pCantidad = cantidad});
        }
    }
}