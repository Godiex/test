using Bll;
using Entity;
using Entity.Excepciones;

ServicioCuenta  servicioCuenta = new ServicioCuenta();
string opcionContinuar;
do
{
    MostrarMenu();
    int opcionMenu = int.Parse(Leer("digite el valor del menu"));
    switch (opcionMenu)
    {
        case 1: {RegistrarCuentas(); break;}
        case 2: {ConsultarCuentas(); break;}
        case 4: {ConsignarEnCuenta(); break;}
        case 3: {ConsultarMovimientos(); break;}
        default: { Console.WriteLine("opcion no valida"); break; }
    }
    opcionContinuar = Leer("digite si desea continuar la aplicacion -> s");
} while (opcionContinuar.ToLower() == "s");

Console.ReadKey();

void RegistrarCuentas()
{
do
    {
        CuentaBancaria cuenta = CrearCuenta();
        servicioCuenta.Agregar(cuenta);
        opcionContinuar = Leer("digite s para continuar");
        Console.Clear();
    } while (opcionContinuar.ToLower() == "s");
}

void ConsultarCuentas()
{
    Console.Clear();
    List<CuentaBancaria> cuentas = servicioCuenta.Consultar();
    foreach (var c in cuentas)
    {
        Console.WriteLine($"Numero: {c.NumeroCuenta} - Cantidad Movimientos: {c.Movimientos.Count} - Tipo Cuenta: {c.TipoCuenta} - Saldo: {c.Saldo}");
    }
}

void ConsultarMovimientos()
{
    try
    {
        Console.Clear();
        string numeroCuenta = Leer("digite el numero de cuenta");
        ListarMovimientos(numeroCuenta);
    }
    catch (AppException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void ListarMovimientos(string numeroCuenta)
{
    Console.Clear();
    List<Movimiento> movimientos = servicioCuenta.ConsultarMovimientos(numeroCuenta);
    foreach (var c in movimientos)
    {
        Console.WriteLine($"Numero: {c.Numero} - fecha: {c.Fecha.ToShortDateString()} -- {c.Fecha.ToShortTimeString()} - Valor Movmiento: {c.Valor}");
    }
}

void ConsignarEnCuenta()
{
    try
    {
        Console.Clear();
        string numeroCuenta = Leer("digite el numero de cuenta");
        decimal saldo = decimal.Parse(Leer("digite el valor a consignar"));
        servicioCuenta.Consignar(numeroCuenta, saldo);
    }
    catch (AppException ex)
    {
        Console.WriteLine(ex.Message);
        ConsignarEnCuenta();
    }
}

CuentaBancaria CrearCuenta()
{
    string tipoCuenta = Leer("1 para ahorro y 2 para corriente");
    if(tipoCuenta == "1")
    {
        return new CuentaAhorro();
    }
    else
    {
        return new CuentaCorriente();
    }
}

string Leer(string texto)
{
    Console.WriteLine(texto);
    return Console.ReadLine();
}

void MostrarMenu()
{
    Console.Clear();
    Console.WriteLine("------------SISTEMA BANCARIO------------");
    Console.WriteLine("1 -> crear cuenta");
    Console.WriteLine("2 -> ver cuentas");
    Console.WriteLine("3 -> buscar movimientos");
    Console.WriteLine("4 -> Consignar en cuenta");
    Console.WriteLine("0 -> para salir");
    Console.WriteLine("Seleccione una opcion");
}
