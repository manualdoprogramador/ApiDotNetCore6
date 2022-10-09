using MP.ApiDotNet6.Application.DTOs.PersonImage;

namespace MP.ApiDotNet6.Application.Services.Interfaces
{
    public interface IPersonImageService
    {
        Task<ResultService> CreateImageBase64Async(PersonImageDTO personImageDTO);
    }
}