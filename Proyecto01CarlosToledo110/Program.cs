using System.Net.Http.Headers;

bool reglatecnica = true; string impacto = "";

int opcionmenuprincipal; string tipocontenido; int duracioncontenido; string clasificacion; int horaprogramada; string produccionobra;
do
{
    Console.WriteLine("Bienvenido al sistema de la plataforma de streaming, elija una opción");
    Console.WriteLine("1. Evaluar un nuevo contenido");
    Console.WriteLine("2. Mostrar reglas del sistema");
    Console.WriteLine("3. Mostrar estadísticas de la sesión");
    Console.WriteLine("4. Reiniciar estadísticas");
    Console.WriteLine("5. Salir");

    opcionmenuprincipal = int.Parse(Console.ReadLine());

    switch (opcionmenuprincipal)
    {
        case 1:
            {
                Console.WriteLine("Ingrese el típo de contenido (Película, serie documental, evento en vivo): ");
                tipocontenido = Console.ReadLine();
                Console.WriteLine("Ingrese su duración (en minutos): ");
                duracioncontenido = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese su clasificación: ");
                clasificacion = (Console.ReadLine());
                Console.WriteLine("Ingrese la hora programada de la función (0-23): ");
                horaprogramada = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el nivel de producción de la obra: ");
                produccionobra = (Console.ReadLine());

                //reglas de clasificación y horario
                if (horaprogramada < 0 || horaprogramada > 23)
                {
                    reglatecnica = false;
                }
                else
                {
                    if (horaprogramada >= 6 && horaprogramada <= 22)
                    {
                        Console.WriteLine("Clasificación Sugerida: +13");
                    }
                    if (horaprogramada <= 5 && horaprogramada >= 23)
                    {
                        Console.WriteLine("Clasificación sugerida: +18");
                    }
                }

                //Reglas de duración por tipo 
                if (duracioncontenido < 2 || duracioncontenido > 500)
                {
                    reglatecnica = false;
                }

                //Reglas de producción
                if (produccionobra == "baja" || produccionobra == "Baja" || produccionobra == "BAJA")
                {
                    Console.WriteLine("Solo válida para todo público o +13");
                }
                else if (produccionobra == "media" || produccionobra == "Media" || produccionobra == "MEDIA" || produccionobra == "Alta" || produccionobra == "alta" || produccionobra == "ALTA")
                {
                    Console.WriteLine("Válida para cualquier clasificación");
                }
                //Clasificación de Impacto
                if ((produccionobra == "Alta" || produccionobra == "alta" || produccionobra == "ALTA" && duracioncontenido >= 120) || (horaprogramada >= 20 && horaprogramada <= 23))
                {
                    impacto = "Impacto Alto";
                }
                if (produccionobra == "media" || produccionobra == "Media" || produccionobra == "MEDIA" && duracioncontenido >= 60 && duracioncontenido <= 120)
                {
                    impacto = "Impacto Medio";
                }
                if (produccionobra == "baja" || produccionobra == "Baja" || produccionobra == "BAJA" && duracioncontenido <= 60)
                {
                    impacto = "Impacto Bajo";
                }

                Console.WriteLine($"Impacto: {impacto}");

                //Decisión final
                if (reglatecnica && impacto == "Impacto Bajo" || impacto == "Impacto Medio")
                {
                    Console.WriteLine("Publicar");
                }
                if (reglatecnica != false)
                {
                    Console.WriteLine("Publicar con ajustes");
                }
                if (reglatecnica != false && impacto == "Impacto Alto")
                {
                    Console.WriteLine("Enviar a Revisión");
                }
                if (!reglatecnica)
                {
                    Console.WriteLine("Rechazar");
                }

                break;
            }
        case 2:
            {
                break;
            }
        case 3:
            {
                break;
            }
        case 4:
            {
                break;
            }
        case 5:
            {
                break;
            }
        default:
            {
                break;
            }
    }
} while (opcionmenuprincipal != 5);