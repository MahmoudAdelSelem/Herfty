using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GPP.Services;
using GPP.Models;
using System.IO;
using System.Net.Http.Headers;

namespace GPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromForm] RegisterModel model)
        {

            try
            {
                if (Request.Form.Files.ToArray().Length <= 0)
                {
                    model.fileurl = "http://localhost:24491/StaticFiles\\Images\\Freelancers\\Defualt.png";
                    var result = await _authService.RegisterAsync(model);
                    if (!result.IsAuthenticated)
                        return BadRequest(result.Message);

                    return Ok(result);
                }

                    var file = Request.Form.Files[0];
                var folderName = Path.Combine("StaticFiles", "Images","Freelancers");
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

                    model.fileurl = "http://localhost:24491/"+ dbPath;

                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    var result = await _authService.RegisterAsync(model);
                    if (!result.IsAuthenticated)
                        return BadRequest(result.Message);

                    return Ok(result);
                    //return Ok(new { dbPath, fform.imagePath });
                }
                else
                {
                    model.fileurl = "http://localhost:24491/StaticFiles\\Images\\Freelancers\\Defualt.png";
                    var result = await _authService.RegisterAsync(model);
                    if (!result.IsAuthenticated)
                        return BadRequest(result.Message);

                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }

            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //var result = await _authService.RegisterAsync(model);
            //if (!result.IsAuthenticated)
            //    return BadRequest(result.Message);

            //return Ok(result);
        }


        [HttpPost("registerUser")]
        public async Task<IActionResult> RegisterUserAsync([FromForm] RegisterUserModel model)
        {


            try
            {
                if (Request.Form.Files.ToArray().Length <= 0)
                {
                    model.fileurl = "http://localhost:24491/StaticFiles\\Images\\Freelancers\\Defualt.png";
                    var result = await _authService.RegisterUserAsync(model);
                    if (!result.IsAuthenticated)
                        return BadRequest(result.Message);

                    return Ok(result);
                }
                
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("StaticFiles", "Images", "Users");
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

                    model.fileurl = "http://localhost:24491/"+ dbPath;

                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    var result = await _authService.RegisterUserAsync(model);
                    if (!result.IsAuthenticated)
                        return BadRequest(result.Message);

                    return Ok(result);
                    //return Ok(new { dbPath, fform.imagePath });
                }
                else
                {
                    model.fileurl = "http://localhost:24491/StaticFiles\\Images\\Freelancers\\Defualt.png";
                    var result = await _authService.RegisterUserAsync(model);
                    if (!result.IsAuthenticated)
                        return BadRequest(result.Message);

                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }



            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //var result = await _authService.RegisterUserAsync(model);
            //if (!result.IsAuthenticated)
            //    return BadRequest(result.Message);

            //return Ok(result);
        }

        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.GetTokenAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.AddRoleAsync(model);

            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok(model);
        }
    }
}
