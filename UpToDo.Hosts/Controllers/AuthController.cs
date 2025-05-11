using MediatR;
using Microsoft.AspNetCore.Mvc;
using UpToDo.Application.Users.Commands;
using UpToDo.Contracts.Users;

namespace UpToDo.Hosts.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Регистрирует пользователя.
        /// </summary>
        /// <param name="request">Сущность с параметрами пользователя</param>
        /// <returns>Токен авторизации.</returns>
        [HttpPost("register")]
        public async Task<TokenResponse> Register(RegisterRequest request)
        {
            return await mediator.Send(
                new RegisterUserCommand(request.Name, 
                    request.Email, request.Password, request.ConfirmPassword));
        }

        /// <summary>
        /// Авторизует пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Токен авторизации.</returns>
        [HttpPost("login")]
        public async Task<TokenResponse> Login(LoginRequest request)
        {
            return await mediator.Send(
                new LoginUserCommand(request.Email, request.Password));
        }
    }
}
