using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoStock.API.Dtos;
using Shared.Dtos;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace PhotoStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> PhotoSave(IFormFile photo, CancellationToken cancellationToken)
        {
            if (photo != null && photo.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Photos", photo.FileName);

                using var stream = new FileStream(path, FileMode.Create);
                await photo.CopyToAsync(stream, cancellationToken);

                var returnPath = "Photos/" + photo.FileName;

                PhotoDto photoDto = new() { Url = returnPath };

                return Ok(Response<PhotoDto>.Success(photoDto, 200));
            }

            return BadRequest("Photo is empty!");
        }

        [HttpDelete]
        public IActionResult PhotoDelete(string photoUrl)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Photos", photoUrl);

            if (!System.IO.File.Exists(path))
            {
                return BadRequest("Photo not found");
            }

            System.IO.File.Delete(path);

            return Ok(Response<NoContent>.Success(204));
        }
    }
}
