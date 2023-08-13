using System.ComponentModel.DataAnnotations;

namespace EShop.API.DTOS
{
    public class RegisterDTO
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$",ErrorMessage ="Password must have 1 upper case , Lower Case 1 Number , 1 non alphanmeric and at least 6 characters")]
        public string Password { get; set; }
    }
}
