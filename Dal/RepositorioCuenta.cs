using Entity;

namespace Dal;
public class RepositorioCuenta
{
    public List<CuentaBancaria> Cuentas { get; set; }
    
    public RepositorioCuenta()
    {
        Cuentas = new List<CuentaBancaria>();
    }

    public void Agregar(CuentaBancaria cuenta)
    {
        Cuentas.Add(cuenta);
    }

    public List<CuentaBancaria> Consultar()
    {
        return Cuentas;
    }

    public void Editar(CuentaBancaria cuentaEditada)
    {
        foreach (var c in Cuentas)
        {
            if (c.NumeroCuenta == cuentaEditada.NumeroCuenta)
            {
                c.Movimientos = cuentaEditada.Movimientos;
                c.Saldo = cuentaEditada.Saldo;
            }
        }
    }

    public CuentaBancaria Buscar(string numeroCuenta)
    {
        foreach (var c in Cuentas)
        {
            if (c.NumeroCuenta == numeroCuenta)
            {
                return c;
            }
        }
        return null;
    }

    public List<Movimiento> ConsultarMovimientos(string numeroCuenta)
    {
        CuentaBancaria cuenta = Buscar(numeroCuenta);
        if(cuenta !=  null){
            return cuenta.Movimientos;
        }
        return new List<Movimiento>();
    }
}
