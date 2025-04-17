using System.ComponentModel.DataAnnotations;

namespace DropdownDemo.Models
{
    public class DesignationEntity
    {
        [Key]
        public int DesignationId { get; set; }

        [Required]
        public required string DesignationName { get; set; }
    }
}
