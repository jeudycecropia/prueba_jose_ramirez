using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AndresRamirezPTC.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
    }
}