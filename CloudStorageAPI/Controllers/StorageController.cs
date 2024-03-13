using CloudStorage.Application.UseCases.Users.UploadProfilePhoto;
using CloudStorage.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CloudStorage.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StorageController : ControllerBase
{
    [HttpPost]
    public IActionResult UploadImage([FromServices] IUploadProfilePhotoUseCase useCase, [FromServices] WebApplicationBuilder builder, IFormFile file)
    {
        var name = builder.Configuration.GetValue<string>("User:Name") ?? string.Empty;
        var email = builder.Configuration.GetValue<string>("User:Email") ?? string.Empty;
        var accessToken = builder.Configuration.GetValue<string>("User:AccessToken") ?? string.Empty;
        var refreshToken = builder.Configuration.GetValue<string>("User:RefreshToken") ?? string.Empty;

        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            Name = name,
            Email = email,
            AccessToken = accessToken,
            RefreshToken = refreshToken,
        };

        useCase.Execute(user, file);

        return Created();
    }
}
