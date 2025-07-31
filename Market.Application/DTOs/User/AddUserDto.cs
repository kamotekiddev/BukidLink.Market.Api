using System.ComponentModel.DataAnnotations;

namespace Market.Application.DTOs.User;

public class AddUserDto
{
    [Required] [EmailAddress] public string Email { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string Password { get; set; }
}