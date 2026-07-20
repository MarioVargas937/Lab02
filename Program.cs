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
                    Console.WriteLine($"Saldo disponible para retiro: {limite_retiro}");
                    Console.WriteLine($"Limite restante del dia: {limite_retiro - monto_dia}");
                    break;



                case 2:
                    Console.Write("Monto a retirar: ");
                    double monto_retiro = double.Parse(Console.ReadLine()!);
                    if (monto_retiro <= limite_retiro && monto_retiro <= saldo_ini && monto_retiro > 0 && monto_retiro <= 500 && monto_retiro % 10 == 0)
                    {
                        saldo_ini -= monto_retiro;
                        limite_retiro -= monto_retiro;
                        monto_dia += monto_retiro;
                        Console.WriteLine($"Retiro exitoso. Saldo actual: {saldo_ini}");
                    }
                    else if (monto_retiro > limite_retiro || monto_retiro > saldo_ini || monto_retiro <= 0 || monto_retiro > 500)
                    {
                        Console.WriteLine("Monto excede el limite de retiro o saldo insuficiente.");
                    }
                    else if (monto_retiro % 10 != 0)
                    {
                        Console.WriteLine("El monto debe ser múltiplo de 10.");
                    }
                    else
                    {
                        Console.WriteLine("Monto no válido.");
                    }
                    break;




                case 3:
                    Console.Write("Monto a depositar: ");
                    double monto_deposito = double.Parse(Console.ReadLine()!);
                    if (monto_deposito > 0 && monto_deposito <= 5000)
                    {
                        saldo_ini += monto_deposito;
                        Console.WriteLine($"Deposito exitoso. Saldo actual: {saldo_ini}");
                    }
                    else
                    {
                        Console.WriteLine("Monto no válido. Debe ser mayor a 0 y menor o igual a 5000.");
                    }
                    break;





                case 4:
                    Console.Write("Cuenta destino: (diferente de la actual y de 9 dígitos) ");
                    int cuenta_destino = int.Parse(Console.ReadLine()!);
                    if (cuenta_destino == n_cuenta)
                    {
                        Console.WriteLine("No puede transferirse a la misma cuenta.");
                    }
                    else if (cuenta_destino < 100000000 || cuenta_destino > 999999999)
                    {
                        Console.WriteLine("Cuenta destino inválida. Debe ser de 9 dígitos.");
                    }
                    else
                    {
                        Console.Write("Monto a transferir: Comisión: hasta $500 → $2 · entre $501 y $1,000 → $5 · mayor de $1,000 → $8.");
                        double monto_transferencia = double.Parse(Console.ReadLine()!);
                        if (monto_transferencia > 0 && monto_transferencia <= saldo_ini)
                        {
                            saldo_ini -= monto_transferencia;
                            Console.WriteLine($"Transferencia exitosa. Saldo actual: {saldo_ini}");
                        }
                        else
                        {
                            Console.WriteLine("Monto no válido o saldo insuficiente.");
                        }
                        if (monto_transferencia <= 500)
                        {
                            saldo_ini -= 2;
                            Console.WriteLine($"Comisión de $2 aplicada. Saldo actual: {saldo_ini}");
                        }
                        else if (monto_transferencia > 500 && monto_transferencia <= 1000)
                        {
                            saldo_ini -= 5;
                            Console.WriteLine($"Comisión de $5 aplicada. Saldo actual: {saldo_ini}");
                        }
                        else if (monto_transferencia > 1000)
                        {
                            saldo_ini -= 8;
                            Console.WriteLine($"Comisión de $8 aplicada. Saldo actual: {saldo_ini}");
                        }

                    }
                    break;




                case 5:
                    Console.Write("PIN actual: ");
                    int confirmar_pin = int.Parse(Console.ReadLine()!);
                    if (pin == confirmar_pin)
                    {
                        Console.Write("Nuevo PIN: (4 dígitos) ");
                        pin = int.Parse(Console.ReadLine()!);
                        Console.Write("Ingrese nuevamente el PIN: ");
                        if (pin == confirmar_pin)
                        {
                            Console.WriteLine("El nuevo PIN no puede ser igual al anterior.");
                            break;
                        }
                        if (pin == int.Parse(Console.ReadLine()!))
                        {
                            Console.WriteLine("PIN cambiado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("Los PIN no coinciden. Intente nuevamente.");
                        }

                        if (pin < 1000 || pin > 9999)
                        {
                            Console.WriteLine("PIN inválido. Debe ser de 4 dígitos.");
                        }

                    }
                    else
                    {
                        Console.WriteLine("PIN incorrecto.");
                    }

                    break;




                case 6:
                    Console.Write("Monto del préstamo: ");
                    double monto_prestamo = double.Parse(Console.ReadLine()!);
                    Console.Write("Plazo en meses: (12 meses al 8%, 24 meses al 12%, 36 meses al 18%) ");
                    int plazo_meses = int.Parse(Console.ReadLine()!);
                    if (plazo_meses == 12)
                    {
                        double interes = monto_prestamo * 0.08;
                        double total = monto_prestamo + interes;
                        double cuota_mensual = total / plazo_meses;
                        Console.WriteLine($"Interés: {interes}, Total a pagar: {total}, Cuota mensual: {cuota_mensual}");
                    }
                    else if (plazo_meses == 24)
                    {
                        double interes = monto_prestamo * 0.12;
                        double total = monto_prestamo + interes;
                        double cuota_mensual = total / plazo_meses;
                        Console.WriteLine($"Interés: {interes}, Total a pagar: {total}, Cuota mensual: {cuota_mensual}");
                    }
                    else if (plazo_meses == 36)
                    {
                        double interes = monto_prestamo * 0.18;
                        double total = monto_prestamo + interes;
                        double cuota_mensual = total / plazo_meses;
                        Console.WriteLine($"Interés: {interes}, Total a pagar: {total}, Cuota mensual: {cuota_mensual}");
                    }
                    else if (monto_prestamo >15000)
                    {
                        Console.WriteLine("Requiere aprobación del gerente.");
                    }
                    else
                    {
                        Console.WriteLine("Plazo no válido.");
                    }

                    break;

                case 7:
                    Console.WriteLine("Resumen de cuenta:");
                    Console.WriteLine("Cliente: Juan Perez");
                    Console.WriteLine($"Número de cuenta: {n_cuenta}");
                    Console.WriteLine($"Saldo actual: {saldo_ini}");
                    Console.WriteLine($"Monto retirado hoy: {monto_dia}");
                    Console.WriteLine($"Límite restante del día: {limite_retiro - monto_dia}");
                   if (saldo_ini > 2000)
                    {
                        Console.WriteLine("Cliente Oro");
                    }
                    else if (saldo_ini > 1000)
                    {
                        Console.WriteLine("Cliente Plata");
                    }
                    else
                    {
                        Console.WriteLine("Cliente Bronce");
                    }
                    if (saldo_ini>5000)
                    {
                        Console.WriteLine("Excelente capacidad financiera");
                    }
                    else if (saldo_ini>2000)
                    {
                        Console.WriteLine("Finanzas saludables");
                    }
                    else if (saldo_ini>1000)
                    {
                        Console.WriteLine("Controle sus gastos");
                    }
                    else
                    {
                        Console.WriteLine("Nivel de saldo bajo");
                    }
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