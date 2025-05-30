using MediatR;
using UpToDo.Application.Shared.Common;
using UpToDo.Application.Shared.Exceptions;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Contracts.Users;
using UpToDo.Domain;

namespace UpToDo.Application.Users.Commands;

/// <summary>
/// Обработчик регистрации пользователя
/// </summary>
public class RegisterUserHandler(
    IUsersRepository usersRepository,
    IUserSettingsRepository userSettingsRepository,
    IPasswordHasher passwordHasher,
    IJwtTokenGenerator jwtTokenGenerator)
    : IRequestHandler<RegisterUserCommand, TokenResponse>
{
    /// <summary>
    /// Регистрирует пользователя
    /// </summary>
    /// <returns>JWT токен авторизации.</returns>
    public async Task<TokenResponse> Handle(RegisterUserCommand command, CancellationToken ct)
    {
        var existing = await usersRepository.GetByEmailAsync(command.Email, ct);
        if (existing is not null)
            throw new EmailAlreadyExistsException();

        if (command.Password != command.ConfirmPassword)
            throw new PasswordsDoNotMatchException();

        
        //TODO:накинуть валидаций по паролю еще
        
        var user = new User(command.Name, command.Email, passwordHasher.Hash(command.Password));
        await usersRepository.AddAsync(user, ct);
        
        var settings = new Domain.UserSettings
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            TimeZoneItemId = 1,
            CompanyNotificationsEnabled = true
        };
        await userSettingsRepository.AddAsync(settings, ct);

        
        return new(jwtTokenGenerator.Generate(user), user.Id);
    }
}
