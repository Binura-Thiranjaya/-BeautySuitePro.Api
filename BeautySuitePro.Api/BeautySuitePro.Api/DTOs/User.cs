using System.ComponentModel.DataAnnotations;

namespace BeautySuitePro.Api.DTOs;

// DTOs/User/UserCreateDTO.cs
public class UserCreateDTO
{
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    [Required] [EmailAddress] public string Email { get; set; }
    [Required] public string Password { get; set; }
    [Required] public string Role { get; set; }
}

// DTOs/User/UserReadDTO.cs
public class UserReadDTO
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
}

// DTOs/User/UserUpdateDTO.cs
public class UserUpdateDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; }
}
