 public class Concierto
{
      public int IdConcierto{get; set;}
      public string Nombre{get; set;}
      public dateTime Fecha{get; set;}
      public Time Hora{get; set;}
      public int IdArtista{get; set;}
     public string Ubicacion{get; set;}
     public string Pais {get;set;} 
     public string Imagen{get; set;}
     public string Genero{get; set;}
     public int Stock{get; set;}
     public string Mes{get; set;}

     public Concierto(){

    }

     public Concierto(string Nombre, Date Fecha,  dateTime Hora, int IdArtista,  string Ubicacion , string pais, string Imagen, string Genero, int Stock, String Mes){
        
    }
}

