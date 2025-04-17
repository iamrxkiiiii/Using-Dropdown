using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DropdownDemo.Models
{
    public class EmployeeEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [ForeignKey("Designation")]
        public int DesignationId { get; set; }

        [ValidateNever]
        public DesignationEntity Designation { get; set; } = null!;
    }
}
