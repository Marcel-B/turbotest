using System.ComponentModel.DataAnnotations;

namespace com.marcelbenders.Aqua.Api.Dto;

public record Register(
    [Required] string DisplayName,
 [Required, EmailAddress] string Email,
/*[RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$", ErrorMessage = "Password must be complex")]*/ [Required] string Password,
 [Required] string Username);
