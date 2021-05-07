using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GPP.Models;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using System.Net.Http.Headers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionController : ControllerBase
    {
        public ProfessionController(ApplicationContext db)
        {
            this.db = db;
        }
        ApplicationContext db { get; set; }

        // GET: api/<ProfessionController>
        [HttpGet]
        public ActionResult<List<Profession>> Get()
        {
            return db.Professions.Select(p => p).ToList();
        }

        // GET api/<ProfessionController>/5
        [HttpGet("{id}")]
        public ActionResult<Profession> Get(int id)
        {
            Profession profession = db.Professions.Where(p => p.Id == id).SingleOrDefault();

           
            return Ok(profession);
        }

        [Authorize(Roles = "Freelancer")]
        [HttpGet("Search/{name}")]

        public ActionResult<Profession> Search(string name)
        {
            Profession profession = db.Professions.Where(p => p.ProfName == name).SingleOrDefault();


            return Ok(profession);
        }



        // POST api/<ProfessionController>
        [HttpPost]
        public ActionResult Post([FromForm] addProfessionModel addprofessionModel)
        {

            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("StaticFiles", "Images", "Profession");
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

                    addprofessionModel.ProfPic = "http://localhost:24491/"+ dbPath;
                    Profession profession = new Profession
                    {
                        ProfName = addprofessionModel.ProfName,
                        ProfPic = addprofessionModel.ProfPic
                    };
                    db.Professions.Add(profession);
                    db.SaveChanges();
                    return Ok(profession);
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

        // PUT api/<ProfessionController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Profession profession)
        {
            Profession profession1 = db.Professions.Where(p => p.Id == id).SingleOrDefault();

            profession1.ProfName = profession.ProfName;

            profession1.ProfPic = profession.ProfPic;
            db.SaveChanges();
            return Ok(profession1);
        }
        [HttpPut("Putname/{id}")]
        public ActionResult PutName(int id, [FromBody] string name)
        {
            Profession profession1 = db.Professions.Where(p => p.Id == id).SingleOrDefault();

            profession1.ProfName = name;
            db.SaveChanges();
            return Ok(profession1);
        }

        [HttpPut("PutImage/{id}")]
        public ActionResult PutImage(int id, [FromBody] string image)
        {
            Profession profession1 = db.Professions.Where(p => p.Id == id).SingleOrDefault();

            profession1.ProfPic = image;
            db.SaveChanges();
            return Ok(profession1);
        }
        // DELETE api/<ProfessionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Profession profession = db.Professions.Where(p => p.Id == id).SingleOrDefault();
            db.Remove(profession);
        }
    }
}
