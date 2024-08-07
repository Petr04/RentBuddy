using Microsoft.AspNetCore.Mvc;
using RentBuddyBackend.DAL.Entities;

namespace RentBuddyBackend.Modules.ImageModule;

[ApiController]
[Route("api/[controller]")]
public class ImageController(IWebHostEnvironment webHostEnvironment) : ControllerBase
{
    /// <summary>
    /// Получить изображение по имени
    /// </summary>
    /// <param name="id">Имя изображения</param>
    /// <returns></returns>
    [HttpGet("{imageName}")]
    public async Task<ActionResult> GetImage([FromRoute] string imageName)
    {
        var imagePath = Path.Combine(webHostEnvironment.WebRootPath, "Image", imageName);

        if (!System.IO.File.Exists(imagePath))
            return NotFound();

        var imageData = await System.IO.File.ReadAllBytesAsync(imagePath);

        return File(imageData, "image/jpeg");
    }
    
    /// <summary>
    /// Загрузить картинку из ОС
    /// </summary>
    /// <param name="image"> Изображение</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult> Post([FromForm] ImageEntity image)
    {
        try
        {
            if (image.files.Length > 0)
            {
                var path = Path.Combine(webHostEnvironment.WebRootPath, "Image");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var filePath = Path.Combine(path, image.files.FileName);
                using (var fileStream = System.IO.File.Create(filePath))
                {
                    image.files.CopyTo(fileStream);
                    fileStream.Flush();
                    return Ok("Upload done");
                }
            }

            return Ok("Failed");
        }
        catch (Exception ex)
        {
            return Ok(ex.Message);
        }
    }
}