namespace proyecto.CONTROLADOR;
public class Usuario
{
    public int id { get; set; }
    public string usuario { get; set; }
    public int idPersona { get; set; }
    public int idRol { get; set; }

    public int getId(){
        return this.id;
    }

    //Funcion para setear el usuario
    public void setUsuario(string usuario){
        this.usuario = usuario;
    }
    public string getUsuario(){
        return this.usuario;
    }
    //Funcion para setear el id de la persona
    public void setIdPersona(int idPersona){
        this.idPersona = idPersona;
    }
    public int getIdPersona(){
        return this.idPersona;
    }
    //Funcion para setear el id del rol

    public void setIdRol(int idRol){
        this.idRol = idRol;
    }

    public int getIdRol(){
        return this.idRol;
    }

}