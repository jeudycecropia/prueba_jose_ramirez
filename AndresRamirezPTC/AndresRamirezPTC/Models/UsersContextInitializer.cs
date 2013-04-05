using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AndresRamirezPTC.Models
{
    public class UsersContextInitializer : DropCreateDatabaseAlways<PerfilUsuarioContext>
    {
        protected override void Seed(PerfilUsuarioContext context)
        {
            var users = new List<User>()            
            {
                new User() {   UserName = "Jose", Password = "123123", Nombre="Pedro",  Apellido1="Ramirez",  Direccion="San Jose",
                Email="correo@gmail.com" },
                new User() {  UserName = "Consulta",  Password = "123123",Nombre = "Jose Andres", Apellido1 = "Ramirez",
                Direccion = "San Jose",
                Email = "correo@gmail.com" },
                new User() {    UserName = "testing", Password = "123123",  Nombre = "Juan",  Apellido1 = "Blanco", Direccion = "San Jose",
                Email = "correo@gmail.com"}

         
            };

            users.ForEach(p => context.Users.Add(p));
            context.SaveChanges();

        }
    }
}