using System.ComponentModel.DataAnnotations;


namespace WashingCarDB.DAL.Entities
{
    public class Entity
    {
        [Key]
        [Required]
        public Guid Id { get; set; } 
    }
}

