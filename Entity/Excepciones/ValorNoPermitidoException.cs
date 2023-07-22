namespace Entity.Excepciones;

public class ValorNoPermitidoException : AppException
{
    public ValorNoPermitidoException(string mensaje) : base(mensaje)
    {
    }

}
