using GPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GigController : ControllerBase
    {
        public GigController(ApplicationContext db)
        {
            this.db = db;
        }
        ApplicationContext db { get; set; }


        // GET: api/<GigController>
        [HttpGet]
        public ActionResult<List<Gig>> Get()
        {
            return db.Gigs
                .Include(s=>s.Profession)
                .Select(g=>g).
                ToList();
        }

        // GET api/<GigController>/5
        [HttpGet("{id}")]
        public ActionResult searchById(int id)
        {
            var gig = db.Gigs.Select(n => new
            {
                gigdetails = n,
                freelancerFirstName = n.applicationUser.FirstName,
                freelancerLastName = n.applicationUser.LastName,
                Freelancerworkcity = n.applicationUser.WorkCity,
                FreelancerPhone = n.applicationUser.PhoneNumber,
                professionname  = n.Profession.ProfName
            }).Where(m=>m.gigdetails.GigId==id).FirstOrDefault();
                //Include(n=>n.applicationUser).Include(n=>n.Profession).FirstOrDefault();


            return Ok(gig);
        }

        [HttpGet("searchByName/{name}")]
        public ActionResult<Gig> searchByName(string name)
        {
            Gig gig = db.Gigs.Where(p => p.GigName == name).SingleOrDefault();


            return Ok(gig);
        }


        [HttpGet("searchByProfession/{ProfessionID}")]
        public ActionResult<List<Gig>> searchByProfession(int ProfessionID)
        {
            List<Gig> gigs = db.Gigs.Where(p => p.ProfessionId == ProfessionID).Include(s => s.Profession)
                .ToList();


            return Ok(gigs);
        }


        [HttpGet("searchByMinPrice/{minPrice}")]
        public ActionResult<List<Gig>> searchByMinPrice(int minPrice)
        {
           List<Gig>  gigs = db.Gigs.Where(p => p.MinPrice == minPrice).ToList();


            return Ok(gigs);
        }

        [HttpGet("searchByLocation/{cityName}")]
        public ActionResult<List<Gig>> searchByLocation(string cityName)
        {
            List<Gig> gigs = db.Gigs.Where(p => p.applicationUser.WorkCity == cityName).Include(s => s.Profession).ToList();


            return Ok(gigs);
        }
        
        [HttpGet("searchByLocprofession/{ProfessionID}/{cityName}")]
        public ActionResult<List<Gig>> searchByLocprofession(int ProfessionID ,  string cityName)
        {
            List<Gig> gigs = db.Gigs.Where(p => p.applicationUser.WorkCity == cityName).Where(p => p.ProfessionId == ProfessionID).ToList();


            return Ok(gigs);
        }

        [HttpGet("searchByMaxPrice/{MaxPrice}")]
        public ActionResult<List<Gig>> searchByMaxPrice(int MaxPrice)
        {
            List<Gig> gigs = db.Gigs.Where(p => p.MaxPrice == MaxPrice).ToList();


            return Ok(gigs);
        }

        // POST api/<GigController>
        [HttpPost]
        public ActionResult Post([FromForm] AddGigModel gigModel)
        {

            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("StaticFiles", "Images", "Gigs");
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

                    gigModel.GigPic = "http://localhost:24491/"+dbPath;
                    Gig gig = new Gig
                    {
                        GigName = gigModel.GigName ,
                        Description = gigModel.Description ,
                        MaxPrice = gigModel.MaxPrice,
                        MinPrice = gigModel.MinPrice,
                        ProfessionId = gigModel.ProfessionId,
                        UserId = gigModel.UserId,
                        GigPic = gigModel.GigPic

                    };
                    db.Gigs.Add(gig);
                    db.SaveChanges();
                    return Ok(gigModel);
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


            //db.Gigs.Add(gig);
            //db.SaveChanges();
            //return Ok(gig);

        }

        // PUT api/<GigController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Gig gig)
        {
            Gig newGig = db.Gigs.Where(p => p.GigId == id).SingleOrDefault();

            newGig.GigName = gig.GigName;
            newGig.Description = gig.Description;
            newGig.MinPrice = gig.MinPrice;
            newGig.MaxPrice = gig.MaxPrice;
            newGig.GigPic = gig.GigPic;

            
            db.SaveChanges();
            return Ok(newGig);
        }

        // DELETE api/<GigController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Gig gig = db.Gigs.Where(p => p.GigId == id).SingleOrDefault();
            db.Remove(gig);
        }
    }
}
