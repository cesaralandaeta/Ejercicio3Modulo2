using Microsoft.EntityFrameworkCore;

namespace EjercicioClase3Modulo2EFCore
{
    internal class Program
    {
        static void Main( string[] args )
        {
            #region Pasos previos
            //Ejecutar el script de base de datos en Management Studio para crear la base de datos y la tabla con datos
            //Instalar Microsoft.EntityFrameworkCore y Microsoft.EntityFrameworkCore.SqlServer
            //Crear las entidades necesarias
            //Crear el dbcontext
            //Configurar aqui el connection string e instanciar el contexto de la base de datos.
            var options = new DbContextOptionsBuilder<DBContext>();
            options.UseSqlServer("Data Source=localhost;Initial Catalog=SimpleIMDB;Persist Security Info=True;User ID=sa;Password=Password01;Trust Server Certificate=True");
            
            var context = new DBContext(options.Options);
         
            #endregion

            #region ejercicio 1
            //Obtener un listado de todos los actores y actrices de la tabla actor
            var result = context.Actor.ToList();
            #endregion

            #region ejercicio 2
            //Obtener listado de todas las actrices de la tabla actor
            var result2 = context.Actor.Where(actor => actor.Genero == "F").ToList();
           
            #endregion

            #region ejercicio 3
            //Obtener un listado de todos los actores y actrices mayores de 50 años de la tabla actor
            var result3 = context.Actor.Where(edad => edad.Edad > 50).ToList();

            #endregion

            #region ejercicio 4
            //Obtener la edad de la actriz "Julia Roberts"
            var resul4 = context.Actor.Where(edadJ => edadJ.Nombre == "Julia").Select(colum1 => colum1.Edad).ToList();

            #endregion

            #region ejercicio 5
            //Insertar un nuevo actor en la tabla actor con los siguientes datos:
            //nombre: Ricardo
            //apellido: Darin
            //edad: 67 años
            //nombre_artistico: Ricardo Darin
            //nacionalidad: argentino
            //género: Masculino.
            //Actor nuevoActor = new Actor() { Nombre = "Ricardo", Apellido = "Darin", Edad = 67, Nombre_Artistico = "Ricardo Darin",Nacionalidad = "Argentino", Genero="M" };
            //context.Actor.Add(nuevoActor);
            //context.SaveChanges();
            var result5 = context.Actor.Where(actorNew => actorNew.Nombre_Artistico == "Ricardo Darin").ToList();


            #endregion

            #region ejercicio 6
            //obtener la cantidad de actores y actrices que no son de Estados Unidos.
            var result6 = context.Actor.Where(noUSA => noUSA.Nacionalidad != "USA").Count();
            Console.WriteLine("ver resultados");
            #endregion

            #region ejercicio 7
            //obtener los nombres y apellidos de todos los actores maculinos.
            var result7 = context.Actor.Where(actor => actor.Genero == "M").Select(nombApe => new {nombApe.Nombre, nombApe.Apellido }).ToList();
            Console.WriteLine("ver resultados");
            #endregion
        }
    }
}