using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Ingrese un número entero: ");
        int number = int.Parse(Console.ReadLine());

        string result = CheckNumber(number);
        Console.WriteLine(result);
    }

    static string CheckNumber(int number)
    {
        if (number > 0)
        {
            return "El número es positivo";
        }
        else if (number < 0)
        {
            return "El número es negativo";
        }
        else
        {
            return "El número es cero";
        }
    }
}