using Entity.Excepciones;

namespace Entity;

public class CuentaCorriente : CuentaBancaria
{
    public CuentaCorriente() : base("CORRIENTE")
    {
    }
    public override void Consignar(decimal valor)
    {
        if(valor < 0){
            throw new ValorNoPermitidoException("no se permite valores negativos");
        }
        Saldo += valor;
        Movimientos.Add(new Movimiento(valor, CONSIGNACION));
    }

    public override void Retirar(decimal valor)
    {
        if(valor < 0){
            throw new ValorNoPermitidoException("no se permite valores negativos");
        }

        if(valor > Saldo){
            throw new ValorCuentaExcedidoException("No se permite retirar un valor mayor al saldo");
        }

        Saldo -= valor;
        Movimientos.Add(new Movimiento(valor, RETIRO));
    }

}
