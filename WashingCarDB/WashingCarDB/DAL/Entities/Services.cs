
using System.ComponentModel.DataAnnotations;
using WashingCarDB.DAL.Entities;

namespace WashingCarDB.DAL;
public class Services: Entity
{

        [Display  (Name = "Servicios")]
        [MaxLength (100, ErrorMessage = "El campo {0} debe ser de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es oblilgatorio.")]
        public String Name { get; set; }
        public Decimal Price { get; set; }


    }


