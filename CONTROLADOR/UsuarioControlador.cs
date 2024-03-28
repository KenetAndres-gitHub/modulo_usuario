using Biblioteca.DATOS;
using MySql.Data.MySqlClient;
using proyecto.MODELOS;

namespace proyecto.CONTROLADOR;
public class UsuarioControlador
{
    private Conexion conexion;

    public UsuarioControlador()
    {
        conexion = Conexion.getInstancia();
    }

    public void CrearUsuario(Usuario usuario)
    {
        try
        {
            MySqlConnection connection = conexion.CrearConexion();
            connection.Open();
            string query = "INSERT INTO usuario (Usuario, IdPersona, IdRol) VALUES (@Usuario, @IdPersona, @IdRol)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Usuario", usuario.getUsuario());
            command.Parameters.AddWithValue("@IdPersona", usuario.getIdPersona());
            command.Parameters.AddWithValue("@IdRol", usuario.getIdRol());
            command.ExecuteNonQuery();
            Console.WriteLine($"Usuario creado: {usuario.getUsuario()}");
            connection.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"Error al crear el usuario: {ex.Message}");
        }
    }

    public void LeerUsuarios()
    {
        PersonaControlador personaControlador = new PersonaControlador();
        RolControlador rolControlador = new RolControlador();
        try{
            MySqlConnection connection = conexion.CrearConexion();
            connection.Open();
            string query = "SELECT * FROM usuario";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Persona persona = personaControlador.buscarPersona(reader.GetInt32(2));
                Rol rol = rolControlador.buscarRol(reader.GetInt32(3));
                Console.WriteLine($"ID: {reader.GetInt32(0)}, Usuario: {reader.GetString(1)}, Nombres y Apellidos: {persona.getNombres()} {persona.getApellidos()}, Rol: {rol.getNombre()}");
            }
            reader.Close();
            connection.Close();
        }catch (Exception ex){
            Console.WriteLine($"Error al leer los usuarios: {ex.Message}");
        }
    }

    public void BuscarUsuarioPorNumeroIdentificacion(string numeroIdentificacion)
    {
        MySqlConnection connection = conexion.CrearConexion();
        //Buscar la persona por el numero de identificacion
        PersonaControlador personaControlador = new PersonaControlador();
        Persona persona = personaControlador.buscarPersonaPorNumeroIdentificacion(numeroIdentificacion, connection);
        if (persona == null){
            Console.WriteLine("No se encontró la persona");
        }
        Console.WriteLine($"Persona encontrada: {persona.getNombres()} {persona.getApellidos()} con ID: {persona.getId()}");
        connection.Open();
        string query = "SELECT * FROM usuario WHERE idPersona = @IdPersona";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@IdPersona", persona.getId());
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            RolControlador rolControlador = new RolControlador();
            Rol rol = rolControlador.buscarRol(reader.GetInt32(3));
            Console.WriteLine($"ID: {reader.GetInt32(0)}, Usuario: {reader.GetString(1)}, Nombres y Apellidos: {persona.getNombres()} {persona.getApellidos()}, Rol: {rol.getNombre()}");
            //Reservas
        }       
    }
    public void ActualizarUsuario(Usuario usuario, int idUsuario)
    {
        try
        {
            MySqlConnection connection = conexion.CrearConexion();
            connection.Open();
            string query = "UPDATE usuario SET Usuario = @Usuario, IdPersona = @IdPersona, IdRol = @IdRol WHERE Id = @Id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Usuario", usuario.getUsuario());
            command.Parameters.AddWithValue("@IdPersona", usuario.getIdPersona());
            command.Parameters.AddWithValue("@IdRol", usuario.getIdRol());
            command.Parameters.AddWithValue("@Id", idUsuario);
            command.ExecuteNonQuery();
            Console.WriteLine($"Usuario actualizado: {usuario.getUsuario()}");
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al actualizar el usuario: {ex.Message}");
        }
    }

    public void EliminarUsuario(int idUsuario){
        try
        {
            MySqlConnection connection = conexion.CrearConexion();
            connection.Open();
            string query = "DELETE FROM usuario WHERE Id = @Id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", idUsuario);
            command.ExecuteNonQuery();
            Console.WriteLine($"Usuario eliminado: {idUsuario}");
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al eliminar el usuario: {ex.Message}");
        }
    }
}


