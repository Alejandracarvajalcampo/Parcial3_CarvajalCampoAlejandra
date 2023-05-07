using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WashingCarDB.Enums;

namespace WashingCarDB.DAL.Entities
{
    public class User : IdentityUser
    {

        [Display(Name = "Documento")]

        public string Document { get; set; }

        [Display(Name = "Nombres")]

        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]

        public string LastName { get; set; }

       

        [Display(Name = "Tipo de usuario")]
        public UserType UserType { get; set; }

        //Propiedades de Lectura
        [Display(Name = "Usuario")]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "Usuario")]
        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";

    }
}

