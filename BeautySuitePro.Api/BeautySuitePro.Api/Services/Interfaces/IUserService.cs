// Services/Interfaces/IUserService.cs

using BeautySuitePro.Api.DTOs;

public interface IUserService
{
    Task<UserReadDTO> CreateUserAsync(UserCreateDTO dto);
    Task<UserReadDTO> GetUserByIdAsync(Guid id);
    Task<IEnumerable<UserReadDTO>> GetAllUsersAsync();
    Task<UserReadDTO> UpdateUserAsync(Guid id, UserUpdateDTO dto);
    Task<bool> DeleteUserAsync(Guid id);
}