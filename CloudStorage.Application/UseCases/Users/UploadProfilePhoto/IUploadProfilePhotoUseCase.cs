using CloudStorage.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStorage.Application.UseCases.Users.UploadProfilePhoto;
public interface IUploadProfilePhotoUseCase
{
    public void Execute(User user, IFormFile file);
}
