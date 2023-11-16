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
   
    public static void AgregarAlCarrito (Carrito carr)
    {
            string sql = "INSERT INTO Carrito(IdUsuario, IdConcierto) VALUES (@pIdUsuario, @pIdConcierto)";
            using(SqlConnection db = new SqlConnection(ConnectionString)){
            db.Execute(sql, new {pIdUsuario = carr.IdUsuario, pIdCarrito = carr.IdConcierto});
        }
       
    }
       public static List<Carrito> traerCarrito(int IdUsuario)
    {
        List<Carrito> listaCarrito = new List<Carrito>();
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Carrito WHERE IdUsuario=@pIdUsuario";
            listaCarrito = db.Query<Carrito>(sql, new { pIdUsuario=IdUsuario}).ToList();
        }
        return listaCarrito;
    }
    
    public static Usuario login(string username, string contraseña)
    {
        Usuario user = null;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Usuario WHERE username = @pusername AND contraseña = @pcontra";
            user = db.QueryFirstOrDefault<Usuario>(sql, new { pusername = username, pcontra = contraseña });
        }
        return user;
    }
    public static void crearUsuario(Usuario usu){
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "INSERT INTO Usuario(Dni,Nombre,Email,Clave) VALUES (@pDni, @pNombre, @pEmail, @pClave)";
            db.Execute(sql, new {pDni = usu.Dni, pNombre = usu.Nombre, pEmail = usu.Email, pClave = usu.Clave});
        }
    }    
    public static string traerPregunta(string email){
        string pregunta ="";
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT pregunta FROM Usuario WHERE email = @puemail";
            pregunta = db.QueryFirstOrDefault<string>(sql, new { puemail = email});
        }
        return pregunta;
    }
    public static bool validarRta(string respuesta){
        int cant=0;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT COUNT(*) FROM Usuario WHERE respuesta = @prespuesta";
            cant = db.QueryFirstOrDefault<int>(sql, new { prespuesta = respuesta});
        }
        if (cant > 0) return true;
        else return false;
    }
    public static string traerContra(string email){
        string contra = "";
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT contraseña FROM Usuario WHERE email = @puemail";
            contra = db.QueryFirstOrDefault<string>(sql, new { puemail = email});
        }
        return contra;
    }
    public static bool existe(string username)
    {
        int cant=0;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string lowerUsername = username.ToLower();
            string sql = "SELECT COUNT(*) FROM Usuario WHERE LOWER(username) = @pusername";
            cant = db.QueryFirstOrDefault<int>(sql, new { pusername = lowerUsername});
        }
        if (cant > 0) return true;
        else return false;
    }
    public static bool existeMail(string email)
    {
        int cant=0;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string lowerMail = email.ToLower();
            string sql = "SELECT COUNT(*) FROM Usuario WHERE LOWER(email) = @pemail";
            cant = db.QueryFirstOrDefault<int>(sql, new { pemail = lowerMail});
        }
        if (cant > 0) return true;
        else return false;
    }
}