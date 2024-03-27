using System.ComponentModel.DataAnnotations;

namespace proyecto.MODELOS;

public class Persona
{
    public int id { get; set; }
    public string nombres { get; set; }
    public string apellidos { get; set; }
    public DateTime anioNacimiento { get; set; }
    public string numeroIdentificacion { get; set; }
    public string contacto { get; set; }

    public int getId(){
        return this.id;
    }

    //Funcion para setear el nombre de la persona
    public void setNombres(string nombres){
        this.nombres = nombres;
    }
    public string getNombres(){
        return this.nombres;
    }
    //Funcion para setear el apellido de la persona
    public void setApellidos(string apellidos){
        this.apellidos = apellidos;
    }
    public string getApellidos(){
        return this.apellidos;
    }
    //Funcion para setear el anio de nacimiento de la persona
    public void setAnioNacimiento(DateTime anioNacimiento){
        this.anioNacimiento = anioNacimiento;
    }
    //Funcion para obtener el anio de nacimiento de la persona con formato DateTime
    public DateTime getAnioNacimiento(){
        return this.anioNacimiento;
    }
    //Funcion para setear el numero de identificacion de la persona
    public void setNumeroIdentificacion(string numeroIdentificacion){
        this.numeroIdentificacion = numeroIdentificacion;
    }
    public string getNumeroIdentificacion(){
        return this.numeroIdentificacion;
    }
    //Funcion para setear el contacto de la persona
    public void setContacto(string contacto){
        this.contacto = contacto;
    }
    public string getContacto(){
        return this.contacto;
    }
    
    
    
}
