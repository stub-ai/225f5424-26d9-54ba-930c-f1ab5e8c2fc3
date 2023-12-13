using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace SingleFileApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "yourfile.txt");
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/octet-stream", Path.GetFileName(path));
        }
    }
}