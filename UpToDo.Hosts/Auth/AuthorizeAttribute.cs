using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace UpToDo.Hosts.Auth;

/// <summary>
/// Атрибут для JWT авторизации
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public sealed class JwtAuthorizeAttribute : AuthorizeAttribute
{
    public JwtAuthorizeAttribute()
    {
        AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
    }

    public JwtAuthorizeAttribute(string policy) : base(policy)
    {
        AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
    }
}