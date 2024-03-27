using System;
using proyecto.MODELOS;
using proyecto.CONTROLADOR;

namespace proyecto;
class Program
{
    static void Main(string[] args)
    {
        //Rol
        /* RolControlador rolControl = new RolControlador();

        while (true)
        {
            Console.WriteLine("Menú de opciones:");
            Console.WriteLine("1. Crear Rol");
            Console.WriteLine("2. Leer Roles");
            Console.WriteLine("3. Actualizar Rol");
            Console.WriteLine("4. Eliminar Rol");
            Console.WriteLine("5. Salir");
            Console.Write("Ingrese el número de la opción deseada: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("Ingrese el nombre del nuevo rol:");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese la descripción del nuevo rol:");
                    string descripcion = Console.ReadLine();

                    Rol rolNuevo = new Rol();
                    rolNuevo.setNombre(nombre);
                    rolNuevo.setDescripcion(descripcion);
                    rolControl.CrearRol(rolNuevo); 

                    break;
                case "2":
                    rolControl.LeerRoles();
                    break;
                case "3":
                    Console.WriteLine("Ingrese el ID del rol que desea actualizar:");
                    int idActualizar = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingrese el nuevo nombre del rol:");
                    string nuevoNombre = Console.ReadLine();
                    Console.WriteLine("Ingrese la nueva descripción del rol:");
                    string nuevaDescripcion = Console.ReadLine();
                    
                    Rol rolActualizar = new Rol();
                    rolActualizar.setNombre(nuevoNombre);
                    rolActualizar.setDescripcion(nuevaDescripcion);
                    rolControl.ActualizarRol(rolActualizar, idActualizar);

                    break;
                case "4":
                    Console.WriteLine("Ingrese el ID del rol que desea eliminar:");
                    int idEliminar = Convert.ToInt32(Console.ReadLine());
                    rolControl.EliminarRol(idEliminar);
                    break;
                case "5":
                    Console.WriteLine("Saliendo del programa...");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Por favor, ingrese una opción válida.");
                    break;
            }
        } */

        //Persona
        PersonaControlador personaControl = new PersonaControlador();

        while (true)
        {
            Console.WriteLine("Menú de opciones:");
            Console.WriteLine("1. Crear Persona");
            Console.WriteLine("2. Leer Personas");
            Console.WriteLine("3. Actualizar Persona");
            Console.WriteLine("4. Eliminar Persona");
            Console.WriteLine("5. Salir");
            Console.Write("Ingrese el número de la opción deseada: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("Ingrese el nombre de la nueva persona:");
                    string nombres = Console.ReadLine();
                    Console.WriteLine("Ingrese el apellido de la nueva persona:");
                    string apellidos = Console.ReadLine();
                    Console.WriteLine("Ingrese el año de nacimiento de la nueva persona:");
                    DateTime anioNacimiento = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Ingrese el número de identificación de la nueva persona:");
                    string numeroIdentificacion = Console.ReadLine();
                    Console.WriteLine("Ingrese el contacto de la nueva persona:");
                    string contacto = Console.ReadLine();

                    Persona personaNueva = new Persona();
                    personaNueva.setNombres(nombres);
                    personaNueva.setApellidos(apellidos);
                    personaNueva.setAnioNacimiento(anioNacimiento);
                    personaNueva.setNumeroIdentificacion(numeroIdentificacion);
                    personaNueva.setContacto(contacto);
                    personaControl.CrearPersona(personaNueva); 
                    break;
                case "2":
                    personaControl.LeerPersonas();
                    break;
                case "3":
                    Console.WriteLine("Ingrese el ID de la persona que desea actualizar:");
                    int idActualizar = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingrese el nuevo nombre de la persona:");
                    string nuevoNombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo apellido de la persona:");
                    string nuevoApellido = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo año de nacimiento de la persona:");
                    DateTime nuevoAnioNacimiento = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Ingrese el nuevo número de identificación de la persona:");
                    string nuevoNumeroIdentificacion = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo contacto de la persona:");
                    string nuevoContacto = Console.ReadLine();

                    Persona personaActualizar = new Persona();
                    personaActualizar.setNombres(nuevoNombre);
                    personaActualizar.setApellidos(nuevoApellido);
                    personaActualizar.setAnioNacimiento(nuevoAnioNacimiento);
                    personaActualizar.setNumeroIdentificacion(nuevoNumeroIdentificacion);
                    personaActualizar.setContacto(nuevoContacto);
                    personaControl.ActualizarPersona(personaActualizar, idActualizar);
                    break;
                case "4":
                    return;
                    }
        }
    }    

}
