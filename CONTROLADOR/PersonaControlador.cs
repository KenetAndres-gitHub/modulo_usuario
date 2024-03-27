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
    
    public void CrearPersona(Persona persona)
    {
        try
        {
            MySqlConnection connection = conexion.CrearConexion();
            connection.Open();
            string query = "INSERT INTO persona (Nombres, Apellidos, AnioNacimiento, NumeroIdentificacion, Contacto) VALUES (@Nombres, @Apellidos, @AnioNacimiento, @NumeroIdentificacion, @Contacto)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Nombres", persona.getNombres());
            command.Parameters.AddWithValue("@Apellidos", persona.getApellidos());
            command.Parameters.AddWithValue("@AnioNacimiento", persona.getAnioNacimiento());
            command.Parameters.AddWithValue("@NumeroIdentificacion", persona.getNumeroIdentificacion());
            command.Parameters.AddWithValue("@Contacto", persona.getContacto());
            command.ExecuteNonQuery();
            Console.WriteLine($"Persona creada: {persona.getNombres()} {persona.getApellidos()}");
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear la persona: {ex.Message}");
        }
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
}
