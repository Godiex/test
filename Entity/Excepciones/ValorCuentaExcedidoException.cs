namespace Entity.Excepciones;

public class ValorCuentaExcedidoException : AppException
{
    public ValorCuentaExcedidoException(string mensaje) : base(mensaje)
    {
    }

}
