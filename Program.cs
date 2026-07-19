using System;

class Program
{
    static void Main(string[] args)
    {
        int n_cuenta = 100200300;
        int pin = 2580;
        double saldo_ini = 2750.50;
        double monto_dia = 350.00;
        double limite_retiro = 1200.00;

        //Datos iniciales

        //Solicitud de datos
        Console.WriteLine("================================");
        Console.WriteLine("\tBANCO TECH");
        Console.WriteLine("================================");
        Console.WriteLine();
        Console.WriteLine();

        Console.Write("Ingrese N Cuenta: ");
        int n_cuentaingresado = int.Parse(Console.ReadLine()!);
        Console.Write("Ingrese el PIN: ");
        int pin_ingresado = int.Parse(Console.ReadLine()!);

        if (n_cuenta == n_cuentaingresado && pin == pin_ingresado)
        {
            Console.WriteLine("Bienvenido: Juan Perez");
            Console.WriteLine("Seleccione una opcion:\n");
            Console.WriteLine(" 1. Consultar saldo\n 2. Retirar\n 3. Depositar\n 4. Transferir\n 5. Cambiar PIN\n 6. Simular Prestamo\n 7. Resumen\n 8. Salir");
            Console.Write("Opcion: ");
            int opc = int.Parse(Console.ReadLine()!);
            switch (opc)
            {
                case 1:
                    Console.WriteLine($"Saldo Actual: {saldo_ini}");
                    Console.WriteLine($"Saldo disponible para retiro: {limite_retiro-monto_dia}");
                    Console.WriteLine($"Limite restante del dia: {limite_retiro-monto_dia}");
                    break;
                case 2:
                    Console.Write("Monto a retirar: ");
                    double monto_retiro = double.Parse(Console.ReadLine()!);
                    if (monto_retiro <= limite_retiro && monto_retiro <= saldo_ini)
                    {
                        saldo_ini -= monto_retiro;
                        limite_retiro -= monto_retiro;
                        monto_dia += monto_retiro;
                        Console.WriteLine($"Retiro exitoso. Saldo actual: {saldo_ini}");
                    }
                    else if (monto_retiro > limite_retiro || monto_retiro > saldo_ini || monto_retiro <= 0 || monto_retiro>500)
                    {
                        Console.WriteLine("Monto excede el limite de retiro o saldo insuficiente.");
                    }
                    else if (monto_retiro%10 != 0)
                    {
                        Console.WriteLine("El monto debe ser múltiplo de 10.");
                    }
                    else
                    {
                        Console.WriteLine("Monto no válido.");
                    }
                    break;

                case 3:
                    break;

                case 4:
                    break;

                case 5:
                    Console.Write("PIN actual: ");
                    int confi_pin = int.Parse(Console.ReadLine()!);
                    if (pin == confi_pin)
                    {
                        Console.Write("Nuevo PIN: ");
                        pin = int.Parse(Console.ReadLine()!);
                        Console.Write("Ingrese nuevamente el PIN: ");
                        if (pin == int.Parse(Console.ReadLine()!))
                        {

                        }
                    }

                    break;

                case 6:
                    break;

                case 7:
                    break;

                default:
                    Console.WriteLine("Gracias por utilizar BancoTech");
                    break;
            }
        }
        else if (n_cuenta != n_cuentaingresado)
        {
            Console.WriteLine("Cuenta no encontrada");
        }
        else
        {
            Console.WriteLine("PIN incorrecto");
        }



    }
}