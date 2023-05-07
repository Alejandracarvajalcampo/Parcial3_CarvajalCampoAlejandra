using System.ComponentModel.DataAnnotations;
using WashingCarDB.DAL.Entities;
using WashingCarDB.Enums;

namespace WashingCarDB.Models
{
    public class AddUserViewModel: Entity
    {
     
            [Display(Name = "Email")]
            [EmailAddress(ErrorMessage = "Debes ingresar un correo v�lido.")]
            [MaxLength(100, ErrorMessage = "El campo {0} debe tener m�ximo {1} caract�res.")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            public string Username { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Contrase�a")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(20, MinimumLength = 6, ErrorMessage = "El campo {0} debe tener entre {2} y {1} car�cteres.")]
            public string Password { get; set; }

            [Compare("Password", ErrorMessage = "La contrase�a y la confirmaci�n no son iguales.")]
            [Display(Name = "Confirmaci�n de contrase�a")]
            [DataType(DataType.Password)]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(20, MinimumLength = 6, ErrorMessage = "El campo {0} debe tener entre {2} y {1} car�cteres.")] //New DataAnnotation
            public string PasswordConfirm { get; set; }

            [Display(Name = "Tipo de usuario")]
            public UserType UserType { get; set; }
        }
    }

