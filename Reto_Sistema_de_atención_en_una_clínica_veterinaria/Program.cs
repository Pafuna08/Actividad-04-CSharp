using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Sistema de Atención Veterinaria ===");

        // ---------------- ENTRADA DE DATOS ----------------

        // Especie (obligatoria)
        string especieMascota;
        do
        {
            Console.Write("Especie de la mascota (perro, gato, conejo, reptil): ");
            especieMascota = (Console.ReadLine() ?? "").ToLower();
        }
        while (especieMascota != "perro" &&
               especieMascota != "gato" &&
               especieMascota != "conejo" &&
               especieMascota != "reptil");

        // Edad (TryParse)
        int edadMascota;
        while (true)
        {
            Console.Write("Edad de la mascota (años): ");
            if (int.TryParse(Console.ReadLine(), out edadMascota) && edadMascota >= 0)
                break;

            Console.WriteLine("Edad inválida. Intente nuevamente.");
        }

        // Peso (TryParse)
        double peso;
        while (true)
        {
            Console.Write("Peso de la mascota (kg): ");
            if (double.TryParse(Console.ReadLine(), out peso) && peso > 0)
                break;

            Console.WriteLine("Peso inválido. Intente nuevamente.");
        }

        // Vacunas (si/no)
        bool tieneVacunasAlDia;
        while (true)
        {
            Console.Write("¿Tiene vacunas al día? (si/no): ");
            string vacunasInput = (Console.ReadLine() ?? "").ToLower();

            if (vacunasInput == "si")
            {
                tieneVacunasAlDia = true;
                break;
            }
            else if (vacunasInput == "no")
            {
                tieneVacunasAlDia = false;
                break;
            }

            Console.WriteLine("Ingrese solo 'si' o 'no'.");
        }

        // Socio (si/no)
        bool esSocio;
        while (true)
        {
            Console.Write("¿Es socio? (si/no): ");
            string socioInput = (Console.ReadLine() ?? "").ToLower();

            if (socioInput == "si")
            {
                esSocio = true;
                break;
            }
            else if (socioInput == "no")
            {
                esSocio = false;
                break;
            }

            Console.WriteLine("Ingrese solo 'si' o 'no'.");
        }

        // Motivo (obligatorio)
        string motivoConsulta;
        do
        {
            Console.Write("Motivo de consulta (vacuna, revision, cirugia, urgencia): ");
            motivoConsulta = (Console.ReadLine() ?? "").ToLower();
        }
        while (motivoConsulta != "vacuna" &&
               motivoConsulta != "revision" &&
               motivoConsulta != "cirugia" &&
               motivoConsulta != "urgencia");

        Console.WriteLine("\n=== Reporte de Atención Veterinaria ===");

        // ---------------- PARTE 1 ----------------
        string etapaVida = edadMascota switch
        {
            < 1 => "Cachorro",
            >= 1 and <= 3 => "Joven",
            >= 4 and <= 8 => "Adulto",
            _ => "Senior"
        };

        Console.WriteLine($"Mascota: {especieMascota} | Edad: {edadMascota} años | Etapa: {etapaVida}");

        // ---------------- PARTE 2 ----------------
        string alertaVacuna;

        if ((especieMascota == "perro" || especieMascota == "gato") && !tieneVacunasAlDia)
        {
            alertaVacuna = "ALERTA: vacunación urgente requerida";
        }
        else if ((especieMascota == "perro" || especieMascota == "gato") && tieneVacunasAlDia)
        {
            alertaVacuna = "Vacunación al día";
        }
        else
        {
            alertaVacuna = "Esquema de vacunación no aplica";
        }

        Console.WriteLine($"Estado de vacunación: {alertaVacuna}");

        // ---------------- PARTE 3 ----------------
        decimal costoBase;

        switch (motivoConsulta)
        {
            case "vacuna":
                costoBase = 35000;
                break;

            case "revision":
                costoBase = 50000;
                break;

            case "cirugia":
                costoBase = 280000;
                break;

            case "urgencia":
                costoBase = 150000;
                break;

            default:
                costoBase = 0;
                break;
        }

        Console.WriteLine($"Motivo: {motivoConsulta} | Costo base: ${costoBase:N0}");

        // ---------------- PARTE 4 ----------------
        double porcentajeDescuento = esSocio
            ? (peso > 25 ? 15.0 : 10.0)
            : 0.0;

        decimal descuento = costoBase * (decimal)(porcentajeDescuento / 100);
        decimal costoFinal = costoBase - descuento;

        Console.WriteLine($"Descuento: {porcentajeDescuento}% | Costo final: ${costoFinal:N0}");

        // ---------------- PARTE 5 ----------------
        string recomendacion;

        if (motivoConsulta == "cirugia")
        {
            if (etapaVida == "Senior")
            {
                recomendacion = "Reposo absoluto por 10 días, control post-operatorio obligatorio";
            }
            else
            {
                recomendacion = "Reposo por 5 días, evitar ejercicio intenso";
            }
        }
        else if (motivoConsulta == "urgencia")
        {
            if (!tieneVacunasAlDia)
            {
                recomendacion = "Atender urgencia y programar vacunación inmediata";
            }
            else
            {
                recomendacion = "Seguimiento en 48 horas";
            }
        }
        else
        {
            recomendacion = "Seguimiento en próxima consulta de rutina";
        }

        Console.WriteLine($"Recomendación: {recomendacion}");
    }
}