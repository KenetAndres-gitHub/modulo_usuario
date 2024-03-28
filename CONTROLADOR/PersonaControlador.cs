using Biblioteca.DATOS;
using MySql.Data.MySqlClient;
using proyecto.MODELOS;

namespace proyecto.CONTROLADOR;

public class PersonaControlador
{
    private Conexion conexion;

    public PersonaControlador()
    {
        conexion = Conexion.getInstancia();
    }

    public Persona buscarPersona(int idPersona)
    {
        try
        {
            MySqlConnection connection = conexion.CrearConexion();
            connection.Open();
            string query = "SELECT * FROM persona WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", idPersona);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Persona persona = new Persona();
            persona.setNombres(reader.GetString(1));
            persona.setApellidos(reader.GetString(2));
            persona.setAnioNacimiento(reader.GetDateTime(3));
            persona.setNumeroIdentificacion(reader.GetString(4));
            persona.setContacto(reader.GetInt32(5));
            reader.Close();
            connection.Close();
            return persona;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al buscar la persona: {ex.Message}");
            return null;
        }
    }

    public Persona buscarPersonaPorNumeroIdentificacion(string numeroIdentificacion, MySqlConnection connection)
    {
        try
        {
            connection.Open();
            string query = "SELECT * FROM persona WHERE NumeroIdentificacion = @NumeroIdentificacion";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@NumeroIdentificacion", numeroIdentificacion);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Persona persona = new Persona();
            persona.setId(reader.GetInt32(0));
            persona.setNombres(reader.GetString(1));
            persona.setApellidos(reader.GetString(2));
            persona.setAnioNacimiento(reader.GetDateTime(3));
            persona.setNumeroIdentificacion(reader.GetString(4));
            persona.setContacto(reader.GetInt32(5));
            reader.Close();connection.Close();
            return persona;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al buscar la persona: {ex.Message}");
            return null;
        }
    }

    public int getPersonaId(string numeroIdentificacion)
    {
        try
        {
            MySqlConnection connection = conexion.CrearConexion();
            connection.Open();
            string query = "SELECT id FROM persona WHERE NumeroIdentificacion = @NumeroIdentificacion";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@NumeroIdentificacion", numeroIdentificacion);
            MySqlDataReader reader = command.ExecuteReader();
            int idPersona = reader.GetInt32(0);
            reader.Close(); connection.Close();
            return idPersona;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener el ID de la persona: {ex.Message}");
            return 0;
        }
    }

    
    public bool setPersona(string nombres, string apellidos, DateTime anioNacimiento, string numeroIdentificacion, int contacto)
    {
        Persona persona = new Persona();
        persona.setNombres(nombres);
        persona.setApellidos(apellidos);
        persona.setAnioNacimiento(anioNacimiento);
        persona.setNumeroIdentificacion(numeroIdentificacion);
        persona.setContacto(contacto);
        return this.CrearPersona(persona);
    }

    public bool CrearPersona(Persona persona)
    {

        try
        {
            MySqlConnection connection = conexion.CrearConexion();
            connection.Open();

            //Validar si el numero de identificacion ya existe
            if (ValidarPersonaNumeroIdentificacion(connection, persona.getNumeroIdentificacion()))
            {
                Console.WriteLine("El número de identificación ya existe");
                return false;
            }

            string query = "INSERT INTO persona (Nombres, Apellidos, AnioNacimiento, NumeroIdentificacion, Contacto) VALUES (@Nombres, @Apellidos, @AnioNacimiento, @NumeroIdentificacion, @Contacto)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Nombres", persona.getNombres());
            command.Parameters.AddWithValue("@Apellidos", persona.getApellidos());
            command.Parameters.AddWithValue("@AnioNacimiento", persona.getAnioNacimiento());
            command.Parameters.AddWithValue("@NumeroIdentificacion", persona.getNumeroIdentificacion());
            command.Parameters.AddWithValue("@Contacto", persona.getContacto());
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear la persona: {ex.Message}");
            return false;
        }
    }

    private bool ValidarPersonaNumeroIdentificacion(MySqlConnection connection,string numeroIdentificacion)
    {
        string query = "SELECT * FROM persona WHERE NumeroIdentificacion = @NumeroIdentificacion";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@NumeroIdentificacion", numeroIdentificacion);
        MySqlDataReader reader = command.ExecuteReader();
        bool result = reader.HasRows;
        reader.Close();
        return result;
    }

    public void LeerPersonas()
    {
        try
        {
            MySqlConnection connection = conexion.CrearConexion();
            connection.Open();
            string query = "SELECT * FROM persona";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DateTime anioNacimiento = reader.GetDateTime(3);
                string formattedAnioNacimiento = anioNacimiento.ToString("yyyy-MM-dd");
                Console.WriteLine($"ID: {reader.GetInt32(0)}, Nombres: {reader.GetString(1)}, Apellidos: {reader.GetString(2)}, Año de nacimiento: {formattedAnioNacimiento}, Número de identificación: {reader.GetString(4)}, Contacto: {reader.GetInt32(5)}");
            }
            reader.Close();
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer las personas: {ex.Message}");
        }
    }

    public void ActualizarPersona(Persona persona, int idPersona)
    {
        try
        {
            MySqlConnection connection = conexion.CrearConexion();
            connection.Open();
            string query = "UPDATE persona SET Nombres = @Nombres, Apellidos = @Apellidos, AnioNacimiento = @AnioNacimiento, NumeroIdentificacion = @NumeroIdentificacion, Contacto = @Contacto WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Nombres", persona.getNombres());
            command.Parameters.AddWithValue("@Apellidos", persona.getApellidos());
            command.Parameters.AddWithValue("@AnioNacimiento", persona.getAnioNacimiento());
            command.Parameters.AddWithValue("@NumeroIdentificacion", persona.getNumeroIdentificacion());
            command.Parameters.AddWithValue("@Contacto", persona.getContacto());
            command.Parameters.AddWithValue("@id", idPersona);
            command.ExecuteNonQuery();
            Console.WriteLine($"Persona actualizada: {persona.getNombres()} {persona.getApellidos()}");
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al actualizar la persona: {ex.Message}");
        }
    }

    public void EliminarPersona(int idPersona)
    {
        try
        {
            MySqlConnection connection = conexion.CrearConexion();
            connection.Open();
            //Validar si el usuario tiene registros asociados
            string queryValidar = "SELECT * FROM usuario WHERE idPersona = @idPersona";
            MySqlCommand commandValidar = new MySqlCommand(queryValidar, connection);
            commandValidar.Parameters.AddWithValue("@idPersona", idPersona);
            MySqlDataReader reader = commandValidar.ExecuteReader();
            if (reader.HasRows)
            {
                Console.WriteLine("No se puede eliminar la persona porque tiene registros asociados en la tabla usuario");
                return;
            }
            reader.Close();

            string query = "DELETE FROM persona WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", idPersona);
            command.ExecuteNonQuery();
            Console.WriteLine($"Persona eliminada con ID: {idPersona}");
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al eliminar la persona: {ex.Message}");
        }
    }
}
