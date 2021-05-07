using GPP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        
        public UsersController(ApplicationContext db , UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this._userManager = userManager;
        }

        private readonly UserManager<ApplicationUser> _userManager;

        ApplicationContext db { get; set; }
        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult Get()
        {
            var userList = db.applicationUsers.Select(u => new { user = u, gigs = u.Gigs, profession = u.Profession.ProfName }).ToList();
            return Ok(userList);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
           
            return Ok(db.applicationUsers.Where(n=>n.Id==id).Select(u => new { 
                name = u.FirstName+" "+u.LastName,
                fName=u.FirstName,
                lName=u.LastName,
                id= u.Id,
                email=u.Email,
                phone=u.PhoneNumber,
                profpic=u.profilepic,
                location=u.WorkDistrict + " - "+ u.WorkCity + " - "+u.WorkCountry,
                district=u.WorkDistrict,
                city=u.WorkCity,
                country=u.WorkCountry,
                gigs = u.Gigs, profession = u.Profession.ProfName 
            }));
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<UsersController>/5
        [HttpPut("Putuser/{id}")]
        public ActionResult PutUser(string id, [FromBody] EditUserModel user)
        {
            ApplicationUser applicationUser = db.applicationUsers.Where(u => u.Id == id).SingleOrDefault();

            applicationUser.FirstName = user.FirstName;
            applicationUser.LastName = user.LastName;
            applicationUser.Email = user.Email;
            applicationUser.PhoneNumber = user.Phone;

            db.SaveChanges();

            return Ok(applicationUser);

        }

        [HttpPut("Putfreelancer/{id}")]
        public ActionResult PutFeelancer(string id, [FromBody] EditFreelancerModel user)
        {
            ApplicationUser applicationUser = db.applicationUsers.Where(u => u.Id == id).SingleOrDefault();

            applicationUser.FirstName = user.FirstName;
            applicationUser.LastName = user.LastName;
            applicationUser.Email = user.Email;
            applicationUser.PhoneNumber = user.Phone;
            applicationUser.WorkCity = user.WorkCity;
            applicationUser.WorkCountry = user.WorkCountry;
            applicationUser.WorkDistrict = user.WorkDistrict;
            applicationUser.UserName = user.userName;

            db.SaveChanges();

            return Ok(applicationUser);


        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            ApplicationUser user = db.applicationUsers.Where(u => u.Id == id).SingleOrDefault();
            _userManager.DeleteAsync(user);
            return Ok();

            //db.applicationUsers.Remove(user);





        }
    }
}
