using System;
using System.IO;
using System.Windows;

namespace Finstats.BaseDatos
{
    public static class DirectorioConfig
    {
        public static string DirectorioQuerido { get; set; }
    }

    public class Instalar_ruta
    {
        // Convertir el constructor en un método normal o estático
        public static void InstalarRuta()
        {
            // Obtener la ruta del ejecutable y moverse cuatro niveles hacia arriba
            string rutaAplicacion = AppDomain.CurrentDomain.BaseDirectory;
            DirectorioConfig.DirectorioQuerido = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(rutaAplicacion).FullName).FullName).FullName).FullName;

            // Verificar si la carpeta 'datafolders' existe en la ruta deseada
            if (Directory.Exists(Path.Combine(DirectorioConfig.DirectorioQuerido, "datafolders")))
            {
                Console.WriteLine("Instalation success");
                Console.WriteLine($"Ruta del archivo origen: {DirectorioConfig.DirectorioQuerido}");
            }
            else
            {
                Directory.CreateDirectory(Path.Combine(DirectorioConfig.DirectorioQuerido, "datafolders"));
                Console.WriteLine("Directorio 'datafolders' creado exitosamente");
            }
        }
    }

    public class GestorArchivos
    {
        // Método para crear un archivo
        public static void CrearArchivo()
        {
            string archivoPath = "nuevoArchivo";
            string archivoPathmod = archivoPath;
            int archivopathnum = 0;
            
            try
            {
                string archivoOrigen = Path.Combine(DirectorioConfig.DirectorioQuerido, "database.db3");
                string archivoCreado;

                if (File.Exists(archivoOrigen))
                {
                    // Verificar si el archivo existe y modificar el nombre si es necesario
                    while (File.Exists(Path.Combine(DirectorioConfig.DirectorioQuerido, "datafolders", archivoPathmod + ".db3")))
                    {
                        archivopathnum++;
                        archivoPathmod = archivoPath + archivopathnum;
                    }

                    // Crear el archivo
                    archivoCreado = Path.Combine(DirectorioConfig.DirectorioQuerido, "datafolders", archivoPathmod + ".db3");
                    File.Copy(archivoOrigen, archivoCreado, false); // El tercer parámetro fase lanza excepcion si existe archivo
                    Console.WriteLine($"Archivo {archivoPathmod}.db3 creado exitosamente."); //quitar esto 
                }
                else
                {
                    Console.WriteLine("El archivo original no existe");//aqui poñer que salte un mensaje pola aplicacion ou asi de que falta ese archivo
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Se ha producido un error: {ex.Message}");
            }
                
        }
    }
}
