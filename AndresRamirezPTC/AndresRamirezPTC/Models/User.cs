using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Spatial;

namespace AndresRamirezPTC.Models
{
    public class User
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
         [Required]
        public string Email { get; set; }
        public string Direccion { get; set; }
    }
}