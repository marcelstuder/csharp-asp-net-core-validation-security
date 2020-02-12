using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConferenceTracker.Entities
{
    public class Speaker : IValidatableObject
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 10)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public bool IsStaff { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();
            var isTechConferenceMailAddress = EmailAddress?.EndsWith("TechnologyLiveConference.com", StringComparison.InvariantCultureIgnoreCase) ?? false;
            if (isTechConferenceMailAddress) {
                result.Add(new ValidationResult("Technology Live Conference staff should not use their conference email addresses."));
            }

            return result;
        }
    }
}
