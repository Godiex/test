namespace Entity;

public class Movimiento
{
    public string Numero { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public DateTime Fecha { get; set; }
    public string TipoMovimiento { get; set; } = string.Empty;

    public Movimiento(decimal valor, string tipoMovimiento)
    {
        Numero = Guid.NewGuid().ToString();
        Valor = valor;
        TipoMovimiento = tipoMovimiento;
        Fecha = DateTime.Now;
    }
}
