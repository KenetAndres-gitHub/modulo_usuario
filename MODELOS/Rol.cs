using Biblioteca.DATOS;
using MySql.Data.MySqlClient;
using Mysqlx.Expr;

namespace proyecto.MODELOS;

public class Rol
{
    public int id { get; set; }
    public string nombre { get; set; }
    public string descripcion { get; set; }

    public int getId(){
        return this.id;
    }

    //Funcion para setear el nombre del rol
    public void setNombre(string nombre){
        this.nombre = nombre;
    }
    public string getNombre(){
        return this.nombre;
    }
    //Funcion para setear la descripcion del rol
    public void setDescripcion(string descripcion){
        this.descripcion = descripcion;
    }
    public string getDescripcion(){
        return this.descripcion;
    }

}

