namespace Entity;

public abstract class CuentaBancaria
{
    public const string RETIRO = "RETIRO";
    public const string CONSIGNACION = "CONSIGNACION";
    public string NumeroCuenta { get; set; } = string.Empty;
    public decimal Saldo { get; set; }
    public string TipoCuenta { get; set; } = string.Empty;
    public List<Movimiento> Movimientos { get; set; }

    public CuentaBancaria(string tipoCuenta)
    {
        NumeroCuenta = Guid.NewGuid().ToString();
        Saldo = 0;
        TipoCuenta = tipoCuenta;
        Movimientos = new List<Movimiento>();
    }

    public abstract void Consignar(decimal valor);
    public abstract void Retirar(decimal valor);
}
