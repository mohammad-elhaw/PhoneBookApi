using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public abstract record ContactForManipulationDto
    {
        [Required(ErrorMessage ="Contact name is a required field")]
        [MaxLength(50, ErrorMessage ="Maximum length is 50 characters")]
        public string Name { get; init; }

        [Required(ErrorMessage ="PhoneNumber is a required field")]
        [Phone(ErrorMessage ="Invalid Phone Number")]
        [MaxLength(20, ErrorMessage = "Maximum Length is 20 characters")]
        public string PhoneNumber { get; init; }

        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        [MaxLength(50, ErrorMessage = "Maximum length is 50 characters")]
        public string Email { get; init; }
    }
}
