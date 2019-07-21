using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HR.Models
{
    public interface IPhotoStorage
    {
         Task<string> StorePhoto(string uploadsFolderPath, IFormFile file);
    }
}