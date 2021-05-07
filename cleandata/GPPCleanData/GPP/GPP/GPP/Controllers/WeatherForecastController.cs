using GPP.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace GPP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        public IWebHostEnvironment  _webHostEnvironment { get; set; }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger , IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
          
            this._webHostEnvironment = webHostEnvironment;
        }

        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload([FromForm] FileUpload fform)
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("StaticFiles", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    fform.imagePath = dbPath;
                    return Ok(new { dbPath , fform.imagePath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        //[HttpPost]
        //public string PostPic([FromForm] FileUpload objectfile)
        //{
        //    try
        //    {
        //        //var ff = Request.Form.Files[0];
        //        if (objectfile.files.Length > 0)
        //        {
        //            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
        //            if (!Directory.Exists(path))
        //            {
        //                Directory.CreateDirectory(path);
        //            }
        //            using(FileStream fileStream = System.IO.File.Create(path+ objectfile.files.FileName))
        //            {
        //                objectfile.files.CopyTo(fileStream);
        //                fileStream.Flush();
        //                return "uploaded";
        //            }
        //        }
        //        else
        //        {
        //            return "not uploaded";
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return ex.Message;
        //    }
           
           
           
        //}
        //[HttpGet("GetFile")]
        
        //public FileContentResult GetFile()
        //{
        //    string path = _webHostEnvironment.WebRootPath + "\\uploads\\3asfour.PNG";
        //    var data = System.IO.File.ReadAllBytes(path);
        //    var result = new FileContentResult(data, "application/octet-stream")
        //    {
        //        FileDownloadName = "3asfour.PNG"
        //    };

        //    return result;
        //}

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
