using System.Net.Http.Headers;
using System.Numerics;
static void Main()
{ }
bool enteropcionmenu; bool entertipocont; bool enterduracioncont; bool enterclasificacion; bool enterhoraprogram; bool enterproduccion;
bool reglatecnica = true; string impacto = ""; int impactoalto = 0; int impactomedio = 0; int impactobajo = 0; 
int totalevaluados = 0; int totalpublicados = 0; int totalrechazados = 0; int totalenrevision = 0;

int opcionmenuprincipal; string tipocontenido; int duracioncontenido; string clasificacion; int horaprogramada; string produccionobra;
//IMPACTO PREDOMINANTE (Case 3)
string impactpred = "";
if (impactoalto > impactomedio && impactoalto > impactobajo)
{
impactpred = "impacto Alto";
}
else if (impactomedio > impactoalto && impactomedio >= impactobajo)
{
impactpred = "Impacto Medio";
}
else
{
impactpred = "Impacto Bajo";
}
//PORCENTAJE DE APROBACIÓN (Case 3)
double porcentajeaprob(int totalpublicados, int totalevaluados)
{
if (totalevaluados == 0)
{
return 0.0;
}
return (double)totalpublicados / totalevaluados * 100.0;
}
double resultaprob = porcentajeaprob(totalpublicados, totalevaluados);

do
{
    Console.Clear();
    Console.WriteLine("---Bienvenido al sistema de la Plataforma de Streaming, Elija una Opción---");
    Console.WriteLine("1. Evaluar un nuevo contenido");
    Console.WriteLine("2. Mostrar reglas del sistema");
    Console.WriteLine("3. Mostrar estadísticas de la sesión");
    Console.WriteLine("4. Reiniciar estadísticas");
    Console.WriteLine("5. Salir");


    enteropcionmenu = int.TryParse(Console.ReadLine(), out opcionmenuprincipal);
        if (enteropcionmenu)
    { 
        if (opcionmenuprincipal <1 || opcionmenuprincipal >5)
        {
            enteropcionmenu = false;
            Console.WriteLine("ERROR: Valor incorrecto, ingrese un número de 1 a 5");
        }
        switch (opcionmenuprincipal)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("Ingrese el típo de contenido (Película, serie documental, evento en vivo): ");
                tipocontenido = Console.ReadLine();

                do
                {   
                    Console.WriteLine("Ingrese la duración del contenido en minutos: ");
                    enterduracioncont = int.TryParse(Console.ReadLine(), out duracioncontenido);
                    if (enterduracioncont)
                    {
                        if (duracioncontenido < 2 || duracioncontenido > 360)
                        {
                            reglatecnica = false;
                            Console.WriteLine("Advertencia: La duración del contenido no es válida");
                        }
                    }
                } while (!enterduracioncont);


                Console.WriteLine("Ingrese su clasificación: ");
                clasificacion = (Console.ReadLine());

                do
                {
                    Console.WriteLine("Ingrese la hora programada de la función (0-23): ");
                    enterhoraprogram = int.TryParse(Console.ReadLine(), out horaprogramada);
                    if (enterhoraprogram)
                    {
                        if (horaprogramada < 0 || horaprogramada > 23)
                        {
                            reglatecnica = false;
                            Console.WriteLine("Advertencia: El horario programado no es válido");
                        }
                    } 
                } while (!enterhoraprogram);

                Console.WriteLine("Ingrese el nivel de producción de la obra: ");
                produccionobra = (Console.ReadLine());

                //reglas de clasificación y horario
                
                if (horaprogramada >= 6 && horaprogramada <= 22)
                {
                        Console.WriteLine("Clasificación Sugerida: +13");
                }
                if (horaprogramada <= 5 || horaprogramada >= 23)
                {
                        Console.WriteLine("Clasificación sugerida: +18");
                }
                

                //Reglas de duración por tipo 
                if (duracioncontenido < 2 || duracioncontenido > 360)
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
                    impactoalto++;
                }
                if (produccionobra == "media" || produccionobra == "Media" || produccionobra == "MEDIA" && duracioncontenido >= 60 && duracioncontenido <= 120)
                {
                    impacto = "Impacto Medio";
                    impactomedio++;
                }
                if (produccionobra == "baja" || produccionobra == "Baja" || produccionobra == "BAJA" && duracioncontenido <= 60)
                {
                    impacto = "Impacto Bajo";
                    impactobajo++;
                }

                Console.WriteLine($"Impacto: {impacto}");

                //Decisión final
                if (!reglatecnica)
                {
                    Console.WriteLine("Decisión final: Rechazar, No cumple con una o más reglas técnicas");
                    totalrechazados++;
                }
                else if (impacto == "Impacto Alto")
                {
                    Console.WriteLine("Decisión final: Enviar a Revisión");
                    totalenrevision++;
                }
                else if (impacto == "Impacto Medio")
                {
                    Console.WriteLine("Decisión final: Publicar con ajustes");
                    totalpublicados++;
                }
                else
                {
                    Console.WriteLine("Decisión final: Publicar");
                    totalpublicados++;
                }
                Console.WriteLine("---Presione cualquier tecla para volver al menú---");

                break;

            case 2:
                Console.Clear();
                for (int i = 1; i <= 11; i++)
                {
                    Console.WriteLine($"Cargando regla #{i}...");
                }
                Console.Clear();
                Console.WriteLine("----REGLAS DEL SISTEMA----");
                Console.WriteLine("-Horarios válidos: 0-23");
                Console.WriteLine("-Los límites de duración del contenido son de 2 (mínimo) a 360 (máximo) minutos");
                Console.WriteLine("-Si el horario es de 6 a 22 horas, el contenido tiene opción a ser +13, de lo contrario solo puede ser +18");
                Console.WriteLine("-Si la producción del contenido es alta y su duración es de más de 120 minutos, entonces tiene un impacto alto");
                Console.WriteLine("-Si la producción del contenido es media y su duración es de mas de 60 minutos, entonces su impacto será medio");
                Console.WriteLine("-En otros casos su impacto será bajo");
                Console.WriteLine("-Si el contenido tiene un impacto alto entonces será enviado a revisión");
                Console.WriteLine("-Si el contenido tiene impacto medio entonces se publicará con ajustes");
                Console.WriteLine("-El contenido con impacto bajo será publicado directamente");
                Console.WriteLine("-Si el contenido incumple con alguna regla técnica, entonces será inmediatamente rechazado");
                Console.WriteLine("---Presione cualquier tecla para volver al menú---");
                break;

            case 3:
                Console.Clear();
                Console.WriteLine("----ESTADÍSTICAS DE LA SESIÓN----");
                Console.WriteLine($"Contenidos evaluados Totales: {totalevaluados}");
                Console.WriteLine($"Publicados totales:{totalpublicados}");
                Console.WriteLine($"Rechazados totales: {totalrechazados} ");
                Console.WriteLine($"Contenidos en revisión: {totalenrevision}");
                Console.WriteLine($"El impacto predominante es: {impactpred}");
                Console.WriteLine($"El porcentaje de aprobación de los contenidos es del {resultaprob}%");
                Console.WriteLine("---Presione cualquier tecla para volver al menú---");
                break;

            case 4:
                totalevaluados = 0; impactoalto = 0;
                totalpublicados = 0; impactomedio = 0;
                totalrechazados = 0; impactobajo = 0;
                totalenrevision = 0;

                Console.WriteLine("Estadísticas Reiniciadas");
                Console.WriteLine("---Presione cualquier tecla para volver al menú---");


                break;

            case 5:
                Console.WriteLine("RESUMEN FINAL DEL SISTEMA");
                Console.WriteLine($"Contenidos evaluados Totales: {totalevaluados}");
                Console.WriteLine($"Publicados totales:{totalpublicados}");
                Console.WriteLine($"Rechazados totales: {totalrechazados} ");
                Console.WriteLine($"Contenidos en revisión: {totalenrevision}");
                Console.WriteLine($"El impacto predominante es: {impactpred}");
                Console.WriteLine($"El porcentaje de aprobación de los contenido ses del {resultaprob}%");

                Console.WriteLine("Saliendo... Gracias por hacer Uso del Sistema");
                break;

            default:
                Console.WriteLine("ERROR: Opción no disponible/fuera del rango, ingrese una opción válida");
                break;

        }

    }
    Console.ReadKey();

    
} while (opcionmenuprincipal != 5);
