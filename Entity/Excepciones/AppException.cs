namespace Entity.Excepciones;

public class AppException : Exception
{
    public AppException(string mensaje) : base(mensaje)
    {  
    }
}
