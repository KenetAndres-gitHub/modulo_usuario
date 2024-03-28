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
        /* PersonaControlador personaControl = new PersonaControlador();

        while (true)
        {
            Console.WriteLine("Menú de opciones:");
            Console.WriteLine("1. Leer Personas");
            Console.WriteLine("2. Actualizar Persona");
            Console.WriteLine("3. Eliminar Persona");
            Console.WriteLine("4. Salir");
            Console.Write("Ingrese el número de la opción deseada: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                   
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
                    Console.WriteLine("Ingrese el ID de la persona que desea eliminar:");
                    int idEliminar = Convert.ToInt32(Console.ReadLine());
                    personaControl.EliminarPersona(idEliminar);
                    break;
                case "5":
                    Console.WriteLine("Saliendo del programa...");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Por favor, ingrese una opción válida.");
                    break;
            }
        } */

        //Usuario
        UsuarioControlador usuarioControl = new UsuarioControlador();

        while (true)
        {
            Console.WriteLine("Menú de opciones:");
            Console.WriteLine("1. Crear Usuario");
            Console.WriteLine("2. Leer Usuarios");
            Console.WriteLine("3. Buscar Usuario por Numero de Identificación");
            Console.WriteLine("4. Actualizar Usuario");
            Console.WriteLine("5. Eliminar Usuario");
            Console.WriteLine("6. Salir");
            Console.Write("Ingrese el número de la opción deseada: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("Ingrese el username:");
                    string usuario = Console.ReadLine();
                    //Creacion de la persona
                    PersonaControlador personaControl = new PersonaControlador();
                    Console.WriteLine("Ingrese el nombre de la persona del nuevo usuario:");
                    string nombres = Console.ReadLine();
                    Console.WriteLine("Ingrese el apellido de la persona del nuevo usuario:");
                    string apellidos = Console.ReadLine();
                    Console.WriteLine("Ingrese el año de nacimiento de la persona del nuevo usuario:");
                    DateTime anioNacimiento = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Ingrese el número de identificación de la persona del nuevo usuario:");
                    string numeroIdentificacion = Console.ReadLine();
                    Console.WriteLine("Ingrese el contacto de la persona del nuevo usuario:");
                    string contacto = Console.ReadLine();
                    bool personaNueva = personaControl.setPersona(nombres, apellidos, anioNacimiento, numeroIdentificacion, Convert.ToInt32(contacto));
                    if(!personaNueva){
                        Console.WriteLine("Error al crear la persona");
                        return;
                    }

                     //Obtener el ID de la persona creada
                    int idPersona = personaControl.getPersonaId(numeroIdentificacion);
                    //Seleccionar el Rol
                    RolControlador rolControl = new RolControlador();
                    Console.WriteLine("Seleccione el rol del nuevo usuario:");
                    rolControl.LeerRoles();
                    Console.WriteLine("Ingrese el ID del rol:");
                    int idRol = Convert.ToInt32(Console.ReadLine());

                    Usuario usuarioNuevo = new Usuario();
                    usuarioNuevo.setUsuario(usuario);
                    usuarioNuevo.setIdPersona(idPersona);
                    usuarioNuevo.setIdRol(idRol);
                    usuarioControl.CrearUsuario(usuarioNuevo); 
                    break;
                case "2":
                    //Sin Probar
                    usuarioControl.LeerUsuarios();
                    break;
                case "3":
                    //Buscar usuario por numero de identificacion
                    Console.WriteLine("Ingrese el numero de identificacion del usuario que desea buscar:");
                    string numeroIdentificacionBuscar = Console.ReadLine();
                    usuarioControl.BuscarUsuarioPorNumeroIdentificacion(numeroIdentificacionBuscar);

                    break;
                case "4":
                    //Sin Probar
                    Console.WriteLine("Ingrese el ID del usuario que desea actualizar:");
                    int idActualizar = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingrese el nuevo username del usuario:");
                    string nuevoUsuario = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo ID de la persona del usuario:");
                    int nuevoIdPersona = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingrese el nuevo ID del rol del usuario:");
                    int nuevoIdRol = Convert.ToInt32(Console.ReadLine());
                    
                    Usuario usuarioActualizar = new Usuario();
                    usuarioActualizar.setUsuario(nuevoUsuario);
                    usuarioActualizar.setIdPersona(nuevoIdPersona);
                    usuarioActualizar.setIdRol(nuevoIdRol);
                    usuarioControl.ActualizarUsuario(usuarioActualizar, idActualizar);
                    break;
                case "5":
                    //Sin Probar
                    Console.WriteLine("Ingrese el ID del usuario que desea eliminar:");
                    int idEliminar = Convert.ToInt32(Console.ReadLine());
                    usuarioControl.EliminarUsuario(idEliminar);
                    break;
                case "6":
                    Console.WriteLine("Saliendo del programa...");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Por favor, ingrese una opción válida.");
                    break;
            }
        }
    }    

}
