using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WashingCarDB.DAL.Entities
{
    public class Entity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}

//    public class Entity
//    {
//        [Key]
//        [Required]
//        public Guid Id { get; set; }

//        [Display(Name = "Fecha de creación")]
//        public DateTime? CreatedDate { get; set; }

//        [Display(Name = "Fecha de modificación")]
//        public DateTime? ModifiedDate { get; set; }
//    }
//}