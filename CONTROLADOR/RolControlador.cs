using System;
using Biblioteca.DATOS;
using MySql.Data.MySqlClient;
using proyecto.MODELOS;

namespace proyecto.CONTROLADOR;

public class RolControlador
{
    private Conexion conexion;

    public RolControlador()
    {
        conexion = Conexion.getInstancia();
    }

    public Rol buscarRol(int idRol)
    {
        try{
            MySqlConnection connection = conexion.CrearConexion();
            connection.Open();
            string query = "SELECT * FROM rol WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", idRol);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Rol rol = new Rol();
            rol.setNombre(reader.GetString(1));
            rol.setDescripcion(reader.GetString(2));
            reader.Close();
            connection.Close();
            return rol;
        }catch (Exception ex){
            Console.WriteLine($"Error al buscar el rol: {ex.Message}");
            return null;
        }
    }
    public void CrearRol(Rol rol)
    {
        try
        {
            MySqlConnection connection = conexion.CrearConexion();
            connection.Open();
            string query = "INSERT INTO rol (Nombre, Descripcion) VALUES (@Nombre, @Descripcion)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Nombre", rol.getNombre());
            command.Parameters.AddWithValue("@Descripcion", rol.getDescripcion());
            command.ExecuteNonQuery();
            Console.WriteLine($"Rol creado: {rol.getNombre()}");
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear el rol: {ex.Message}");
        }
    }

    public void LeerRoles()
    {
        try
        {
            MySqlConnection connection = conexion.CrearConexion();
            connection.Open();
            string query = "SELECT * FROM rol";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader.GetInt32(0)}, Nombre: {reader.GetString(1)}, Descripción: {reader.GetString(2)}");
            }
            reader.Close();
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer los roles: {ex.Message}");
        }
    }

    public void ActualizarRol(Rol rol, int idRol)
    {
        try
        {
            MySqlConnection connection = conexion.CrearConexion();
            connection.Open();
            string query = "UPDATE rol SET Nombre = @Nombre, Descripcion = @Descripcion WHERE Id = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Nombre", rol.getNombre());
            command.Parameters.AddWithValue("@Descripcion", rol.getDescripcion());
            command.Parameters.AddWithValue("@id", idRol);
            command.ExecuteNonQuery();
            Console.WriteLine($"Rol actualizado: {rol.getNombre()}");
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al actualizar el rol: {ex.Message}");
        }
    }

    public void EliminarRol(int idRol)
    {
        try
        {
            MySqlConnection connection = conexion.CrearConexion();
            connection.Open();
            //Comprobamos si no existe el rol en la tabla usuario
            string queryValidacion = "SELECT * FROM usuario WHERE IdRol = @Id";
            MySqlCommand commandV = new MySqlCommand(queryValidacion, connection);
            commandV.Parameters.AddWithValue("@Id", idRol);
            MySqlDataReader reader = commandV.ExecuteReader();
            // HasRows es un método que devuelve true si hay filas en el reader
            if (reader.HasRows)
            {
                Console.WriteLine("No se puede eliminar el rol porque hay usuarios asociados a él.");
                return;
            }
            reader.Close();
            string query = "DELETE FROM rol WHERE Id = @Id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", idRol);
            command.ExecuteNonQuery();
            Console.WriteLine($"Rol eliminado correctamente.");
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al eliminar el rol: {ex.Message}");
        }
    }
}
