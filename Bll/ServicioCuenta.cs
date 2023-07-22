using Dal;
using Entity;
using Entity.Excepciones;

namespace Bll;

public class ServicioCuenta
{
    private RepositorioCuenta RepositorioCuenta { get; set; }

    public ServicioCuenta()
    {
        RepositorioCuenta =  new RepositorioCuenta();
    }

    public void Agregar(CuentaBancaria cuenta)
    {
        RepositorioCuenta.Agregar(cuenta);
    }

    public List<CuentaBancaria> Consultar()
    {
        return RepositorioCuenta.Consultar();
    }

    public void Consignar(string numeroCuenta, decimal valor)
    {
        CuentaBancaria cuenta = RepositorioCuenta.Buscar(numeroCuenta);
        cuenta.Consignar(valor);
        RepositorioCuenta.Editar(cuenta);
    }

    public List<Movimiento> ConsultarMovimientos(string numeroCuenta)
    {
        List<Movimiento> movimientos = RepositorioCuenta.ConsultarMovimientos(numeroCuenta);
        if (movimientos.Count == 0)
        {
            throw new AppException($"el numero de cuenta {numeroCuenta} no existe");
        }
        return movimientos;
    }
}
