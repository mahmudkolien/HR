using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HR.Core
{
    public interface IPhotoStorage
    {
         Task<string> StorePhoto(string uploadsFolderPath, IFormFile file);
    }
}